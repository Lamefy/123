using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _123
{
    public partial class Form1 : Form
    {
        Model1 lox = new Model1();
        static int counter = 3;
        static string text = "Длинное название крема, 300мг";
        static Color panelColor = Color.White;
        static Random random = new Random();
        Color[] colors = new Color[] { Color.FromArgb(random.Next(255)), Color.FromArgb(random.Next(255)), Color.FromArgb(random.Next(255)) };

        PictureBox mainImage = new PictureBox
        {
            Size = new Size(150, 200),
            BackColor = Color.Aqua
        };
        Label name = new Label
        {
            Text = text,
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = panelColor
        };
        RadioButton[] rd = new RadioButton[counter];
        public Form1()
        {
            InitializeComponent();
            mainImage.Location = new Point(pictureBox1.Location.X + ((pictureBox1.Width - 150) / 2), pictureBox1.Location.Y + 10);
            name.Size = new Size(150, pictureBox1.Height / 5);
            name.Location = new Point(pictureBox1.Location.X + ((pictureBox1.Width - 150) / 2), (pictureBox1.Location.Y + pictureBox1.Height) - pictureBox1.Height / 5 - 10);
            for (int i = 0; i < counter; i++)
            {
                rd[i] = new RadioButton
                {
                    Size = new Size(15, 15),
                    BackColor = pictureBox1.BackColor,
                    Location = new Point((mainImage.Location.X + ((mainImage.Width - (30 * counter / 2)) / 2) + (30 * i) / 2), mainImage.Location.Y + mainImage.Height)
                };
                if (i == 0)
                    rd[i].Checked = true;
                this.Controls.Add(rd[i]);
                rd[i].BringToFront();
            }
            this.Controls.Add(mainImage);
            mainImage.MouseEnter += MainImage_MouseEnter;
            mainImage.MouseMove += MainImage_MouseMove;
            this.Controls.Add(name);
            mainImage.BringToFront();
            name.BringToFront();
        }

        private void MainImage_MouseMove(object sender, MouseEventArgs e)
        {
            double areaChange = mainImage.Width / counter;
            for (int i = 0; i < counter; i++)
            {
                if (MousePosition.X >= this.Left + mainImage.Location.X + areaChange * i - 1
                    && MousePosition.X <= this.Location.X + mainImage.Location.X + areaChange * (i + 1) + 1)
                {
                    mainImage.BackColor = colors[i];
                    rd[i].Checked = true;
                }
            }
        }
        private void MainImage_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }

        private void productBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void productDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productBindingSource.DataSource = lox.Product.ToList();
        }
    }
}
