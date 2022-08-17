using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca{
    class Libro{//Definimos la clase libro con los gets & sets, con los siguientes atributos
        public int claveLibro { get; set; }
        public String nombre { get; set; }
        public String autor { get; set; }
        public String editorial { get; set; }
        public String fecha { get; set; }
        public int categoria { get; set; }

        public Libro(){//constructor vacío
        }


        //constructor completo
        public Libro(int claveLibro, string nombre, string autor, string editorial, string fecha, int categoria){
            this.claveLibro = claveLibro;
            this.nombre = nombre;
            this.autor = autor;
            this.editorial = editorial;
            this.fecha = fecha;
            this.categoria = categoria;
        }

        //función para agregar un libro, recibe un libro, regresa un valor int.
        public int agregarLibro(Libro a){
            int res;
            SqlCommand cmd;
            SqlConnection con;
            con = Conexion.conectarBD(); //creamos una conexión
            //usaremos un comando SQL con el siguiente query para intertar la información del libro.
            //nos apoyamos con un String.Format
            cmd = new SqlCommand(String.Format(
                "insert into libro (idLibro,nombreL,autor,editorial,fechaPublicacion,idCategoria,disponible) " +
                "values ({0},'{1}','{2}','{3}','{4}',{5},0)",
                a.claveLibro, a.nombre, a.autor, a.editorial, a.fecha, a.categoria), con);
            res = cmd.ExecuteNonQuery(); //ejecutamos el query y guardamos la variable en res (int)
            con.Close();
            return res; //regresamos "res" (int) que será positivo si se logró la inserción, caso contrario, será negativo
        }


        //función para eliminar un libro de la bd
        public static int eliminarLibro(int folioLibro){
            int res;
            SqlCommand cmd;
            SqlConnection con;
            con = Conexion.conectarBD();//creamos una conexión
            cmd = new SqlCommand(String.Format(//con el String.Format, el comamnd y el query:
                " delete from libro where idLibro = {0}", folioLibro), con);
            res = cmd.ExecuteNonQuery(); //ejecutmos el query
            con.Close();
            return res; //regresamos un int según nuestro resultado
        }
    }
}
