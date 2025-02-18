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
                CategoriaDB categoriaDB = new CategoriaDB();
                ddlCategorias.DataSource = categoriaDB.listar(); ;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Descripcion";
                ddlCategorias.DataBind();

                dgvProductos.DataSource = productosDB.listarProductos();
                dgvProductos.DataBind();

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