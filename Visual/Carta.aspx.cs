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
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarMenu();
        }
        protected void cargarMenu()
        {
            ProductosDB productosDB = new ProductosDB();
            List<Producto> productos = productosDB.listarProductos();
            foreach (var item in productos)
            {
                Button btn = new Button
                {
                    Text = item.Nombre,
                    ID = item.Id.ToString(),
                };
                btn.Click += new EventHandler(Btn_click);
                btn.CssClass = "btn btn-warning";
                carta.Controls.Add(btn);
            }
        }
        protected void Btn_click(object sender, EventArgs e)
        {

        }
    }
}