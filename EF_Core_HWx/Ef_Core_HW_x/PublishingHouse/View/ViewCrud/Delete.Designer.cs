namespace Ef_Core_HW_x.PublishingHouse.View.ViewCrud
{
    partial class Delete
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
            cencelDeleteButton = new Button();
            confirmDeleteButton = new Button();
            idTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // cencelDeleteButton
            // 
            cencelDeleteButton.Location = new Point(30, 99);
            cencelDeleteButton.Name = "cencelDeleteButton";
            cencelDeleteButton.Size = new Size(75, 23);
            cencelDeleteButton.TabIndex = 0;
            cencelDeleteButton.Text = "Cencel";
            cencelDeleteButton.UseVisualStyleBackColor = true;
            cencelDeleteButton.Click += cencelDeleteButton_Click;
            // 
            // confirmDeleteButton
            // 
            confirmDeleteButton.Location = new Point(111, 99);
            confirmDeleteButton.Name = "confirmDeleteButton";
            confirmDeleteButton.Size = new Size(75, 23);
            confirmDeleteButton.TabIndex = 1;
            confirmDeleteButton.Text = "Confirm";
            confirmDeleteButton.UseVisualStyleBackColor = true;
            confirmDeleteButton.Click += confirmDeleteButton_Click;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(30, 56);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(156, 23);
            idTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 27);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Enter Id";
            // 
            // Delete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(213, 164);
            Controls.Add(label1);
            Controls.Add(idTextBox);
            Controls.Add(confirmDeleteButton);
            Controls.Add(cencelDeleteButton);
            Name = "Delete";
            Text = "Delete";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cencelDeleteButton;
        private Button confirmDeleteButton;
        private TextBox idTextBox;
        private Label label1;
    }
}