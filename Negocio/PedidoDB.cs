using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class PedidoDB
    {
        public List<Pedido> listarPedidosDia (int idMesa)
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

        public int crearPedido(int idMesa)
        {
            DataBase dataBase = new DataBase();
            int idPedido = 0;
            try
            {
                dataBase.setQuery("Insert into Pedidos (Fecha, Estado, Total, IdMesa) values (GetDate(), 1, 0, " + idMesa + ") Select Max(Id) from Pedidos");
                dataBase.executeQuery();
                if (dataBase.Reader.Read())
                {
                    idPedido = dataBase.Reader.GetInt32(0);
                }
                dataBase.closeConn();
                dataBase.setQuery("Update Mesas set Estado = 1 where Numero = " + idMesa);
                dataBase.executeNonQuery();
                return idPedido;
            }
            catch (Exception ex)
            {

                throw ex;
            }finally
            {
                dataBase.closeConn();
            }
        }

        public List<ItemPedido> listarItems(int idPedido)
        {
            List<ItemPedido> listaItems = new List<ItemPedido>();
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("select IT.Id, IT.Cantidad, IT.IdPedido, IT.IdProducto, P.Nombre, P.Precio from ItemsPedido IT inner join Productos P on IT.IdProducto = P.Id where IT.IdPedido = " + idPedido);
                dataBase.executeQuery();
                while (dataBase.Reader.Read())
                {
                    ItemPedido aux = new ItemPedido();
                    aux.Id = (int)dataBase.Reader["Id"];
                    aux.Cantidad = (int)dataBase.Reader["Cantidad"];
                    aux.IdPedido = (int)dataBase.Reader["IdPedido"];
                    Producto auxP = new Producto()
                    {
                        Id = (int)dataBase.Reader["IdProducto"],
                        Nombre = (string)dataBase.Reader["Nombre"],
                        Precio = (decimal)dataBase.Reader["Precio"]
                    };
                    aux.Producto = auxP;
                    listaItems.Add(aux);
                }
                return listaItems;
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
