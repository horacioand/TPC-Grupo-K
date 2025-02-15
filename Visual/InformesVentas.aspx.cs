using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Visual
{
    public partial class InformesVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarRol();
            VentasDB ventasDB = new VentasDB();
            gdwVentas.DataSource = ventasDB.listarVentas(DateTime.Now);
            gdwVentas.DataBind();
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

        protected void gdwVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}