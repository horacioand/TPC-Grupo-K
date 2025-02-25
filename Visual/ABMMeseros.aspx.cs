using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Visual
{
    public partial class ABMMeseros : Page
    {
        private UsuarioDB usuarioDB = new UsuarioDB(); // Instancia para manejar la base de datos de usuarios

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si hay un usuario en sesión, si no, redirige a la página de login
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            // Solo carga la lista de usuarios la primera vez que se carga la página
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                // Obtiene la lista de usuarios activos y la almacena en la sesión
                List<Usuario> listaUsuarios = usuarioDB.listarActivo();
                Session["listaUsuarios"] = listaUsuarios;

                // Configura el DropDownList con los usuarios
                ddlMeseros.DataSource = listaUsuarios;
                ddlMeseros.DataTextField = "Nombre";
                ddlMeseros.DataValueField = "Id";
                ddlMeseros.DataBind();

                ddlMeseros.Items.Insert(0, new ListItem("-- Seleccionar usuario --", "0"));
            }
            catch (Exception ex)
            {
                lblErrorModificarUsuario.InnerText = "❌ Error al cargar usuarios: " + ex.Message;
                lblErrorModificarUsuario.Visible = true;
            }
        }

        protected void ddlMeseros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["UsuarioSeleccionado"] = null;

            // Si no se selecciona ningún usuario, limpia los campos
            if (ddlMeseros.SelectedValue == "0")
            {
                LimpiarCampos();
                return;
            }

            // Busca el usuario seleccionado en la lista de sesión
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            Usuario seleccionado = lista.Find(x => x.Id == int.Parse(ddlMeseros.SelectedValue));

            if (seleccionado != null)
            {
                ViewState["RolUsuario"] = seleccionado.Rol ? 1 : 0; // Guarda el rol original en ViewState
                txtNombreMesero.Text = seleccionado.Nombre;
                txtUsuarioMesero.Text = seleccionado.UsuarioNombre;
                txtContrasenaMesero.Text = seleccionado.Contrasena;
            }
            else
            {
                lblErrorModificarUsuario.InnerText = "❌ Error: No se encontró el usuario seleccionado.";
                lblErrorModificarUsuario.Visible = true;
            }
        }

        private void LimpiarCampos()
        {
            txtNombreMesero.Text = "";
            txtUsuarioMesero.Text = "";
            txtContrasenaMesero.Text = "";
            ViewState["RolUsuario"] = null;
        }

        protected void btnMostrarNuevoMesero_Click(object sender, EventArgs e)
        {
            // Muestra el formulario de agregar usuario y oculta el de modificar
            divAgregarMesero.Visible = true;
            btnMostrarNuevoMesero.Visible = false;
            divModificarMesero.Visible = false;
        }

        protected void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            // Oculta el formulario de agregar usuario y muestra el de modificar
            divAgregarMesero.Visible = false;
            btnMostrarNuevoMesero.Visible = true;
            divModificarMesero.Visible = true;
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Verifica que los campos no estén vacíos
            if (CamposVacios(txtNombreNuevoMesero, txtUsuarioNuevoMesero, txtContrasenaNuevoMesero))
            {
                lblErrorAgregarUsuario.InnerText = "⚠️ Todos los campos son obligatorios.";
                lblErrorAgregarUsuario.Visible = true;
                return;
            }

            // Crea un nuevo usuario con los datos ingresados
            Usuario usuarioNuevo = new Usuario()
            {
                Nombre = txtNombreNuevoMesero.Text.Trim(),
                UsuarioNombre = txtUsuarioNuevoMesero.Text.Trim(),
                Contrasena = txtContrasenaNuevoMesero.Text.Trim()
            };

            try
            {
                usuarioDB.agregarUsuario(usuarioNuevo);
                Response.Redirect("PanelControl.aspx");
            }
            catch (Exception ex)
            {
                lblErrorAgregarUsuario.InnerText = "❌ Error al agregar usuario: " + ex.Message;
                lblErrorAgregarUsuario.Visible = true;
            }
        }

        protected void btnModificarMesero_Click(object sender, EventArgs e)
        {
            if (ddlMeseros.SelectedValue == "0" || CamposVacios(txtNombreMesero, txtUsuarioMesero, txtContrasenaMesero))
            {
                lblErrorModificarUsuario.InnerText = "⚠️ Debes completar todos los campos y seleccionar un usuario válido.";
                lblErrorModificarUsuario.Visible = true;
                return;
            }

            // Crea un usuario con los datos ingresados
            Usuario usuarioMod = new Usuario()
            {
                Id = int.Parse(ddlMeseros.SelectedValue),
                Nombre = txtNombreMesero.Text.Trim(),
                UsuarioNombre = txtUsuarioMesero.Text.Trim(),
                Contrasena = txtContrasenaMesero.Text.Trim()
            };

            // Si el usuario era gerente, no permitir cambiar su rol
            int rolOriginal = ViewState["RolUsuario"] != null ? (int)ViewState["RolUsuario"] : -1;
            if (rolOriginal == 1)
            {
                usuarioMod.Rol = true;
            }

            try
            {
                usuarioDB.modificarUsuario(usuarioMod);
                Response.Redirect("PanelControl.aspx");
            }
            catch (Exception ex)
            {
                lblErrorModificarUsuario.InnerText = "❌ Error al modificar usuario: " + ex.Message;
                lblErrorModificarUsuario.Visible = true;
            }
        }

        protected void btnEliminarMesero_Click(object sender, EventArgs e)
        {
            if (ddlMeseros.SelectedValue == "0")
            {
                lblErrorModificarUsuario.InnerText = "⚠️ Debes seleccionar un usuario válido.";
                lblErrorModificarUsuario.Visible = true;
                return;
            }

            int rol = ViewState["RolUsuario"] != null ? (int)ViewState["RolUsuario"] : -1;

            if (rol == -1)
            {
                lblErrorModificarUsuario.InnerText = "❌ Error: No se pudo determinar el rol del usuario.";
                lblErrorModificarUsuario.Visible = true;
                return;
            }

            if (rol == 1)
            {
                lblErrorModificarUsuario.InnerText = "❌ No se puede eliminar un gerente.";
                lblErrorModificarUsuario.Visible = true;
            }
            else
            {
                try
                {
                    usuarioDB.eliminarLogico(new Usuario { Id = int.Parse(ddlMeseros.SelectedValue) });
                    Response.Redirect("PanelControl.aspx");
                }
                catch (Exception ex)
                {
                    lblErrorModificarUsuario.InnerText = "❌ Error al eliminar usuario: " + ex.Message;
                    lblErrorModificarUsuario.Visible = true;
                }
            }
        }

        private bool CamposVacios(params TextBox[] campos)
        {
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Text)) return true;
            }
            return false;
        }
    }
}
