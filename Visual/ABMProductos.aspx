<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ABMProductos.aspx.cs" Inherits="Visual.ABMProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6 d-flex justify-content-between">
            <div class="mt-2 mb-2">
                <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="btn btn-warning dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="btnLimpiarFiltro" runat="server" Text="🧹" CssClass="btn btn-dark" OnClick="btnLimpiarFiltro_Click" />
            </div>
            <div class="mt-2 mb-2">
                <asp:Button ID="btnAgregarProducto" runat="server" Text="Nuevo Producto" CssClass="btn btn-warning" OnClick="btnAgregarProducto_Click" />
            </div>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <asp:GridView runat="server" ID="dgvProductos" CssClass="table table-dark text-bg-warning"
                DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
                OnPageIndexChanging="dgvProductos_PageIndexChanging" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    
                    <asp:BoundField HeaderText="Categoria" DataField="IdCategoria" />
                    <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍️" ControlStyle-CssClass="text-decoration-none" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
