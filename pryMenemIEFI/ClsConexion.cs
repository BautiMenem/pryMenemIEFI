using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace pryMenemIEFI
{
    internal class ClsConexion
    {
        public OleDbConnection Conexion;
        public OleDbCommand Comando;


        public void ConexionABase()
        {
            Conexion = new OleDbConnection();
            Conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb; ";
            Conexion.Open();
                               
        }

        //public void CargarDatos(string Nombre, string Apellido, string Lugar, int Edad, bool Sexo, int Puntaje)
        //{
        //    Comando.Connection = Conexion;
        //    Comando.CommandType = CommandType.TableDirect;
        //    Comando.CommandText = "INSERT INTO Socios(CODIGO_SOCIO, NOMBRE, APELLIDO, LUGAR_NACIMIENTO, SEXO, PUNTAJE) " +
        //        "VALUES (" + Nombre + " , " + Apellido + " , " + Lugar  + "´" + Edad  + "´" + Sexo + "´" + Puntaje +")";

        //}

        public void RegistrarSocio(string nombre, string apellido, string lugarNacimiento, int edad, bool sexo, decimal ingreso, int puntaje)
        {
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb;Persist Security Info=False;";
            string valorAccess = sexo ? "Yes" : "No";
            //string sql = "INSERT INTO SOCIOS (NOMBRE, APELLIDO, LUGAR_NACIMIENTO, EDAD, SEXO, INGRESO, PUNTAJE) VALUES ('" + nombre + "' , '" + apellido + "' , '" + lugarNacimiento + "' , '" + edad + "' , '" + sexo + "' , '" + ingreso + "' , '" + puntaje + "')";
            string consultaSql = "INSERT INTO SOCIOS (NOMBRE, APELLIDO, LUGAR_NACIMIENTO, EDAD, SEXO, INGRESO, PUNTAJE) " +
                     "VALUES (@nombre, @apellido, @lugarNacimiento, @edad, @sexo, @ingreso, @puntaje)";
            try
            {
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
            }
            catch (Exception ex)
            {
                

            }
        }





    }
}
