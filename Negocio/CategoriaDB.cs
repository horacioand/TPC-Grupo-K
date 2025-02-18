using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class CategoriaDB
    {
        public List<Categoria> listar()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            DataBase dataBase = new DataBase();
            try
            {
                string consulta = "SELECT Id, Nombre FROM Categorias";
                dataBase.setQuery(consulta);
                dataBase.executeQuery();
                while (dataBase.Reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)dataBase.Reader["Id"];
                    categoria.Descripcion = (string)dataBase.Reader["Nombre"];
                    listaCategorias.Add(categoria);
                }
                return listaCategorias;
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
