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
            foreach (var item in productos)
            {
                Button btn = new Button
                {
                    Text = item.Nombre,
                    ID = "btn" + item.Id.ToString(),
                };
                if (Request.QueryString["idPedido"] != null)
                {
                    btn.Click += (sender, e) => Btn_click(sender, e, item.Id);
                }
                btn.CssClass = "btn btn-warning margen";
                carta.Controls.Add(btn);
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
    }
}