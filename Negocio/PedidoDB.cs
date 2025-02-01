using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class PedidoDB
    {
        public List<Pedido> listarMesa(string idMesa)
        {
            DataBase dataBase = new DataBase();
            List<Pedido> listaPedidos = new List<Pedido>();
            try
            {
                dataBase.setQuery("SELECT Id, Fecha, Estado, Total FROM Pedidos WHERE IdMesa = "+idMesa+" AND CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE);");
                dataBase.executeQuery();
                while (dataBase.Reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = dataBase.Reader.GetInt32(0);
                    pedido.Fecha = dataBase.Reader.GetDateTime(1);
                    pedido.Estado = dataBase.Reader.GetBoolean(2);
                    pedido.Total = dataBase.Reader.GetDecimal(3);
                    listaPedidos.Add(pedido);
                }
                return listaPedidos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dataBase.closeConn();
            }
        }     
    }
}
