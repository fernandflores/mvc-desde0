using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IProductoRepository
    {
        void CrearProducto(Productos producto);
        void ModificarProducto(int id, Productos producto);
        List<Productos> ListarProdcutos();
        Productos ObtenerProductoPorId(int id);
        void EliminarPorId(int id);

    }
}
