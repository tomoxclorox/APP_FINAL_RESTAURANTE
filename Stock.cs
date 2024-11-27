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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        private int id = 0;
        public int Id 
        {
             get{ return id; }
            set { id = value; }
        }

        private void btnNotif_Click(object sender, EventArgs e)
        {
            //mal nombrado el boton
            Central central = new Central();
            string query = "SELECT * FROM stock";
            central.LoadDGV(ref dgvCentral, query, "stock");
            Id = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Central central = new Central();
            string query = "SELECT * FROM Usuarios ORDER BY Id ASC";
            central.LoadDGV(ref dgvCentral, query, "Usuarios");
            Id = 3;
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInven_Click(object sender, EventArgs e)
        {
            Central central = new Central();
            string query = "SELECT * FROM inventario";
            central.LoadDGV(ref dgvCentral, query, "inventario");
            Id = 2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                MessageBox.Show("Elija una tabla para comenzar. ","Aviso.",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Central central = new Central();
                central.Consultas(Id,"alta");
                this.Close();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                MessageBox.Show("Elija una tabla para comenzar. ", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Central central = new Central();
                central.Consultas(Id, "baja");
                this.Close();
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                MessageBox.Show("Elija una tabla para comenzar.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Central central = new Central();
                central.Consultas(Id, "modificacion");
                this.Close();
            }
        }
    }
}
