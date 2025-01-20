using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
namespace Negocio
{
    public class UsuarioDB
    {
        // Listar Usuarios
        public List<Usuario> listar()
        {
            DataBase dataBase = new DataBase(); 
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                dataBase.setQuery("SELECT Id, Nombre, Usuario, Contrasena, Rol FROM Usuarios");
                dataBase.executeQuery();
                while(dataBase.Reader.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)dataBase.Reader["Id"];
                    aux.Nombre = (string)dataBase.Reader["Nombre"];
                    aux.UsuarioNombre = (string)dataBase.Reader["Usuario"];
                    aux.Contrasena = (string)dataBase.Reader["Contrasena"];
                    aux.Rol = (bool)dataBase.Reader["Rol"];
                    usuarios.Add(aux);
                }
                return usuarios;
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
