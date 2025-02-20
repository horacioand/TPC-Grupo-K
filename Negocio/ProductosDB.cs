using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductosDB
    {
        public List<Producto> listarProductos()
        {
            List<Producto> list = new List<Producto>();
            DataBase db = new DataBase();
            try
            {
                db.setQuery("select Id, Nombre, Precio, UrlImagen, IdCategoria from Productos where Activo = 1");
                db.executeQuery();
                while (db.Reader.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)db.Reader["Id"];
                    aux.Nombre = (string)db.Reader["Nombre"];
                    aux.Precio = (decimal)db.Reader["Precio"];
                    aux.Imagen = (string)db.Reader["UrlImagen"];
                    aux.IdCategoria = (int)db.Reader["IdCategoria"];
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void crearProducto(Producto producto)
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("INSERT INTO Productos (Nombre, Precio, UrlImagen, IdCategoria, Activo) VALUES (@nombre, @precio, @imagen, @categoria,1)");
                dataBase.setParameter("@nombre", producto.Nombre);
                dataBase.setParameter("@precio", producto.Precio);
                dataBase.setParameter("@imagen", producto.Imagen);
                dataBase.setParameter("@categoria", producto.IdCategoria);
                dataBase.executeNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //falta codigo eliminar producto (logico)
    }
}
