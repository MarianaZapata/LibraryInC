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
    /// Interaction logic for Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        public Alta()
        {
            InitializeComponent();
        }

        //función que se activa al presionar el botón "alta"
        private void btAgregar_Click(object sender, RoutedEventArgs e){
            int res;

            if(!tbFolio.Text.Equals("") && !tbNombre.Text.Equals("") && !tbAutor.Text.Equals("") && !tbEditorial.Text.Equals("") && !tbFecha.Text.Equals("")) {
            // tenemos que verificar que la información de nuestros Text Box no sea vacía
                //también, tenemos que usar un try catch para "atrapar" algún problema en los datos.
                try
                { 
                    //creamos un objeto tipo "Libro" con la información de los Text Boxes
                    Libro a = new Libro(Int32.Parse(tbFolio.Text), tbNombre.Text, tbAutor.Text, tbEditorial.Text, tbFecha.Text, cbCategoria.SelectedIndex + 1);
                    res = a.agregarLibro(a);//igualemos a un int la función agregarLibro que creamos en la clase Libro
                    if (res > 0){//si res es positivo, nuestra alta fue exitosa
                        MessageBox.Show("Alta Existosa");
                    }else{//caso contrario, no se pudo hacer el alta
                        MessageBox.Show("No se pudo hacer el alta");
                    }
                }catch(Exception ex){
                    MessageBox.Show("Hay algún problema con los datos");
                }

            }
            else
            {
                MessageBox.Show("Hay cuadros de texto vacíos");
            }
        }

      
        //función que se activa al presionar el botón "regresar"
        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            //nos redirecciona a la página "portal"
            Portal w = new Portal();
            w.Show();
            this.Hide();
        }

        //función que llena nuestro Combo Box de categorías,
        //ya que está en el Windos Loaded, se ejecuta tan pronto de abre la ventana
        private void btRegresar_Loaded(object sender, RoutedEventArgs e)
        {
            //utilizamos la función para llenar un combo de
            //categorías que declaremos en la clase Conexion
            // le damos como parámetro nuestro Combo Box a llenar.
            Conexion.llenarComboCategorias(cbCategoria);
        }
    }
}
