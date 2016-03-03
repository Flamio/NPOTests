using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOTesting
{
    public interface IFileSource
    {
        List<string> getTextData();
        void saveTextData(List<string> data);
    }
}
