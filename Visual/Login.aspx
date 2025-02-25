<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Visual.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">

    <div class="container-fluid">
        <div class="row mt-4 d-flex justify-content-center">
            <div class="col-sm-10 col-md-3 bg-dark rounded-3 p-4">
                <h5 class="text-center text-warning mt-2 mb-4">Iniciar Sesión</h5>

                <div class="mb-3">
                    <asp:Label for="usuario" class="form-label text-warning" runat="server">Usuario</asp:Label>
                    <asp:TextBox ID="tbUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label for="password" class="form-label text-warning" runat="server">Contraseña</asp:Label>
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="d-grid">
                    <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-warning w-100" OnClick="btnIngresar_Click" Text="Ingresar"></asp:Button>
                </div>

                <asp:Label ID="lblError" CssClass="text-warning text-center d-block mt-3" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>


</asp:Content>
