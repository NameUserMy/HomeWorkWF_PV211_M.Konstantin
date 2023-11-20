
namespace WF_HW_7
{
    partial class FileManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diskView = new System.Windows.Forms.TreeView();
            this.fileView = new System.Windows.Forms.TreeView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // diskView
            // 
            this.diskView.Location = new System.Drawing.Point(12, 40);
            this.diskView.Name = "diskView";
            this.diskView.Size = new System.Drawing.Size(191, 355);
            this.diskView.TabIndex = 2;
            // 
            // fileView
            // 
            this.fileView.Location = new System.Drawing.Point(237, 40);
            this.fileView.Name = "fileView";
            this.fileView.Size = new System.Drawing.Size(306, 355);
            this.fileView.TabIndex = 3;
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(585, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 450);
            this.Controls.Add(this.fileView);
            this.Controls.Add(this.diskView);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "FileManager";
            this.Text = "FileManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView diskView;
        private System.Windows.Forms.TreeView fileView;
        private System.Windows.Forms.MenuStrip menu;
    }
}