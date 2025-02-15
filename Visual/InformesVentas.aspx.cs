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
        List<Venta> list = new List<Venta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarRol();
            //Traemos todas las ventas
            VentasDB ventasDB = new VentasDB();
            list = ventasDB.listarVentas(DateTime.Now);
            gdwVentas.DataSource = list;
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

        protected void busquedaDia(string fecha )
        {
            //Se busca en el array de todas las ventas 
            List<Venta> result = list.FindAll(a => a.Fecha.Date.ToString("yyyy-MM-dd") == fecha);
            gdwVentas.DataSource= result;
            gdwVentas.DataBind();
            return;
        }
    }
}