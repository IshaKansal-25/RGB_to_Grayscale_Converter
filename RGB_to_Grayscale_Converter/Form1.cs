using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_to_Grayscale_Converter
{
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            imageBox.ImageLocation = openFileDialog1.FileName;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            imageBox.Image.Save(saveFileDialog1.FileName);
        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(imageBox.Image);
            Bitmap newImg = new Bitmap(imageBox.Image.Width, imageBox.Image.Height);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color colour = img.GetPixel(i, j);
                    int gray = (int)((colour.R * 0.299) + (colour.G * 0.587) + (colour.B * 0.114));
                    Color newColour = Color.FromArgb(colour.A, gray, gray, gray);
                    newImg.SetPixel(i, j, newColour);
                }
            }
            imageBox.Image = newImg;
        }
    }
}
