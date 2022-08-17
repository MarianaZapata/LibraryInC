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
    /// Interaction logic for Portal.xaml
    /// </summary>
    public partial class Portal : Window
    {
        public Portal()
        {
            InitializeComponent();
        }

        //función que se activa al presionar el botón "Alta"
        private void btAlta_Click(object sender, RoutedEventArgs e)
        {
            //nos redirecciona a la ventana "Alta"
            Alta w = new Alta();
            w.Show();
            this.Hide();
        }


        //función que se activa al presionar el botón "Baja"
        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            //nos redirecciona a la ventana "Baja"
            Baja w = new Baja();
            w.Show();
            this.Hide();
        }


        //función que se activa al presionar el botón "Salir"
        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            //El siguiente comando dejará de correr la aplicación,
            //cerrando y saliendo del programa
            System.Windows.Application.Current.Shutdown();

        }
    }
}
