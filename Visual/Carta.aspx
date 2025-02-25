<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carta.aspx.cs" Inherits="Visual.Carta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">

    <!-- Menú -->
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-12">
                <div class="accordion" id="accordionMenu">
                    <div class="accordion-item bg-dark border-dark rounded">
                        <h2 class="text-warning text-center fs-3 py-3">Menú</h2>
                        <div class="accordion-collapse collapse show">
                            <div class="accordion-body text-warning p-3" id="Bebidas" runat="server">
                                <h4 class="text-warning fs-5">Bebidas</h4>
                                <!-- Aquí se generan las bebidas -->
                            </div>
                            <div class="accordion-body text-warning p-3" id="Comidas" runat="server">
                                <h4 class="text-warning fs-5">Comidas</h4>
                                <!-- Aquí se generan las comidas -->
                            </div>
                            <div class="accordion-body text-warning p-3" id="Postres" runat="server">
                                <h4 class="text-warning fs-5">Postres</h4>
                                <!-- Aquí se generan los postres -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Sección de agregar productos -->
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-4">
                <div class="card bg-dark border-dark text-warning text-center p-4" id="CantidadProductos" runat="server">
                    <h4 class="fs-5">Agregar Producto:</h4>
                    <asp:Label ID="lblProducto" CssClass="text-success fs-3 form-label d-block" runat="server" Text="Producto"></asp:Label>
                    <div class="mb-3" >
                        <asp:Label ID="Label1" runat="server" CssClass="fs-5 mb-3 d-block" Text="Cantidad:"></asp:Label>
                        <div class="d-flex justify-content-center align-items-center gap-2">
                            <asp:Button ID="btnMenos" CssClass="btn btn-warning" runat="server" OnClick="btnMenos_Click" Text="-" />
                            <asp:Label ID="lblCantidad" runat="server" CssClass="fw-bold px-3 fs-4 text-warning" Text="1"></asp:Label>
                            <asp:Button ID="btnMas" CssClass="btn btn-warning" runat="server" OnClick="btnMas_Click" Text="+" />
                        </div>
                    </div>

                    <div class="d-flex justify-content-center gap-3">
                        <asp:Button ID="btnCancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
                        <asp:Button ID="btnAgregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" runat="server" Text="Agregar" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Botón de regresar centrado -->
    <div class="d-flex justify-content-center mt-3">
        <asp:Button ID="btnRegresar" CssClass="btn btn-warning mb-3" runat="server" OnClick="btnRegresar_Click" Visible="false" Text="Regresar" />
    </div>

    <!-- Mensaje de alerta centrado -->
    <div id="alert" class="alert alert-success text-center mt-3 w-50 mx-auto" role="alert" runat="server">
        ¡Agregado correctamente!
    </div>

</asp:Content>
