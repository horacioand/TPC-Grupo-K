<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ABMProductos.aspx.cs" Inherits="Visual.ABMProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6"><asp:DropDownList runat="server" ID="ddlCategorias" CssClass="btn btn-warning dropdown w-25 mb-2"></asp:DropDownList></div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <asp:GridView runat="server" ID="dgvProductos" CssClass="table table-dark text-bg-warning" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField HeaderText="UrlImagen" DataField="Imagen" />
                    <asp:BoundField HeaderText="Categoria" DataField="IdCategoria" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
