using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    internal abstract class Consultas:Conexión
    {
        public string GenericQuery(string SqlQuery, ref List<string> parameters, bool retorno)
        {
            string data="";
            try
            {
                ConectarDB();
                OleDbCommand command = new OleDbCommand(SqlQuery, cnn);
                if (!retorno) 
                {
                    foreach (string param in parameters)
                    {
                        command.Parameters.AddWithValue("", param);
                    }
                    command.ExecuteNonQuery();
                    data = "";
                }
                else
                {
                    foreach (string param in parameters)
                    {
                        command.Parameters.AddWithValue("", param);
                    }
                    data = Convert.ToString(command.ExecuteScalar());
                }
   
        
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"La consulta ha tenido un error critico: {ex.ToString()}","Error.", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                DesconectarDB();    
            }

            return data;
        }
    }
}
