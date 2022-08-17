using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Windows;

namespace webBiblioteca
{
    public class Conexion
    {
        //Se conecta con la base de datos
        public static SqlConnection conectarBD()
        {
            String stringConexion = "Data Source=.;Initial Catalog=bdBiblioteca;Persist Security Info=True;User ID=sa;Password=sqladmin"; 
            try
            {
                SqlConnection conexion = new SqlConnection(stringConexion);
                conexion.Open();
                return conexion;
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}