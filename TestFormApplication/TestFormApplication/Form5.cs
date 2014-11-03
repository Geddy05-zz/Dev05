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
    public partial class Form5 : Form
    {
        Panel panel1;
        Panel panel2;
        Actor actor;
        Director director;
        Movie movie;
        Button buttonUpdateActDir;
        Button buttonUpdateMov;
        TextBox textBoxName;
        TextBox textBoxProfileImage;
        TextBox textBoxDescription;
        TextBox textBoxMovieTitle;
        TextBox textBoxMovieImageUrl;
        TextBox textBoxMovieGenre;
        TextBox textBoxMovieRuntime;
        TextBox textBoxMovieDescription;
        List<Actor> actorList = new List<Actor>();
        DataBaseHandler dbHandler;
         
        

        public Form5()
        {
            InitializeComponent();
            dbHandler = new DataBaseHandler();
            
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
                else if (panel1 != null)
                {
                    panel1.Dispose();
                    panel1 = null;
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

            // Create class according to appropiate Selection in Combobox
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected.Equals("Actor"))
            {
                actor = new Actor();
                searchButton.Click += new EventHandler(onActorButtonClick);
                buttonUpdateActDir.Click += new EventHandler(onActorUpdateButtonClick);
            }
            else if (selected.Equals("Director"))
            {
                director = new Director();
                searchButton.Click += new EventHandler(onDirectorButtonClick);
                buttonUpdateActDir.Click += new EventHandler(onDirectorUpdateButtonClick);
            }
                

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
            movie = new Movie();
            textBoxMovieTitle = new TextBox();
            textBoxMovieImageUrl = new TextBox();
            textBoxMovieGenre = new TextBox();
            textBoxMovieRuntime = new TextBox();
            textBoxMovieDescription = new TextBox();

            // Initialize the Panel control.
            panel2.Location = new Point(29, 164);
            panel2.Size = new Size(257, 350);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Initialize the Label and TextBox controls.
            Size textBoxSize = new Size(178, 26);

            textBoxMovieTitle.Location = new Point(43, 22);
            textBoxMovieTitle.Text = "Title";
            textBoxMovieTitle.Size = textBoxSize;
            textBoxMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieTitle.ReadOnly = true;
            textBoxMovieImageUrl.Location = new Point(43, 55);
            textBoxMovieImageUrl.Text = "Image Url";
            textBoxMovieImageUrl.Size = textBoxSize;
            textBoxMovieImageUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieImageUrl.ReadOnly = true;
            textBoxMovieGenre.Location = new Point(43, 90);
            textBoxMovieGenre.Text = "Genre";
            textBoxMovieGenre.Size = textBoxSize;
            textBoxMovieGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieGenre.ReadOnly = true;
            textBoxMovieRuntime.Location = new Point(43, 125);
            textBoxMovieRuntime.Text = "Runtime";
            textBoxMovieRuntime.Size = textBoxSize;
            textBoxMovieRuntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxMovieRuntime.ReadOnly = true;
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

            searchButton.Click += new EventHandler(onMovieButtonClick);

            // Add the Panel control to the form.
            this.Controls.Add(panel2);
            // Add the TextBox and Button controls to the Panel.
            panel2.Controls.Add(textBoxMovieTitle);
            panel2.Controls.Add(textBoxMovieImageUrl);
            panel2.Controls.Add(textBoxMovieGenre);
            panel2.Controls.Add(textBoxMovieRuntime);
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
                textBoxMovieTitle.ReadOnly = false;
                textBoxMovieImageUrl.ReadOnly = false;
                textBoxMovieGenre.ReadOnly = false;
                textBoxMovieRuntime.ReadOnly = false;
                textBoxMovieDescription.ReadOnly = false;
                buttonUpdateMov.Visible = true;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void onActorButtonClick (object sender , EventArgs e)
        {
            actor.name = textBox1.Text;
            List<Actor> actorList = new List<Actor>();
            
            dbHandler.actorInfo(actor, actorList);
            
            foreach (Actor a in actorList)
            {
                textBoxName.Text = a.name;
                textBoxProfileImage.Text = a.imageUrl;
                textBoxDescription.Text = a.biography;
            }

        }

        void onDirectorButtonClick(object sender, EventArgs e)
        {
            director.name = textBox1.Text;
            List<Director> directorList = new List<Director>();
           
            dbHandler.directorInfo(director, directorList);
           
            foreach (Director d in directorList)
            {
                textBoxName.Text = d.name;
                textBoxProfileImage.Text = d.imageUrl;
                textBoxDescription.Text = d.biography;
            }
        }

        void onMovieButtonClick(object sender, EventArgs e)
        {
            movie.title = textBox1.Text;
            List<Movie> movieList = new List<Movie>();
            
            dbHandler.movieInfo(movie, movieList);
           
            foreach (Movie m in movieList)
            {
                textBoxMovieTitle.Text = m.title;
                textBoxMovieImageUrl.Text = m.imageUrl;
                textBoxMovieGenre.Text = m.genre;
                textBoxMovieRuntime.Text = Convert.ToString(m.runtime);
                textBoxMovieDescription.Text = m.description;
            }
        }

        void onActorUpdateButtonClick(object sender, EventArgs e)
        {
            actor.name = textBoxName.Text;
            actor.imageUrl = textBoxProfileImage.Text;
            actor.biography = textBoxDescription.Text;
            
            dbHandler.updateActor(actor);
         
        }

        void onDirectorUpdateButtonClick(object sender, EventArgs e)
        {

            director.name = textBoxName.Text;
            director.imageUrl = textBoxProfileImage.Text;
            director.biography = textBoxDescription.Text;

            dbHandler.updateDirector(director);

        }

    }
}
