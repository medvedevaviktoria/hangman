namespace hangman
{
    partial class twoplayersFIRST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(twoplayersFIRST));
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.labelword = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.labelcategory = new System.Windows.Forms.Label();
            this.buttonback1 = new System.Windows.Forms.Button();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSecondName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Linen;
            this.buttonStart.Enabled = false;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(462, 424);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(103, 42);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Играть!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxWord
            // 
            this.textBoxWord.BackColor = System.Drawing.Color.Linen;
            this.textBoxWord.Location = new System.Drawing.Point(428, 370);
            this.textBoxWord.Multiline = true;
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(175, 28);
            this.textBoxWord.TabIndex = 1;
            this.textBoxWord.TextChanged += new System.EventHandler(this.textBoxWord_TextChanged);
            this.textBoxWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWord_KeyPress);
            // 
            // labelword
            // 
            this.labelword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelword.Location = new System.Drawing.Point(428, 327);
            this.labelword.Name = "labelword";
            this.labelword.Size = new System.Drawing.Size(175, 28);
            this.labelword.TabIndex = 19;
            this.labelword.Text = "Напишите слово:";
            this.labelword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.BackColor = System.Drawing.Color.Linen;
            this.textBoxCategory.Location = new System.Drawing.Point(428, 256);
            this.textBoxCategory.Multiline = true;
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(175, 28);
            this.textBoxCategory.TabIndex = 0;
            this.textBoxCategory.TextChanged += new System.EventHandler(this.textBoxCategory_TextChanged);
            this.textBoxCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCategory_KeyPress);
            // 
            // labelcategory
            // 
            this.labelcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelcategory.Location = new System.Drawing.Point(414, 215);
            this.labelcategory.Name = "labelcategory";
            this.labelcategory.Size = new System.Drawing.Size(207, 28);
            this.labelcategory.TabIndex = 17;
            this.labelcategory.Text = "Укажите категорию:";
            this.labelcategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonback1
            // 
            this.buttonback1.BackColor = System.Drawing.Color.LightPink;
            this.buttonback1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonback1.Location = new System.Drawing.Point(12, 560);
            this.buttonback1.Name = "buttonback1";
            this.buttonback1.Size = new System.Drawing.Size(106, 38);
            this.buttonback1.TabIndex = 3;
            this.buttonback1.Text = "В меню";
            this.buttonback1.UseVisualStyleBackColor = false;
            this.buttonback1.Click += new System.EventHandler(this.buttonback1_Click);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.BackColor = System.Drawing.Color.Linen;
            this.textBoxFirstName.Location = new System.Drawing.Point(210, 113);
            this.textBoxFirstName.Multiline = true;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(175, 28);
            this.textBoxFirstName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(192, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 88);
            this.label1.TabIndex = 21;
            this.label1.Text = "Имя человека, загадывающего слово:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSecondName
            // 
            this.textBoxSecondName.BackColor = System.Drawing.Color.Linen;
            this.textBoxSecondName.Location = new System.Drawing.Point(637, 113);
            this.textBoxSecondName.Multiline = true;
            this.textBoxSecondName.Name = "textBoxSecondName";
            this.textBoxSecondName.Size = new System.Drawing.Size(175, 28);
            this.textBoxSecondName.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(620, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 78);
            this.label2.TabIndex = 23;
            this.label2.Text = "Имя человека, угадывающего слово:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // twoplayersFIRST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1025, 617);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxSecondName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxWord);
            this.Controls.Add(this.labelword);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.labelcategory);
            this.Controls.Add(this.buttonback1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "twoplayersFIRST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Виселица";
            this.Load += new System.EventHandler(this.twoplayersFIRST_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.Label labelword;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label labelcategory;
        private System.Windows.Forms.Button buttonback1;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSecondName;
        private System.Windows.Forms.Label label2;
    }
}