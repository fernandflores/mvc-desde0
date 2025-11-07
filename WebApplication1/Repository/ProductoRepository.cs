using WebApplication1.Models;
using Microsoft.Data.Sqlite;
namespace WebApplication1.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

      

        public ProductoRepository()
        {
            _connectionString = "Data Source= Tienda.db; Cache= Shared";
        }

        public void CrearProducto(Productos producto)
        {
            
                string queryString = "INSERT INTO productos (descripcion, precio) VALUES (@descripcion, @precio)"; // consulta sql
                using (SqliteConnection conexion = new SqliteConnection(_connectionString)) // objeto connection sirve para conectar(hacemos la conexion)
                {
                    conexion.Open(); //abrimos la conexion gracias al objeto connection
                    SqliteCommand comando = new SqliteCommand(queryString, conexion); // clase comando, permite hacer las consultas(recibe como referencia una consulta sql y la conexion)
                    comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@precio", producto.Precio); // agregamos los parametros gracias a la clase comand
                    comando.ExecuteNonQuery(); // ejectua inset update y delete
                    conexion.Close(); //cerramos la conexion con el objeto connection
                }
            
   
        }
        public void ModificarProducto(int id, Productos producto)
        {
                string queryString = "UPDATE productos SET descripcion= @descripcion, precio= @precio WHERE id_prod=@id";
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@precio", producto.Precio);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
         
        }
        public List<Productos> ListarProdcutos()
        {
                var productos = new List<Productos>();
                string queryString = "SELECT id_prod, descripcion, precio FROM productos";
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(queryString, connection);
                    using (SqliteDataReader reader = command.ExecuteReader()) //uso de la clase DataReader que permite leer datos
                    {
                        while (reader.Read()) //recorremos la tabla sql gracias a la clase DataReader
                        {
                            var productoAux = new Productos();
                            productoAux.IdProducto = Convert.ToInt32(reader["id_prod"]); // reader[""]permite obtener la lectura de ese elemento especifico de la tabla
                            productoAux.Precio = Convert.ToInt32(reader["precio"]);
                            //  productoAux.Descripcion= reader["Descripcion"].ToString(); es lo mismo solo que en caso de ser null devuelve una exepcion
                            productoAux.Descripcion = Convert.ToString(reader["descripcion"]); // en caso de ser null devuelve vacio " "
                            productos.Add(productoAux);
                        }
                    }
                    connection.Close();
                }
                return productos;
           }
          
        
        public Productos ObtenerProductoPorId(int id)
        {
            
                Productos producto = null;
                string query = "SELECT precio, descripcion FROM Productos WHERE id_prod= @id";
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Productos();
                            producto.IdProducto = id;
                            producto.Descripcion = Convert.ToString(reader["Descripcion"]);
                            producto.Precio = Convert.ToInt32(reader["Precio"]);
                        }
                    }
                    connection.Close();
                }
                return producto;
            
          
        }
        public void EliminarPorId(int id)
        {
            
                string query = "DELETE FROM productos WHERE id_Prod=@id";
               // string query2 = "DELETE FROM presupuestosDetalle WHERE id_prod=@id";
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(query, connection);
                 //   SqliteCommand command2 = new SqliteCommand(query2, connection);
                   // command2.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@id", id);
                   // command2.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
         
        }
    }

}

