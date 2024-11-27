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
    public partial class ordenes : Form
    {
        private string nmesa;
        public ordenes(string Nmesa)
        {
            InitializeComponent();
            nmesa = Nmesa;
        }

        private void ordenes_Load(object sender, EventArgs e)
        {
            this.Text = "";
            Mesero mesero = new Mesero();
            string query = $"SELECT plato, cantidad FROM pedidos WHERE mesa = {nmesa} AND estado = 'pedido'";
            mesero.LoadDGV(ref dgvMesas, query , "pedidos");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            meseros meseros = new meseros();
            meseros.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar(nmesa);
            agregar.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Esta seguro de que desea eliminar toda la orden?","Antes de proseguir.",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

            if (res == DialogResult.OK)
            {
                string query = $"UPDATE  pedidos SET estado = 'terminado' WHERE mesa = ?";
                List<string> list = new List<string>();
                list.Add(nmesa);
                Usuario usuario = new Usuario();
                usuario.GenericQuery(query, ref list, false);



                ordenes ordenes = new ordenes(nmesa);
                ordenes.Show();
                this.Close();
            }
            else if (res == DialogResult.Cancel) 
            {
                ordenes ordenes = new ordenes(nmesa);
                ordenes.Show();
                this.Close();
            }

        }
    }
}
