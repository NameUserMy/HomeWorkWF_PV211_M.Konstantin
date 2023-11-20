using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_7
{




public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            this.Load += LoadRedactor;
        }

        private void LoadRedactor(object sender, EventArgs e)
        {
            mainMenu = new MenuStrip()
            {
                Dock = DockStyle.Top,
            };
            MainMenuRender();
            StatusMenuRender();
            EditMenuRender();
            panel = new TableLayoutPanel()
            {
                RowCount = 3,
                Dock=DockStyle.Fill,
            };
            itemsMenuFileName = new string[] { "New file", "Open file", "Close file", "Seve file",
                "Copy", "Cut", "Paste" ,"Cancel"};
            fileRedactor = new TextBox()
            {
                Name="texRedactor",
                Multiline = true,
                Dock = DockStyle.Fill,
                Height = this.ClientSize.Height - (statusBar.Height+mainMenu.Height+10),
            };
            date = new Timer();
            date.Interval = 1000;
            fileRedactor.Click += CurssorPoint;
            date.Tick += DateTimeTick;
            date.Start();

            
            this.Controls.Add(panel);
            panel.Controls.Add(mainMenu, 0, 0);
            panel.Controls.Add(fileRedactor, 0, 1);
            panel.Controls.Add(statusBar, 0, 2);

            

            var itemsMenuFile = file.DropDownItems;
            SetNameMenuFile(itemsMenuFile);
            itemsMenuFile[0].Click += NewFileMenuClick;
            itemsMenuFile[1].Click += OpenFileMenuClick;
            itemsMenuFile[2].Click += CloseMenuClick;
            itemsMenuFile[3].Click += SaveFileMenuClick;



            var ItemsMenuEdit = edit.DropDownItems;
            SetNameMenuFile(ItemsMenuEdit, 4);
            ItemsMenuEdit[0].Click += CopyEditClick;
            ItemsMenuEdit[1].Click +=CatEditClick;
            ItemsMenuEdit[2].Click += PasteEditClick;
            ItemsMenuEdit[3].Click += CencelEditClick;
           
            
            ToolStripMenuItem settings = new ToolStripMenuItem("Settings");
            mainMenu.Items.Add(settings);
            settings.Click += SetingMenuClick;

            contextMenuTextBox = new ContextMenuStrip();

            contextMenuTextBox.Items.AddRange(new[] { ItemsMenuEdit[0], ItemsMenuEdit[1], ItemsMenuEdit[2], ItemsMenuEdit[3] });
            fileRedactor.ContextMenuStrip = contextMenuTextBox;
        }

        private void SetingMenuClick(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();

            fileRedactor.Font = fontDialog.Font;
        }
        private void CloseMenuClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CencelEditClick(object sender, EventArgs e)
        {
            fileRedactor.Undo();
        }
        private void CatEditClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileRedactor.SelectedText))
            {
                curssor = fileRedactor.SelectionStart;
                buffer = fileRedactor.SelectedText;
                fileRedactor.Text = fileRedactor.Text.Remove(fileRedactor.SelectionStart, buffer.Length);
                fileRedactor.SelectionStart = curssor;
            }
        }
        private void PasteEditClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(buffer))
            {
                curssor = fileRedactor.SelectionStart;
                fileRedactor.Text = fileRedactor.Text.Insert(fileRedactor.SelectionStart, buffer);
                fileRedactor.SelectionStart = curssor;
            }
                
        }
        private void CurssorPoint(object sender, EventArgs e)
        {
         curssor= fileRedactor.SelectionStart;
        }
        private void CopyEditClick(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(fileRedactor.SelectedText))
            buffer = fileRedactor.SelectedText;
        }

        private void DateTimeTick(object sender, EventArgs e)
        {
            
            dateTime.Text = DateTime.Now.ToString("  d.M.y  HH:mm:ss");
        }
        private void SaveFileMenuClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, fileRedactor.Text);
            }
        }
        private void OpenFileMenuClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Document (*.txt)|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileRedactor.Text = System.IO.File.ReadAllText(openFile.FileName);
                path.Text = openFile.FileName;
            }
        }
        private void NewFileMenuClick(object sender, EventArgs e)
        {
            fileRedactor.Clear();
            path.Text = "New Document";
        }
        private void MainMenuRender()
        {
            
            menuItemFile = new ToolStripMenuItem[4];
            file = new ToolStripMenuItem("File");
            file.DropDownItems.AddRange(menuItemFile.Select(x => x = new ToolStripMenuItem()).ToArray());
            mainMenu.Items.Add(file);
            
        }
        private void SetNameMenuFile(ToolStripItemCollection itemsMenuFile,int startName=0)
        {
            for (int i = 0; i < itemsMenuFile.Count; i++)
            {
                itemsMenuFile[i].Text = itemsMenuFileName[startName+i];
            }
        }
        private void StatusMenuRender()
        {
            statusBar = new StatusStrip();
            path = new ToolStripLabel()
            {
                Text = "New Document",
            };
            dateTime = new ToolStripLabel()
            {
                Text = DateTime.Now.ToString("  d.M.y  HH:mm:ss"),
 
            };
            statusBar.Items.Add(path);
            statusBar.Items.Add(dateTime);

        }
        private void EditMenuRender()
        {
            menuItemEdit = new ToolStripMenuItem[4];
            edit = new ToolStripMenuItem("Edit");
            edit.DropDownItems.AddRange(menuItemFile.Select(x => x = new ToolStripMenuItem()).ToArray());
            mainMenu.Items.Add(edit);
        }
       

        Timer date;
        TableLayoutPanel panel;

        ToolStripMenuItem[] menuItemFile,menuItemEdit;
        MenuStrip mainMenu;
        ToolStripMenuItem file;
        ToolStripMenuItem edit;
        string[] itemsMenuFileName;
        TextBox fileRedactor;

        StatusStrip statusBar;
        ToolStripLabel path;
        ToolStripLabel dateTime;
        ContextMenuStrip contextMenuTextBox;

        string buffer;
        int curssor;
    }
}
