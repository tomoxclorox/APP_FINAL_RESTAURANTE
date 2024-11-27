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
    public partial class Vistamesas : Form
    {
        public Vistamesas()
        {
            InitializeComponent();
        }

        private void Vistamesas_Load(object sender, EventArgs e)
        {
           btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<Button> list = new List<Button>();
            List<Label> labels = new List<Label>();
            labels.Add(label3);
            labels.Add(label4); 
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            list.Add(btnM1);
            list.Add(btnM2);
            list.Add(btnM3);
            list.Add(btnM4);
            list.Add(btnM5);
            list.Add(btnM6);
            Central central = new Central();
            central.Cargarmesas(ref list, ref labels);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Main main = new Main(); 
            main.Show();    
            this.Close();
        }
    }
}
