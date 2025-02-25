using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Visual
{
    public partial class ABMMeseros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                UsuarioDB usuarios = new UsuarioDB();
                try
                {
                    ddlMeseros.DataSource = usuarios.listarActivo();
                    ddlMeseros.DataTextField = "Nombre";
                    ddlMeseros.DataValueField = "Id";
                    ddlMeseros.DataBind();

                    ddlMeseros.Items.Insert(0, new ListItem("-- Seleccionar usuario --", "0"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void btnMostrarNuevoMesero_Click(object sender, EventArgs e)
        {
            //Boton muestra div para agregar mesero
            divAgregarMesero.Visible = true;
            btnMostrarNuevoMesero.Visible = false;
            divModificarMesero.Visible = false;
        }

        protected void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            //Boton oculta div agregar mesero
            divAgregarMesero.Visible = false;
            btnMostrarNuevoMesero.Visible = true;
            divModificarMesero.Visible = true;
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            //Verificar que no haya campos vacios o nulos
            if (string.IsNullOrWhiteSpace(txtNombreNuevoMesero.Text) || string.IsNullOrWhiteSpace(txtUsuarioNuevoMesero.Text) || string.IsNullOrWhiteSpace(txtContrasenaNuevoMesero.Text))
            {
                lblErrorAgregarUsuario.InnerText = "⚠️ Todos los campos son obligatorios.";
                lblErrorAgregarUsuario.Visible = true;
                return;
            }


            //Crear nuevo usuario y conexion si pasa la verificacion
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuarioNuevo = new Usuario()
            {
                Nombre = txtNombreNuevoMesero.Text.Trim(),
                UsuarioNombre = txtUsuarioNuevoMesero.Text.Trim(),
                Contrasena = txtContrasenaNuevoMesero.Text.Trim()
            };


            //Agregar usuario nuevo a db
            try
            {
                usuarioDB.agregarUsuario(usuarioNuevo);
                Response.Redirect("PanelControl.aspx");
            }
            catch (Exception ex)
            {
                lblErrorAgregarUsuario.InnerText = "❌ Error al agregar usuario: " + ex.Message;   //Muestra el error en la label si falla conexion a db
                lblErrorAgregarUsuario.Visible = true;
            }
        }
        protected void ddlMeseros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["UsuarioSeleccionado"] = null;

            // Verificar si se ha seleccionado una opción válida
            if (ddlMeseros.SelectedValue == "0")
            {
                // Limpiar los campos si no se selecciona un usuario válido
                txtNombreMesero.Text = "";
                txtUsuarioMesero.Text = "";
                txtContrasenaMesero.Text = "";
                ViewState["RolUsuario"] = null;
                return;
            }

            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];

            // Buscar usuario en la lista
            Usuario seleccionado = lista.Find(x => x.Id == int.Parse(ddlMeseros.SelectedValue));

            if (seleccionado != null)
            {
                ViewState["RolUsuario"] = seleccionado.Rol ? 1 : 0;

                txtNombreMesero.Text = seleccionado.Nombre;
                txtUsuarioMesero.Text = seleccionado.UsuarioNombre;
                txtContrasenaMesero.Text = seleccionado.Contrasena;
            }
            else
            {
                // Manejo de error si no se encuentra el usuario en la lista
                lblErrorModificarUsuario.InnerText = "❌ Error: No se encontró el usuario seleccionado.";
                lblErrorModificarUsuario.Visible = true;
            }
        }

        protected void btnModificarMesero_Click(object sender, EventArgs e)
        {
            //Verificar que no haya campos vacios o nulos
            if (string.IsNullOrWhiteSpace(txtNombreMesero.Text) || string.IsNullOrWhiteSpace(txtUsuarioMesero.Text) || string.IsNullOrWhiteSpace(txtContrasenaMesero.Text))
            {
                lblErrorModificarUsuario.InnerText = "⚠️ Todos los campos son obligatorios.";
                lblErrorModificarUsuario.Visible = true;
                return;
            }
            if (ddlMeseros.SelectedValue == "0")
            {
                lblErrorModificarUsuario.InnerText = "⚠️ Debes seleccionar un usuario válido.";
                lblErrorModificarUsuario.Visible = true;
                return;
            }
            //Crear nuevo usuario y conexion si pasa la verificacion
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuarioMod = new Usuario()
            {
                Id = int.Parse(ddlMeseros.SelectedValue),
                Nombre = txtNombreMesero.Text.Trim(),
                UsuarioNombre = txtUsuarioMesero.Text.Trim(),
                Contrasena = txtContrasenaMesero.Text.Trim()
            };

            //Modificar usuario en db
            try
            {
                usuarioDB.modificarUsuario(usuarioMod);
                Response.Redirect("PanelControl.aspx");
            }
            catch (Exception ex)
            {
                lblErrorModificarUsuario.InnerText = "❌ Error al modificar usuario: " + ex.Message;   //Muestra el error en la label si falla conexion a db
                lblErrorModificarUsuario.Visible = true;
            }
        }

        //Eliminar Usuario
        protected void btnEliminarMesero_Click(object sender, EventArgs e)
        {
            if (ddlMeseros.SelectedValue == "0")
            {
                lblErrorModificarUsuario.InnerText = "⚠️ Debes seleccionar un usuario válido.";
                lblErrorModificarUsuario.Visible = true;
                return;
            }
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuarioEliminar = new Usuario()
            {
                Id = int.Parse(ddlMeseros.SelectedValue)
            };

            // Verificar si ViewState["RolUsuario"] tiene un valor antes de usarlo
            int rol = ViewState["RolUsuario"] != null ? (int)ViewState["RolUsuario"] : -1;

            if (rol == -1)
            {
                lblErrorModificarUsuario.InnerText = "❌ Error: No se pudo determinar el rol del usuario.";
                lblErrorModificarUsuario.Visible = true;
                return;
            }

            if (rol == 1) // Si el usuario es gerente, no puede ser eliminado
            {
                lblErrorModificarUsuario.InnerText = "❌ No se puede eliminar un gerente.";
                lblErrorModificarUsuario.Visible = true;
            }
            else
            {
                try
                {
                    usuarioDB.eliminarLogico(usuarioEliminar);
                    Response.Redirect("PanelControl.aspx");
                }
                catch (Exception ex)
                {
                    lblErrorModificarUsuario.InnerText = "❌ Error al modificar usuario: " + ex.Message;
                    lblErrorModificarUsuario.Visible = true;
                }
            }
        }
    }
}