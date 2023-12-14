using System;
using System.Windows.Forms;

namespace PuzzleSlidingGame
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void comboBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check the selected item in comboBoxPlayers and show/hide controls accordingly
            if (comboBoxPlayers.SelectedItem.ToString() == "Single")
            {
                // If there's only one player, hide controls related to Player 2
                labelPlayer02.Visible = false;
                textBoxPlayer02.Visible = false;
            }
            else if (comboBoxPlayers.SelectedItem.ToString() == "Two Players")
            {
                // If there are two players, show controls related to Player 2
                labelPlayer02.Visible = true;
                textBoxPlayer02.Visible = true;
            }
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate player names
                if (string.IsNullOrWhiteSpace(textBoxPlayer01.Text) || string.IsNullOrWhiteSpace(textBoxPlayer02.Text))
                {
                    MessageBox.Show("Please enter names for all players.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (textBoxPlayer01.Text == textBoxPlayer02.Text)
                {
                    MessageBox.Show("Player names must be different.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                const int maxNameLength = 20; //This is a reasonable maximum length for player names

                if (textBoxPlayer01.Text.Length > maxNameLength || textBoxPlayer02.Text.Length > maxNameLength)
                {
                    MessageBox.Show($"Player names cannot exceed {maxNameLength} characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create an instance of the mainForm
                MainForm mainForm = new MainForm();

                // Pass player information to mainForm
                mainForm.Player1Name = textBoxPlayer01.Text;

                // Check the selected item in comboBoxPlayers and set the NumberOfPlayers accordingly
                if (comboBoxPlayers.SelectedItem.ToString() == "Single")
                {
                    mainForm.NumberOfPlayers = 1;
                }
                else if (comboBoxPlayers.SelectedItem.ToString() == "Two Players")
                {
                    mainForm.NumberOfPlayers = 2;
                    mainForm.Player2Name = textBoxPlayer02.Text;
                }

                // Subscribe to the FormClosed event to close startForm when mainForm is closed
                mainForm.FormClosed += (s, args) => this.Close();

                // Show the mainForm
                mainForm.Show();

                // Update UI and display Player names
                mainForm.UpdateUIAndDisplayPlayerName();

                // Start the timer
                mainForm.StartTimer();

                // Hide the startForm
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            // Create an instance of the aboutForm
            aboutForm aboutFormInstance = new aboutForm();

            // Show the aboutFormInstance as a dialog
            aboutFormInstance.ShowDialog();
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            // Create an instance of the howToPlayForm
            howToPlayForm howToPlayFormInstance = new howToPlayForm();

            // Show the howToPlayFormInstance as a dialog
            howToPlayFormInstance.ShowDialog();
        }
    }
}
