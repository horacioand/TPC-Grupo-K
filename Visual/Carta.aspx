<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carta.aspx.cs" Inherits="Visual.Carta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row mt-5 justify-content-md-center">
        <div class="accordion col-8" id="accordionPanelsStayOpenExample">
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true" aria-controls="panelsStayOpen-collapseOne">
                        Bebidas
                    </button>
                </h2>
                <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse show">
                    <div class="accordion-body">
                        <!-- Aqui iran los alimentos de la carta, la idea es generar los botones dinamicamente en base a la lectura de la db -->

                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseThree" aria-expanded="false" aria-controls="panelsStayOpen-collapseThree">
                        Platillos
                    </button>
                </h2>
                <div id="panelsStayOpen-collapseThree" class="accordion-collapse collapse">
                    <div class="accordion-body">
                        <!-- Aqui iran los alimentos de la carta, la idea es generar los botones dinamicamente en base a la lectura de la db -->

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
