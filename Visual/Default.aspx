<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Visual.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .sin-bordes-externos {
            border: none !important;
        }

        .margen {
            margin: 10px;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row row-cols-sm-1 row-cols-md-3 g-4 justify-content-center">
        <% foreach (Dominio.Mesa mesa in ListaMesas)
            { %>
        <div class="col d-flex justify-content-center">
            <div class="card m-3" style="width: 18rem;">
                <div class="rounded card-body text-center bg-dark">
                    <h5 class="card-title text-warning">Mesa <%: mesa.Numero %></h5>
                    <p class="card-text text-warning">Capacidad: <%: mesa.Capacidad %></p>
                    <p class="card-text text-warning">
                        <% if (mesa.IdPedido != 0)
                            {%>
                            Id de Pedido: <%: mesa.IdPedido.ToString() %>
                        <% }%>
                    </p>
                    <%if (mesa.Estado)
                        {%>
                    <a href="DetallesMesa.aspx?id=<%:mesa.Id %>" class="btn btn-success">Ver detalles </a>
                    <%}
                        else
                        {%>
                    <a href="DetallesMesa.aspx?id=<%:mesa.Id %>" class="btn btn-warning"> Abrir pedido </a>                    
                    <%} %>
                </div>
            </div>
        </div>
        <% } %>
    </div>
    <div class="d-grid gap-2 col-2 mx-auto">
        <asp:Button ID="btnCerrarSesion" CssClass="btn btn-danger m-2" Text="Cerrar sesion" runat="server" OnClick="btnCerrarSesion_Click" />
    </div>
</asp:Content>
