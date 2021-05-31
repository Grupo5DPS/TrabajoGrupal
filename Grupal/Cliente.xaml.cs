using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Grupal
{
    /// <summary>
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    public partial class Cliente : Page
    {
        public Cliente()
        {
            InitializeComponent();
            Listar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellido.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            using (VentasEntities ventas = new VentasEntities())
            {

                TCliente cliente = new TCliente();
                cliente.CodCliente = codigo;
                cliente.Nombres = nombre;
                cliente.Apellidos = apellidos;
                cliente.Direccion = direccion;
                ventas.TCliente.Add(cliente);
                ventas.SaveChanges();
            }
            Listar();
        }

        public void Listar()
        {
            using (VentasEntities ventas = new VentasEntities())
            {
                var consulta = from V in ventas.TCliente
                               select V;
                gridCliente1.ItemsSource = consulta.ToList();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            if (txCodigo.Text == "")
            {
                MessageBox.Show("Es necesario el codigo del cliente para Actualizar");
            }
            else
            {
                using (VentasEntities ventas = new VentasEntities())
                {

                    var query = (from user in ventas.TCliente
                                 where user.CodCliente == txCodigo.Text
                                 select user).ToList();
                    foreach (var item in query)
                    {
                        if (txtNombre.Text == ""|| txtApellido.Text == ""|| txtDireccion.Text == "")
                        {
                            MessageBox.Show("Complete todos los campos ");
                        }
                        else
                        {
                            item.Nombres = txtNombre.Text;
                            item.Apellidos = txtApellido.Text;
                            item.Direccion = txtDireccion.Text;
                            ventas.SaveChanges();
                            MessageBox.Show("Se actualizó el Cliente. ");
                        }
                    }
                    
                }
                Listar();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//evento que elimina LOS CLIENTES
            if (txCodigo.Text == "")
            {
                MessageBox.Show("Es necesario el codigo del cliente para eliminar");
            }
            else
            {
                using (VentasEntities ventas = new VentasEntities())
                {

                    var query = (from user in ventas.TCliente
                                 where user.CodCliente == txCodigo.Text
                                 select user).First();
                    ventas.TCliente.Remove(query);

                    ventas.SaveChanges();
                    MessageBox.Show("Se eliminó al Cliente. ");
                }
                Listar();
            }

        }

        private void txCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            //
        }
        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
