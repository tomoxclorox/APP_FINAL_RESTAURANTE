using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace App_Final_Restaurante
{
    public partial class modif2 : Form
    {
        private string query;
        public modif2(string Query)
        {
            InitializeComponent();
            query = Query;
        }

        private void modif2_Load(object sender, EventArgs e)
        {
            this.Text = "";
            cmbRol.Items.Add("administrador");
            cmbRol.Items.Add("recepcionista");
            cmbRol.Items.Add("cocina");
            cmbRol.Items.Add("mesero");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string rol = cmbRol.Text;
            if (cmbRol.Text!="" && txtId.Text != "")
            {
                try
                {
                    List<string> list = new List<string>();
                    list.Add(rol);
                    list.Add(id);
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
                MessageBox.Show("Complete los campos antes de continuar.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
