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
                dataBase.setQuery("Insert into ItemsPedido (Cantidad, PrecioUnitario, IdPedido, IdProducto ) values (" + itemPedido.Cantidad + ", " + itemPedido.Producto.Precio + ", " + itemPedido.IdPedido + ", " + itemPedido.Producto.Id + ")");
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
    }
}
