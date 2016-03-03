using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NPOTesting
{
    public class Parser
    {
        private List<string> _data;

        public Parser(List<string> data)
        {
            _data = data;
        }

        public MatrixModel getMatrix()
       {
           MatrixModel matrix = new MatrixModel();


           string pattern = @"[-]*[0-9]{1,}";
           foreach (var dataString in _data)
           {
               Match m = Regex.Match(dataString, pattern);
               List<int> rowNumbers = new List<int>();
               while (m.Success)
               {
                   rowNumbers.Add(Convert.ToInt32(m.Value));
                   m = m.NextMatch();
               }
               matrix.setRow(rowNumbers);
           }
           

           

           return matrix;
       }
    }
}
