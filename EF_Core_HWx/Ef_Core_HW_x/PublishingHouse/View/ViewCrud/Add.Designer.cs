namespace Ef_Core_HW_x.PublishingHouse.View.ViewBook
{
    partial class Add
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
            TitleTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            genreTextBox = new TextBox();
            Description = new Label();
            descriptionTextBox = new TextBox();
            cencelBookButton = new Button();
            confirmBookButton = new Button();
            SuspendLayout();
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(12, 56);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(139, 23);
            TitleTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 1;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 28);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "Genre";
            // 
            // genreTextBox
            // 
            genreTextBox.Location = new Point(182, 56);
            genreTextBox.Name = "genreTextBox";
            genreTextBox.Size = new Size(139, 23);
            genreTextBox.TabIndex = 2;
            // 
            // Description
            // 
            Description.AutoSize = true;
            Description.Location = new Point(119, 100);
            Description.Name = "Description";
            Description.Size = new Size(67, 15);
            Description.TabIndex = 4;
            Description.Text = "Description";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(12, 136);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(309, 130);
            descriptionTextBox.TabIndex = 5;
            // 
            // cencelBookButton
            // 
            cencelBookButton.Location = new Point(12, 291);
            cencelBookButton.Name = "cencelBookButton";
            cencelBookButton.Size = new Size(75, 23);
            cencelBookButton.TabIndex = 6;
            cencelBookButton.Text = "Cencel";
            cencelBookButton.UseVisualStyleBackColor = true;
            cencelBookButton.Click += cencelBookButton_Click;
            // 
            // confirmBookButton
            // 
            confirmBookButton.Location = new Point(246, 291);
            confirmBookButton.Name = "confirmBookButton";
            confirmBookButton.Size = new Size(75, 23);
            confirmBookButton.TabIndex = 7;
            confirmBookButton.Text = "Confirm";
            confirmBookButton.UseVisualStyleBackColor = true;
            confirmBookButton.Click += confirmBookButton_Click;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 326);
            Controls.Add(confirmBookButton);
            Controls.Add(cencelBookButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(Description);
            Controls.Add(label2);
            Controls.Add(genreTextBox);
            Controls.Add(label1);
            Controls.Add(TitleTextBox);
            MaximizeBox = false;
            Name = "Add";
            Text = "Add";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TitleTextBox;
        private Label label1;
        private Label label2;
        private TextBox genreTextBox;
        private Label Description;
        private TextBox descriptionTextBox;
        private Button cencelBookButton;
        private Button confirmBookButton;
    }
}