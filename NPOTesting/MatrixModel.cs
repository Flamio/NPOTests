using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class MatrixModel
    {
        public MatrixModel()
        {
            rows = new Dictionary<int, List<int>>();
            columns = new Dictionary<int, List<int>>();
        }

        public void setRow(List<int> rowNumbers)
        {
            columnCount = 0;

            rows[rowCount] = rowNumbers;
            rowCount++;

            foreach (var number in rowNumbers)
            {
                try
                {
                    columns[columnCount].Add(number);
                }
                catch (Exception)
                {
                    columns[columnCount] = new List<int>();
                    columns[columnCount].Add(number);
                }
                columnCount++;
            }
            
        }

        private int rowCount = 0;
        private int columnCount = 0;
        private Dictionary<int, List<int>> rows;
        private Dictionary<int, List<int>> columns;

        public int getMatrixElementsCount()
        {
            int count = 0;

            foreach (var row in rows)
            {
                count += row.Value.Count;
            }

            return count;
        }

        public List<int> getRow(int index)
        {
            List<int> row = null;
            try
            {
                row = rows[index];
            }
            catch (Exception)
            {

                row = null;
            }

            return row;
        }

        public List<int> getColumn(int index)
        {
            List<int> column = null;
            try
            {
                column = columns[index];
            }
            catch (Exception)
            {

                column = null;
            }

            return column;
        }

        public List<string> toText()
        {
            List<string> text = new List<string>();
            foreach(var row in rows)//)
            {
                String rowString = "";
                for (int i = 0;i<row.Value.Count;i++)
                {
                    rowString+=Convert.ToString(row.Value[i]) + ((i == columnCount-1) ? "" : " ");
                }
                text.Add(rowString);
            }
            return text;
        }

        public void replaceRows()
        {
            replace(rows,columns);
        }

        public void replaceColumns()
        {
            replace(columns,rows);
        }

        private void replace(Dictionary<int, List<int>> rows, Dictionary<int, List<int>> columns)
        {
            MonoFinder monoFinder = new MonoFinder();
            MonoFinder monoFinder2 = new MonoFinder();

            for (int i = 0; i < rows.Count - 1; i++)
            {
                for (int j = 0; j < rows.Count - i - 1; j++)
                {
                    monoFinder.setCollection(rows[j]);
                    monoFinder2.setCollection(rows[j + 1]);
                    if (monoFinder.getMaxMonoCount() < monoFinder2.getMaxMonoCount())
                    {
                        List<int> b = rows[j];
                        rows[j] = rows[j + 1];
                        rows[j + 1] = b;

                        foreach (var column in columns)
                        {
                            try
                            {
                                int temp = column.Value[j];
                                column.Value[j] = column.Value[j + 1];
                                column.Value[j + 1] = temp;
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

    }
}

