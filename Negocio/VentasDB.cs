using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasDB
    {
        public void crearVenta(int idM, int idP, decimal total, int platillos)
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("Insert into Ventas (IdMesero, IdPedido, TotalCuenta, PlatillosConsumidos) values (" + idM + ", " + idP + ", " + total + ", " + platillos + ")");
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
