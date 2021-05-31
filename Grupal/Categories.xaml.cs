using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Grupal
{
    /// <summary>
    /// Lógica de interacción para Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        public Categories()
        {
            InitializeComponent();
            Listar();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//evento agregar Categorias
            string codigo = txCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string CategoriaPadre = txtCategoriaPadre.Text.Trim();

            using (VentasEntities ventas = new VentasEntities())
            {
                TCategoria Categoria = new TCategoria();
                if (txtCategoriaPadre.Text == "")
                {
                    CategoriaPadre = null;
                    Categoria.CodCategoria = codigo;
                    Categoria.Nombre = nombre;
                    Categoria.CategoriaPadre = CategoriaPadre;
                    ventas.TCategoria.Add(Categoria);
                }
                else
                {
                    Categoria.CodCategoria = codigo;
                    Categoria.Nombre = nombre;
                    Categoria.CategoriaPadre = CategoriaPadre;
                    ventas.TCategoria.Add(Categoria);
                    
                }
                ventas.SaveChanges();

            }
            Listar();
        }
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            if (txCodigo.Text == "")
            {
                MessageBox.Show("Es necesario el codigo de la categoria para Actualizar");
            }
            else
            {
                using (VentasEntities ventas = new VentasEntities())
                {

                    var query = (from user in ventas.TCategoria
                                 where user.CodCategoria == txCodigo.Text
                                 select user).ToList();
                    foreach (var item in query)
                    {
                        if (txtCategoriaPadre.Text =="")
                        {
                            item.Nombre = txtNombre.Text;
                            item.CategoriaPadre = null;
                        }
                        else
                        {
                            item.Nombre = txtNombre.Text;
                            item.CategoriaPadre = txtCategoriaPadre.Text;
                        }
                    }
                    ventas.SaveChanges();
                    MessageBox.Show("Se actualizó la categoria. ");
                }
                Listar();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//Evento aliminar Cliente

            if (txCodigo.Text == "")
            {
                MessageBox.Show("Es necesario el codigo de la categoria para eliminar");
            }
            else
            {
                using (VentasEntities ventas = new VentasEntities())
                {

                    var query = (from user in ventas.TCategoria
                                 where user.CodCategoria == txCodigo.Text
                                 select user).First();
                    if (query.CategoriaPadre==null)
                    {
                        ventas.TCategoria.Remove(query);
                        MessageBox.Show("Se eliminó la categoria. ");
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar categoria/n Pertenece a una sub categoria ");
                    }

                    ventas.SaveChanges();
                    
                }
                Listar();
            }
        }
        public void Listar()
        {
            using (VentasEntities ventas = new VentasEntities())
            {
                var consulta = from V in ventas.TCategoria
                               select new
                               {
                                   COD = V.CodCategoria,
                                   NOMBRE = V.Nombre,
                                   CAT_PADRE = V.CategoriaPadre

                               };
                gridCliente1.ItemsSource = consulta.ToList();
            }
        }

    }
}
