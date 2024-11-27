using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    public partial class notificador : Form
    {
        public notificador()
        {
            InitializeComponent();
        }

        private void notificador_Load(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cocinero cocinero = new cocinero();
            cocinero.Show();
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (rdbStock.Checked == true || rdbFalla.Checked == true || rdbDemora.Checked == true)
            {
                if (rdbStock.Checked == true)
                {
                    mensaje = "Falta stock en cocina";
                }
                else if (rdbFalla.Checked == true)
                {
                    mensaje = "Hubo una falla critica en la cocina";
                }
                else if (rdbDemora.Checked == true)
                {
                    mensaje = "Demora importante sucediendo en la cocina";
                }

                string query = @"INSERT INTO notificaciones (Fecha, Mensaje) VALUES (NOW(), ?)";
                cocina cocina = new cocina();
                cocina.EnviarNotif(query, mensaje);
                MessageBox.Show("El mensaje se ha enviado satisfactoriamente.","Exito.",MessageBoxButtons.OK,MessageBoxIcon.Information);

                cocinero cocinero = new cocinero();
                cocinero.Show();
                this.Close();    

            }
            else 
            {
                MessageBox.Show("Elija una opcion o vuelva al apartado de cocina.","Error.",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}