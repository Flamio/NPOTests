using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class MainModel
    {
        private readonly IFileSource _fileSource;

        public MainModel(IFileSource fileSource)
        {
            _fileSource = fileSource;
        }

        public void run()
        {
            List<string> data = null;
            try
            {
                data = _fileSource.getTextData();
            }
            catch (Exception)
            {
                ioError();
                return;
            }

            Parser parser = new Parser(data);
            var graph = parser.getGraph();
            var path = graph.getShortestPath(parser.getSource(), parser.getDestination());

            try
            {
                _fileSource.saveTextData(pathToText(path));
            }
            catch (Exception)
            {
                ioError();
            }

        }

        private List<string> pathToText(List<int> path)
        {
            List<string> text = new List<string>();
            string textString = "";
            for (int i =0;i<path.Count;i++)
            {
                textString+=(Convert.ToString(path[i]) + ((i == path.Count - 1) ? "" : " "));
            }
            text.Add(textString);
            return text;
        }

        public event Action ioError;

    }
}
