namespace PuzzleSlidingGame
{
    partial class StartForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.comboBoxPlayers = new System.Windows.Forms.ComboBox();
            this.labelPlayer01 = new System.Windows.Forms.Label();
            this.textBoxPlayer01 = new System.Windows.Forms.TextBox();
            this.labelPlayer02 = new System.Windows.Forms.Label();
            this.textBoxPlayer02 = new System.Windows.Forms.TextBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnHowToPlay = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(72, 87);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1527, 147);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "PUZZLE SLIDING GAME";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayers.ForeColor = System.Drawing.Color.White;
            this.labelPlayers.Location = new System.Drawing.Point(363, 329);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(420, 51);
            this.labelPlayers.TabIndex = 1;
            this.labelPlayers.Text = "Number of Players: ";
            // 
            // comboBoxPlayers
            // 
            this.comboBoxPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayers.FormattingEnabled = true;
            this.comboBoxPlayers.Items.AddRange(new object[] {
            "Single",
            "Two Players"});
            this.comboBoxPlayers.Location = new System.Drawing.Point(857, 346);
            this.comboBoxPlayers.Name = "comboBoxPlayers";
            this.comboBoxPlayers.Size = new System.Drawing.Size(371, 33);
            this.comboBoxPlayers.TabIndex = 2;
            this.comboBoxPlayers.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayers_SelectedIndexChanged);
            // 
            // labelPlayer01
            // 
            this.labelPlayer01.AutoSize = true;
            this.labelPlayer01.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer01.ForeColor = System.Drawing.Color.White;
            this.labelPlayer01.Location = new System.Drawing.Point(439, 414);
            this.labelPlayer01.Name = "labelPlayer01";
            this.labelPlayer01.Size = new System.Drawing.Size(344, 51);
            this.labelPlayer01.TabIndex = 3;
            this.labelPlayer01.Text = "Player 1 Name: ";
            // 
            // textBoxPlayer01
            // 
            this.textBoxPlayer01.Location = new System.Drawing.Point(857, 432);
            this.textBoxPlayer01.Name = "textBoxPlayer01";
            this.textBoxPlayer01.Size = new System.Drawing.Size(371, 31);
            this.textBoxPlayer01.TabIndex = 4;
            // 
            // labelPlayer02
            // 
            this.labelPlayer02.AutoSize = true;
            this.labelPlayer02.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer02.ForeColor = System.Drawing.Color.White;
            this.labelPlayer02.Location = new System.Drawing.Point(439, 502);
            this.labelPlayer02.Name = "labelPlayer02";
            this.labelPlayer02.Size = new System.Drawing.Size(344, 51);
            this.labelPlayer02.TabIndex = 5;
            this.labelPlayer02.Text = "Player 2 Name: ";
            this.labelPlayer02.Visible = false;
            // 
            // textBoxPlayer02
            // 
            this.textBoxPlayer02.Location = new System.Drawing.Point(857, 520);
            this.textBoxPlayer02.Name = "textBoxPlayer02";
            this.textBoxPlayer02.Size = new System.Drawing.Size(371, 31);
            this.textBoxPlayer02.TabIndex = 6;
            this.textBoxPlayer02.Visible = false;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(661, 610);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(290, 78);
            this.btnStartGame.TabIndex = 7;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHowToPlay.Location = new System.Drawing.Point(1452, 759);
            this.btnHowToPlay.Name = "btnHowToPlay";
            this.btnHowToPlay.Size = new System.Drawing.Size(185, 58);
            this.btnHowToPlay.TabIndex = 8;
            this.btnHowToPlay.Text = "How to Play";
            this.btnHowToPlay.UseVisualStyleBackColor = true;
            this.btnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Location = new System.Drawing.Point(1452, 835);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(185, 52);
            this.btnAbout.TabIndex = 9;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1682, 950);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnHowToPlay);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.textBoxPlayer02);
            this.Controls.Add(this.labelPlayer02);
            this.Controls.Add(this.textBoxPlayer01);
            this.Controls.Add(this.labelPlayer01);
            this.Controls.Add(this.comboBoxPlayers);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.labelTitle);
            this.Name = "StartForm";
            this.Text = "Puzzle Sliding Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.ComboBox comboBoxPlayers;
        private System.Windows.Forms.Label labelPlayer01;
        private System.Windows.Forms.TextBox textBoxPlayer01;
        private System.Windows.Forms.Label labelPlayer02;
        private System.Windows.Forms.TextBox textBoxPlayer02;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnHowToPlay;
        private System.Windows.Forms.Button btnAbout;
    }
}