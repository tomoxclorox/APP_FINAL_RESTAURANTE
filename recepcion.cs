using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    internal class recepcion:Usuario
    {
        public void Cambiarmesa(ref Button btn, string num, ref Label lbl)
        {
            try
            {
                ConectarDB();
                if (btn.BackColor == Color.Lime)
                {
                    string query = @"UPDATE mesas SET ocupada = true WHERE Id = ?";
                    btn.BackColor = Color.Red;
                    lbl.BackColor = Color.Red;
                    List<string> list = new List<string>();
                    list.Add(num);
                    Usuario usuario = new Usuario();
                    usuario.GenericQuery(query, ref list, false);
                }
                else
                {
                    string query = @"UPDATE mesas SET ocupada = false WHERE Id = ?";
                    btn.BackColor = Color.Lime;
                    lbl.BackColor = Color.Lime;
                    List<string> list = new List<string>();
                    list.Add(num);
                    Usuario usuario = new Usuario();
                    usuario.GenericQuery(query, ref list, false); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La consulta ha tenido un error critico: {ex.ToString()}", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DesconectarDB();
            }
        }
        public void Cargarmesas(ref List<Button> botones, ref List<Label> labels)
        {
            try
            {
                ConectarDB();
                int control = 1;
                string sqlQuery = "SELECT ocupada FROM mesas WHERE Id = ?";
                foreach (Button b in botones)
                {
                    List<string> list = new List<string>();
                    list.Add(control.ToString());
                    bool state = Convert.ToBoolean(GenericQuery(sqlQuery, ref list, true));
                    if (state)
                    {
                        b.BackColor = Color.Red;
                        labels[control - 1].BackColor = Color.Red;
                    }
                    else
                    {
                        b.BackColor = Color.Lime;
                        labels[control - 1].BackColor = Color.Lime;
                    }
                    control++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La consulta ha tenido un error critico: {ex.ToString()}", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DesconectarDB();
            }
        }
       
    }
}
