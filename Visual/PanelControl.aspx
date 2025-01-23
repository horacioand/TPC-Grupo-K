<%@ Page Title="Panel de control" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PanelControl.aspx.cs" Inherits="Visual.PanelControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <h3 class="contenedor">Panel de control</h3>
    <div class="text-center contenedor">
        <div class="card text-center mb-3 margen" style="width: 18rem;">
            <div class="card-body divpanelcontrol">
                <h5 class="card-title">Meseros</h5>
                <asp:Button ID="btnAgregarMesero" CssClass="btn btn-primary margen" runat="server" Text="Agregar" />
                <asp:Button ID="btnModificarMesero" CssClass="btn btn-primary margen" runat="server" Text="Modificar" />
                <asp:Button ID="btnEliminarMesero" CssClass="btn btn-primary margen" runat="server" Text="Eliminar" />
            </div>
        </div>
        <div class="card text-center mb-3 margen" style="width: 18rem;">
            <div class="card-body divpanelcontrol">
                <h5 class="card-title">Platos</h5>
                <asp:Button ID="btnAgregarPlato" CssClass="btn btn-primary margen" runat="server" Text="Agregar" />
                <asp:Button ID="btnModificarPlato" CssClass="btn btn-primary margen" runat="server" Text="Modificar" />
                <asp:Button ID="btnEliminarPlato" CssClass="btn btn-primary margen" runat="server" Text="Eliminar" />
            </div>
        </div>
        <div class="card text-center mb-3 margen" style="width: 18rem;">
            <div class="card-body divpanelcontrol">
                <h5 class="card-title">Informes</h5>
                <asp:Button ID="btnVentas" CssClass="btn btn-primary margen" runat="server" Text="Ventas" />
            </div>
        </div>
    </div>
    <div class="d-grid gap-2 col-6 mx-auto">
        <asp:Button ID="btnAsignarMesas" CssClass="btn btn-primary margen" runat="server" Text="Asignar Mesas" />
    </div>
</asp:Content>
