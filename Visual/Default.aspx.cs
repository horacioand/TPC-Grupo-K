﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace Visual
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Mesa> ListaMesas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                MesaDB mesaDB = new MesaDB();
                PedidoDB pedidoDB = new PedidoDB();
                ListaMesas = mesaDB.listaAsignada(usuario.Id);
                Session["ListaMesas"] = ListaMesas;
            }
        }

        protected void dgvMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // Response.Redirect();
        }
    }
}