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
    public partial class Ingresar_Codigo : Form
    {
        private string Codigo;
        private string Email;
        public Ingresar_Codigo(string email,string codigo)
        {
            InitializeComponent();
            Codigo = codigo;
            Email = email;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Recuperar recuperar = new Recuperar();
            recuperar.Show();
            this.Close();
        }

        private void Ingresar_Codigo_Load(object sender, EventArgs e)
        {

        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            string texto=txtCode.Text;
            if (texto == Codigo)
            {
                MessageBox.Show("El codigo ingresado coincide con el enviado por correo.", "Codigo introducido correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nueva_Contraseña nueva_Contraseña = new Nueva_Contraseña(Email);
                nueva_Contraseña.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El codigo ingresado no coincide con el enviado por correo.", "Codigo invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Recuperar recuperar = new Recuperar();
                recuperar.Show();
                this.Close();
            }
        }
    }
}
