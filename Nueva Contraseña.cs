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
    public partial class Nueva_Contraseña : Form
    {
        private string Email;
        public Nueva_Contraseña(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            string pass = txtNewpass.Text;
            string conf = txtConfirm.Text;
            if (Confirmar(pass, conf)) {
                if (ValidarContraseña(pass) == false)
                {
                    txtNewpass.Text = "";
                }
                else
                {
                    string sqlQuery = @"UPDATE  Usuarios SET Contraseña = ?, Primera_contraseña= false, Fecha_ult_cambio= DATE() WHERE Correo_Electronico = ?";
                    Usuario usuario = new Usuario();
                    usuario.CambioContraseña2(sqlQuery, pass, Email);
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas deben de coincidir entre si.", "Error de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool ValidarContraseña(string password)
        {
            // Lista de patrones no permitidos
            string[] patronesNoPermitidos = new string[]
            {
            @"\s",                 // Espacios
            @"['""]",              // Comillas simples y dobles
            @"[\x00-\x1F]",        // Caracteres de control
            @"[\\|;<>]",           // Backslash, pipe, punto y coma, menor que, mayor que
            @"--",                 // Secuencia de escape SQL
            @"\/\*",               // Comentarios en SQL (/*)
            @"&",                  // Caracter '&'
            @"%",                  // Caracter '%'
            @"[$#]",               // Caracteres '$' y '#'
            @"[\x7F-\x9F]",        // Caracteres de control adicionales
            };

            // Verificar si el password contiene algún patrón no permitido
            foreach (string pattern in patronesNoPermitidos)
            {
                if (Regex.IsMatch(password, pattern))
                {
                    MessageBox.Show($"La contraseña contiene caracteres no permitidos: {pattern}", "Contraseña Invalida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Verificar si la contraseña contiene caracteres Unicode no permitidos
            if (password.Any(c => char.IsSurrogate(c)))
            {
                MessageBox.Show("La contraseña contiene caracteres Unicode no permitidos.", "Contraseña Invalida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show("La contraseña es válida para su uso.", "Contraseña Valida.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool Confirmar(string pass, string conf)
        {
            bool state;
            if (pass == conf)
            {
                state = true;
            }
            else
            {
                state = false;
            }
            return state;
        }
        private void Nueva_Contraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Recuperar recuperar = new Recuperar();
            recuperar.Show();
            this.Close();
        }
    }
}
