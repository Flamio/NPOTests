using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOTesting
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

            data.RemoveAt(0);

            Parser parser = new Parser(data);

            var matrix = parser.getMatrix();

            matrix.replaceRows();
            matrix.replaceColumns();

            try
            {
                _fileSource.saveTextData(matrix.toText());
            }
            catch (Exception)
            {
                ioError();
            }

        }

        public event Action ioError;

    }
}
