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
    public partial class Carta : System.Web.UI.Page
    {
        List<Producto> productos = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si hay un usuario en sesión, si no, redirige a la página de login
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            alert.Visible = false;
            if (!IsPostBack)
            {
                ViewState["cantidad"] = 1;
                CantidadProductos.Visible = false;
            }
            else
            {
                lblCantidad.Text = ViewState["cantidad"].ToString();
            }
            ProductosDB productosDB = new ProductosDB();
            productos = productosDB.listarProductos();
            cargarMenu();
        }

        protected void cargarMenu()
        {
            List<Producto> listBebidas = productos.FindAll(e => e.IdCategoria == 1);
            foreach (var item in listBebidas)
            {
                Button btn = new Button
                {
                    Text = item.Nombre,
                    ID = "btn" + item.Id.ToString(),
                    CssClass = "btn btn-warning margen"
                };
                if (Request.QueryString["idPedido"] != null)
                {
                    btn.Click += (sender, e) => Btn_click(sender, e, item.Id);
                    btnRegresar.Visible = true;
                }
                Bebidas.Controls.Add(btn);
            }
            List<Producto> listComidas = productos.FindAll(e => e.IdCategoria == 2);
            foreach (var item in listComidas)
            {
                Button btn = new Button
                {
                    Text = item.Nombre,
                    ID = "btn" + item.Id.ToString(),
                    CssClass = "btn btn-warning margen"
                };
                if (Request.QueryString["idPedido"] != null)
                {
                    btn.Click += (sender, e) => Btn_click(sender, e, item.Id);
                    btnRegresar.Visible = true;
                }
                Comidas.Controls.Add(btn);
            }
            List<Producto> listPostres = productos.FindAll(e => e.IdCategoria == 3);
            foreach (var item in listPostres)
            {
                Button btn = new Button
                {
                    Text = item.Nombre,
                    ID = "btn" + item.Id.ToString(),
                    CssClass = "btn btn-warning margen"
                };
                if (Request.QueryString["idPedido"] != null)
                {
                    btn.Click += (sender, e) => Btn_click(sender, e, item.Id);
                    btnRegresar.Visible = true;
                }
                Postres.Controls.Add(btn);
            }
        }

        protected void Btn_click(object sender, EventArgs e, int productId)
        {
            CantidadProductos.Visible = true;
            ViewState["cantidad"] = 1;
            lblCantidad.Text = ViewState["cantidad"].ToString();
            Producto aux = productos.Find(a => a.Id == productId);
            lblProducto.Text = aux.Nombre;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CantidadProductos.Visible=false;
            ViewState["cantidad"] = 1;
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            int cantidad = (int)ViewState["cantidad"];
            if (cantidad == 1)
            {
                return;
            }
            else
            {
                cantidad--;
                ViewState["cantidad"] = cantidad;
                lblCantidad.Text = cantidad.ToString();
            }
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int cantidad = (int)ViewState["cantidad"];
            cantidad++;
            ViewState["cantidad"] = cantidad;
            lblCantidad.Text = cantidad.ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CantidadProductos.Visible = false;
            //Se guarda la cantidad seleccionada
            int cantidad = int.Parse(lblCantidad.Text);
            //Se busca el producto y se le asignan los datos al item pedido
            Producto producto = productos.Find(aux => aux.Nombre == lblProducto.Text);
            ItemPedido itemPedido = new ItemPedido();
            itemPedido.Cantidad = cantidad;
            itemPedido.Producto = producto;
            itemPedido.IdPedido = int.Parse(Request.QueryString["idPedido"]);
            //Se sube a la DB
            ItemPedidoDB itemDB = new ItemPedidoDB();
            itemDB.crearItem(itemPedido);
            alert.Visible = true;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["idMesa"];
            Response.Redirect("DetallesMesa.aspx?id=" + id);
        }
    }
}