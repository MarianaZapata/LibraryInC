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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaBiblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        //se activa al presionar el botón "siguiente",
        //nos apoyaremos de la función verificacióonUsuario de la clase Conexion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int res;


            //en una variable int guardaremos el resultado de nuestra verificación,
            //como parametros usaremos la información de nuestros textboxs.

            if (!txUsuario.Text.Equals("") && !txPassword.Text.Equals("") )
            {// tenemos que verificar que la información de nuestros Text Box no sea vacía
                //también, tenemos que usar un try catch para "atrapar" algún problema en los datos.
                try { 
                res = Conexion.verificacionUsuario(Int32.Parse(txUsuario.Text), txPassword.Text);


                    //con ayuda de un switch case evaluaremos nuestro resultado
                    switch (res)
                    {
                        case 1: //la información es correcta, redireccionamos al portal
                            Portal w = new Portal();
                            w.Show();
                            this.Hide();
                            break;

                        case 2://la contraseña no coincide con la obtenida en el SQL
                            MessageBox.Show("Contraseña equivocada");
                            break;
                        case 3://no pudimos encontrar dicho usuario en el SQL
                            MessageBox.Show("Usuario y contraseña equivocada");
                            break;
                    }

                }catch (Exception ex){
                    MessageBox.Show("La información ingresada es incorrecta");
                }
                
             }else{
                MessageBox.Show("Hay cuadros de texto vacíos");
                }
            }
        }
    }

