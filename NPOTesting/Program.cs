using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            MainModel mainModel = new MainModel(new FileSource());
            mainModel.ioError += mainModel_ioError;

            mainModel.run();
        }

        static void mainModel_ioError()
        {
            Console.Write("IO Error!!!");
            Console.ReadKey();
        }
    }
}
