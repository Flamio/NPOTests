using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class GraphModel
    {
        private Dictionary<int, List<int>> reach;
        private List<List<int>> pathes;
        private List<int> path;

        public GraphModel()
        {
            reach = new Dictionary<int, List<int>>();
            pathes = new List<List<int>>();
            path = new List<int>();
        }

        public void setNumbersPair(int send, int receive)
        {
            try
            {
                reach[send].Add(receive);
            }
            catch (Exception)
            {
                reach[send] = new List<int>();
                reach[send].Add(receive);
            }
        }

        private int depth = 0;

        public void getPathes(int source, int destination)
        {
           
            path.Add(source);

            List<int> allDestFromSource = null;
            try
            {
                allDestFromSource = reach[source];
            }
            catch (Exception)
            {
                path.Clear();
                return;
            }

            if (allDestFromSource.Find(x => x == destination) != 0)
            {
                path.Add(destination);

                List<int> copyPath = new List<int>(path);
                pathes.Add(copyPath);
                path.RemoveRange(depth-1,path.Count-depth+1);
            }
            else
            {
                foreach (var dest in allDestFromSource)
                {
                    depth ++;
                    getPathes(dest, destination);
                }
            }
            depth --;
        }

        public List<int> getShortestPath(int source, int destination)
        {
            getPathes(source,destination);
            int count = Int32.MaxValue;
            List<int> returnPath = null;
            foreach (var path in pathes)
            {
                if (path.Count < count)
                {
                    count = path.Count;
                    returnPath = path;
                }
            }
            return returnPath;
        }
    }
}
