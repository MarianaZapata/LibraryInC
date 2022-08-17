using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows;

namespace webBiblioteca
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Cuando se le da click al botón para ingresar al resto del portal se hace una verificación de los datos ingresados y comprueba que
        //estas credenciales se encuentren como fueron ingresadas en la base de datos, de ser así redirije al usuario a la siguiente página
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd;
            SqlDataReader rd;
            Session["fecha"] = txFecha.Text;
            if (miConexion != null)
            {
                String query = String.Format("select contraseña from alumno where claveUnica = {0}", txUsuario.Text);
                cmd = new SqlCommand(query, miConexion);
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    Session["contra"] = rd.GetString(0);
                    if (rd.GetString(0) == txContra.Text)
                    {
                        lbStatusConexion.Text = "Las credenciales son correctas.";
                        Response.Redirect("Inicio.aspx");

                    } else
                    {
                        lbStatusConexion.Text = "Las credenciales son incorrectas";
                    }

                    rd.Close();
                    miConexion.Close();
                } else
                {
                    lbStatusConexion.Text = "Error al ingresar";
                }
                rd.Close();
                miConexion.Close();
            } else
            {
                lbStatusConexion.Text = "Las credenciales son incorrectas, intente de nuevo";
            }
        }
    }
}