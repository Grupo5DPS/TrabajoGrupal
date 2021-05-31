using System.Windows;

namespace Grupal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //ContentArea.Content = new Categories();
            Cliente cliente = new Cliente();
            this.Contenedor1.Content = cliente;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //ContentArea.Content = new Categories();
            Categories nueva = new Categories();
            this.Contenedor1.Content = nueva;

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //frame  Vendedor
            Vendedr vendedor = new Vendedr();
            this.Contenedor1.Content = vendedor;
        }
    }
}
