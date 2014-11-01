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
    public partial class queries : Form
    {
        Actor actor;
        Director director;
        Movie movie;
        DataBaseHandler dbHandler;

        public queries()
        {
            InitializeComponent();
            dbHandler = new DataBaseHandler();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //Actors who played more than two films together
            actor = new Actor();
            actor.name = textBoxInput.Text;

            //List to hold the result
            List<Actor> listActor1 = new List<Actor>();
            List<Actor> listActorResult = new List<Actor>();
            

            dbHandler.actorsWhoPlayedMoreThanTwoFilms(actor, listActor1,listActorResult);
            
            //Prints result
            foreach( Actor a in listActorResult)
            {
                textBoxOutput.Text += a.name + Environment.NewLine;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
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

        private void Back_Click(object sender, EventArgs e)
        {
            disposeForm();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Actor who directed own film
            List<Actor> listActorResult = new List<Actor>();
            List<long> listCountResultActor = new List<long>();

            dbHandler.actorWhoDirectedOwnMovie(listActorResult, listCountResultActor);
            textBoxOutput.Text = " ";

            int index = 0;
            foreach (Actor a in listActorResult)
            {
                textBoxOutput.Text += " " + a.name + "   Movie count : " + listCountResultActor[index] + Environment.NewLine;
                index++;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Most Recent Movie 
            List<Movie> listMovieResult = new List<Movie>();
            dbHandler.mostRecentMovies(listMovieResult);
            textBoxOutput.Text = " ";

            foreach (Movie m in listMovieResult)
            {
                textBoxOutput.Text += m.title + "  " + m.longToDate() + Environment.NewLine;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Most recent movie by genre
            List<Movie> listMovieResult = new List<Movie>();
            textBoxOutput.Text = " ";
            Movie mov = new Movie();
            mov.genre = textBoxInputGenre.Text;

            dbHandler.mostRecentMoviesByGenre(mov, listMovieResult);

            foreach (Movie m in listMovieResult)
            {
                textBoxOutput.Text += m.title + "  " + m.longToDate() + Environment.NewLine;
            }



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Most
        }

        private void input_TextChanged(object sender, EventArgs e)
        {

        }

        private void queries_Load(object sender, EventArgs e)
        {

        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
