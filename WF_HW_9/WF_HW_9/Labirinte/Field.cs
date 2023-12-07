using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_9.Labirinte
{

   
    class Field
    {
        private int[,] _field;
        private int _size;
        private string[] row;
        string[] cols;
        public int SizeTile
        {
            get { return _size; }
            set { _size = value; }
        }
        public int[,] MyField
        {
            get { return _field; }
            set { _field = value; }
        }
        public void LoadMap(string path)
        {
            StreamReader sr = new StreamReader(path);
            string Line = sr.ReadToEnd();
            row = Line.Split('\n');
            for (int i = 0; i < row.Length; i++)
            {
                cols = row[i].Split(' ');
            }

            _field = new int[row.Length, cols.Length];
            
            for (int i = 0; i < row.Length; i++)
            {
                cols = row[i].Split(' ');
                for (int j = 0; j < cols.Length; j++)
                {
                    MyField[i, j] = int.Parse(cols[j]);
                }
            }
            

        }
        public Field()
        {
            _field = new int[10, 10];
            SizeTile = 20;
        }
    }
}
