using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    public partial class cocinero : Form
    {
        public cocinero()
        {
            InitializeComponent();
        }

        private void cocinero_Load(object sender, EventArgs e)
        {
            this.Text = "";
            int control = 1;
            List<DataGridView> list = new List<DataGridView>();
            list.Add(dgvM1);
            list.Add(dgvM2);
            list.Add(dgvM3);
            list.Add(dgvM4);
            list.Add(dgvM5);
            list.Add(dgvM6);
            foreach (DataGridView dgv in list)
            {
                string query = $"SELECT plato, cantidad FROM pedidos WHERE mesa = {control.ToString()} AND estado = 'pedido'";
                cocina cocina = new cocina();
                DataGridView Dgv = list[control - 1];
                cocina.LoadDGV(ref Dgv, query, "pedidos");
                control++;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           Login login = new Login();
            login.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void btnNotificar_Click(object sender, EventArgs e)
        {
            notificador notificador = new notificador();
            notificador.Show();
            this.Close();
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            Envio("1");
            Restart();
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            Envio("2");
            Restart();
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            Envio("3");
            Restart();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Envio("4");
            Restart();
        }
        private void btnA5_Click(object sender, EventArgs e)
        {
            Envio("5");
            Restart();
        }

        private void btnA6_Click(object sender, EventArgs e)
        {
            Envio("6");
            Restart();
        }

        private void Restart()
        {
            cocinero cocinero = new cocinero();
            cocinero.Show();
            this.Close();
        }

        private void Envio(string nmesa)
        {

            DialogResult res = MessageBox.Show("¿Esta seguro de que desea terminar toda la orden?", "Antes de proseguir.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (res == DialogResult.OK)
            {
                string query = $"UPDATE  pedidos SET estado = 'terminado' WHERE mesa = ?";
                List<string> list = new List<string>();
                list.Add(nmesa);
                Usuario usuario = new Usuario();
                usuario.GenericQuery(query, ref list, false);

            }
            else if (res == DialogResult.Cancel)
            {
              //
            }
        }
    }
}
