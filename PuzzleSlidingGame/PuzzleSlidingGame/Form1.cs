using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PuzzleSlidingGame
{
    public partial class Form1 : Form
    {
        // Lists to store PictureBoxes, Bitmaps, and positions
        private List<PictureBox> pictureboxlist = new List<PictureBox>();
        private List<Bitmap> images = new List<Bitmap>();
        private List<string> locations = new List<string>();
        private List<string> current_locations = new List<string>();

        // Strings to store the winning and current positions
        private string win_position;
        private string current_position;

        // Bitmap for the main image
        private Bitmap MainBitmap;

        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for opening an image file
        private void OpenFileEvent(object sender, EventArgs e)
        {
            // Clear existing elements if any
            ClearExistingElements();

            // Open file dialog to select an image
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image
                MainBitmap = new Bitmap(open.FileName);
                // Create PictureBoxes and add images
                CreatePictureBoxes();
                AddImages();
            }
        }

        // Create PictureBoxes and set up event handler
        private void CreatePictureBoxes()
        {
            for (int i = 0; i < 9; i++)
            {
                PictureBox temp_pic = new PictureBox
                {
                    Size = new Size(130, 130),
                    Tag = i.ToString()
                };
                temp_pic.Click += OnPicClick;
                pictureboxlist.Add(temp_pic);
                locations.Add(temp_pic.Tag.ToString());
            }
        }

        // Event handler for PictureBox click
        private void OnPicClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            PictureBox emptyBox = pictureboxlist.Find(x => x.Tag.ToString() == "0");

            // Swap positions of clicked PictureBox and the empty box
            SwapPictureBoxesPositions(pictureBox, emptyBox);

            // Update UI and check if the game is won
            UpdateUIAndCheckGame();
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

        // Update UI and check if the game is won
        private void UpdateUIAndCheckGame()
        {
            label2.Text = "";
            current_locations.Clear();
            CheckGame();
        }

        // Crop the main image into smaller pieces
        private void CropImage(Bitmap main_bitmap, int height, int width)
        {
            int x = 0;
            int y = 0;

            for (int blocks = 0; blocks < 9; blocks++)
            {
                Bitmap cropped_image = new Bitmap(height, width);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        cropped_image.SetPixel(i, j, main_bitmap.GetPixel((i + x), (j + y)));
                    }
                }
                images.Add(cropped_image);
                x += 130;
                if (x == 390)
                {
                    x = 0;
                    y += 130;
                }
            }
        }

        // Add cropped images to PictureBoxes
        private void AddImages()
        {
            Bitmap tempBitmap = new Bitmap(MainBitmap, new Size(390, 390));

            CropImage(tempBitmap, 130, 130);

            for (int i = 1; i < pictureboxlist.Count; i++)
            {
                pictureboxlist[i].BackgroundImage = (Image)images[i];
            }

            PlacePictureBoxesToForm();
        }

        // Place PictureBoxes on the form
        private void PlacePictureBoxesToForm()
        {
            var shuffleImages = pictureboxlist.OrderBy(a => Guid.NewGuid()).ToList();
            pictureboxlist = shuffleImages;
            int x = 200;
            int y = 25;

            for (int i = 0; i < pictureboxlist.Count; i++)
            {
                pictureboxlist[i].BackColor = Color.Gold;

                if (i == 3 || i == 6)
                {
                    y += 130;
                    x = 200;
                }

                pictureboxlist[i].BorderStyle = BorderStyle.FixedSingle;
                pictureboxlist[i].Location = new Point(x, y);

                this.Controls.Add(pictureboxlist[i]);
                x += 130;

                win_position += locations[i];
            }
        }

        // Check if the game is won
        private void CheckGame()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    current_locations.Add(x.Tag.ToString());
                }
            }

            current_position = string.Join("", current_locations);
            label1.Text = win_position;
            label2.Text = current_position;

            if (win_position == current_position)
            {
                label2.Text = "You Win!";
            }
        }

        // Clear existing elements on the form
        private void ClearExistingElements()
        {
            if (pictureboxlist != null)
            {
                foreach (PictureBox pics in pictureboxlist.ToList())
                {
                    this.Controls.Remove(pics);
                }

                pictureboxlist.Clear();
                images.Clear();
                locations.Clear();
                current_locations.Clear();
                win_position = string.Empty;
                current_position = string.Empty;
                label2.Text = string.Empty;
            }
        }
    }
}
