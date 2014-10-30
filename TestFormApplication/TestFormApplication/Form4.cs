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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected.Equals("Actor") || selected.Equals("Director"))
            {
                textBox2.Text = "Name";
            }
            else if (selected.Equals("Movie"))
            {
                textBox2.Text = "Title";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to delete this node?",
            "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result1 == DialogResult.Yes)
            {
                MessageBox.Show("No Mercy!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
