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
            MesaDB mesaDB = new MesaDB();
            ListaMesas = mesaDB.listar();
            ddlMeseros.DataSource = Session["listaUsuarios"];
            ddlMeseros.DataTextField= "Nombre";
            ddlMeseros.DataValueField = "Id";
            ddlMeseros.DataBind();
        }

        protected void ddlMeseros_SelectedIndexChanged(object sender, EventArgs e)
        {
            //no necesario
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            //asignar mesa a usuario en db
        }
    }
}