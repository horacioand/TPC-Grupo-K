using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace Visual
{
    public partial class CartaPublico : System.Web.UI.Page
    {
        public List<Producto> productos;
        public List<Producto> bebidas;
        public List<Producto> comidas;
        public List<Producto> postres;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                linkVovler.Visible = true;
            }

            ProductosDB productosDB = new ProductosDB();
            productos = productosDB.listarProductos();
            bebidas = productos.FindAll(x => x.IdCategoria == 1);
            comidas = productos.FindAll(x => x.IdCategoria == 2);
            postres = productos.FindAll(x => x.IdCategoria == 3);
        }
    }
}