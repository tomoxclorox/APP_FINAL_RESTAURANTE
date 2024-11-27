using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;

namespace App_Final_Restaurante
{
    internal class Central:Usuario
    {
        public void LoadDGV(ref DataGridView dgv, string qry, string tabla)
        {
            DataSet ds = new DataSet();
            try
            {
                ConectarDB();
                OleDbDataAdapter adapter = new OleDbDataAdapter(qry, cnn);
                adapter.Fill(ds, tabla);
                dgv.DataSource = ds.Tables[tabla];
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
                    bool state = Convert.ToBoolean(GenericQuery(sqlQuery,ref list,true));
                    if (state) 
                    { 
                       b.BackColor =Color.Red;
                        labels[control-1].BackColor = Color.Red;
                    }
                    else
                    {
                        b.BackColor =Color.Lime;
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
        public void Consultas(int identificador, string consulta)
        {
            string sqlQuery;
            if (identificador == 1)
            {
                if (consulta == "alta")
                {
                    sqlQuery = @"INSERT INTO stock (insumo, cantidad) VALUES (?, ?)";
                    alta1 alta1 = new alta1(sqlQuery);
                    alta1.Show();
                }
                else if (consulta == "baja")
                {
                    sqlQuery = @"DELETE FROM stock WHERE Id = ?";
                    baja1 baja1 = new baja1(sqlQuery);
                    baja1.Show();
                }
                else if(consulta == "modificacion")
                {
                    sqlQuery = @"UPDATE stock SET insumo=?, cantidad=? WHERE Id=?";
                    modif1 modif1 = new modif1(sqlQuery);
                    modif1.Show();
                }
            }
            else if (identificador == 2)
            {
                if (consulta == "alta")
                {
                    sqlQuery = @"INSERT INTO inventario (objeto, cantidad) VALUES (?, ?)";
                    alta1 alta1 = new alta1(sqlQuery);
                    alta1.Show();
                }
                else if (consulta == "baja")
                {
                    sqlQuery = @"DELETE FROM inventario WHERE Id = ?";
                    baja1 baja1 = new baja1(sqlQuery);
                    baja1.Show();
                }
                else if (consulta == "modificacion")
                {
                    sqlQuery = @"UPDATE inventario SET objeto=?, cantidad=? WHERE Id=?";
                    modif1 modif1 = new modif1(sqlQuery);
                    modif1.Show();
                }
            }
            else if (identificador == 3)
            {
                if (consulta == "alta")
                {
                    sqlQuery = @"UPDATE Usuarios SET Estatus_Bloqueo=false WHERE Id=?";
                    alta2 alta2 = new alta2(sqlQuery);
                    alta2.Show();
                }
                else if (consulta == "baja")
                {
                    sqlQuery = @"UPDATE Usuarios SET Estatus_Bloqueo=true WHERE Id=?";
                   baja2 baja2 = new baja2(sqlQuery);
                    baja2.Show();
                }
                else if (consulta == "modificacion")
                {
                    sqlQuery = @"UPDATE Usuarios SET tipo = ? WHERE Id=?";
                    modif2 modif2 = new modif2(sqlQuery); 
                    modif2.Show();
                }
            }
        }
    }
}
