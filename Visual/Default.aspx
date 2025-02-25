<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Visual.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">

    <div class="container">
        <div class="row d-flex justify-content-center">
            <% foreach (Dominio.Mesa mesa in ListaMesas)
                { %>
            <div class="col-12 col-sm-6 col-md-4 d-flex justify-content-center">
                <div class="card m-3 border-dark w-100">
                    <div class="rounded card-body text-center bg-dark">
                        <h5 class="card-title text-warning">Mesa <%: mesa.Numero %></h5>
                        <p class="card-text text-warning">Capacidad: <%: mesa.Capacidad %></p>
                        <p class="card-text text-warning">
                            <% if (mesa.IdPedido != 0)
                            { %>
                        Id de Pedido: <%: mesa.IdPedido.ToString() %>
                            <% } %>
                        </p>
                        <% if (mesa.Estado)
                        { %>
                        <a href="DetallesMesa.aspx?id=<%:mesa.Id %>" class="btn btn-success">Ver detalles</a>
                        <% }
                        else
                        { %>
                        <a href="DetallesMesa.aspx?id=<%:mesa.Id %>" class="btn btn-warning">Abrir pedido</a>
                        <% } %>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>
