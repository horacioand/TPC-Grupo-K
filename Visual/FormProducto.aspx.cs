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
    public partial class FormProducto : System.Web.UI.Page
    {
        public Producto productoSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaDB categoriaDB = new CategoriaDB();
            //Producto productoSeleccionado;
            if (!IsPostBack)
            {
                ddlCategoria.DataSource = categoriaDB.listar();
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && int.TryParse(Request.QueryString["id"], out _))
            {
                btnEliminarProducto.Visible = true;
                int id = int.Parse(Request.QueryString["id"]);
                List<Producto> listaProductos = (List<Producto>)Session["listaProductos"];
                productoSeleccionado = listaProductos.Find(p => p.Id == id);
                txtNombreProducto.Text = productoSeleccionado.Nombre.ToString();
                txtUrlImagen.Text = productoSeleccionado.Imagen.ToString();
                txtPrecio.Text = productoSeleccionado.Precio.ToString();
                ddlCategoria.DataSource = categoriaDB.listar();
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
                ddlCategoria.SelectedValue = productoSeleccionado.IdCategoria.ToString();
                //falta codigo de boton eliminar producto
            }
        }

        protected void btnEnviarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreProducto.Text;
            string imagen = txtUrlImagen.Text;
            decimal money = decimal.Parse(txtPrecio.Text);
            int categoria = int.Parse(ddlCategoria.SelectedValue);
            Producto producto = new Producto()
            {
                Nombre = txtNombreProducto.Text,
                Precio = money,
                Imagen = imagen,
                IdCategoria = categoria
            };

            try
            {
                ProductosDB productoDB = new ProductosDB();
                productoDB.crearProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            ProductosDB productoDB = new ProductosDB();
            productoDB.eliminarLogico(productoSeleccionado);
            Response.Redirect("PanelControl.aspx");
        }
    }
}