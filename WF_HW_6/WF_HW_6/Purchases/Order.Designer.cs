
namespace WF_HW_6
{
    partial class Order
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
            this.orderDG = new System.Windows.Forms.DataGridView();
            this.accept = new System.Windows.Forms.Button();
            this.refusal = new System.Windows.Forms.Button();
            this.totalOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderDG)).BeginInit();
            this.SuspendLayout();
            // 
            // orderDG
            // 
            this.orderDG.BackgroundColor = System.Drawing.SystemColors.Control;
            this.orderDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDG.Location = new System.Drawing.Point(12, 12);
            this.orderDG.Name = "orderDG";
            this.orderDG.Size = new System.Drawing.Size(346, 367);
            this.orderDG.TabIndex = 0;
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(12, 385);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(86, 23);
            this.accept.TabIndex = 1;
            this.accept.Text = "Подтвердить";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // refusal
            // 
            this.refusal.Location = new System.Drawing.Point(272, 385);
            this.refusal.Name = "refusal";
            this.refusal.Size = new System.Drawing.Size(86, 23);
            this.refusal.TabIndex = 2;
            this.refusal.Text = "Отказ";
            this.refusal.UseVisualStyleBackColor = true;
            this.refusal.Click += new System.EventHandler(this.refusal_Click);
            // 
            // totalOrder
            // 
            this.totalOrder.AutoSize = true;
            this.totalOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalOrder.Location = new System.Drawing.Point(176, 391);
            this.totalOrder.Name = "totalOrder";
            this.totalOrder.Size = new System.Drawing.Size(18, 20);
            this.totalOrder.TabIndex = 3;
            this.totalOrder.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(104, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "К оплате";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalOrder);
            this.Controls.Add(this.refusal);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.orderDG);
            this.Name = "Order";
            this.Text = "Order";
            ((System.ComponentModel.ISupportInitialize)(this.orderDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView orderDG;
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Button refusal;
        private System.Windows.Forms.Label totalOrder;
        private System.Windows.Forms.Label label1;
    }
}