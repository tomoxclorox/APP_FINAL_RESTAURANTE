using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App_Final_Restaurante
{
    public partial class Recuperar : Form
    {
        public static string DireccionCorreo { get; set; }
        public static string Asunto { get; set; }

        public static string Codigo { get; set; }
        public Recuperar()
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

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            string email = txtRecovery.Text;


            if (EsEmailValido(email)==true)
            {
                Usuario usuario = new Usuario();
                if (usuario.ExisteMail(email) == true)
                {
                    string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    Random random = new Random();
                    string codigo = new string(Enumerable.Repeat(caracteres, 8)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    // MessageBox.Show("Se ha creado un codigo de recuperación para usted: "+ codigo+" ", "Proceso de recuperación de contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Se ha creado un codigo de recuperación para usted y se le ha enviado por correo electronico a su direccion de Email.", "Proceso de recuperación de contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Codigo = codigo;
                    DireccionCorreo = email;
                    Preparar();
                    Ingresar_Codigo ingresar_Codigo = new Ingresar_Codigo(email,codigo);
                    ingresar_Codigo.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un email existente.", "Email no existe.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRecovery.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un email correcto.", "Email no válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRecovery.Focus();
            }
        }
        public static void Preparar()
        {
            string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1> Codigo de ingreso: </h1></br>
                            <h2> " + Codigo + "</h2>";
            Emails.sendMail(DireccionCorreo, Asunto, body);
        }

        private void Recuperar_Load(object sender, EventArgs e)
        {

        }
    }
}
