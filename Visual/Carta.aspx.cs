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
            ProductosDB productosDB = new ProductosDB();
            List<Producto> productos = productosDB.listarProductos();
            foreach (var item in productos)
            {
                Button btn = new Button();
                btn.Text = item.Nombre;
                btn.ID = item.Id.ToString();
                carta.Controls.Add(btn);
            }

        }
    }
}