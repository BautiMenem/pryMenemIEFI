using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace pryMenemIEFI
{
    internal class ClsConexion
    {
        public OleDbConnection Conexion;
        public OleDbCommand Comando;
        public OleDbDataReader rd;


        public void RegistrarSocio(string nombre, string apellido, string lugarNacimiento, int edad, bool sexo, decimal ingreso, int puntaje)
        {

            //string conexion y query sql
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb;Persist Security Info=False;";
            string consultaSql = "INSERT INTO SOCIOS (NOMBRE, APELLIDO, LUGAR_NACIMIENTO, EDAD, SEXO, INGRESO, PUNTAJE) " +
                     "VALUES (@nombre, @apellido, @lugarNacimiento, @edad, @sexo, @ingreso, @puntaje)";


            try
            {
                //llamo los objetos conexion y command para escribir la base de datos
                Conexion = new OleDbConnection(conexion);
                Comando = new OleDbCommand();
                Comando.Connection = Conexion;
                Comando.Connection.Open();
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consultaSql;
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@apellido", apellido);
                Comando.Parameters.AddWithValue("@lugarNacimiento", lugarNacimiento);
                Comando.Parameters.AddWithValue("@edad", edad);
                Comando.Parameters.AddWithValue("@sexo", sexo);
                Comando.Parameters.AddWithValue("@ingreso", ingreso);
                Comando.Parameters.AddWithValue("@puntaje", puntaje);

                Comando.ExecuteNonQuery();

                MessageBox.Show("Socio registrado!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

            }
        }

        public void CargarPaises(ComboBox cmbLugar)
        {
            //string conexion y query sql
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb;Persist Security Info=False;";
            string sql = "SELECT DISTINCT Pais from Tabla1";



            try
            {
                //llamo los objetos conexion y command para manipular la base de datos, y el readear para leer los datos que contiene
                Conexion = new OleDbConnection(conexion);
                Comando = new OleDbCommand();
                Comando.Connection = Conexion;
                Comando.Connection.Open();
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = sql;
                rd = Comando.ExecuteReader();

                while (rd.Read())
                {
                    //agrego los paises de la tabla en el combo box
                    cmbLugar.Items.Add(rd["Pais"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

            }

        }

        public void RegistrarPais(string Pais)
        {
            //string conexion y query sql
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb;Persist Security Info=False";
            string consultaSql = "INSERT INTO Tabla1 (Pais) VALUES (@Pais)";

            try
            {
                //llamo los objetos conexion y command para escribir la base de datos
                Conexion = new OleDbConnection(conexion);
                Comando = new OleDbCommand();
                Comando.Connection = Conexion;
                Comando.Connection.Open();
                Comando.CommandType = CommandType.Text;


                // verificar si el pais ya existe en la tabla
                string verificacionSql = "SELECT COUNT(*) FROM Tabla1 WHERE Pais = @Pais";
                Comando.CommandText = verificacionSql;
                Comando.Parameters.AddWithValue("@Pais", Pais);
                int count = (int)Comando.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("El país ya existe en la tabla.", "", MessageBoxButtons.OK);
                }
                else
                {
                    // insertar el pais en la tabla
                    Comando.CommandText = consultaSql;
                    Comando.Parameters.Clear(); // limpiar los parametros previos
                    Comando.Parameters.AddWithValue("@Pais", Pais);
                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Pais registrado!", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);
            }

        }





    }
}
