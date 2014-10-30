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
        Panel panel1;
        Actor actor;
        Director director;
        Movie movie;
        public Form3()
        {
            InitializeComponent();
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
            this.Dispose();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        //example msdn
        public void CreateMyPanel()
        {
            panel1 = new Panel();
            textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            TextBox textBox4 = new TextBox();
            Button button1 = new Button();

            // make the proper class for the situation.
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

            textBox1.Location = new Point(65, 40);
            textBox1.Text = "Name";
            textBox1.Size = textBoxSize;
            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox2.Location = new Point(65, 93);
            textBox2.Text = "Profile Image Url";
            textBox2.Size = textBoxSize;
            textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox3.Location = new Point(65, 151);
            textBox3.Text = "Biography";
            textBox3.Size = new Size(215, 107);
            textBox3.Multiline = true;
            textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  
            button1.Location = new Point(124, 286);
            button1.Text = "Create Node";
            button1.Size = new Size(102, 23);
            button1.Click += new EventHandler(Onb2Click);
            // Add the Panel control to the form.
            this.Controls.Add(panel1);
            // Add the TextBox and Button controls to the Panel.
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(button1);
        }

        public void CreateMyPanelMovie()
        {
            panel1 = new Panel();
            textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            TextBox textBox4 = new TextBox();
            TextBox textBox5 = new TextBox();
            Button button1 = new Button();

            // Initialize the Panel control.
            panel1.Location = new Point(71, 87);
            panel1.Size = new Size(350, 370);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Initialize the Label and TextBox controls.
            Size textBoxSize = new Size(215, 26);

            textBox1.Location = new Point(65, 20);
            textBox1.Text = "Title";
            textBox1.Size = textBoxSize;
            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox2.Location = new Point(65, 65);
            textBox2.Text = "Image Url";
            textBox2.Size = textBoxSize;
            textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox3.Location = new Point(65, 113);
            textBox3.Text = "Genre";
            textBox3.Size = textBoxSize;
            textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox4.Location = new Point(65, 156);
            textBox4.Text = "Runtime";
            textBox4.Size = textBoxSize;
            textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox5.Location = new Point(65, 198);
            textBox5.Text = "Discription";
            textBox5.Size = new Size(215, 107);
            textBox5.Multiline = true;
            textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            button1.Location = new Point(124, 329);
            button1.Text = "Create Node";
            button1.Size = new Size(102, 23);
            button1.Click += new EventHandler(Onb2Click);
            // Add the Panel control to the form.
            this.Controls.Add(panel1);
            // Add the TextBox and Button controls to the Panel.
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(button1);
        }

        void Onb2Click(object sender, EventArgs e)
        {
            textBox1.Text = "New Button (b2) Was Clicked!!";
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
