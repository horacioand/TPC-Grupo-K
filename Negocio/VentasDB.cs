using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public List<Venta> listarVentas(DateTime date)
        {
            List<Venta> list = new List<Venta>();
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("Select Id, IdMesero, IdPedido, Fecha, TotalCuenta, PlatillosConsumidos from Ventas where  CONVERT(DATE, Fecha) = '" + date.Date.ToString("yyyy-MM-dd") + "'");
                dataBase.executeQuery();
                while (dataBase.Reader.Read())
                {
                    Venta venta = new Venta()
                    {
                        Id = (int)dataBase.Reader["Id"],
                        IdMesero = (int)dataBase.Reader["IdMesero"],
                        IdPedido = (int)dataBase.Reader["IdPedido"],
                        TotalCuenta = (decimal)dataBase.Reader["TotalCuenta"],
                        PlatillosConsumidos = (int)dataBase.Reader["PlatillosConsumidos"]
                    };
                    list.Add(venta);
                }
                return list;
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
