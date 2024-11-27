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
    public partial class alta1 : Form
    {
        private string query;
        public alta1(string Query)
        {
            InitializeComponent();
            query = Query;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text;
            string cant = txtCant.Text;
            if (txtNombre.Text != "" && txtCant.Text != "")
            {
                try
                {
                    List<string> list = new List<string>();
                    list.Add(name);
                    list.Add(cant);
                    Usuario usuario = new Usuario();
                    usuario.GenericQuery(query, ref list, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"La consulta ha tenido un error critico: {ex.ToString()}", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                {
                    Stock stock = new Stock();
                    stock.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Complete los campos antes de continuar.","Aviso.",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void alta1_Load(object sender, EventArgs e)
        {
            this.Text = "";
        }
    }
}
