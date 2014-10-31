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
    public partial class Form6 : Form
    {
        DataBaseHandler dbHandler;
        String confirmationMessage = "The relationship has been created successfully";

        public Form6()
        {
            InitializeComponent();
            dbHandler = new DataBaseHandler();
        }

        private void Back_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected.Equals("Actor"))
            {
                textBoxName.Text = "Actor's Name";
                createRelationButton.Click += new EventHandler(createActorRel);

            }
            else if (selected.Equals("Director"))
            {
                textBoxName.Text = "Director's Name";
                createRelationButton.Click += new EventHandler(createDirectorRel);
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void createActorRel(object sender , EventArgs e)
        {
            Actor actor = new Actor();
            actor.name = textBoxName.Text;
            Movie movie = new Movie();
            movie.title = textBoxTitle.Text;
            dbHandler.createActorRelationship(actor, movie);
            MessageBox.Show(confirmationMessage);
            disposeForm();
        }

        private void createDirectorRel(object sender , EventArgs e)
        {
            Director director = new Director();
            director.name = textBoxName.Text;
            Movie movie = new Movie();
            movie.title = textBoxTitle.Text;
            dbHandler.createDirectorRelationship(director, movie);
            MessageBox.Show(confirmationMessage);
            disposeForm();
        }
    }
}
