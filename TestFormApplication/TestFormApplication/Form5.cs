using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormApplication
{
    public partial class Form5 : Form
    {
        Panel panel1;
        Panel panel2;
        Button buttonUpdateActDir;
        Button buttonUpdateMov;
        TextBox textBoxName;
        TextBox textBoxProfileImage;
        TextBox textBoxDescription;
        TextBox textBoxTitle;
        TextBox textBoxImageUrl;
        TextBox textBoxGenre;
        TextBox textBoxRuntime;
        TextBox textBoxMovieDescription;
        

        public Form5()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected.Equals("Actor") || selected.Equals("Director"))
            {
                if (panel2 != null)
                {
                    panel2.Dispose();
                    panel2 = null;
                }
                CreateActorDirectorPanel();
            }
            else if(selected.Equals("Movie"))
            {
                if(panel1 != null)
                {
                    panel1.Dispose();
                    panel1 = null;
                }
                CreateMoviePanel();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editButton.Visible = true;
        }

        public void CreateActorDirectorPanel()
        {
            panel1 = new Panel();
            buttonUpdateActDir = new Button();
            textBoxName = new TextBox();
            textBoxProfileImage = new TextBox();
            textBoxDescription = new TextBox();

            // Initialize the Panel control.
            panel1.Location = new Point(29, 164);
            panel1.Size = new Size(257, 302);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Initialize the Label and TextBox controls.
            Size textBoxSize = new Size(178, 26);

            textBoxName.Location = new Point(43, 31);
            textBoxName.Text = "Name";
            textBoxName.Size = textBoxSize;
            textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxName.ReadOnly = true;
            textBoxProfileImage.Location = new Point(43, 75);
            textBoxProfileImage.Text = "Profile Image Url";
            textBoxProfileImage.Size = textBoxSize;
            textBoxProfileImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxProfileImage.ReadOnly = true;
            textBoxDescription.Location = new Point(43, 123);
            textBoxDescription.Text = "Biography";
            textBoxDescription.Size = new Size(178, 125);
            textBoxDescription.Multiline = true;
            textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxDescription.ReadOnly = true;
            buttonUpdateActDir.Location = new Point(50,260);
            buttonUpdateActDir.Text = "update node";
            buttonUpdateActDir.Size = new Size(88,23);
            buttonUpdateActDir.Visible = false;
                

            // Add the Panel control to the form.
            this.Controls.Add(panel1);
            // Add the TextBox and Button controls to the Panel.
            panel1.Controls.Add(textBoxName);
            panel1.Controls.Add(textBoxProfileImage);
            panel1.Controls.Add(textBoxDescription);
            panel1.Controls.Add(buttonUpdateActDir);
        }

        public void CreateMoviePanel()
        {
            panel2 = new Panel();
            buttonUpdateMov = new Button();
            textBoxTitle = new TextBox();
            textBoxImageUrl = new TextBox();
            textBoxGenre = new TextBox();
            textBoxRuntime = new TextBox();
            textBoxMovieDescription = new TextBox();

            // Initialize the Panel control.
            panel2.Location = new Point(29, 164);
            panel2.Size = new Size(257, 350);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Initialize the Label and TextBox controls.
            Size textBoxSize = new Size(178, 26);

            textBoxTitle.Location = new Point(43, 22);
            textBoxTitle.Text = "Title";
            textBoxTitle.Size = textBoxSize;
            textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxTitle.ReadOnly = true;
            textBoxImageUrl.Location = new Point(43, 55);
            textBoxImageUrl.Text = "Image Url";
            textBoxImageUrl.Size = textBoxSize;
            textBoxImageUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxImageUrl.ReadOnly = true;
            textBoxGenre.Location = new Point(43, 90);
            textBoxGenre.Text = "Genre";
            textBoxGenre.Size = textBoxSize;
            textBoxGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxGenre.ReadOnly = true;
            textBoxRuntime.Location = new Point(43, 125);
            textBoxRuntime.Text = "Runtime";
            textBoxRuntime.Size = textBoxSize;
            textBoxRuntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxRuntime.ReadOnly = true;
            textBoxMovieDescription.Location = new Point(43, 175);
            textBoxMovieDescription.Text = "Description";
            textBoxMovieDescription.Size = new Size(178, 125);
            textBoxMovieDescription.Multiline = true;
            textBoxMovieDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieDescription.ReadOnly = true;
            buttonUpdateMov.Location = new Point(50, 310);
            buttonUpdateMov.Text = "update node";
            buttonUpdateMov.Size = new Size(88, 23);
            buttonUpdateMov.Visible = false;

            // Add the Panel control to the form.
            this.Controls.Add(panel2);
            // Add the TextBox and Button controls to the Panel.
            panel2.Controls.Add(textBoxTitle);
            panel2.Controls.Add(textBoxImageUrl);
            panel2.Controls.Add(textBoxGenre);
            panel2.Controls.Add(textBoxRuntime);
            panel2.Controls.Add(textBoxMovieDescription);
            panel2.Controls.Add(buttonUpdateMov);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(panel1 != null)
            {
                textBoxName.ReadOnly = false;
                textBoxProfileImage.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
                buttonUpdateActDir.Visible = true;
            }
            else if(panel2 != null)
            {
                textBoxTitle.ReadOnly = false;
                textBoxImageUrl.ReadOnly = false;
                textBoxGenre.ReadOnly = false;
                textBoxRuntime.ReadOnly = false;
                textBoxMovieDescription.ReadOnly = false;
                buttonUpdateMov.Visible = true;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (string.Equals((sender as Button).Name, @"CloseButton"))
            {
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
