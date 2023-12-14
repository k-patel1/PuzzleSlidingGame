namespace PuzzleSlidingGame
{
    partial class aboutForm
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
            this.labelAboutTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAboutTitle
            // 
            this.labelAboutTitle.AutoSize = true;
            this.labelAboutTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboutTitle.ForeColor = System.Drawing.Color.White;
            this.labelAboutTitle.Location = new System.Drawing.Point(132, 13);
            this.labelAboutTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAboutTitle.Name = "labelAboutTitle";
            this.labelAboutTitle.Size = new System.Drawing.Size(110, 26);
            this.labelAboutTitle.TabIndex = 0;
            this.labelAboutTitle.Text = "Group 12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(94, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 120);
            this.label1.TabIndex = 1;
            this.label1.Text = "     Kirtan Patel\r\n  Bhumin Odedra\r\n     Enes Gunerli\r\n    Apoorv Rawat\r\nMuhammad" +
    " Haider";
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(400, 234);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAboutTitle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "aboutForm";
            this.Text = "About";
            this.Load += new System.EventHandler(this.aboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAboutTitle;
        private System.Windows.Forms.Label label1;
    }
}