
namespace WF_HW_2
{
    partial class NotIdenticalLetters
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
            this.incomminTextBox = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // incomminTextBox
            // 
            this.incomminTextBox.Location = new System.Drawing.Point(152, 69);
            this.incomminTextBox.Name = "incomminTextBox";
            this.incomminTextBox.Size = new System.Drawing.Size(168, 20);
            this.incomminTextBox.TabIndex = 0;
            this.incomminTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(152, 105);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(168, 23);
            this.clear.TabIndex = 1;
            this.clear.Text = "Reset";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter your text(Only different letters)";
            // 
            // NotIdenticalLetters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.incomminTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotIdenticalLetters";
            this.Text = "NotIdenticalLetters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox incomminTextBox;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label label1;
    }
}