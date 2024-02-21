namespace Ef_Core_HW_x
{
    partial class UserSettings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userNameTextBox = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            addUserButton = new Button();
            userPassTextBox = new TextBox();
            label4 = new Label();
            userEmailTextBox = new TextBox();
            label3 = new Label();
            userLogginTextBox = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            deleteUserById = new Button();
            userIdTextBox = new TextBox();
            label5 = new Label();
            ifoGridView = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ifoGridView).BeginInit();
            SuspendLayout();
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(22, 46);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(100, 23);
            userNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 28);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(addUserButton);
            groupBox1.Controls.Add(userPassTextBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(userEmailTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(userLogginTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(userNameTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(268, 210);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add user";
            // 
            // addUserButton
            // 
            addUserButton.Location = new Point(22, 152);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(227, 46);
            addUserButton.TabIndex = 8;
            addUserButton.Text = "Confirm";
            addUserButton.UseVisualStyleBackColor = true;
            addUserButton.Click += addUserButton_Click;
            // 
            // userPassTextBox
            // 
            userPassTextBox.Location = new Point(149, 104);
            userPassTextBox.Name = "userPassTextBox";
            userPassTextBox.Size = new Size(100, 23);
            userPassTextBox.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(149, 86);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 7;
            label4.Text = "Pass";
            // 
            // userEmailTextBox
            // 
            userEmailTextBox.Location = new Point(149, 46);
            userEmailTextBox.Name = "userEmailTextBox";
            userEmailTextBox.Size = new Size(100, 23);
            userEmailTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(149, 28);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // userLogginTextBox
            // 
            userLogginTextBox.Location = new Point(22, 104);
            userLogginTextBox.Name = "userLogginTextBox";
            userLogginTextBox.Size = new Size(100, 23);
            userLogginTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 86);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 3;
            label2.Text = "Loggin";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(deleteUserById);
            groupBox2.Controls.Add(userIdTextBox);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(304, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(295, 210);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delete user by id";
            // 
            // deleteUserById
            // 
            deleteUserById.Location = new Point(135, 46);
            deleteUserById.Name = "deleteUserById";
            deleteUserById.Size = new Size(131, 23);
            deleteUserById.TabIndex = 9;
            deleteUserById.Text = "Confirm";
            deleteUserById.UseVisualStyleBackColor = true;
            deleteUserById.Click += deleteUserById_Click;
            // 
            // userIdTextBox
            // 
            userIdTextBox.Location = new Point(6, 46);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.Size = new Size(100, 23);
            userIdTextBox.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 28);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 3;
            label5.Text = "Enter id";
            // 
            // ifoGridView
            // 
            ifoGridView.BackgroundColor = SystemColors.Control;
            ifoGridView.BorderStyle = BorderStyle.None;
            ifoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ifoGridView.Location = new Point(12, 228);
            ifoGridView.Name = "ifoGridView";
            ifoGridView.Size = new Size(587, 184);
            ifoGridView.TabIndex = 4;
            // 
            // UserSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 415);
            Controls.Add(ifoGridView);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimizeBox = false;
            Name = "UserSettings";
            Text = "UserAndSettings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ifoGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox userNameTextBox;
        private Label label1;
        private GroupBox groupBox1;
        private Button addUserButton;
        private TextBox userPassTextBox;
        private Label label4;
        private TextBox userEmailTextBox;
        private Label label3;
        private TextBox userLogginTextBox;
        private Label label2;
        private GroupBox groupBox2;
        private Button deleteUserById;
        private TextBox userIdTextBox;
        private Label label5;
        private DataGridView ifoGridView;
    }
}
