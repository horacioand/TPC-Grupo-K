<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AsignacionMesas.aspx.cs" Inherits="Visual.AsignacionMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .asignarDiv {
            display: flex;
            justify-content: center;
        }
        .itemsAsignar {
            display: flex;
            flex-direction: column;
            align-items: center;
            background-color: #212529;
            color: #ffc107;
            border-radius: 8px;
            border: 1px solid white;
            width: 200px;
        }
        .margen {
            margin: 15px;
        }
    </style>
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
        <% foreach (var mesa in ListaMesas)
            {%>
        <div class="col d-flex justify-content-center">
            <div class="card m-3" style="width: 18rem;">
                <div class="rounded card-body text-center bg-dark">
                    <h5 class="card-title text-warning">Mesa <%: mesa.Numero %></h5>
                    <p class="card-text text-warning mb-0">Mesero:</p>
                    <p class="card-text text-warning"><%:mesa.Mesero.Nombre %></p>
                </div>
            </div>
        </div>
        <% } %>
    </div>
    <div class="asignarDiv">
        <div class="itemsAsignar">
            <asp:Label ID="lblMesa" runat="server" CssClass="form-label" Text="Mesa: "></asp:Label>
            <asp:DropDownList ID="ddlMesas" runat="server" CssClass=""></asp:DropDownList>
            <asp:Label ID="lblMesero" runat="server" CssClass="form-label" Text="Mesero: "></asp:Label>
            <asp:DropDownList ID="ddlMeseros" runat="server" CssClass=""></asp:DropDownList>
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" OnClick="btnAsignar_Click" CssClass="btn btn-warning margen" />
        </div>
    </div>
</asp:Content>
