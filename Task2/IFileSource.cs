using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface IFileSource
    {
        List<string> getTextData();
        void saveTextData(List<string> data);
    }
}
