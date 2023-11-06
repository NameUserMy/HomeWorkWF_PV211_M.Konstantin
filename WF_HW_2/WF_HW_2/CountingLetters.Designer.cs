
namespace WF_HW_2
{
    partial class CountingLetters
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
            this.incommingString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.countLetеer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // incommingString
            // 
            this.incommingString.Location = new System.Drawing.Point(92, 47);
            this.incommingString.Name = "incommingString";
            this.incommingString.Size = new System.Drawing.Size(140, 20);
            this.incommingString.TabIndex = 0;
            this.incommingString.TextChanged += new System.EventHandler(this.incommingString_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter string";
            // 
            // countLetеer
            // 
            this.countLetеer.Location = new System.Drawing.Point(92, 83);
            this.countLetеer.Name = "countLetеer";
            this.countLetеer.ReadOnly = true;
            this.countLetеer.Size = new System.Drawing.Size(140, 20);
            this.countLetеer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "count (a,b) ";
            // 
            // CountingLetters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 128);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countLetеer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.incommingString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountingLetters";
            this.Text = "CountingLetters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox incommingString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countLetеer;
        private System.Windows.Forms.Label label2;
    }
}