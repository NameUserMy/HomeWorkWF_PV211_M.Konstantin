
using System.Drawing;
using System.Windows.Forms;

namespace WF_HW_1
{
    partial class AddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        int size;
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
            size = 247;
            this._panelForInfo = new FlowLayoutPanel();
            this._nameTextBox = new TextBox();
            this._ageNumUPDown = new NumericUpDown();
            this._weightNumUPDown = new NumericUpDown();
            this._countryTextBox = new TextBox();
            this._userListBox = new ListBox();
            this._addUserButton = new Button();
            this.SuspendLayout();
            // 
            // _panelForInfo
            // 
            this._panelForInfo.Dock = DockStyle.Left;
            this._panelForInfo.Location = new Point(0, 0);
            this._panelForInfo.Name = "_panelForInfo";
            this._panelForInfo.Size = new Size(250, 450);
            this._panelForInfo.TabIndex = 0;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new Size(size, 20);
            this._nameTextBox.TabIndex = 0;
            // 
            // _ageNumUPDown
            // 
            this._ageNumUPDown.Minimum = 1;
            this._ageNumUPDown.Name = "ageNumUPDown";
            this._ageNumUPDown.Size = new Size(size, 20);
            // 
            // _weightNumUPDown
            // 
            this._weightNumUPDown.Minimum = 1;
            this._weightNumUPDown.Name = "weightNumUPDown";
            this._weightNumUPDown.Size = new Size(size, 20);
            // 
            // _countryTextBox
            // 
            this._countryTextBox.Name = "_countryTextBox";
            this._countryTextBox.Size = new Size(size, 20);
            this._countryTextBox.TabIndex = 3;
            // 
            // _userListBox
            // 
            this._userListBox.BackColor = SystemColors.Control;
            this._userListBox.BorderStyle = BorderStyle.None;
            this._userListBox.Name = "userListBox";
            this._userListBox.Size = new Size(size, 50);
            // 
            // _addUserButton
            // 
            this._addUserButton.Text="Add user";
            this._addUserButton.Click+= new System.EventHandler(this.AddUserB);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._panelForInfo);
            this._panelForInfo.Controls.Add(this._nameTextBox);
            this._panelForInfo.Controls.Add(this._ageNumUPDown);
            this._panelForInfo.Controls.Add(this._weightNumUPDown);
            this._panelForInfo.Controls.Add(this._countryTextBox);
            this._panelForInfo.Controls.Add(this._userListBox);
            this._panelForInfo.Controls.Add(this._addUserButton);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this._panelForInfo.ResumeLayout(false);
            this._panelForInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ageNumUPDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._weightNumUPDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox _nameTextBox;
        private NumericUpDown _ageNumUPDown;
        private NumericUpDown _weightNumUPDown;
        private TextBox _countryTextBox;
        private FlowLayoutPanel _panelForInfo;
        private ListBox _userListBox;
        private Button _addUserButton;
    }
}