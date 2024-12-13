namespace hangman.Forms
{
    partial class leaderboard
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
            this.leaderboardTop = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.leaderboardTop)).BeginInit();
            this.SuspendLayout();
            // 
            // leaderboardTop
            // 
            this.leaderboardTop.AllowUserToAddRows = false;
            this.leaderboardTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leaderboardTop.Location = new System.Drawing.Point(26, 54);
            this.leaderboardTop.Name = "leaderboardTop";
            this.leaderboardTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.leaderboardTop.Size = new System.Drawing.Size(538, 333);
            this.leaderboardTop.TabIndex = 0;
            // 
            // leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 415);
            this.Controls.Add(this.leaderboardTop);
            this.Name = "leaderboard";
            this.Text = "leaderboard";
            this.Load += new System.EventHandler(this.leaderboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leaderboardTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView leaderboardTop;
    }
}