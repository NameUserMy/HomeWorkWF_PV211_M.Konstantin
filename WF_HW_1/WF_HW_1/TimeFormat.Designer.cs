using System.Drawing;
using System.Windows.Forms;
namespace WF_HW_1
{
    partial class TimeFormat
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
            this.components = new System.ComponentModel.Container();
            this._formatTime = new System.Windows.Forms.GroupBox();
            this._format12 = new System.Windows.Forms.RadioButton();
            this._format24 = new System.Windows.Forms.RadioButton();
            this._periodicity = new System.Windows.Forms.GroupBox();
            this._setPeriodicity = new System.Windows.Forms.NumericUpDown();
            this._text = new System.Windows.Forms.Label();
            this._time = new System.Windows.Forms.TextBox();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._formatTime.SuspendLayout();
            this._periodicity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._setPeriodicity)).BeginInit();
            this.SuspendLayout();
            // 
            // _formatTime
            // 
            this._formatTime.Controls.Add(this._format12);
            this._formatTime.Controls.Add(this._format24);
            this._formatTime.Location = new System.Drawing.Point(300, 50);
            this._formatTime.Name = "_formatTime";
            this._formatTime.Size = new System.Drawing.Size(200, 100);
            this._formatTime.TabIndex = 0;
            this._formatTime.TabStop = false;
            this._formatTime.Text = "Selecting the time format";
            // 
            // _format12
            // 
            this._format12.Location = new System.Drawing.Point(12, 25);
            this._format12.Name = "_format12";
            this._format12.Size = new System.Drawing.Size(104, 24);
            this._format12.TabIndex = 0;
            this._format12.Text = "12";
            // 
            // _format24
            // 
            this._format24.Checked = true;
            this._format24.Location = new System.Drawing.Point(12, 60);
            this._format24.Name = "_format24";
            this._format24.Size = new System.Drawing.Size(104, 24);
            this._format24.TabIndex = 1;
            this._format24.TabStop = true;
            this._format24.Text = "24";
            // 
            // _periodicity
            // 
            this._periodicity.Controls.Add(this._setPeriodicity);
            this._periodicity.Controls.Add(this._text);
            this._periodicity.Controls.Add(this._time);
            this._periodicity.Location = new System.Drawing.Point(20, 50);
            this._periodicity.Name = "_periodicity";
            this._periodicity.Size = new System.Drawing.Size(200, 100);
            this._periodicity.TabIndex = 1;
            this._periodicity.TabStop = false;
            this._periodicity.Text = "Periodicity";
            // 
            // _setPeriodicity
            // 
            this._setPeriodicity.Location = new System.Drawing.Point(60, 20);
            this._setPeriodicity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._setPeriodicity.Name = "_setPeriodicity";
            this._setPeriodicity.Size = new System.Drawing.Size(120, 20);
            this._setPeriodicity.TabIndex = 0;
            this._setPeriodicity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._setPeriodicity.ValueChanged += new System.EventHandler(this._setPeriodicity_ValueChanged);
            // 
            // _text
            // 
            this._text.Location = new System.Drawing.Point(2, 20);
            this._text.Name = "_text";
            this._text.Size = new System.Drawing.Size(100, 23);
            this._text.TabIndex = 1;
            this._text.Text = "Periodicity:";
            // 
            // _time
            // 
            this._time.Location = new System.Drawing.Point(5, 50);
            this._time.MinimumSize = new System.Drawing.Size(190, 10);
            this._time.Name = "_time";
            this._time.ReadOnly = true;
            this._time.Size = new System.Drawing.Size(190, 20);
            this._time.TabIndex = 2;
            // 
            // TimeFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._formatTime);
            this.Controls.Add(this._periodicity);
            this.Name = "TimeFormat";
            this.Text = "TimeFormat";
            this._formatTime.ResumeLayout(false);
            this._periodicity.ResumeLayout(false);
            this._periodicity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._setPeriodicity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private NumericUpDown _setPeriodicity;
        private GroupBox _formatTime;
        private GroupBox _periodicity;
        private RadioButton _format12;
        private RadioButton _format24;
        private Label _text;
        private TextBox _time;
        private Timer _timer;
       

        
    }
}

