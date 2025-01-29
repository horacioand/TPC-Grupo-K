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
    }
}
