using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    internal abstract class Conexión 
    {
      private string chain = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Final.accdb";
      protected OleDbConnection cnn;

        protected void ConectarDB() {
            cnn = new OleDbConnection(chain);
              
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                try
                {
                    cnn.Open();
                  //  MessageBox.Show("Conexión a la base de datos realizada con éxito.","Éxito al conectar",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }catch (Exception ex)
                {

                    MessageBox.Show("Error:" + ex.Message, "Imposible conectar a la base de datos.", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
              
         }

        protected void DesconectarDB()
        { 
            cnn.Close();
            cnn.Dispose();
           // MessageBox.Show("Conexión a la base de datos cerrada con éxito.", "Éxito al desconectar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
