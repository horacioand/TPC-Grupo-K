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
    }
}