using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasDB
    {
        public void crearVenta(Venta venta)
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("Insert into Ventas (IdMesero, IdPedido, TotalCuenta, PlatillosConsumidos) values (" + venta.IdMesero + ", " + venta.IdPedido + ", " + venta.TotalCuenta + ", " + venta.PlatillosConsumidos + ")");
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
