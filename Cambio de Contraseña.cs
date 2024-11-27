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
    public partial class Cambio_de_Contraseña : Form
    {
        private int id; 
        public Cambio_de_Contraseña(int Id)
        {
            InitializeComponent();
             id = Id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnNewpass_Click(object sender, EventArgs e)
        {
            string pass = txtNewpass.Text;  
            if (ValidarContraseña(pass)==false)
            {
                txtNewpass.Text = "";
            }
            else
            {
                string sqlQuery = @"UPDATE  Usuarios SET Contraseña = ?, Primera_contraseña= false, Fecha_ult_cambio= DATE() WHERE Id = ?";
                Usuario usuario = new Usuario();
                usuario.CambioContraseña(sqlQuery, pass, id);
                Preguntas_de_Usuario preguntas_De_Usuario = new Preguntas_de_Usuario(id);
                preguntas_De_Usuario.Show();
                this.Close();
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
                    MessageBox.Show($"La contraseña contiene caracteres no permitidos: {pattern}","Contraseña Invalida.",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void Cambio_de_Contraseña_Load(object sender, EventArgs e)
        {
           
        }
    }
}
