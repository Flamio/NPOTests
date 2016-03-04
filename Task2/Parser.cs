using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Parser
    {
        private List<string> _data;
        private int source;
        private int destination;

        public Parser(List<string> data)
        {
            _data = data;
        }

        public GraphModel getGraph()
       {
           GraphModel graphModel = new GraphModel();

            int stringCounter = 0;
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
               if (stringCounter == 0)
               {
                   source = rowNumbers[1];
                   destination = rowNumbers[2];
               }
               else
               {
                   graphModel.setNumbersPair(rowNumbers[0], rowNumbers[1]);
               }
               stringCounter++;
           }
           return graphModel;
       }

        public int getSource()
        {
            return source;
        }

        public int getDestination()
        {
            return destination;
        }
    }
}
