// MainForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace PuzzleSlidingGame
{
    public partial class MainForm : Form
    {
        // Constants for better readability
        private const int PictureBoxSize = 130;
        private const int PictureBoxCount = 9;

        // Lists to store PictureBoxes, Bitmaps, and positions
        private List<PictureBox> pictureBoxList = new List<PictureBox>();
        private List<Bitmap> images = new List<Bitmap>();
        private List<string> locations = new List<string>();
        private List<string> currentLocations = new List<string>();

        // Strings to store the winning and current positions
        private string winPosition;
        private string currentPosition;

        // Bitmap for the main image
        private Bitmap mainBitmap;

        // Player information
        private Player currentPlayer;
        private List<Player> players = new List<Player>();

        // Timer start time
        private DateTime startTime;

        // Properties to store Player names and number of players
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int NumberOfPlayers { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }


        // Create PictureBoxes and set up event handler
        private void CreatePictureBoxes()
        {
            for (int i = 0; i < PictureBoxCount; i++)
            {
                PictureBox tempPic = new PictureBox
                {
                    Size = new Size(PictureBoxSize, PictureBoxSize),
                    Tag = i.ToString()
                };
                tempPic.Click += OnPicClick;
                pictureBoxList.Add(tempPic);
                locations.Add(tempPic.Tag.ToString());
            }
        }

        // Event handler for PictureBox click
        private void OnPicClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            PictureBox emptyBox = pictureBoxList.Find(x => x.Tag.ToString() == "0");

            // Swap positions of clicked PictureBox and the empty box
            SwapPictureBoxesPositions(pictureBox, emptyBox);

            // Update UI and check if the game is won
            UpdateUIAndCheckGame();

            // Start the timer for the current player
            if (currentPlayer != null)
            {
                StartTimer();

                // Update the timer label after starting the timer
                UpdatePlayerTimerLabel(currentPlayer);
            }
        }


        // Swap positions of two PictureBoxes
        private void SwapPictureBoxesPositions(PictureBox pictureBox, PictureBox emptyBox)
        {
            Point pic1 = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            Point pic2 = new Point(emptyBox.Location.X, emptyBox.Location.Y);

            var index1 = this.Controls.IndexOf(pictureBox);
            var index2 = this.Controls.IndexOf(emptyBox);

            if (ArePictureBoxesAdjacent(pictureBox, emptyBox))
            {
                pictureBox.Location = pic2;
                emptyBox.Location = pic1;

                this.Controls.SetChildIndex(pictureBox, index2);
                this.Controls.SetChildIndex(emptyBox, index1);
            }
        }

        // Check if two PictureBoxes are adjacent
        private bool ArePictureBoxesAdjacent(PictureBox pictureBox, PictureBox emptyBox)
        {
            return pictureBox.Right == emptyBox.Left && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Left == emptyBox.Right && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Top == emptyBox.Bottom && pictureBox.Location.X == emptyBox.Location.X
                || pictureBox.Bottom == emptyBox.Top && pictureBox.Location.X == emptyBox.Location.X;
        }

        // Update UI and display Player name
        public void UpdateUIAndDisplayPlayerName()
        {
            // Use the Player1Name property where you want to display the name in your UI
            labelPlayer01Name.Text = $"Player 1: {Player1Name}";

            // Check the number of players and show/hide controls accordingly
            if (NumberOfPlayers == 1)
            {
                // If there's only one player, hide controls related to Player 2
                labelPlayer02Name.Visible = false;
            }
            else if (NumberOfPlayers == 2)
            {
                // If there are two players, show controls related to Player 2
                labelPlayer02Name.Visible = true;
                labelPlayer02Name.Text = $"Player 2: {Player2Name}";
            }
        }

        // Update UI and check if the game is won
        private void UpdateUIAndCheckGame()
        {
            currentLocations.Clear();
            if (CheckForWin())
            {
                // Stop the timer
                TimeSpan elapsedTime = DateTime.Now - startTime;

                // Display winner message
                MessageBox.Show($"{currentPlayer.Name} won! Time taken: {elapsedTime}", "Winner!");

                // Save player's time to a text file
                SavePlayerTime(currentPlayer);

                // Reset player information
                currentPlayer = null;
                startTime = DateTime.MinValue;

                // Clear existing elements for a new game
                ClearExistingElements();
            }

            // Update timer labels after each move
            if (currentPlayer != null)
            {
                UpdatePlayerTimerLabel(currentPlayer);
            }
        }

        // Crop the main image into smaller pieces
        private void CropImage(Bitmap mainBitmap, int height, int width)
        {
            int x = 0;
            int y = 0;

            for (int blocks = 0; blocks < PictureBoxCount; blocks++)
            {
                Bitmap croppedImage = new Bitmap(height, width);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        croppedImage.SetPixel(i, j, mainBitmap.GetPixel((i + x), (j + y)));
                    }
                }
                images.Add(croppedImage);
                x += PictureBoxSize;
                if (x == PictureBoxSize * 3)
                {
                    x = 0;
                    y += PictureBoxSize;
                }
            }
        }

        // Add cropped images to PictureBoxes
        private void AddImages()
        {
            Bitmap tempBitmap = new Bitmap(mainBitmap, new Size(PictureBoxSize * 3, PictureBoxSize * 3));

            CropImage(tempBitmap, PictureBoxSize, PictureBoxSize);

            for (int i = 1; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackgroundImage = (Image)images[i];
            }

            PlacePictureBoxesToForm();
        }

        // Place PictureBoxes on the form
        private void PlacePictureBoxesToForm()
        {
            var shuffledImages = pictureBoxList.OrderBy(a => Guid.NewGuid()).ToList();
            pictureBoxList = shuffledImages;
            int x = 200;
            int y = 25;

            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackColor = Color.Gold;

                if (i == 3 || i == 6)
                {
                    y += PictureBoxSize;
                    x = 200;
                }

                pictureBoxList[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxList[i].Location = new Point(x, y);

                this.Controls.Add(pictureBoxList[i]);
                x += PictureBoxSize;

                winPosition += locations[i];
            }
        }

        // Check if the game is won
        private bool CheckForWin()
        {
            currentLocations = this.Controls.OfType<PictureBox>().Select(x => x.Tag.ToString()).ToList();
            currentPosition = string.Join("", currentLocations);

            if (winPosition == currentPosition)
            {
                // If there is no current player, create a new one
                if (currentPlayer == null)
                {
                    currentPlayer = new Player
                    {
                        Name = (NumberOfPlayers == 1) ? Player1Name : Player2Name,
                        TimeTaken = DateTime.Now - startTime
                    };
                }

                return true;
            }

            return false;
        }

        // Save player's time to a text file
        private void SavePlayerTime(Player player)
        {
            string fileName = "PlayerTimes.txt";

            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{player.Name}: {player.TimeTaken}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving player time: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clear existing elements on the form
        private void ClearExistingElements()
        {
            if (pictureBoxList != null)
            {
                foreach (PictureBox pictureBox in pictureBoxList.ToList())
                {
                    this.Controls.Remove(pictureBox);
                }

                pictureBoxList.Clear();
                images.Clear(); // Clear the images list
                locations.Clear();
            }
        }

        // Start the timer
        public void StartTimer()
        {
            startTime = DateTime.Now;

            // Update TimeTaken for the current player
            if (currentPlayer != null)
            {
                currentPlayer.TimeTaken = DateTime.Now - startTime;
            }

            UpdatePlayerTimerLabel(currentPlayer);
        }

        private void UpdatePlayerTimerLabel(Player player)
        {
            // Calculate elapsed time
            TimeSpan elapsedTime = DateTime.Now - startTime;

            // Update the corresponding player's timer label
            if (player == null)
            {
                return;
            }

            if (player == players[0])
            {
                labelPlayer01Timer.Text = $"{player.Name}: {elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
            }
            else if (player == players[1])
            {
                labelPlayer02Timer.Text = $"{player.Name}: {elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // Event handler for uploading an image
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear existing elements if any
                ClearExistingElements();

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Load the selected image
                        mainBitmap = new Bitmap(openFileDialog.FileName);

                        // Create PictureBoxes and add images
                        CreatePictureBoxes();
                        AddImages();
                    }
                }

                // Reset player information when a new image is selected
                currentPlayer = null;
                startTime = DateTime.MinValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for using sample images
        private void btnSampleImages_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear existing elements if any
                ClearExistingElements();

                // Specify the path to the folder containing sample images
                string sampleImagesFolder = Path.Combine(Application.StartupPath, "SampleImages");

                // Get a list of image files from the folder
                string[] imageFiles = Directory.GetFiles(sampleImagesFolder, "*.jpg");

                if (imageFiles.Length > 0)
                {
                    // Load a random sample image
                    Random random = new Random();
                    string randomImageFile = imageFiles[random.Next(imageFiles.Length)];
                    mainBitmap = new Bitmap(randomImageFile);

                    // Create PictureBoxes and add images
                    CreatePictureBoxes();
                    AddImages();
                }
                else
                {
                    MessageBox.Show("No sample images found in the specified folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Reset player information when a new image is selected
                currentPlayer = null;
                startTime = DateTime.MinValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelPlayer01Timer_Click(object sender, EventArgs e)
        {

        }
    }
}
