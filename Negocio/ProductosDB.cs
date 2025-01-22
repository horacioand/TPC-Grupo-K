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
                db.setQuery("select Id, Nombre, Precio, Stock, Imagen from Productos");
                db.executeQuery();
                while (db.Reader.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)db.Reader["Id"];
                    aux.Nombre = (string)db.Reader["Nombre"];
                    aux.Precio = (decimal)db.Reader["Precio"];
                    aux.Imagen = (string)db.Reader["Imagen"];   
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
