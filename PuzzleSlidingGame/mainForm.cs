using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PuzzleSlidingGame
{
    public partial class MainForm : Form
    {
        private const int PictureBoxSize = 130;
        private const int PictureBoxCount = 9;

        private List<PictureBox> pictureBoxList = new List<PictureBox>();
        private List<Bitmap> images = new List<Bitmap>();

        private Player currentPlayer;
        private DateTime startTime;

        private Bitmap mainBitmap;

        private Timer timer; 

        private Button btnPauseTime;

        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int NumberOfPlayers { get; set; }

        public MainForm()
        {
            InitializeComponent();

            // Initialize the timer
            timer = new Timer();
            timer.Interval = 1000; // Update every 1 second
            timer.Tick += Timer_Tick;

            // Initialize Pause Button
            btnPauseTime = new Button();
            btnPauseTime.Text = "Pause";
            btnPauseTime.Click += btnPause_Click_1;
        }

        #region Event Handlers

        private void OnPicClick(object sender, EventArgs e)
        {
            // Handle picture box click event
            var pictureBox = (PictureBox)sender;
            var emptyBox = pictureBoxList.Find(x => x.Tag.ToString() == "0");

            // Swap positions when a valid move is made
            SwapPictureBoxesPositions(pictureBox, emptyBox);

            // Check for win and update UI
            UpdateUIAndCheckGame();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Handle image upload button click event
                ClearExistingElements();
                StopAndResetTimer();

                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Load selected image and set up the game
                        mainBitmap = new Bitmap(openFileDialog.FileName);
                        CreatePictureBoxes();
                        AddImages();

                        currentPlayer = null;
                        startTime = DateTime.MinValue;

                        CreateNewPlayer();
                        StartTimer();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError($"Error: {ex.Message}");
            }
        }

        private void btnSampleImages_Click(object sender, EventArgs e)
        {
            try
            {
                // Handle sample images button click event
                ClearExistingElements();
                StopAndResetTimer();

                string sampleImagesFolder = Path.Combine(Application.StartupPath, "SampleImages");
                string[] imageFiles = Directory.GetFiles(sampleImagesFolder, "*.jpg");

                if (imageFiles.Length > 0)
                {
                    // Load a random sample image and set up the game
                    Random random = new Random();
                    string randomImageFile = imageFiles[random.Next(imageFiles.Length)];
                    mainBitmap = new Bitmap(randomImageFile);

                    CreatePictureBoxes();
                    AddImages();

                    currentPlayer = null;
                    startTime = DateTime.MinValue;

                    CreateNewPlayer();
                    StartTimer();
                }
                else
                {
                    HandleError("No sample images found in the specified folder.");
                }
            }
            catch (Exception ex)
            {
                HandleError($"Error: {ex.Message}");
            }
        }

        private void btnPause_Click_1(object sender, EventArgs e)
        {
            // Toggle the timer on/off when the Pause button is clicked
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
                startTime = DateTime.Now; // Resume the timer
            }
        }

        #endregion

        #region Initialization

        private void CreatePictureBoxes()
        {
            // Create picture boxes for the puzzle pieces
            for (int i = 0; i < PictureBoxCount; i++)
            {
                var tempPictureBox = new PictureBox
                {
                    Size = new Size(PictureBoxSize, PictureBoxSize),
                    Tag = i.ToString()
                };
                tempPictureBox.Click += OnPicClick;
                pictureBoxList.Add(tempPictureBox);
            }
        }

        #endregion

        #region Game Logic

        private void SwapPictureBoxesPositions(PictureBox pictureBox, PictureBox emptyBox)
        {
            // Swap positions of two picture boxes
            Point pic1 = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            Point pic2 = new Point(emptyBox.Location.X, emptyBox.Location.Y);

            var index1 = Controls.IndexOf(pictureBox);
            var index2 = Controls.IndexOf(emptyBox);

            if (ArePictureBoxesAdjacent(pictureBox, emptyBox))
            {
                pictureBox.Location = pic2;
                emptyBox.Location = pic1;

                Controls.SetChildIndex(pictureBox, index2);
                Controls.SetChildIndex(emptyBox, index1);
            }
        }

        private bool ArePictureBoxesAdjacent(PictureBox pictureBox, PictureBox emptyBox)
        {
            // Check if two picture boxes are adjacent for a valid move
            return pictureBox.Right == emptyBox.Left && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Left == emptyBox.Right && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Top == emptyBox.Bottom && pictureBox.Location.X == emptyBox.Location.X
                || pictureBox.Bottom == emptyBox.Top && pictureBox.Location.X == emptyBox.Location.X;
        }

        private void UpdateUIAndCheckGame()
        {
            // Check for win and update UI
            if (CheckForWin())
            {
                TimeSpan elapsedTime = DateTime.Now - startTime;
                MessageBox.Show($"{currentPlayer.Name} won! Time taken: {elapsedTime}", "Winner!");
                SavePlayerTime(currentPlayer);

                currentPlayer = null;
                startTime = DateTime.MinValue;

                ClearExistingElements();
            }

            // Update player timer labels
            if (currentPlayer != null)
            {
                UpdatePlayerTimerLabel(currentPlayer);
            }
        }

        private bool CheckForWin()
        {
            // Check if the puzzle is in the winning position
            var currentLocations = Controls.OfType<PictureBox>().Select(x => x.Tag.ToString()).ToList();
            var currentPosition = string.Join("", currentLocations);

            return currentPosition == GetWinPosition();
        }

        private void SavePlayerTime(Player player)
        {
            // Save player's time to a file
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
                HandleError($"Error saving player time: {ex.Message}");
            }
        }

        private void CreateNewPlayer()
        {
            // Create a new player and start the timer
            currentPlayer = new Player
            {
                Name = (NumberOfPlayers == 1) ? Player1Name : Player2Name,
                TimeTaken = TimeSpan.Zero
            };

            StartTimer();
        }

        // Start the timer
        public void StartTimer()
        {
            if (timer == null)
            {
                timer = new Timer(); // Initialize the timer if it's null
                timer.Interval = 1000; // Update every 1 second
                timer.Tick += Timer_Tick;
                timer.Start();
                startTime = DateTime.Now;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the player's time on each timer tick
            if (currentPlayer != null && startTime != DateTime.MinValue)
            {
                currentPlayer.TimeTaken = DateTime.Now - startTime;
                UpdatePlayerTimerLabel(currentPlayer);
            }
        }

        private void UpdatePlayerTimerLabel(Player player)
        {
            // Update the player's timer label
            TimeSpan elapsedTime = DateTime.Now - startTime;

            if (player == currentPlayer)
            {
                labelPlayer01Timer.Text = $"{elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
            }
            else if (NumberOfPlayers == 2 && player != currentPlayer)
            {
                labelPlayer02Timer.Text = $"{elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
            }
        }

        private string GetWinPosition()
        {
            // Define the winning position for the puzzle
            return "012345678";
        }

        #endregion

        #region Image Operations

        private void CropImage(Bitmap mainBitmap, int height, int width)
        {
            int x = 0;
            int y = 0;

            for (int blocks = 0; blocks < PictureBoxCount; blocks++)
            {
                // Crop the main image into smaller pieces
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

        private void AddImages()
        {
            // Add cropped images to picture boxes
            Bitmap tempBitmap = new Bitmap(mainBitmap, new Size(PictureBoxSize * 3, PictureBoxSize * 3));

            CropImage(tempBitmap, PictureBoxSize, PictureBoxSize);

            for (int i = 1; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackgroundImage = (Image)images[i];
            }

            PlacePictureBoxesToForm();
        }

        private void PlacePictureBoxesToForm()
        {
            // Place shuffled picture boxes on the form
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

                Controls.Add(pictureBoxList[i]);
                x += PictureBoxSize;
            }
        }

        #endregion

        #region UI Operations

        public void UpdateUIAndDisplayPlayerName()
        {
            // Update player names and timer labels on the UI
            labelPlayer01Name.Text = $"Player 1: {Player1Name}";
            labelPlayer01Timer.Text = "00:00:00";

            if (NumberOfPlayers == 1)
            {
                labelPlayer02Name.Visible = false;
            }
            else if (NumberOfPlayers == 2)
            {
                labelPlayer02Name.Visible = true;
                labelPlayer02Name.Text = $"Player 2: {Player2Name}";
                labelPlayer02Timer.Text = "00:00:00";
            }
        }

        #endregion

        #region File Operations

        private void ClearExistingElements()
        {
            // Clear existing picture boxes and images
            foreach (var pictureBox in pictureBoxList)
            {
                Controls.Remove(pictureBox);
            }

            pictureBoxList.Clear();
            images.Clear();
        }

        private void StopAndResetTimer()
        {
            // Stop and reset the timer
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
        }

        #endregion

        #region Error Handling

        private void HandleError(string errorMessage)
        {
            // Display an error message in a message box
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
