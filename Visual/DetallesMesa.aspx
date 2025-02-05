<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetallesMesa.aspx.cs" Inherits="Visual.DetallesMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div>
        <asp:GridView runat="server" ID="dgvPedidos" CssClass="table"></asp:GridView>
    </div>
    <div class="d-grid gap-2 col-6 mx-auto">
        <asp:Button ID="btnAgregarPedido" CssClass="btn btn-warning m-2" Text="Agregar" runat="server" OnClick="btnAgregarPedido_Click" />
    </div>
</asp:Content>
