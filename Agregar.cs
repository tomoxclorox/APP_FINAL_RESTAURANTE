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
    public partial class Agregar : Form
    {
        private string nmesa;
        public Agregar(string Nmesa)
        {
            InitializeComponent();
            nmesa = Nmesa;
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ordenes ordenes = new ordenes(nmesa);
            ordenes.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCant.Text == "")
            {
                MessageBox.Show("Rellene todos los campos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                string name = txtName.Text; 
                string cant = txtCant.Text;
                List<string> list = new List<string>();
                list.Add(name);
                list.Add(cant);
                string query = $"INSERT INTO pedidos (mesa, plato, cantidad, hora, estado) VALUES ({nmesa}, ?, ?, NOW(), 'pedido') ";
                Usuario usuario = new Usuario();
                usuario.GenericQuery(query, ref list, false);
                ordenes ordenes = new ordenes(nmesa);
                ordenes.Show();
                this.Close();
            }
        }
    }
}
