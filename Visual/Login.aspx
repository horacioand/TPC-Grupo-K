<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Visual.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row">
    </div>
    <div class="row mt-5">
        <div class="col-5"></div>
        <div class="col-2 bg-primary rounded-3 d-flex flex-column align-items-center">
            <div class="mb-3">
                <h5 class="d-flex justify-content-center mt-2 text-light mt-3 mb-4">Iniciar Sesión</h5>
                <asp:Label for="usuario" class="form-label text-light" runat="server">Usuario</asp:Label>
                <asp:TextBox type="" class="form-control" ID="usuario" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label for="password" class="form-label text-light" runat="server">Contraseña</asp:Label>
                <input type="password" class="form-control mb-4" id="password">
            </div>
            <asp:Button type="submit" class="btn btn-primary bg-light text-dark mb-4" runat="server" Text="Ingresar"></asp:Button>
        </div>
        <div class="col-5"></div>
    </div>
</asp:Content>
