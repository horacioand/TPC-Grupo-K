using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ItemPedidoDB
    {
        public void crearItem(ItemPedido itemPedido)
        {
            DataBase dataBase = new DataBase();
            try
            {
                string query = "INSERT INTO ItemsPedido (Cantidad, PrecioUnitario, IdPedido, IdProducto) VALUES (@Cantidad, @PrecioUnitario, @IdPedido, @IdProducto)";

                dataBase.setQuery(query);
                dataBase.setParameter("@Cantidad", itemPedido.Cantidad);
                dataBase.setParameter("@PrecioUnitario", itemPedido.Producto.Precio);
                dataBase.setParameter("@IdPedido", itemPedido.IdPedido);
                dataBase.setParameter("@IdProducto", itemPedido.Producto.Id);

                dataBase.executeNonQuery(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }finally
            {
                dataBase.closeConn();
            }
        }

        public void borrarItem(int Id)
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("Delete ItemsPedido where Id = " + Id.ToString());
                dataBase.executeNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataBase.closeConn();
            }
        }
    }
}
