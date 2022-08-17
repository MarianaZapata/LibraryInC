using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace webBiblioteca
{
    public partial class Catalogo : System.Web.UI.Page
    {
        //Cuando carga la página llena los dropdown list con las diferentes categorías de los libros
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection miConexion = Conexion.conectarBD();
                SqlCommand cmd;
                SqlDataReader rd;
                if (miConexion != null)
                {
                    String query = string.Format("select nombreC from categoria");
                    cmd = new SqlCommand(query, miConexion);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {   //Llena el dropdown list con las diferentes categorias de libros
                        ddCategoria.Items.Add(rd.GetString(0));
                    }
                    rd.Close();
                    miConexion.Close();
                }
            }
            
        }

        //Regresa al usuario a la página de inicio
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        //Muestra los datos de los libros correspondientes a la categoria seleccionada
        protected void btBuscarCat_Click(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd, cmd2;
            SqlDataReader rd, rd2;
            if (miConexion != null)
            {
                //Obtiene el id de la categoria que corresponde al nombre de categoria seleccionado en el dropdown list
                String query = string.Format("select idCategoria from categoria where nombreC = '{0}'", ddCategoria.SelectedValue);
                cmd = new SqlCommand(query, miConexion);
                rd = cmd.ExecuteReader();
                rd.Read();
                int categoriaLibro = rd.GetInt32(0);
                rd.Close();
                //Una vez con el id de la categoria se muestran los libros que estén dentro de esa categoría
                String query1 = string.Format("select * from libro where idCategoria = {0}", categoriaLibro);
                cmd2 = new SqlCommand(query1, miConexion);
                rd2 = cmd2.ExecuteReader();
                gvLibros.DataSource = rd2; //que meta la info a la grid
                gvLibros.DataBind();//para que muestre la info
                rd2.Close();
                miConexion.Close();
            }
            
        }
        //Muestra los libros que tengan el mismo nombre que el que se ingreso para búsqueda
        protected void btBuscarNombre_Click(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd;
            SqlDataReader rd;
            if (miConexion != null)
            {
                String query1 = string.Format("select * from libro where nombreL = '{0}'", txNombreLibro.Text);
                cmd = new SqlCommand(query1, miConexion);
                rd = cmd.ExecuteReader();
                gvLibros.DataSource = rd; //que meta la info a la grid
                gvLibros.DataBind();//para que muestre la info
                rd.Close();
                miConexion.Close();
            }
        }

    }
}