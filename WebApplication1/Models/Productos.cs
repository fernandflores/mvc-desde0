using System.Runtime.CompilerServices;

namespace WebApplication1.Models
{
    public class Productos
    {
        private int _idProducto;
        private string _descripcion;
        private int _precio;

        public Productos()
        {
        }

        public Productos(int idProducto, string descripcion, int precio)
        {
            IdProducto = idProducto;
            Precio = precio;
            Descripcion = descripcion;
        }

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Precio { get => _precio; set => _precio = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
