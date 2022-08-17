using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

namespace webBiblioteca
{
    public partial class Inicio : System.Web.UI.Page
    {
        //Al cargar esta página, se trae toda la información actual del usuario y se muestra en los distintos campos
        //Cuando manda a llamar P.hayMulta es para actualizar el espacio donde se indica si hay multa o no, esto a través de validaciones
        //en dicha función 
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd;
            SqlDataReader rd;
            if (miConexion != null)
            {
               
                String query = String.Format("select claveUnica, nombreA, apellidoM, apellidoP, correo, semestre, programa, cantPrestamos, histPrestamos, multa from alumno where claveUnica = '{0}'", Session["contra"].ToString());
                cmd = new SqlCommand(query, miConexion);
                rd = cmd.ExecuteReader();
                rd.Read();
                txCU.Text = rd.GetInt32(0) + "";
                txNombre.Text = rd.GetString(1);
                txApellidoM.Text = rd.GetString(2);
                txApellidoP.Text = rd.GetString(3);
                txCorreo.Text = rd.GetString(4);
                txSemestre.Text = rd.GetInt16(5) + "";
                txPrograma.Text = rd.GetString(6);
                txPrestamosActuales.Text = rd.GetInt32(7) + "";
                txHistorialPrestamos.Text = rd.GetInt32(8) + "";
                int res = P.hayMulta(int.Parse(Session["contra"].ToString()), Session["fecha"].ToString());
                if (res==1)
                    txMulta.Text = "Hay multa(s)";
                else if (res==0)
                    txMulta.Text = "No hay multa(s)";
                else 
                    txMulta.Text = "Error al calcular";
                    
                rd.Close();
                miConexion.Close();
                
            }
        }

        //Las siguientes 4 funciones sirven para redirigir a las distintas páginas
        protected void btConectar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }

        protected void btPrestamo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prestamo.aspx");
        }

        protected void btDevolucion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Devolucion.aspx");
        }

        //Este botón no termina el programa pero se sale a la página de inicio donde se solicitan los datos del usuario
        protected void btSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}