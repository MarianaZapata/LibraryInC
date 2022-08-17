using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace webBiblioteca
{
    public class P
    {
        //Se manda a llamar cuando en la página de Préstamos se quiere dar de alta un préstamo
        //Se solicita la clave única, el id del libro y la fecha actual
        public static int nuevoPrestamo(int id, int cu, String fechaP)
        {
            int res = 0;
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd, cmd2, cmd3, cmd4;
            SqlDataReader dr, dr2;
            if (miConexion != null)
            {
                //primero se checa si dicho libro está disponible para ser prestado
                String query = String.Format("Select disponible from libro where idLibro = {0}", id);
                cmd = new SqlCommand(query, miConexion);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (!dr.GetBoolean(0))
                {
                    dr.Close();
                    //vuelve a la fecha actual capaz de ser comparable (de cadena a enteros) para indicar la fecha de entrega
                    StringBuilder sb = new StringBuilder(fechaP);
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
                    //convierte la fecha de entrega de enteros a una cadena de caracteres
                    if (nD < 10)
                    {
                        if (nM < 10)
                        {
                            fechaN = "0" + nM.ToString() + "/0" + nD + "/" + sb[6].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString();
                        }
                        else
                        {
                            fechaN = nM.ToString() + "/0" + nD + "/" + sb[6].ToString() + sb[7].ToString() + sb[8].ToString() + sb[9].ToString();
                        }

                    }
                    else
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

                    //agrega la información del préstamo a la tabla de prestamo de la base de datos
                    String query1 = String.Format("insert into prestamo values({0}, {1}, '{2}', '{3}')", id, cu, fechaP, fechaN);
                    
                    cmd = new SqlCommand(query1, miConexion);
                    res=cmd.ExecuteNonQuery();

                    //Actualiza la cantidad de prestamos del alumnx
                    String query2 = String.Format("Select cantPrestamos, histPrestamos from alumno where claveUnica = {0}", cu);
                    cmd2 = new SqlCommand(query2, miConexion);
                    dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                    int cant = dr2.GetInt32(0) + 1;
                    int hist = dr2.GetInt32(1) + 1;
                    dr2.Close();
                    query2 = String.Format("Update alumno set histPrestamos = {0} , cantPrestamos = {1} where claveUnica = {2}", hist, cant, cu);
                    cmd3 = new SqlCommand(query2, miConexion);
                    cmd3.ExecuteNonQuery();
                    //Actualiza la disponibilidad del libro (para que ya no pueda volver a ser pedido)
                    query2 = String.Format("Update libro set disponible = 1 where idLibro = {0}", id);
                    cmd4 = new SqlCommand(query2, miConexion);
                    cmd4.ExecuteNonQuery();
                    res = 1;

                } else
                {
                    res = 0;
                }
                
                miConexion.Close();
            }
            return res;
        }

        //Se manda a llamar para actualizar la información de si hay una multa pendiente en la cuenta o no
        public static int hayMulta(int cu, String fechaA)
        {
            int res = 0;

            int m = 0;
            SqlConnection miConexion = Conexion.conectarBD();
            SqlCommand cmd, cmd2, cmd3;
            SqlDataReader dr, dr2;
            if (miConexion != null)
            {
                //Solo es posible que hayan multas si hay prestamos activos, se checa eso primero
                String query = String.Format("Select cantPrestamos from alumno where claveUnica = {0}", cu);
                cmd = new SqlCommand(query, miConexion);
                dr = cmd.ExecuteReader();
                dr.Read();
                int cantPrestamos = dr.GetInt32(0);
                dr.Close();
                if ( cantPrestamos != 0)
                {
                    int cont = 1;
                    //se realiza un ciclo a través de los prestamos del usuario en donde se compara la fecha actual
                    //contra la fecha de entrega de los pedidos, con que en un caso la fecha actual sea mayor que 14 días que
                    //la fecha de entrega se indica que hay una multa pendiente
                    while (m == 0 && cont <= cantPrestamos)
                    {
                            String query1 = String.Format("SELECT fechaEntrega FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY idLibro) AS ROW FROM prestamo where claveUnica = {0}) AS TMP WHERE ROW = {1}", cu, cont);
                            cmd2 = new SqlCommand(query1, miConexion);
                            dr2 = cmd2.ExecuteReader();
                            dr2.Read();
                            StringBuilder sb = new StringBuilder(dr2.GetString(0));
                            String diaE = sb[3].ToString() + sb[4].ToString();
                            int dE = int.Parse(diaE);
                            String mesE = sb[0].ToString() + sb[1].ToString();
                            int mE = int.Parse(mesE);
                            StringBuilder sb1 = new StringBuilder(fechaA);
                            String diaA = sb1[3].ToString() + sb1[4].ToString();
                            String mesA = sb1[0].ToString() + sb1[1].ToString();
                            int dA = int.Parse(diaA);
                            int mA = int.Parse(mesA);
                            if ((dA > dE && mE == mA) || (mA > mE))
                            {
                                m++;
                            }
                            cont++;
                            dr2.Close();
                    }

                } else
                {
                    m = 0;
                }
            }
            return m;
        }
    }
}