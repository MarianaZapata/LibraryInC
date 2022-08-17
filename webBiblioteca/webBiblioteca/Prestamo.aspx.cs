using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webBiblioteca
{
    public partial class Prestamo : System.Web.UI.Page
    {
        //Llena los campos de clave única y de fecha actual con los datos que se ingresaron en la primera pantalla
        protected void Page_Load(object sender, EventArgs e)
        {
            txClaveUnica.Text = Session["contra"].ToString();
            txFechaP.Text = Session["fecha"].ToString();
            
        }

        //Regresa al usuario a la página de Inicio
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");

        }

        //Se captura la información de los campos de texto para dar de alta un préstamo
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Hace la fecha comparable para indicarle al usuario cuando debe de entregar el ejemplar para no adquirir una multa
            StringBuilder sb = new StringBuilder(txFechaP.Text);
            String fechaN;
            String dia = sb[3].ToString() + sb[4].ToString();
            int d = int.Parse(dia);
            int nD = d + 14;
            int nM = int.Parse(sb[0].ToString()) + int.Parse(sb[1].ToString());
            if (nD > 30)
            {
                nD = nD - 30;
                nM = nM + 1;

            }
            //Convierte la nueva fecha de entrega a una cadena de caracteres
            if (nD < 10)
            {
                if (nM < 10)
                {
                    fechaN = "0" +  nM.ToString() + "/0" + nD + "/" + sb[6].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString();
                } else
                {
                    fechaN = nM.ToString() + "/0" + nD + "/" + sb[6].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString();
                }
                 
            } else
            {
                if (nM < 10)
                {
                    fechaN = "0" + nM.ToString() + "/" + nD + "/" + sb[6].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString();
                }
                else
                {
                    fechaN = nM.ToString() + "/" + nD + "/" + sb[6].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString();
                }

                
            }
            
            //Manada a llamar la clase P en donde se inserta un nuevo préstamo a la base de datos
            int res = P.nuevoPrestamo(int.Parse(txIdLibro.Text), int.Parse(txClaveUnica.Text), txFechaP.Text);

            //Depende del resultado anterior se le indica al usuario si la dada de alta del prestamo fue éxitoso o no
            if (res == 1)
            {
                lbStatus.Text = "Prestamo registrado.";
                lbFechaE.Text = "La fecha de entrega de este prestamo es: " + fechaN;
               
            } else
            {
                lbStatus.Text = "El prestamo no se pudo registrar, asegurese de que el ejemplar este disponible.";
            }

            
        }

        //Cuando se le da click muestra en una grid view los prestamos actuales del usuario con toda su información
        protected void btPrestamos_Click(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd;
            SqlDataReader rd;
            if (miConexion != null)
            {
                String query1 = string.Format("select * from prestamo where claveUnica = {0}", int.Parse(txClaveUnica.Text));
                cmd = new SqlCommand(query1, miConexion);
                rd = cmd.ExecuteReader();
                gvPrestamos.DataSource = rd; //que meta la info a la grid
                gvPrestamos.DataBind();//para que muestre la info
                rd.Close();
                miConexion.Close();
            }
        }
    }
}