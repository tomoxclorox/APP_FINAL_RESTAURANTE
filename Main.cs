using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace App_Final_Restaurante
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void pctConfig_Click(object sender, EventArgs e)
        {
            CambiarConfig cambiarConfig = new CambiarConfig();
            cambiarConfig.Show();
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pctConfig.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"images/config2.png"));
        }

        private void btnNotif_Click(object sender, EventArgs e)
        {
            notif notif = new notif();
            notif.Show();
            this.Close();
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            Vistamesas ocupacion = new Vistamesas();
            ocupacion.Show();
            this.Close();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();  
            stock.Show();
            this.Close();
        }
    }
}
