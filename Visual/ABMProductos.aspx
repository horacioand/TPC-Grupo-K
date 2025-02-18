<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ABMProductos.aspx.cs" Inherits="Visual.ABMProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6 d-flex justify-content-between">
            <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="btn btn-warning dropdown w-25 m-2 ms-0">
            </asp:DropDownList>
            <asp:Button ID="btnAgregarProducto" runat="server" Text="Nuevo Producto" CssClass="btn btn-warning m-2 me-0" OnClick="btnAgregarProducto_Click" />
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
                    <asp:BoundField HeaderText="UrlImagen" DataField="Imagen" />
                    <asp:BoundField HeaderText="Categoria" DataField="IdCategoria" />
                    <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="➡" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
