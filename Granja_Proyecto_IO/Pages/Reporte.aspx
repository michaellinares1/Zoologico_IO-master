<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Granja_Proyecto_IO.Pages.Reporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="top-title mb-5">
            <a href="../Inicio" class="back-to"><i class="icon-back mr-2"></i><span>Volver</span></a>
            <h3>Reporte</h3>
        </div>

        <section class="report-info">
            <div class="canvas mb-5">
                <canvas id="salesData"></canvas>
            </div>
            <div id="totalSales">
                <div class="circle mb-4">
                    <div id="creditSales" class="progressBar"></div>
                    <div class="info">
                        <h3><span runat="server" id="txtCostoPer1" class="price">1200</span></h3>
                        <span class="progressTitle">Costo Periodo 1</span>
                    </div>
                </div>
                <div class="circle mb-4">
                    <div id="channelSales" class="progressBar"></div>
                    <div class="info">
                        <h3><span runat="server" id="txtCostoPer2" class="price">1200</span></h3>
                        <span class="progressTitle">Costo Periodo 2</span>
                    </div>
                </div>
                <div class="circle">
                    <div id="directSales" class="progressBar"></div>
                    <div class="info">
                        <h3><span runat="server" id="txtCostoPer3" class="price">1200</span></h3>
                        <span class="progressTitle">Costo Periodo 3</span>
                    </div>
                </div>
            </div>
        </section>

        <section class="mb-4">
            <div class="row row-cols-1 row-cols-md-4">
                <div class="col mb-4">
                    <a href="Reporte/Alimento" class="card-ind p-4 h-100">
                        <span class="card-tit">Reporte Alimento</span>
                    </a>
                </div>
                <div class="col mb-4">
                    <a href="Reporte/Consumo" class="card-ind p-4 h-100">
                        <span class="card-tit">Consumo de Animales</span>
                    </a>
                </div>
                <div class="col mb-4">
                    <a href="Reporte/Inventario" class="card-ind p-4 h-100">
                        <span class="card-tit">Reporte Inventario</span>
                    </a>
                </div>
            </div>
        </section>
    </div>
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnCostoFinal" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnCost1" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnCost2" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnCost3" />
    <script src="../js/reporte.js"></script>
</asp:Content>
