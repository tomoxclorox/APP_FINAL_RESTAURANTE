﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Final_Restaurante
{
    internal class Mesero:Usuario
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
    }
}
