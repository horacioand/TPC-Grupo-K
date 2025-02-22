﻿using System;
using System.Collections.Generic;
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
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            Usuario seleccionado = lista.Find(x => x.Id == int.Parse(ddlMeseros.SelectedValue));
            txtNombreMesero.Text = seleccionado.Nombre;
            txtUsuarioMesero.Text = seleccionado.UsuarioNombre;
            txtContrasenaMesero.Text = seleccionado.Contrasena;
            //chkGerente.Checked = seleccionado.Rol;
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

        protected void btnEliminarMesero_Click(object sender, EventArgs e)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuarioEliminar = new Usuario()
            {
                Id = int.Parse(ddlMeseros.SelectedValue),
            };
            
            try
            {
                usuarioDB.eliminarLogico(usuarioEliminar);
                Response.Redirect("PanelControl.aspx");
            }
            catch (Exception ex)
            {
                lblErrorModificarUsuario.InnerText = "❌ Error al modificar usuario: " + ex.Message;   //Muestra el error en la label si falla conexion a db
                lblErrorModificarUsuario.Visible = true;
            }
        }
    }
}