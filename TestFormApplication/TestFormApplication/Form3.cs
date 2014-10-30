using Neo4jClient;
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
    public partial class Form3 : Form
    {
        TextBox textBox1;
        TextBox textBoxName;
        TextBox textBoxProfileImg;
        TextBox textBoxDescription;
        TextBox textBoxMovieTitle = new TextBox();
        TextBox textBoxMovieImageUrl = new TextBox();
        TextBox textBoxMovieGenre = new TextBox();
        TextBox textBoxMovieRunTime = new TextBox();
        TextBox textBoxMovieDescription = new TextBox();
        Panel panel1;
        Actor actor;
        Director director;
        Movie movie;
        DataBaseHandler dbHandler;
        public Form3()
        {
            InitializeComponent();
            dbHandler = new DataBaseHandler();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected.Equals("Actor") || selected.Equals("Director"))
            {
  
                CreateMyPanel();
            }
            else if (selected.Equals("Movie"))
            {
                if (panel1 != null)
                {
                    panel1.Dispose();
                }
                CreateMyPanelMovie();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disposeForm();
        }

        //example msdn
        public void CreateMyPanel()
        {
            panel1 = new Panel();
            textBoxName = new TextBox();
            textBoxProfileImg = new TextBox();
            textBoxDescription = new TextBox();
            
            Button button1 = new Button();

            // make the proper class for the setup.
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if(selected.Equals("Actor"))
            {
                actor = new Actor();
            }
            else if(selected.Equals("Director")) 
            {
                director = new Director();
            }



            // Initialize the Panel control.
            panel1.Location = new Point(71, 87);
            panel1.Size = new Size(350, 338);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Initialize the Label and TextBox controls.
            Size textBoxSize = new Size(215, 26);

            textBoxName.Location = new Point(65, 40);
            textBoxName.Text = "Name";
            textBoxName.Size = textBoxSize;
            textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxProfileImg.Location = new Point(65, 93);
            textBoxProfileImg.Text = "Profile Image Url";
            textBoxProfileImg.Size = textBoxSize;
            textBoxProfileImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxDescription.Location = new Point(65, 151);
            textBoxDescription.Text = "Biography";
            textBoxDescription.Size = new Size(215, 107);
            textBoxDescription.Multiline = true;
            textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  
            button1.Location = new Point(124, 286);
            button1.Text = "Create Node";
            button1.Size = new Size(102, 23);
            button1.Click += new EventHandler(Onb2Click);
            // Add the Panel control to the form.
            this.Controls.Add(panel1);
            // Add the TextBox and Button controls to the Panel.
            panel1.Controls.Add(textBoxName);
            panel1.Controls.Add(textBoxProfileImg);
            panel1.Controls.Add(textBoxDescription);
            panel1.Controls.Add(button1);
        }

        public void CreateMyPanelMovie()
        {
            panel1 = new Panel();
            textBoxMovieTitle = new TextBox();
            textBoxMovieImageUrl = new TextBox();
            textBoxMovieGenre = new TextBox();
            textBoxMovieRunTime = new TextBox();
            textBoxMovieDescription = new TextBox();
            Button button1 = new Button();

            // Initialize the Panel control.
            panel1.Location = new Point(71, 87);
            panel1.Size = new Size(350, 370);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            //Create the class appropiate for this setup.
            movie = new Movie();

            // Initialize the Label and TextBox controls.
            Size textBoxSize = new Size(215, 26);

            textBoxMovieTitle.Location = new Point(65, 20);
            textBoxMovieTitle.Text = "Title";
            textBoxMovieTitle.Size = textBoxSize;
            textBoxMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieImageUrl.Location = new Point(65, 65);
            textBoxMovieImageUrl.Text = "Image Url";
            textBoxMovieImageUrl.Size = textBoxSize;
            textBoxMovieImageUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieGenre.Location = new Point(65, 113);
            textBoxMovieGenre.Text = "Genre";
            textBoxMovieGenre.Size = textBoxSize;
            textBoxMovieGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieRunTime.Location = new Point(65, 156);
            textBoxMovieRunTime.Text = "Runtime";
            textBoxMovieRunTime.Size = textBoxSize;
            textBoxMovieRunTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieDescription.Location = new Point(65, 198);
            textBoxMovieDescription.Text = "Discription";
            textBoxMovieDescription.Size = new Size(215, 107);
            textBoxMovieDescription.Multiline = true;
            textBoxMovieDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            button1.Location = new Point(124, 329);
            button1.Text = "Create Node";
            button1.Size = new Size(102, 23);
            button1.Click += new EventHandler(Onb2Click);
            // Add the Panel control to the form.
            this.Controls.Add(panel1);
            // Add the TextBox and Button controls to the Panel.
            panel1.Controls.Add(textBoxMovieTitle);
            panel1.Controls.Add(textBoxMovieImageUrl);
            panel1.Controls.Add(textBoxMovieGenre);
            panel1.Controls.Add(textBoxMovieRunTime);
            panel1.Controls.Add(textBoxMovieDescription);
            panel1.Controls.Add(button1);
        }

        void Onb2Click(object sender, EventArgs e)
        {
            string confirmationMessage = "Node has been created successfully";

            if (actor != null)
            {
                actor.name = textBoxName.Text;
                actor.imageUrl = textBoxProfileImg.Text;
                actor.biography = textBoxDescription.Text;
                dbHandler.createNode(actor, "Actor");

            }
            else if (director != null)
            {
                director.name = textBoxName.Text;
                director.imageUrl = textBoxProfileImg.Text;
                director.biography = textBoxDescription.Text;
                dbHandler.createNode(director, "Director");
            }
            else if (movie != null)
            {
                movie.title = textBoxMovieTitle.Text;
                movie.imageUrl = textBoxMovieImageUrl.Text;
                movie.genre = textBoxMovieGenre.Text;
                movie.runtime = Convert.ToInt32(textBoxMovieRunTime.Text);
                movie.description = textBoxMovieDescription.Text;
                dbHandler.createNode(movie, "Movie");
            }
            MessageBox.Show(confirmationMessage);
            disposeForm();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void disposeForm()
        {
            this.Dispose();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

    }
}
