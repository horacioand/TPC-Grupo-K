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
                if (Session["MesaSeleccionada"] == null)
                {
                    btn.Click += (sender, e) => Btn_click(sender, e, item.Id);
                }
                btn.CssClass = "btn btn-warning margen";
                carta.Controls.Add(btn);
            }
        }
        protected void Btn_click(object sender, EventArgs e, int productId)
        {           
            Producto aux = productos.Find(a => a.Id == productId);
        }
    }
}