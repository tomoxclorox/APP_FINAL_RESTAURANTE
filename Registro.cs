using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace App_Final_Restaurante
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private bool EsEmailValido(string email)
        {
        
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patronEmail);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

         
            if (EsEmailValido(email))
            {
                Usuario user = new Usuario();
                string name = txtName.Text;
                if (user.ExisteMail(email) == false&&user.ExisteNombre(name)==false)
                {
                    string sqlQuery = @"INSERT INTO Usuarios (Usuario, Contraseña, Primera_contraseña, Correo_Electronico, Estatus_Bloqueo, Fecha_Registro,Fecha_ult_cambio, Intentos_Fallidos, Vencimiento_Usuario, Tipo) VALUES (?, '1234', true, ?, true, DATE(), DATE(), 0, DateAdd('yyyy', 1, Date()), 'usuario')";
                    user.Register(sqlQuery, name, email);
                }
                else
                {
                    MessageBox.Show("Nombre de usuario y/o Email ya registrados.","Advertencia:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un email correcto.", "Email no válido.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtEmail.Focus();
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
