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
            // Verifica si hay un usuario en sesión, si no, redirige a la página de login
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ProductosDB productosDB = new ProductosDB();
                CategoriaDB categoriaDB = new CategoriaDB();
                ddlCategorias.DataSource = categoriaDB.listar(); ;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Descripcion";
                ddlCategorias.DataBind();

                Session["listaProductos"] = productosDB.listarProductos();
                dgvProductos.DataSource = Session["listaProductos"];
                dgvProductos.DataBind(); 
            }

        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductosDB productosDB = new ProductosDB();
            List<Producto> productosFiltrados;

            // Recuperar el filtro de categoría si está en ViewState
            if (ViewState["CategoriaSeleccionada"] != null)
            {
                int idCategoria = (int)ViewState["CategoriaSeleccionada"];
                productosFiltrados = productosDB.listarProductos().FindAll(x => x.IdCategoria == idCategoria);
            }
            else
            {
                productosFiltrados = productosDB.listarProductos();
            }

            dgvProductos.DataSource = productosFiltrados;
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

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategoria = int.Parse(ddlCategorias.SelectedValue);
            ProductosDB productosDB = new ProductosDB();

            // Guardar categoría seleccionada en el ViewState para no perderla en el PageIndex
            ViewState["CategoriaSeleccionada"] = idCategoria;

            List<Producto> productosFiltrados = productosDB.listarProductos().FindAll(x => x.IdCategoria == idCategoria);

            dgvProductos.DataSource = productosFiltrados;
            dgvProductos.DataBind();
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
        }
    }
}