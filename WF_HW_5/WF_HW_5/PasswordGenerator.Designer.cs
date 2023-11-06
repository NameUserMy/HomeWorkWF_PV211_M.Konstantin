
namespace WF_HW_5
{
    partial class PasswordGenerator
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
            this.countSimbol = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.selfGeneration = new System.Windows.Forms.TextBox();
            this.setings = new System.Windows.Forms.GroupBox();
            this.generation = new System.Windows.Forms.Button();
            this.exception = new System.Windows.Forms.CheckBox();
            this.specSimbol = new System.Windows.Forms.CheckBox();
            this.upperLetter = new System.Windows.Forms.CheckBox();
            this.lowLetter = new System.Windows.Forms.CheckBox();
            this.numbers = new System.Windows.Forms.CheckBox();
            this.password = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.countSimbol)).BeginInit();
            this.setings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество символов:";
            // 
            // countSimbol
            // 
            this.countSimbol.Location = new System.Drawing.Point(51, 54);
            this.countSimbol.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.countSimbol.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.countSimbol.Name = "countSimbol";
            this.countSimbol.Size = new System.Drawing.Size(389, 20);
            this.countSimbol.TabIndex = 1;
            this.countSimbol.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(48, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Генерировать из символов:";
            // 
            // selfGeneration
            // 
            this.selfGeneration.Location = new System.Drawing.Point(51, 132);
            this.selfGeneration.Name = "selfGeneration";
            this.selfGeneration.Size = new System.Drawing.Size(389, 20);
            this.selfGeneration.TabIndex = 3;
            this.selfGeneration.Enter += new System.EventHandler(this.selfGenerationEnter);
            // 
            // setings
            // 
            this.setings.Controls.Add(this.generation);
            this.setings.Controls.Add(this.exception);
            this.setings.Controls.Add(this.specSimbol);
            this.setings.Controls.Add(this.upperLetter);
            this.setings.Controls.Add(this.lowLetter);
            this.setings.Controls.Add(this.numbers);
            this.setings.Location = new System.Drawing.Point(51, 173);
            this.setings.Name = "setings";
            this.setings.Size = new System.Drawing.Size(389, 158);
            this.setings.TabIndex = 4;
            this.setings.TabStop = false;
            this.setings.Text = "Выбор параметров";
            // 
            // generation
            // 
            this.generation.BackColor = System.Drawing.Color.Green;
            this.generation.FlatAppearance.BorderSize = 0;
            this.generation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generation.ForeColor = System.Drawing.Color.LavenderBlush;
            this.generation.Location = new System.Drawing.Point(167, 100);
            this.generation.Name = "generation";
            this.generation.Size = new System.Drawing.Size(216, 23);
            this.generation.TabIndex = 5;
            this.generation.Text = "Сгенерировать";
            this.generation.UseVisualStyleBackColor = false;
            this.generation.Click += new System.EventHandler(this.generation_Click);
            // 
            // exception
            // 
            this.exception.AutoSize = true;
            this.exception.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exception.Location = new System.Drawing.Point(165, 63);
            this.exception.Name = "exception";
            this.exception.Size = new System.Drawing.Size(227, 19);
            this.exception.TabIndex = 4;
            this.exception.Tag = "4";
            this.exception.Text = "Исключать похожие символы ";
            this.exception.UseVisualStyleBackColor = true;
            this.exception.Click += new System.EventHandler(this.numbers_CheckedChanged);
            // 
            // specSimbol
            // 
            this.specSimbol.AutoSize = true;
            this.specSimbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.specSimbol.Location = new System.Drawing.Point(165, 19);
            this.specSimbol.Name = "specSimbol";
            this.specSimbol.Size = new System.Drawing.Size(180, 19);
            this.specSimbol.TabIndex = 3;
            this.specSimbol.Tag = "3";
            this.specSimbol.Text = "Специальные символы";
            this.specSimbol.UseVisualStyleBackColor = true;
            this.specSimbol.Click += new System.EventHandler(this.numbers_CheckedChanged);
            // 
            // upperLetter
            // 
            this.upperLetter.AutoSize = true;
            this.upperLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upperLetter.Location = new System.Drawing.Point(15, 105);
            this.upperLetter.Name = "upperLetter";
            this.upperLetter.Size = new System.Drawing.Size(146, 19);
            this.upperLetter.TabIndex = 2;
            this.upperLetter.Tag = "2";
            this.upperLetter.Text = "Заглавные буквы ";
            this.upperLetter.UseVisualStyleBackColor = true;
            this.upperLetter.Click += new System.EventHandler(this.numbers_CheckedChanged);
            // 
            // lowLetter
            // 
            this.lowLetter.AutoSize = true;
            this.lowLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lowLetter.Location = new System.Drawing.Point(15, 63);
            this.lowLetter.Name = "lowLetter";
            this.lowLetter.Size = new System.Drawing.Size(144, 19);
            this.lowLetter.TabIndex = 1;
            this.lowLetter.Tag = "1";
            this.lowLetter.Text = "Маленькие буквы";
            this.lowLetter.UseVisualStyleBackColor = true;
            this.lowLetter.Click += new System.EventHandler(this.numbers_CheckedChanged);
            // 
            // numbers
            // 
            this.numbers.AutoSize = true;
            this.numbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numbers.Location = new System.Drawing.Point(15, 19);
            this.numbers.Name = "numbers";
            this.numbers.Size = new System.Drawing.Size(78, 19);
            this.numbers.TabIndex = 0;
            this.numbers.Tag = "0";
            this.numbers.Text = "Цифры ";
            this.numbers.UseVisualStyleBackColor = true;
            this.numbers.CheckedChanged += new System.EventHandler(this.numbers_CheckedChanged);
            // 
            // password
            // 
            this.password.FormattingEnabled = true;
            this.password.Location = new System.Drawing.Point(509, 54);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(264, 277);
            this.password.TabIndex = 5;
            // 
            // PasswordGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.password);
            this.Controls.Add(this.setings);
            this.Controls.Add(this.selfGeneration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countSimbol);
            this.Controls.Add(this.label1);
            this.Name = "PasswordGenerator";
            this.Text = "Password Generator";
            ((System.ComponentModel.ISupportInitialize)(this.countSimbol)).EndInit();
            this.setings.ResumeLayout(false);
            this.setings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown countSimbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox selfGeneration;
        private System.Windows.Forms.GroupBox setings;
        private System.Windows.Forms.CheckBox exception;
        private System.Windows.Forms.CheckBox specSimbol;
        private System.Windows.Forms.CheckBox upperLetter;
        private System.Windows.Forms.CheckBox lowLetter;
        private System.Windows.Forms.CheckBox numbers;
        private System.Windows.Forms.Button generation;
        private System.Windows.Forms.ListBox password;
    }
}

