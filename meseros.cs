using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    public partial class meseros : Form
    {
        public meseros()
        {
            InitializeComponent();
        }

        private void meseros_Load(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void btnM1_Click(object sender, EventArgs e)
        {
            ordenes ordenes = new ordenes("1");
            ordenes.Show();
            this.Close();
        }

        private void btnM2_Click(object sender, EventArgs e)
        {
            ordenes ordenes = new ordenes("2");
            ordenes.Show();
            this.Close();
        }

        private void btnM3_Click(object sender, EventArgs e)
        {
            ordenes ordenes = new ordenes("3");
            ordenes.Show();
            this.Close();
        }

        private void btnM4_Click(object sender, EventArgs e)
        {
            ordenes ordenes = new ordenes("4");
            ordenes.Show();
            this.Close();
        }

        private void btnM5_Click(object sender, EventArgs e)
        {
            ordenes ordenes = new ordenes("5");
            ordenes.Show();
            this.Close();
        }
        private void btnM6_Click(object sender, EventArgs e)
        {
            ordenes ordenes = new ordenes("6");
            ordenes.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();   
        }
    }
}
