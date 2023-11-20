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
    public partial class FileManager : Form
    {
        public FileManager()
        {
            InitializeComponent();
            allDrives = DriveInfo.GetDrives();
            dir = new TreeNode();
            path = new ToolStripLabel() { 
            
            Text="tets"
            };
            this.Load += LoadManager;
        }

        private void LoadManager(object sender, EventArgs e)
        {
            GetDrive();
            diskView.AfterSelect += SlectFolder;
            fileView.AfterSelect += GetPath;
            menu.Items.Add(path);
        }
        private void GetPath(object sender, TreeViewEventArgs e)
        {
            path.Text = $"  Path - {e.Node.FullPath}";
        }
        private void HDDClickMenu(object sender, EventArgs e)
        {
            
            diskView.Nodes.Clear();
            if (Directory.Exists(sender.ToString()))
            {
                for (int i = 0; i < Directory.GetFileSystemEntries(sender.ToString()).Length; i++)
                {
                    diskView.Nodes.Add(new TreeNode(Directory.GetFileSystemEntries(sender.ToString())[i]));
                }
            }
            else { return; }
            path.Text = $"  Path - {sender}";
        }
        private void SlectFolder(object sender, TreeViewEventArgs e)
        {
            
            if (Directory.Exists(e.Node.Text))
            {
                fileView.Nodes.Clear();
                dir.Nodes.Clear();
                dir.Text = e.Node.Text;
                for (int i = 0; i < Directory.GetFileSystemEntries(e.Node.Text).Length; i++)
                {
                    dir.Nodes.Add(Directory.GetFileSystemEntries(e.Node.Text)[i]);
                }
                fileView.Nodes.Add(dir);
                dir.Collapse();
                path.Text = $"  Path - {dir.FullPath}";
                
            }
            else if (File.Exists(e.Node.Text))
            {
                fileView.Nodes.Clear();
                fileView.Nodes.Add (e.Node.Text);
                path.Text = $"  Path - {e.Node.Text}";
            }
            

        }
        private void GetDrive()
        {
            for (int i = 0; i < allDrives.Length; i++)
            {
                HDD = new ToolStripMenuItem(allDrives[i].Name);
                HDD.Click += HDDClickMenu;
                menu.Items.Add(HDD);
                for (int j = 0; j < Directory.GetFileSystemEntries(allDrives[0].Name).Length; j++)
                {
                    diskView.Nodes.Add(new TreeNode(Directory.GetFileSystemEntries(allDrives[0].Name)[j]));
                }
            }
        }
        private DriveInfo[] allDrives;
        private TreeNode dir;
        private ToolStripMenuItem HDD;
        private ToolStripLabel path;
    }
}
