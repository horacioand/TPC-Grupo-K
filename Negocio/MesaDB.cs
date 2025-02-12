using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MesaDB
    {
        public List<Mesa> listar()
        {
            DataBase dataBase = new DataBase();
            List<Mesa> mesas = new List<Mesa>();
            try
            {
                string consulta = "SELECT M.Id IdMesa, M.Numero NumeroMesa, Capacidad, Estado, AM.IdUsuario, U.Nombre FROM Mesas M, AsignacionMesas AM, Usuarios U WHERE AM.IdMesa = M.Id AND AM.IdUsuario = U.Id\r\n";
                dataBase.setQuery(consulta);
                dataBase.executeQuery();
                while(dataBase.Reader.Read())
                {
                    Mesa aux = new Mesa();
                    aux.Id = (int)dataBase.Reader["IdMesa"];
                    aux.Numero = (int)dataBase.Reader["NumeroMesa"];
                    aux.Capacidad = (int)dataBase.Reader["Capacidad"];
                    aux.Estado = (bool)dataBase.Reader["Estado"];
                    aux.Mesero = new Usuario();
                    aux.Mesero.Id = (int)dataBase.Reader["IdUsuario"];
                    aux.Mesero.Nombre = (string)dataBase.Reader["Nombre"];
                    mesas.Add(aux);
                }
                return mesas;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Mesa> listaAsignada(int idUsuario)
        {
            DataBase dataBase = new DataBase();
            List<Mesa> mesas = new List<Mesa>();
            try
            {
                string consulta = "SELECT M.Id IdMesa, M.Numero NumeroMesa, Capacidad, Estado FROM Mesas M, AsignacionMesas AM, Usuarios U WHERE AM.IdMesa = M.Id AND AM.IdUsuario = U.Id AND U.Id = "+ idUsuario;
                dataBase.setQuery(consulta);
                dataBase.executeQuery();

                while (dataBase.Reader.Read())
                {
                    Mesa aux = new Mesa();
                    aux.Id = (int)dataBase.Reader["IdMesa"];
                    aux.Numero = (int)dataBase.Reader["NumeroMesa"];
                    aux.Capacidad = (int)dataBase.Reader["Capacidad"];
                    aux.Estado = (bool)dataBase.Reader["Estado"];
                    mesas.Add(aux);
                }
                return mesas;
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
        public int traerIdPedido(int idmesa)
        {
            int id = 0;
            DataBase dataBase = new DataBase();
            try
            {
                string consulta = "select Id as IdPedido from Pedidos where IdMesa = " + idmesa + " and Estado = 1";
                dataBase.setQuery(consulta);
                dataBase.executeQuery();
                if (dataBase.Reader.Read())
                {
                    id = (int)dataBase.Reader["IdPedido"];
                }
                return id;
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
        public void cerrarMesa(int id)
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("Update Mesas set Estado = 0 where Numero = " + id.ToString());
                dataBase.executeNonQuery();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { dataBase.closeConn(); }
        }
    }
}
