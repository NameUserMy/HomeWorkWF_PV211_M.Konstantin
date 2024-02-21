namespace Ef_Core_HW_x.PublishingHouse.View
{
    partial class PublishingHouseView
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
            tabPublishControl = new TabControl();
            BooksTab = new TabPage();
            booksGridView = new DataGridView();
            tabAuthors = new TabPage();
            authorsDataGridView = new DataGridView();
            tabPublishers = new TabPage();
            publisherDataGridView = new DataGridView();
            deleteBookButton = new Button();
            changeBookButton = new Button();
            addBookButton = new Button();
            tabPublishControl.SuspendLayout();
            BooksTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksGridView).BeginInit();
            tabAuthors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)authorsDataGridView).BeginInit();
            tabPublishers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)publisherDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabPublishControl
            // 
            tabPublishControl.Controls.Add(BooksTab);
            tabPublishControl.Controls.Add(tabAuthors);
            tabPublishControl.Controls.Add(tabPublishers);
            tabPublishControl.Location = new Point(4, 41);
            tabPublishControl.Name = "tabPublishControl";
            tabPublishControl.SelectedIndex = 0;
            tabPublishControl.Size = new Size(797, 407);
            tabPublishControl.TabIndex = 0;
            tabPublishControl.Tag = "Publishers";
            tabPublishControl.Selected += tabPublishControl_Selected;
            // 
            // BooksTab
            // 
            BooksTab.BackColor = SystemColors.Control;
            BooksTab.Controls.Add(booksGridView);
            BooksTab.Location = new Point(4, 24);
            BooksTab.Name = "BooksTab";
            BooksTab.Padding = new Padding(3);
            BooksTab.Size = new Size(789, 379);
            BooksTab.TabIndex = 0;
            BooksTab.Tag = "Books";
            BooksTab.Text = "Books";
            // 
            // booksGridView
            // 
            booksGridView.BackgroundColor = SystemColors.Control;
            booksGridView.BorderStyle = BorderStyle.None;
            booksGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksGridView.Location = new Point(6, 6);
            booksGridView.Name = "booksGridView";
            booksGridView.Size = new Size(777, 373);
            booksGridView.TabIndex = 3;
            // 
            // tabAuthors
            // 
            tabAuthors.Controls.Add(authorsDataGridView);
            tabAuthors.Location = new Point(4, 24);
            tabAuthors.Name = "tabAuthors";
            tabAuthors.Padding = new Padding(3);
            tabAuthors.Size = new Size(789, 379);
            tabAuthors.TabIndex = 1;
            tabAuthors.Tag = "Authors";
            tabAuthors.Text = "Authors";
            tabAuthors.UseVisualStyleBackColor = true;
            // 
            // authorsDataGridView
            // 
            authorsDataGridView.BackgroundColor = SystemColors.Control;
            authorsDataGridView.BorderStyle = BorderStyle.None;
            authorsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            authorsDataGridView.Location = new Point(6, 3);
            authorsDataGridView.Name = "authorsDataGridView";
            authorsDataGridView.Size = new Size(777, 373);
            authorsDataGridView.TabIndex = 4;
            // 
            // tabPublishers
            // 
            tabPublishers.Controls.Add(publisherDataGridView);
            tabPublishers.Location = new Point(4, 24);
            tabPublishers.Name = "tabPublishers";
            tabPublishers.Padding = new Padding(3);
            tabPublishers.Size = new Size(789, 379);
            tabPublishers.TabIndex = 2;
            tabPublishers.Tag = "Publishers";
            tabPublishers.Text = "Publishers";
            tabPublishers.UseVisualStyleBackColor = true;
            // 
            // publisherDataGridView
            // 
            publisherDataGridView.BackgroundColor = SystemColors.Control;
            publisherDataGridView.BorderStyle = BorderStyle.None;
            publisherDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            publisherDataGridView.Location = new Point(6, 3);
            publisherDataGridView.Name = "publisherDataGridView";
            publisherDataGridView.Size = new Size(777, 373);
            publisherDataGridView.TabIndex = 5;
            // 
            // deleteBookButton
            // 
            deleteBookButton.Location = new Point(690, 12);
            deleteBookButton.Name = "deleteBookButton";
            deleteBookButton.Size = new Size(88, 23);
            deleteBookButton.TabIndex = 2;
            deleteBookButton.Text = "Delete";
            deleteBookButton.UseVisualStyleBackColor = true;
            deleteBookButton.Click += deleteBookButton_Click;
            // 
            // changeBookButton
            // 
            changeBookButton.Location = new Point(609, 12);
            changeBookButton.Name = "changeBookButton";
            changeBookButton.Size = new Size(75, 23);
            changeBookButton.TabIndex = 1;
            changeBookButton.Text = "Edit";
            changeBookButton.UseVisualStyleBackColor = true;
            // 
            // addBookButton
            // 
            addBookButton.Location = new Point(528, 12);
            addBookButton.Name = "addBookButton";
            addBookButton.Size = new Size(75, 23);
            addBookButton.TabIndex = 0;
            addBookButton.Text = "Add";
            addBookButton.UseVisualStyleBackColor = true;
            addBookButton.Click += addBookButton_Click;
            // 
            // PublishingHouseView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabPublishControl);
            Controls.Add(deleteBookButton);
            Controls.Add(addBookButton);
            Controls.Add(changeBookButton);
            Name = "PublishingHouseView";
            Text = "PublishingHouseView";
            tabPublishControl.ResumeLayout(false);
            BooksTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)booksGridView).EndInit();
            tabAuthors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)authorsDataGridView).EndInit();
            tabPublishers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)publisherDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabPublishControl;
        private TabPage BooksTab;
        private TabPage tabAuthors;
        private TabPage tabPublishers;
        private DataGridView booksGridView;
        private Button deleteBookButton;
        private Button changeBookButton;
        private Button addBookButton;
        private DataGridView authorsDataGridView;
        private DataGridView publisherDataGridView;
    }
}