using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SistemaBiblioteca{
    class Conexion{


        //función que crea una conexión SQL con nuestra base de datos
        public static SqlConnection conectarBD(){
            //usamos un try catch en caso de no podernos conectar.
            SqlConnection cnn;
            try{                    //Con el siguiente código hacemos la conexión
                cnn = new SqlConnection("Data Source=.;Initial Catalog=bdBiblioteca;Integrated Security=True");
                // MessageBox.Show("Se conectó");
                cnn.Open();
            }catch (Exception ex){
                cnn = null;
                MessageBox.Show("No se pudo contectar" + ex);
            }
            return cnn;
        }


        // función nos sirve para verificar la validez del usuario y contraseña
        public static int verificacionUsuario(int clave, String contra){
            int res = 0;

            SqlDataReader dr;
            SqlConnection con;
            SqlCommand cmd;
            //con un try catch
            try{
                con = Conexion.conectarBD(); //nos conectamosa la base de datos
                cmd = new SqlCommand(String.Format("select contraseña from empleado where claveUnica = {0}", clave), con);
                //vamos a sacar del SQL la contraseña del empleado que tenga la clave dada
                dr = cmd.ExecuteReader();
                if (dr.Read()){
                    //al ejecutar el query, compararemos la contraseña obtenida contra la dada
                    if (dr.GetString(0).Equals(contra)){
                        res = 1;// si la contraseña es correcta regresamos un 1
                    }else
                        res = 2; //si es incorrecta regresamos un 2
                }else
                    res = 3; //si no pudo leer información según el query, regresamos un 3
                con.Close();
            }catch (Exception ex){
                MessageBox.Show("Error " + ex);
            }

            return res;
        }

        // para llenar el combobox de las categorías de los libros
        public static void llenarComboCategorias(ComboBox cb){
            SqlDataReader dr;
            SqlConnection con;
            SqlCommand cmd;

            try{
                con = Conexion.conectarBD(); //nos conectamos a la bd
                //queremos obtener toda la columna de nombre de la tabla categoría
                cmd = new SqlCommand("select nombreC from categoria", con);
                dr = cmd.ExecuteReader();
                while (dr.Read()){//con un while vamos a leer todos los elementos
                    cb.Items.Add(dr.GetString(0));//vamos a agregar todos los elementos a nuestro combo
                }
                cb.SelectedIndex = 0; //empezamos con el primer elemento    
                //no olvidemos cerrar nuestro dataReader y nuestra conexión
                dr.Close();
                con.Close();
            }catch (Exception ex){
                MessageBox.Show("Error combo" + ex);
            }
        }
    }
}