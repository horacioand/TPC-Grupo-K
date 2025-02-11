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
            UsuarioDB usuarioDB = new UsuarioDB();
            Session["listaUsuarios"] = usuarioDB.listar();
        }

        protected void btnAsignarMesas_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionMesas.aspx");
        }
    }
}