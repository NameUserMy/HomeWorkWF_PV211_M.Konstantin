
namespace WF_HW_6
{
    partial class Purchases
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
            this.CBcategories = new System.Windows.Forms.ComboBox();
            this.goots = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.сheckout = new System.Windows.Forms.Button();
            this.editProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.details)).BeginInit();
            this.SuspendLayout();
            // 
            // CBcategories
            // 
            this.CBcategories.BackColor = System.Drawing.SystemColors.Control;
            this.CBcategories.FormattingEnabled = true;
            this.CBcategories.Location = new System.Drawing.Point(105, 12);
            this.CBcategories.Name = "CBcategories";
            this.CBcategories.Size = new System.Drawing.Size(188, 21);
            this.CBcategories.TabIndex = 0;
            // 
            // goots
            // 
            this.goots.BackColor = System.Drawing.SystemColors.Control;
            this.goots.FormattingEnabled = true;
            this.goots.Location = new System.Drawing.Point(12, 50);
            this.goots.Name = "goots";
            this.goots.Size = new System.Drawing.Size(281, 259);
            this.goots.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Категории";
            // 
            // details
            // 
            this.details.BackgroundColor = System.Drawing.SystemColors.Control;
            this.details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.details.Location = new System.Drawing.Point(343, 50);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(445, 259);
            this.details.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Подробние о товаре";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(343, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Всего к оплате";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.total.Location = new System.Drawing.Point(467, 330);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(18, 20);
            this.total.TabIndex = 6;
            this.total.Text = "0";
            // 
            // сheckout
            // 
            this.сheckout.Location = new System.Drawing.Point(644, 334);
            this.сheckout.Name = "сheckout";
            this.сheckout.Size = new System.Drawing.Size(143, 23);
            this.сheckout.TabIndex = 7;
            this.сheckout.Text = "Оформить";
            this.сheckout.UseVisualStyleBackColor = true;
            this.сheckout.Click += new System.EventHandler(this.сheckout_Click);
            // 
            // editProduct
            // 
            this.editProduct.Location = new System.Drawing.Point(12, 334);
            this.editProduct.Name = "editProduct";
            this.editProduct.Size = new System.Drawing.Size(280, 23);
            this.editProduct.TabIndex = 8;
            this.editProduct.Text = "Редактировать";
            this.editProduct.UseVisualStyleBackColor = true;
            // 
            // Purchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.editProduct);
            this.Controls.Add(this.сheckout);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.details);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goots);
            this.Controls.Add(this.CBcategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Purchases";
            this.Text = "Shop";
            ((System.ComponentModel.ISupportInitialize)(this.details)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CBcategories;
        private System.Windows.Forms.CheckedListBox goots;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView details;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Button сheckout;
        private System.Windows.Forms.Button editProduct;
    }
}

