using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Reflection.Emit;
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

        public Usuario loginUsuario(string usuario, string password)
        {
            DataBase dataBase = new DataBase();
            Usuario user = new Usuario();
            try
            {
                dataBase.setQuery("select Id, Nombre, Usuario, Contrasena, Rol from Usuarios where Usuario = '" + usuario + "' and Contrasena = '" + password + "'");
                dataBase.executeQuery();
                if (dataBase.Reader.Read())
                {
                    user.Id = (int)dataBase.Reader["Id"];
                    user.Nombre = (string)dataBase.Reader["Nombre"];
                    user.Contrasena = (string)dataBase.Reader["Contrasena"];
                    user.Rol = (bool)dataBase.Reader["Rol"];
                }
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
