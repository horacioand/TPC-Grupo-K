using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Visual
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuario aux = (Usuario)Session["usuario"];
                btnIngresar.Visible = false;
                if (!aux.Rol)
                {
                    btnPanelControl.Visible = false;
                }
                else
                {
                    btnPanelControl.Visible = true;
                }
            }else
            {
                btnPanelControl.Visible=false;
            }
        }

        protected void btnPanelControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelControl.aspx");
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}