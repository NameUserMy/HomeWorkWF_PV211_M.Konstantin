using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_4
{
    public partial class QuantityMatches : Form
    {
        public QuantityMatches()
        {
            InitializeComponent();
            data.CellValueChanged += test;
        }

        private void test(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < data.Columns.Count-1; i++)
            {
                for (int j = 0; j < data.Rows.Count-1; j++)
                {
                    if (e.ColumnIndex == 1&& data[1, j].Value!=null)
                    {
                        var result = data[i, j].Value.ToString().Intersect(data[1, j].Value.ToString());
                        data[2, j].Value = Convert.ToString(result.ToList().Count);
                    }
                }
            }
            
            
        }
    }
}
