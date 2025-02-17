using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Visual
{
    public partial class ABMMeseros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnMostrarNuevoMesero_Click(object sender, EventArgs e)
        {
            //Boton muestra div para agregar mesero
            divAgregarMesero.Visible = true;
            btnMostrarNuevoMesero.Visible = false;
        }

        protected void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            //Boton oculta div agregar mesero
            divAgregarMesero.Visible = false;
            btnMostrarNuevoMesero.Visible = true;
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}