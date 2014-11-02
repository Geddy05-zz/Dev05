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

        //Most recent movies 
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        //actorWhoDirectedOwnMovie
        private void Button2_Click(object sender, EventArgs e)
        {
            List<Actor> listActor = new List<Actor>();
            List<long> listCount = new List<long>();
            dbHandler.actorWhoDirectedOwnMovie(listActor, listCount);

            if (listActor.Any() && listCount.Any())
            {
                List<String> actorNames = listActor.Select(C => C.name).ToList();
                //List<String> counts = listCount.Select(C => C.name).ToList();
                textBox2.Text = listActor.First().name;
            }
            else
            {
                textBox2.Text = "There are no Directors whom acted in their own movies";
            }
        }

        //mostRecentMovies
        private void Button3_Click(object sender, EventArgs e)
        {
            List<Movie> movies = new List<Movie>();
            dbHandler.mostRecentMovies(movies);

            if (movies.Any())
            {
                List<String> titles = movies.Select(C => C.title).ToList();
                textBox2.Text = titles.ToString();
            }
            else
            {
                textBox2.Text = "There are no movies!?";
            }
        }

        //mostRecentMoviesByGenre
        private void Button4_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            List<Movie> movies = new List<Movie>();
            dbHandler.mostRecentMoviesByGenre(movie, movies);

            if (movies.Any())
            {
                List<String> titles = movies.Select(C => C.title).ToList();
                textBox2.Text = titles.ToString();
            }
            else
            {
                textBox2.Text = "There are no movies!?";
            }
        }

        //actorsWhoPlayedMoreThanTwoFilms
        private void Button5_Click(object sender, EventArgs e)
        {
            Actor ac = new Actor();
            ac.name = this.textBox1.Text;
            List<Actor> listActor1 = new List<Actor>();
            List<Actor> listActor2 = new List<Actor>();
            dbHandler.actorsWhoPlayedMoreThanTwoFilms(ac, listActor1, listActor2);
            if (listActor1.Any() && listActor2.Any())
            {
                List<String> actorNames1 = listActor1.Select(C => C.name).ToList();
                List<String> actorNames2 = listActor2.Select(C => C.name).ToList();

                textBox2.Text = ac.name + " played in more than two films with: /n" + actorNames1 + actorNames2;
            }
            else
            {
                textBox2.Text = ac.name + " hasn't played more than once with other actors";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            disposeForm();
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
