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
    public partial class AsignacionMesas : System.Web.UI.Page
    {
        public List<Mesa> ListaMesas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            if (user == null || !user.Rol)
            {
                Response.Redirect("Login.aspx");
            }
            MesaDB mesaDB = new MesaDB();
            ListaMesas = mesaDB.listar();
            if (!IsPostBack)
            {
                cargarMesas();
                cargarMeseros();
            }

        }

        protected void cargarMesas()
        {
            ddlMesas.DataSource = ListaMesas;
            ddlMesas.DataTextField = "Numero";
            ddlMesas.DataValueField = "Numero";
            ddlMesas.DataBind();
        }

        protected void cargarMeseros()
        {
            ddlMeseros.DataSource = Session["listaUsuarios"];
            ddlMeseros.DataTextField= "Nombre";
            ddlMeseros.DataValueField = "Id";
            ddlMeseros.DataBind();
        }
    }
}