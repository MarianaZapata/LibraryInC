using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaBiblioteca
{
    /// <summary>
    /// Interaction logic for Baja.xaml
    /// </summary>
    public partial class Baja : Window
    {
        public Baja()
        {
            InitializeComponent();
        }

        //función que se activa al presionar el botón "Baja"
        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            
            int res;

            if (!tbFolio.Text.Equals("")) {
            // tenemos que verificar que la información de nuestros Text Box no sea vacía
                //también, tenemos que usar un try catch para "atrapar" algún problema en los datos.
                try
                { 
                //utilizaremos una variavle int para
                //guardar la información del Text Box donde se inserta la clave
                    int auxClave = Int32.Parse(tbFolio.Text);

                    //igualaremos a un int el resultado de la función "eliminarLibro"
                    //que declaramos en la clase "Libro",
                    //dando como atributo la clave que guardamos en nuestra variable auxiliar
                    res = Libro.eliminarLibro(auxClave);

                    if (res > 0)//si nuestro resultado es mayor a cero, la baja fue exitosa
                    {
                        MessageBox.Show("Baja Existosa");
                    }
                    else//caso contrario, no se pudo dar de baja
                    {
                        MessageBox.Show("No se pudo dar de baja");
                    }
                }catch (Exception ex)
            {
                MessageBox.Show("Hay algún problema con los datos");
            }
        }else{
                MessageBox.Show("Por favor inserte una clave");
            }
        }
            
        

        //función que se activa al presionar el botón "Regresar"
        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            //nos redirecciona al la ventana "Portal" 
            Portal w = new Portal();
            w.Show();
            this.Hide();
        }
    }
}
