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
        public List<Usuario> listarActivo()
        {
            DataBase dataBase = new DataBase();
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                dataBase.setQuery("SELECT Id, Nombre, Usuario, Contrasena, Rol FROM Usuarios WHERE Activo = 1");
                dataBase.executeQuery();
                while (dataBase.Reader.Read())
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

        public void agregarUsuario(Usuario usuario)
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("INSERT INTO Usuarios (Nombre, Usuario, Contrasena, Rol, Activo) VALUES (@Nombre, @Usuario, @Contrasena, @Rol, 1)");
                dataBase.setParameter("@Nombre", usuario.Nombre);
                dataBase.setParameter("@Usuario", usuario.UsuarioNombre);
                dataBase.setParameter("@Contrasena", usuario.Contrasena);
                dataBase.setParameter("@Rol", usuario.Rol);
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

        public void modificarUsuario(Usuario usuario)
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("UPDATE Usuarios SET NOMBRE = @nombre, Usuario = @usuario, Contrasena = @contrasena, ROL = @rol WHERE ID = " + usuario.Id + "");
                dataBase.setParameter("@nombre", usuario.Nombre);
                dataBase.setParameter("@usuario", usuario.UsuarioNombre);
                dataBase.setParameter("@contrasena", usuario.Contrasena);
                dataBase.setParameter("@Rol", usuario.Rol);
                dataBase.executeNonQuery();
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

        public void eliminarLogico(Usuario usuario) 
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.setQuery("UPDATE USUARIOS SET Activo = 0 WHERE Id = " + usuario.Id + "");
                dataBase.executeNonQuery();
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
