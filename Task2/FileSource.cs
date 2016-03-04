using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class FileSource : IFileSource
    {
        public List<string> getTextData()
        {
            return File.ReadAllLines("input.txt").ToList();
        }

        public void saveTextData(List<string> data)
        {
            File.WriteAllLines("output.txt",data);
        }
    }
}
