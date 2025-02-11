<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AsignacionMesas.aspx.cs" Inherits="Visual.AsignacionMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4 d-flex justify-content-center mt-2">
            <h3>Asignacion de Mesas</h3>
        </div>
        <div class="col-4"></div>

    </div>
    <div class="row">
        <% foreach (Dominio.Mesa mesa in ListaMesas)
            { %>
        <div class="col d-flex justify-content-center">
            <div class="card m-3" style="width: 18rem;">
                <div class="rounded card-body text-center bg-dark">
                    <h5 class="card-title text-warning">Mesa <%: mesa.Numero %></h5>
                    <p class="card-text text-warning mb-0">Mesero:</p>
                    <p class="card-text text-warning"><%:mesa.Mesero.Nombre %></p>
                    <asp:DropDownList ID="ddlMeseros" runat="server" OnSelectedIndexChanged="ddlMeseros_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Button ID="btnAsignar" runat="server" OnClick="btnAsignar_Click" Text="Asignar" CssClass="btn btn-warning" />
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
