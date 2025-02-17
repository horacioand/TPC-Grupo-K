using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace Visual
{
    public partial class PanelControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarRol();
            UsuarioDB usuarioDB = new UsuarioDB();
            Session["listaUsuarios"] = usuarioDB.listar();
        }

        public bool ValidarRol()
        {
            bool validacion = true;
            Usuario user = (Usuario)Session["usuario"];
            if (user == null || !user.Rol)
            {
                // Evitamos que entren mediante la URL si el usuario no tiene el rol
                Response.Redirect("Login.aspx");
                Response.End(); // Detenemos la ejecución del código
                validacion = false;
            }
            return validacion;
        }

        protected void btnAsignarMesas_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionMesas.aspx");
        }

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformesVentas.aspx");
        }

        protected void btnAMBMesero_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMMeseros.aspx");
        }

        protected void btnAMBPlato_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMProductos.aspx");
        }
    }
}