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
    public partial class ABMProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ProductosDB productosDB = new ProductosDB();
                dgvProductos.DataSource = productosDB.listarProductos();
                dgvProductos.DataBind();

                //agregar ejemplos dropdown
                ddlCategorias.Items.Add("Bebidas");
                ddlCategorias.Items.Add("Comidas");
                ddlCategorias.Items.Add("Postres");
            }

        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataBind();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormProducto.aspx?id=" + id);
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProducto.aspx");
        }
    }
}