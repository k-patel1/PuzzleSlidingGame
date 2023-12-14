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
            this.labelAboutTitle.Location = new System.Drawing.Point(265, 25);
            this.labelAboutTitle.Name = "labelAboutTitle";
            this.labelAboutTitle.Size = new System.Drawing.Size(208, 51);
            this.labelAboutTitle.TabIndex = 0;
            this.labelAboutTitle.Text = "Group 12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(267, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 84);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kirtan Patel\r\nBhumin ";
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAboutTitle);
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