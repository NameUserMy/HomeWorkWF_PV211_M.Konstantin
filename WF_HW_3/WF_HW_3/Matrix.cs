using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_3
{
    public partial class Matrix : Form
    {
        int sizeMatrix;
        
        public Matrix()
        {
            InitializeComponent();
            
        }
        public void InitTable(TableLayoutPanel table)
        {
            table.Width = sizeMatrix*26;
            table.Height = sizeMatrix*26;
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                   table.Controls.Add(new TextBox {Width=20,Height=20}, i, j);
                }
            }
            panelLayout.Controls.Add(table);
        }
        public void ControlM() {

            selectMatrix = new GroupBox()
            {
                Name = "selectMatrixGroup",
                Text = "Select size",
                Width = sizeMatrix * 26,
                Height = sizeMatrix * 26,
            };
            selecSizeMatrix3 = new RadioButton();
            selecSizeMatrix6 = new RadioButton();
            selecSizeMatrix9 = new RadioButton();

            selecSizeMatrix3.Location = new Point(10, 20);
            selecSizeMatrix3.Text = "3";
            selecSizeMatrix3.Tag = 3;
            selecSizeMatrix3.CheckedChanged += MatrixChange;

            selecSizeMatrix6.Location = new Point(10, 40);
            selecSizeMatrix6.Text = "6";
            selecSizeMatrix6.Tag = 6;
            //selecSizeMatrix6.CheckedChanged += MatrixChange;
            selecSizeMatrix9.Location = new Point(10, 60);
            selecSizeMatrix9.Text = "9";
            selecSizeMatrix9.Tag = 9;
            selecSizeMatrix9.CheckedChanged += MatrixChange;
            selectMatrix.Controls.Add(selecSizeMatrix3);
            selectMatrix.Controls.Add(selecSizeMatrix6);
            selectMatrix.Controls.Add(selecSizeMatrix9);
            
            panelLayout.Controls.Add(selectMatrix);
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sizeMatrix = 3;
            panelLayout = new FlowLayoutPanel();
            
            panelLayout.Size = new Size(sizeMatrix*28*2+3,sizeMatrix*28*2);
            selectMatrix = new GroupBox()
            {
                Name = "selectMatrixGroup",
                Text = "Select size",
                Width = sizeMatrix * 26,
                Height = sizeMatrix * 26,
                Dock=DockStyle.Right
            };
            buttonCalculate = new Button()
            {
                Text = "Calculate",
                Width = sizeMatrix * 26,
                Height = sizeMatrix * 26,
                
            };
            buttonCalculate.Click += Calulate;
            selecSizeMatrix3 = new RadioButton();
            selecSizeMatrix6 = new RadioButton();
            selecSizeMatrix9 = new RadioButton();

            selecSizeMatrix3.Location = new Point(10, 20);
            selecSizeMatrix3.Checked = true;
            selecSizeMatrix3.Text = "3";
            selecSizeMatrix3.Tag = 3;
            selecSizeMatrix3.CheckedChanged += MatrixChange;

            selecSizeMatrix6.Location = new Point(10, 40);
            selecSizeMatrix6.Text = "6";
            selecSizeMatrix6.Tag = 6;
            selecSizeMatrix9.Location = new Point(10, 60);
            selecSizeMatrix9.Text = "9";
            selecSizeMatrix9.Tag = 9;
            selecSizeMatrix9.CheckedChanged += MatrixChange;
            selectMatrix.Controls.Add(selecSizeMatrix3);
            selectMatrix.Controls.Add(selecSizeMatrix6);
            selectMatrix.Controls.Add(selecSizeMatrix9);

            this.Controls.Add(panelLayout);
            firstOp = new TableLayoutPanel();
            secondtOp = new TableLayoutPanel();
            resultOp = new TableLayoutPanel();
           
            InitTable(firstOp);
            InitTable(secondtOp);
            InitTable(resultOp);
            panelLayout.Controls.Add(buttonCalculate);
            this.Controls.Add(selectMatrix);
           
        }

        private void Calulate(object sender, EventArgs e)
        {
            var first = firstOp.Controls.OfType<TextBox>().Select(x => Convert.ToInt32(x.Text)).ToArray();
            var second = secondtOp.Controls.OfType<TextBox>().Select(x => Convert.ToInt32(x.Text)).ToArray();

            for (int i = 0; i < first.Length; i++)
            {
                resultOp.Controls[i].Text = (first[i] + second[i]).ToString();
            }
        }

        private void MatrixChange(object sender, EventArgs e)
        {
            panelLayout.Controls.Clear();
            this.sizeMatrix = Convert.ToInt32(selectMatrix.Controls.
            OfType<RadioButton>().FirstOrDefault(x => x.Checked).Tag);
            panelLayout.Size = new Size(sizeMatrix * 28 * 2 + 3, sizeMatrix * 28 * 2);
            InitTable(firstOp);
            InitTable(secondtOp);
            InitTable(resultOp);
            buttonCalculate = new Button()
            {
                Text = "Calculate",
                Width = sizeMatrix * 26,
                Height = sizeMatrix * 26,

            };
            panelLayout.Controls.Add(buttonCalculate);
        }
        

        private TableLayoutPanel firstOp;
        private TableLayoutPanel secondtOp;
        private FlowLayoutPanel panelLayout;
        private TableLayoutPanel resultOp;
        private GroupBox selectMatrix;
        private RadioButton selecSizeMatrix3;
        private RadioButton selecSizeMatrix6;
        private RadioButton selecSizeMatrix9;
        private Button buttonCalculate;
    }
}
