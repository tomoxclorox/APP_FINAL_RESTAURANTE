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
    public partial class Preguntas_de_Usuario : Form
    {
        private int id;
        public Preguntas_de_Usuario(int Id)
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

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            string SQLquery = "SELECT Tipo FROM Usuarios WHERE Id=?";
            List<string> list = new List<string>();
            list.Add(id.ToString());
            Usuario user = new Usuario();
            string result = user.GenericQuery(SQLquery, ref list, true);
            if (result == "administrador")
            {
                Main main = new Main();
                main.Show();
                this.Close();
            }
            else if (result == "recepcionista")
            {
                Ocupacion ocupacion = new Ocupacion();
                ocupacion.Show();
                this.Close();    
            }
            else if (result == "cocina")
            {
                cocinero cocinero = new cocinero();
                cocinero.Show();
                this.Close();
            }
            else if (result == "mesero")
            {
              meseros meseros = new meseros();
                meseros.Show();
                this.Close();
            }

        }

        private void Preguntas_de_Usuario_Load(object sender, EventArgs e)
        {

        }
    }
}
