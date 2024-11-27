using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Login";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string Query = @"SELECT Count(*) FROM Usuarios WHERE Usuario= ? AND Contraseña = ?";
            Usuario user = new Usuario();
           if(user.Login(Query, username, password, user))
           {
                if(user.RevisarContraseña(username)==true){
                    if (user.Estatus())
                    {
                        MessageBox.Show("Usuario bloqueado hasta que un administrador lo habilite y le de su rol.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        Cambio_de_Contraseña cambio_De_Contraseña = new Cambio_de_Contraseña(user.Id);
                        cambio_De_Contraseña.Show();
                        this.Hide();
                    }
               }
               else
                {
                    if (!user.Estatus())
                    {
                        Preguntas_de_Usuario preguntas_De_Usuario = new Preguntas_de_Usuario(user.Id);
                        preguntas_De_Usuario.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario bloqueado hasta que un administrador lo habilite y le de su rol.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
           }
            else
            {
                limpiarCajas();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro register = new Registro();
            register.Show();
            this.Close();
        }

        private void limpiarCajas()
        {
            txtPass.Text = "";
            txtUser.Text = "";
        }

        private void lnkForgottenpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperar recuperar = new Recuperar();  
            recuperar.Show();
            this.Close();
        }
    }
}
