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
    public partial class notif : Form
    {
        public notif()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void notif_Load(object sender, EventArgs e)
        {
            this.Text = "";
            btnRefresh.PerformClick();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM notificaciones ORDER BY  Id DESC";
            Central central = new Central();
            central.LoadDGV(ref dgvNotificaciones,query, "notificaciones");
        }
    }
}
