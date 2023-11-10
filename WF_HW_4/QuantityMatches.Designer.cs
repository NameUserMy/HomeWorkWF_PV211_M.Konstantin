
namespace WF_HW_4
{
    partial class QuantityMatches
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
            this.data = new System.Windows.Forms.DataGridView();
            this.incomming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comparison = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overlap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.incomming,
            this.comparison,
            this.overlap});
            this.data.Location = new System.Drawing.Point(12, 12);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(776, 426);
            this.data.TabIndex = 0;
            // 
            // incomming
            // 
            this.incomming.HeaderText = "Входяшая строка";
            this.incomming.Name = "incomming";
            // 
            // comparison
            // 
            this.comparison.HeaderText = "Срока для сверки";
            this.comparison.Name = "comparison";
            // 
            // overlap
            // 
            this.overlap.HeaderText = "Количество совпадений";
            this.overlap.Name = "overlap";
            this.overlap.ReadOnly = true;
            // 
            // QuantityMatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.data);
            this.Name = "QuantityMatches";
            this.Text = "QuantityMatches";
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.DataGridViewTextBoxColumn incomming;
        private System.Windows.Forms.DataGridViewTextBoxColumn comparison;
        private System.Windows.Forms.DataGridViewTextBoxColumn overlap;
    }
}