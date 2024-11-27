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
    public partial class alta2 : Form
    {
        private string query;
        public alta2(string Query)
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

        private void alta2_Load(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if (txtId.Text != "")
            {
                try
                {
                    List<string> list = new List<string>();
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
                    string sqlquery = @"UPDATE Usuarios SET tipo = ? WHERE Id=?";
                    modif2 modif2 = new modif2(sqlquery);
                    modif2.Show();
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

