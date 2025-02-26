<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ABMMeseros.aspx.cs" Inherits="Visual.ABMMeseros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">

    <div class="container d-flex flex-column align-items-center mt-4 vh-100">
        <div class="row w-100">
            <div class="col-sm-12 col-md-6 mx-auto bg-dark rounded-3 p-3" id="divModificarMesero" runat="server">
                <h5 class="text-warning text-center">Modificar Mesero</h5>
                <div class="mb-3">
                    <label class="form-label text-warning">Mesero:</label>
                    <asp:DropDownList ID="ddlMeseros" runat="server" class="form-control btn btn-warning dropdown w-100" OnSelectedIndexChanged="ddlMeseros_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label text-warning">Nombre</label>
                    <asp:TextBox ID="txtNombreMesero" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label text-warning">Usuario</label>
                    <asp:TextBox ID="txtUsuarioMesero" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label text-warning">Contraseña</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtContrasenaMesero" type="password" runat="server" class="form-control"></asp:TextBox>
                        <button class="btn btn-outline-secondary" type="button" id="togglePassword">
                            <i class="bi bi-eye text-warning"></i>
                        </button>
                    </div>
                </div>
                <label id="lblErrorModificarUsuario" runat="server" visible="false" class="text-danger">Complete todos los campos</label>
                <div class="d-flex justify-content-center">
                    <asp:Button ID="btnEliminarMesero" runat="server" class="btn btn-danger m-1" Text="Eliminar" OnClick="btnEliminarMesero_Click"></asp:Button>
                    <asp:Button ID="btnModificarMesero" runat="server" class="btn btn-success m-1" Text="Modificar" OnClick="btnModificarMesero_Click"></asp:Button>
                </div>
                <div class="d-flex justify-content-center">
                    <asp:Button ID="btnMostrarNuevoMesero" runat="server" Text="Nuevo Mesero >" CssClass="btn btn-warning" OnClick="btnMostrarNuevoMesero_Click" />
                </div>
            </div>

            <div class="col-sm-12 col-md-6 mx-auto bg-dark rounded-3 p-3" id="divAgregarMesero" runat="server" visible="false">
                <h5 class="text-warning text-center">Nuevo Mesero</h5>
                <div class="mb-3">
                    <label class="form-label text-warning">Nombre</label>
                    <asp:TextBox ID="txtNombreNuevoMesero" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label text-warning">Usuario</label>
                    <asp:TextBox ID="txtUsuarioNuevoMesero" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label text-warning">Contraseña</label>
                    <asp:TextBox ID="txtContrasenaNuevoMesero" type="password" runat="server" class="form-control"></asp:TextBox>
                </div>
                <label id="lblErrorAgregarUsuario" runat="server" visible="false" class="text-danger">Complete todos los campos</label>
                <div class="d-flex justify-content-center">
                    <asp:Button ID="btnCancelarUsuario" runat="server" class="btn btn-secondary m-1" Text="Cancelar" OnClick="btnCancelarUsuario_Click"></asp:Button>
                    <asp:Button ID="btnCrearUsuario" runat="server" class="btn btn-success m-1" Text="Crear" OnClick="btnCrearUsuario_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>



<!--Script para alternar visibilidad del campo de contraseña-->
<script>
    document.addEventListener("DOMContentLoaded", function () {
        let passwordField = document.getElementById("<%= txtContrasenaMesero.ClientID %>");
            let toggleButton = document.getElementById("togglePassword");

            toggleButton.addEventListener("click", function () {
                let icon = this.querySelector("i");

                if (passwordField.type === "password") {
                    passwordField.type = "text";
                    icon.classList.remove("bi-eye");
                    icon.classList.add("bi-eye-slash");
                } else {
                    passwordField.type = "password";
                    icon.classList.remove("bi-eye-slash");
                    icon.classList.add("bi-eye");
                }
            });
        });
</script>
</asp:Content>
