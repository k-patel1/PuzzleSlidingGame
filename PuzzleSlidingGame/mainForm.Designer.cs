namespace PuzzleSlidingGame
{
    partial class MainForm
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
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.labelPlayer01Name = new System.Windows.Forms.Label();
            this.labelPlayer02Name = new System.Windows.Forms.Label();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnSampleImages = new System.Windows.Forms.Button();
            this.labelPlayer01Timer = new System.Windows.Forms.Label();
            this.labelPlayer02Timer = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1Name.ForeColor = System.Drawing.Color.White;
            this.labelPlayer1Name.Location = new System.Drawing.Point(12, 352);
            this.labelPlayer1Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(0, 24);
            this.labelPlayer1Name.TabIndex = 4;
            // 
            // labelPlayer01Name
            // 
            this.labelPlayer01Name.AutoSize = true;
            this.labelPlayer01Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer01Name.ForeColor = System.Drawing.Color.White;
            this.labelPlayer01Name.Location = new System.Drawing.Point(12, 423);
            this.labelPlayer01Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer01Name.Name = "labelPlayer01Name";
            this.labelPlayer01Name.Size = new System.Drawing.Size(76, 24);
            this.labelPlayer01Name.TabIndex = 6;
            this.labelPlayer01Name.Text = "Name1";
            // 
            // labelPlayer02Name
            // 
            this.labelPlayer02Name.AutoSize = true;
            this.labelPlayer02Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer02Name.ForeColor = System.Drawing.Color.White;
            this.labelPlayer02Name.Location = new System.Drawing.Point(485, 423);
            this.labelPlayer02Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer02Name.Name = "labelPlayer02Name";
            this.labelPlayer02Name.Size = new System.Drawing.Size(76, 24);
            this.labelPlayer02Name.TabIndex = 7;
            this.labelPlayer02Name.Text = "Name2";
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.Location = new System.Drawing.Point(6, 7);
            this.btnUploadImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(116, 60);
            this.btnUploadImage.TabIndex = 8;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // btnSampleImages
            // 
            this.btnSampleImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSampleImages.Location = new System.Drawing.Point(6, 75);
            this.btnSampleImages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSampleImages.Name = "btnSampleImages";
            this.btnSampleImages.Size = new System.Drawing.Size(116, 102);
            this.btnSampleImages.TabIndex = 9;
            this.btnSampleImages.Text = "Random Sample Images";
            this.btnSampleImages.UseVisualStyleBackColor = true;
            this.btnSampleImages.Click += new System.EventHandler(this.btnSampleImages_Click);
            // 
            // labelPlayer01Timer
            // 
            this.labelPlayer01Timer.AutoSize = true;
            this.labelPlayer01Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer01Timer.ForeColor = System.Drawing.Color.White;
            this.labelPlayer01Timer.Location = new System.Drawing.Point(12, 455);
            this.labelPlayer01Timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer01Timer.Name = "labelPlayer01Timer";
            this.labelPlayer01Timer.Size = new System.Drawing.Size(0, 20);
            this.labelPlayer01Timer.TabIndex = 10;
            // 
            // labelPlayer02Timer
            // 
            this.labelPlayer02Timer.AutoSize = true;
            this.labelPlayer02Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer02Timer.ForeColor = System.Drawing.Color.White;
            this.labelPlayer02Timer.Location = new System.Drawing.Point(485, 455);
            this.labelPlayer02Timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer02Timer.Name = "labelPlayer02Timer";
            this.labelPlayer02Timer.Size = new System.Drawing.Size(0, 20);
            this.labelPlayer02Timer.TabIndex = 11;
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(6, 187);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(116, 43);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(846, 492);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.labelPlayer02Timer);
            this.Controls.Add(this.labelPlayer01Timer);
            this.Controls.Add(this.btnSampleImages);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.labelPlayer02Name);
            this.Controls.Add(this.labelPlayer01Name);
            this.Controls.Add(this.labelPlayer1Name);
            this.Name = "MainForm";
            this.Text = "Puzzle Sliding Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer01Name;
        private System.Windows.Forms.Label labelPlayer02Name;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnSampleImages;
        private System.Windows.Forms.Label labelPlayer01Timer;
        private System.Windows.Forms.Label labelPlayer02Timer;
        private System.Windows.Forms.Button btnPause_Click;
        private System.Windows.Forms.Button btnPause;
    }
}

