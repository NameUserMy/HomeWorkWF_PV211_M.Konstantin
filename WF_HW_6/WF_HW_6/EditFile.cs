using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_6
{
    public partial class EditFile : Form
    {
        MainText mainWindow;
        public EditFile(MainText mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            editFileTextBox.Text = mainWindow.MainTextEdit;
            saveButton.Click += SaveChangeFile;
            closeButton.Click += CloseEditWindowButton;
        }
        private void CloseEditWindowButton(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveChangeFile(object sender, EventArgs e)
        {

            mainWindow.MainTextEdit = editFileTextBox.Text;
        }
    }
}
