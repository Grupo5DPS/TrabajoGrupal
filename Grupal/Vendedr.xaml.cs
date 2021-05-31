using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Grupal
{
    /// <summary>
    /// Lógica de interacción para Vendedr.xaml
    /// </summary>
    public partial class Vendedr : Page
    {
        public Vendedr()
        {
            InitializeComponent();
            Listar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();

            using (VentasEntities ventas = new VentasEntities())
            {//evento agregar VENDEDOR

                TVendedor vendedor = new TVendedor();
                vendedor.CodVendedor = codigo;
                vendedor.Nombres = nombre;
                vendedor.Apellidos = apellido;
                ventas.TVendedor.Add(vendedor);
                ventas.SaveChanges();
            }
            Listar();
        }
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            if (txCodigo.Text == "")
            {
                MessageBox.Show("Es necesario el codigo de la Vendedor para Actualizar");
            }
            else
            {
                using (VentasEntities ventas = new VentasEntities())
                {

                    var query = (from user in ventas.TVendedor
                                 where user.CodVendedor == txCodigo.Text
                                 select user).ToList();
                    foreach (var item in query)
                    {
                        if (txtApellido.Text == "" || txtNombre.Text =="")
                        {
                            MessageBox.Show("Complete todos los campos ");
                        }
                        else
                        {
                            item.Nombres = txtNombre.Text;
                            item.Apellidos = txtApellido.Text;
                            ventas.SaveChanges();
                            MessageBox.Show("Se actualizó el Vendedor. ");
                        }
                    }
                }
                Listar();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//ELIMMINAR VENDEDOR
            if (txCodigo.Text == "")
            {
                MessageBox.Show("Es necesario el codigo del Vendedor para eliminar");
            }
            else
            {
                using (VentasEntities ventas = new VentasEntities())
                {

                    var query = (from user in ventas.TVendedor
                                 where user.CodVendedor == txCodigo.Text
                                 select user).First();
                    ventas.TVendedor.Remove(query);

                    ventas.SaveChanges();
                    MessageBox.Show("Se eliminó al Vendedor. ");
                }
                Listar();
            }
        }
        public void Listar()
        {
            using (VentasEntities ventas = new VentasEntities())
            {
                var consulta = from V in ventas.TVendedor
                               select V;
                gridCliente1.ItemsSource = consulta.ToList();
            }
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
