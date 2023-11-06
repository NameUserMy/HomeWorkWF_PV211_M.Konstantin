using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_2
{
    public partial class EvenOdd : Form
    {
        public EvenOdd()
        {
            InitializeComponent();
        }
        Random rand = new Random();
        int[] numbers = new int[100];

        private void EvenOdd_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 200);
            }
        }

        private void evenOrNot_Click(object sender, EventArgs e)
        {
            var evens = numbers.Where(ev=>ev % 2 == 0);
            var Notevens = numbers.Where(ev=>ev % 2 != 0);
            foreach (var item in Notevens)
            {
                notEven.Items.Add(item);
            }
            foreach (var item in evens)
            {
                even.Items.Add(item);       
            }
        }
    }
}
