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
    public partial class Ocupacion : Form
    {
        public Ocupacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           recepcion recepcion = new recepcion();
            recepcion.Cambiarmesa(ref btnM1,"01", ref label3);
        }

        private void btnM2_Click(object sender, EventArgs e)
        {
            recepcion recepcion = new recepcion();
            recepcion.Cambiarmesa(ref btnM2, "02", ref label4);
        }

        private void btnM3_Click(object sender, EventArgs e)
        {
            recepcion recepcion = new recepcion();
            recepcion.Cambiarmesa(ref btnM3, "03", ref label5);
        }

        private void btnM4_Click(object sender, EventArgs e)
        {
            recepcion recepcion = new recepcion();
            recepcion.Cambiarmesa(ref btnM4, "04", ref label6);
        }

        private void btnM5_Click(object sender, EventArgs e)
        {
            recepcion recepcion = new recepcion();
            recepcion.Cambiarmesa(ref btnM5, "05", ref label7);
        }

        private void btnM6_Click(object sender, EventArgs e)
        {
            recepcion recepcion = new recepcion();
            recepcion.Cambiarmesa(ref btnM6, "06", ref label8);
        }

        private void Ocupacion_Load(object sender, EventArgs e)
        {
            List<Button> list = new List<Button>();
            List<Label> labels = new List<Label>();
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            list.Add(btnM1);
            list.Add(btnM2);
            list.Add(btnM3);
            list.Add(btnM4);
            list.Add(btnM5);
            list.Add(btnM6);
            recepcion recepcion = new recepcion();
            recepcion.Cargarmesas(ref list, ref labels);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();   
        }
    }
}
