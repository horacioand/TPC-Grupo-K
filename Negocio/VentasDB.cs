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
                dataBase.setQuery("Insert into Ventas (IdMesero, IdPedido, TotalCuenta, PlatillosConsumidos) values (" + venta.Mesero.Id + ", " + venta.IdPedido + ", " + venta.TotalCuenta + ", " + venta.PlatillosConsumidos + ")");
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
                dataBase.setQuery("Select V.Id, V.IdMesero, U.Nombre Mesero, V.IdPedido, CONVERT(DATE, P.Fecha) as Fecha, V.TotalCuenta Total, V.PlatillosConsumidos Platillos, P.nroClientes Personas, M.Numero Mesa from Ventas V inner join Usuarios U on V.IdMesero = U.Id inner join Pedidos P on V.IdPedido = P.Id INNER JOIN Mesas M on P.IdMesa = M.Id\r\n");
                dataBase.executeQuery();
                while (dataBase.Reader.Read())
                {
                    Venta venta = new Venta()
                    {
                        Id = (int)dataBase.Reader["Id"],
                        IdPedido = (int)dataBase.Reader["IdPedido"],
                        TotalCuenta = (decimal)dataBase.Reader["Total"],
                        PlatillosConsumidos = (int)dataBase.Reader["Platillos"],
                        Personas = (int)dataBase.Reader["Personas"],
                        NumMesa = (int)dataBase.Reader["Mesa"],
                        Fecha = (DateTime)dataBase.Reader["Fecha"]                        
                    };
                    Usuario usuario = new Usuario()
                    {
                        Id = (int)dataBase.Reader["IdMesero"],
                        Nombre = (string)dataBase.Reader["Mesero"]
                    };
                    venta.Mesero = usuario;
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
