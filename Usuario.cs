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
    internal class Usuario:Consultas{

        private int _id;
        public int Id 
        {
            get { return _id; }
            set { _id = value; }        
        }
        public  void Escribir_ID(int id)
        {
            Id = id;
        }
        public bool  Login(string sqlQuery, string user, string pass, Usuario usuario)
        {
            bool state;
           
            try
            {
                List<string> list = new List<string>();
                list.Add(user);
                list.Add(pass);
               double  result = Convert.ToDouble(GenericQuery(sqlQuery, ref list, true));
               
                if (result == 0)
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos.", "Error de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    state = false;
                }
                else
                {
                    MessageBox.Show("Usuario y contraseña correctos.", "Sesión Iniciada con Éxito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    state = true;
                    sqlQuery = @"SELECT Id FROM Usuarios WHERE Usuario=?";
                    list.Remove(pass);
                    usuario.Escribir_ID(Convert.ToInt32(GenericQuery(sqlQuery, ref list, true)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Imposible ejecutar la consulta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
            }
            return state;
        }
        public void  Register(string sqlQuery, string name, string email)
        {
            try
            {
                if (RevisarUsuarios(email, name)==false)
                {
                    List<string> list = new List<string>();
                    list.Add(name);
                    list.Add(email);
                    GenericQuery(sqlQuery, ref list, false);
                    MessageBox.Show("Registro Exitoso; su contraseña de acceso inicial será 1234.", "Email válido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Si usted ya es dueño de una cuenta, proceda a iniciar sesión.","Nombre y/o email ya registrados.",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Imposible ejecutar la consulta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool RevisarUsuarios(string email, string name) {
            bool state = false;
            string sql = @"SELECT COUNT(*) FROM Usuarios WHERE Usuario= ? OR Correo_Electronico= ?";
            List<string> list = new List<string>();
            list.Add(email);
            list.Add(name);
            double result = Convert.ToDouble(GenericQuery(sql, ref list, true));
            if (result  !=0) { 
                state = true;
            }
            return state;
        }

        public void CambioContraseña(string sqlQuery, string newPass, int id)
        {
         
            try
            {
                List<string> list = new List<string>();
                list.Add(newPass);
                list.Add(id.ToString());
                GenericQuery(sqlQuery, ref list, false);
                MessageBox.Show("La nueva contraseña se ha ingresado con éxito.", "Éxito al cambiar la contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error:" + ex.Message, "Imposible ejecutar la consulta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool RevisarContraseña(string name)
        {
            bool state = true;
            try
            {
                string sqlQuery = @"SELECT Primera_contraseña FROM Usuarios WHERE Usuario = ?";
                List<string> list = new List<string>();
                list.Add(name);
                bool result = Convert.ToBoolean(GenericQuery(sqlQuery, ref list, true));
                if (result == true)
                {
                    state = true;
                }
                else 
                {
                    state = false;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error:" + ex.Message, "Imposible ejecutar la consulta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return state;
        }
        public bool ExisteMail(string email)
        {
            bool state = false;
            try
            {
                string sqlQuery = @"SELECT COUNT(*) FROM Usuarios WHERE Correo_Electronico = ?";
                List<string> list = new List<string>();
                list.Add(email);
                double result = Convert.ToDouble(GenericQuery(sqlQuery, ref list, true));
                if (result !=0)
                {
                    state = true;
                }
                else
                {
                    state = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Imposible ejecutar la consulta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return state;
        }
        public bool ExisteNombre(string name)
        {
            bool state = false;
            try
            {
                string sqlQuery = @"SELECT COUNT(*) FROM Usuarios WHERE Usuario = ?";
                List<string> list = new List<string>();
                list.Add(name);
                double result = Convert.ToDouble(GenericQuery(sqlQuery, ref list, true));
                if (result != 0)
                {
                    state = true;
                }
                else
                {
                    state = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Imposible ejecutar la consulta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return state;
        }
        public void CambioContraseña2(string sqlQuery, string newPass, string email)
        {
            try
            {
                List<string> list = new List<string>();
                list.Add(newPass);
                list.Add(email);
                GenericQuery(sqlQuery, ref list, false);
                MessageBox.Show("La nueva contraseña se ha ingresado con éxito.", "Éxito al cambiar la contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Imposible ejecutar la consulta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool  Estatus()
        {
           bool state = false;
            List<string> list = new List<string>();
            list.Add(Id.ToString());
            string sqlQuery = @"SELECT Estatus_Bloqueo FROM Usuarios WHERE Id = ?";
            state = Convert.ToBoolean(GenericQuery(sqlQuery, ref list, true));
            return state;
        }
    }
}
