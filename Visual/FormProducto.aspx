<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="FormProducto.aspx.cs" Inherits="Visual.FormProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="col-3 bg-dark rounded-3">
            <div class="d-flex justify-content-center">
                <asp:Label runat="server" ID="lblCrearProducto" CssClass="form-label text-warning m-1 fs-4" Text="Crear Producto"></asp:Label>
            </div>
                <div class="mb-3 d-flex flex-column justify-content-center">
                    <label for="txtNombreProducto" class="form-label text-warning m-1">Producto:</label>
                    <asp:TextBox ID="txtNombreProducto" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3 d-flex flex-column justify-content-center">
                    <label for="txtNombreProducto" class="form-label text-warning m-1">Precio:</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3 d-flex flex-column justify-content-center">
                    <label for="txtUrlImagen" class="form-label text-warning m-1">Url Imagen:</label>
                    <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3 d-flex flex-column justify-content-center">
                    <label for="ddlCategoria" class="form-label text-warning m-1">Categoria:</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-warning dropdown w-100"></asp:DropDownList>
                </div>
                <div class="mb-3 d-flex flex-column justify-content-center">
                    <asp:Button CssClass="btn btn-danger mb-2" id="btnEliminarProducto" runat="server" visible="false" Text="Eliminar" />
                    <asp:Button CssClass="btn btn-warning" id="btnEnviarProducto" runat="server" Text="Crear" OnClick="btnEnviarProducto_Click"/>
                </div>
        </div>
        <div class="col-2"></div>
        <div class="col-3"></div>
        <div class="col-2"></div>
        
    </div>
</asp:Content>

