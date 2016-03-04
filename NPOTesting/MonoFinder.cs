using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class MonoFinder
    {
        private List<int> _collection;

        public void setCollection(List<int> collection)
        {
            _collection = collection;
        }

        public int getMaxMonoCount()
        {
            int count = 0;
            int sign = 0;
            int localCount = 0;
            for(int i = 0;i<_collection.Count;i++)
            {
                int diff;
                try
                {
                    diff = _collection[i] - _collection[i + 1];
                }
                catch (Exception)
                {
                    diff = 0;
                }
                    
                var localsign = (diff>0?1:diff<0?-1:0);


                if (sign == 0 && localsign!=0)
                {
                    localCount+=2;
                    sign = localsign;
                    continue;
                }

                if (localsign == sign && localsign != 0)
                {
                    localCount++;
                    
                    sign = localsign;
                }
                else
                {
                    count = localCount > count ? localCount : count;
                    localCount = 0;
                    sign = 0;
                    if (localsign != 0)
                    {
                        i--;
                    }
                }
            }



            return count;
        }


    }
}
