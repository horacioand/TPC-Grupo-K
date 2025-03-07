﻿<%@ Page Title="Panel de control" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PanelControl.aspx.cs" Inherits="Visual.PanelControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <h3 class="contenedor">Panel de control</h3>
    <div class="text-center contenedor">
        <div class="card text-center mb-3 margen bg-dark" style="width: 18rem;">
            <div class="card-body divpanelcontrol">
                <h5 class="card-title gap-2 text-light">Meseros</h5>
                <asp:Button ID="btnAMBMesero" CssClass="btn btn-warning m-2" runat="server" Text="Editar" onclick="btnAMBMesero_Click"/>
            </div>
        </div>
        <div class="card text-center mb-3 margen bg-dark" style="width: 18rem;">
            <div class="card-body divpanelcontrol">
                <h5 class="card-title text-light">Platos</h5>
                <asp:Button ID="btnAMBPlato" CssClass="btn btn-warning m-2" runat="server" Text="Editar" OnClick="btnAMBPlato_Click" />
            </div>
        </div>
        <div class="card text-center mb-3 margen bg-dark" style="width: 18rem;">
            <div class="card-body divpanelcontrol">
                <h5 class="card-title text-light">Informes</h5>
                <asp:Button ID="btnVentas" OnClick="btnVentas_Click" CssClass="btn btn-warning m-2" runat="server" Text="Ventas" />
            </div>
        </div>
    </div>
    <div class="d-grid gap-2 col-6 mx-auto">
        <asp:Button ID="btnAsignarMesas" CssClass="btn btn-warning m-2" runat="server" Text="Asignar Mesas" OnClick="btnAsignarMesas_Click" />
    </div>
</asp:Content>
