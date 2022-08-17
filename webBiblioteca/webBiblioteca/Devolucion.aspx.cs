using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace webBiblioteca
{
    public partial class Devolucion : System.Web.UI.Page
    {
        //Llena los campos de clave única y de fecha actual con la información que ingresó el usuario en la primera página
        protected void Page_Load(object sender, EventArgs e)
        {
            txClaveU.Text = Session["contra"].ToString();
            txFechaActual.Text = Session["fecha"].ToString();
        }

        //Regresa al usuario a la página de inicio
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        //Ejecuta la devolución de un libro
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd, cmd2, cmd3, cmd4;
            SqlDataReader dr2;
            if (miConexion != null)
            {
                //Elimina de la tabla de prestamos el libro que tenga el id que se ingresó
                String query = String.Format("delete from prestamo where idLibro = {0}", int.Parse(txIdLibro.Text.ToString()));
                cmd = new SqlCommand(query, miConexion);
                int res = cmd.ExecuteNonQuery();
                //Se obtiene la información del usuario de cantidad de prestamos activos y se disminuye en 1 
                String query2 = String.Format("Select cantPrestamos from alumno where claveUnica = {0}", int.Parse(txClaveU.Text));
                cmd2 = new SqlCommand(query2, miConexion);
                dr2 = cmd2.ExecuteReader();
                dr2.Read();
                int cant = dr2.GetInt32(0);
                dr2.Close();
                query2 = String.Format("Update alumno set cantPrestamos = {0} where claveUnica = {1}", cant-1, int.Parse(txClaveU.Text));
                cmd3 = new SqlCommand(query2, miConexion);
                cmd3.ExecuteNonQuery();
                //El ejemplar devuelto se vuelve a poner disponible
                query2 = String.Format("Update libro set disponible = 0 where idLibro = {0}", int.Parse(txIdLibro.Text.ToString()));
                cmd4 = new SqlCommand(query2, miConexion);
                cmd4.ExecuteNonQuery();
                if (res == 1)
                    lbStatus.Text = "Libro devuelto";
                else
                    lbStatus.Text = "Error al devolver";
                miConexion.Close();
            }
        }
    }
}