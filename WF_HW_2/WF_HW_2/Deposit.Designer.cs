
namespace WF_HW_2
{
    partial class Deposit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.period = new System.Windows.Forms.GroupBox();
            this.month_12 = new System.Windows.Forms.RadioButton();
            this.month_24 = new System.Windows.Forms.RadioButton();
            this.month_6 = new System.Windows.Forms.RadioButton();
            this.month_3 = new System.Windows.Forms.RadioButton();
            this.sum = new System.Windows.Forms.NumericUpDown();
            this.rate = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.result = new System.Windows.Forms.TextBox();
            this.calculate = new System.Windows.Forms.Button();
            this.period.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rate";
            // 
            // period
            // 
            this.period.Controls.Add(this.month_12);
            this.period.Controls.Add(this.month_24);
            this.period.Controls.Add(this.month_6);
            this.period.Controls.Add(this.month_3);
            this.period.Location = new System.Drawing.Point(195, 39);
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(200, 100);
            this.period.TabIndex = 4;
            this.period.TabStop = false;
            this.period.Text = "Period";
            // 
            // month_12
            // 
            this.month_12.AutoSize = true;
            this.month_12.Location = new System.Drawing.Point(97, 29);
            this.month_12.Name = "month_12";
            this.month_12.Size = new System.Drawing.Size(70, 17);
            this.month_12.TabIndex = 8;
            this.month_12.TabStop = true;
            this.month_12.Tag = "12";
            this.month_12.Text = "12 Month";
            this.month_12.UseVisualStyleBackColor = true;
            // 
            // month_24
            // 
            this.month_24.AutoSize = true;
            this.month_24.Location = new System.Drawing.Point(97, 65);
            this.month_24.Name = "month_24";
            this.month_24.Size = new System.Drawing.Size(70, 17);
            this.month_24.TabIndex = 7;
            this.month_24.TabStop = true;
            this.month_24.Tag = "24";
            this.month_24.Text = "24 Month";
            this.month_24.UseVisualStyleBackColor = true;
            // 
            // month_6
            // 
            this.month_6.AutoSize = true;
            this.month_6.Location = new System.Drawing.Point(6, 65);
            this.month_6.Name = "month_6";
            this.month_6.Size = new System.Drawing.Size(64, 17);
            this.month_6.TabIndex = 6;
            this.month_6.TabStop = true;
            this.month_6.Tag = "6";
            this.month_6.Text = "6 Month";
            this.month_6.UseVisualStyleBackColor = true;
            // 
            // month_3
            // 
            this.month_3.AutoSize = true;
            this.month_3.Checked = true;
            this.month_3.Location = new System.Drawing.Point(6, 29);
            this.month_3.Name = "month_3";
            this.month_3.Size = new System.Drawing.Size(64, 17);
            this.month_3.TabIndex = 5;
            this.month_3.TabStop = true;
            this.month_3.Tag = "3";
            this.month_3.Text = "3 Month";
            this.month_3.UseVisualStyleBackColor = true;
            // 
            // sum
            // 
            this.sum.Location = new System.Drawing.Point(48, 44);
            this.sum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.sum.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(120, 20);
            this.sum.TabIndex = 5;
            this.sum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // rate
            // 
            this.rate.Location = new System.Drawing.Point(48, 119);
            this.rate.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.rate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(120, 20);
            this.rate.TabIndex = 6;
            this.rate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.result);
            this.panel1.Controls.Add(this.calculate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 100);
            this.panel1.TabIndex = 7;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(0, 0);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(182, 100);
            this.result.TabIndex = 1;
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(181, 0);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(220, 100);
            this.calculate.TabIndex = 0;
            this.calculate.Text = "Сalculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // Deposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rate);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.period);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Deposit";
            this.Text = "Deposit";
            this.period.ResumeLayout(false);
            this.period.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox period;
        private System.Windows.Forms.RadioButton month_12;
        private System.Windows.Forms.RadioButton month_24;
        private System.Windows.Forms.RadioButton month_6;
        private System.Windows.Forms.RadioButton month_3;
        private System.Windows.Forms.NumericUpDown sum;
        private System.Windows.Forms.NumericUpDown rate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button calculate;
    }
}

