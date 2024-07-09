<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Consumo.aspx.cs" Inherits="Granja_Proyecto_IO.Pages.DetalleReporte.Consumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="top-title mb-4">
        <a href="../Reporte" class="back-to"><i class="icon-back mr-2"></i> <span>Volver</span></a>
        <h3>Consumo de Animales</h3>
    </div>
     <section class="report-info">
            <div class="canvas mb-5">
                <canvas id="consumo"></canvas>
            </div>
            <div id="totalSales">
                <div class="circle mb-4">
                    <div id="alimento1" class="progressBar"></div>
                    <div class="info">
                        <h3><span runat="server" id="txtAli1" class="kg">1200</span></h3>
                        <span class="progressTitle">Maiz</span>
                    </div>
                </div>
                <div class="circle mb-4">
                    <div id="alimento2" class="progressBar"></div>
                    <div class="info">
                        <h3><span runat="server" id="txtAli2" class="kg">1200</span></h3>
                        <span class="progressTitle">Soja</span>
                    </div>
                </div>
                <div class="circle">
                    <div id="alimento3" class="progressBar"></div>
                    <div class="info">
                        <h3><span runat="server" id="txtAli3" class="kg">1200</span></h3>
                        <span class="progressTitle">Hierba</span>
                    </div>
                </div>
            </div>
        </section>
      <div class="container">
        <div class="header_wrap">
            <div class="num_rows">
                <select class="form-control" name="state" id="maxRows">

                    <option value="10">10</option>
                    <option value="15">15</option>
                    <option value="20">20</option>
                    <option value="50">50</option>
                    <option value="70">70</option>
                    <option value="100">100</option>
                    <option value="5000">Show ALL Rows</option>
                </select>
            </div>
            <div class="tb_search">
                <input type="text" id="search_input_all" onkeyup="FilterkeyWord_all_table()" placeholder="Search.." class="form-control">
            </div>
        </div>
        <table class="table table-striped table-dark t-dark mt-5" id="table-items">
        <thead class="text-center">
            <tr>
                <th scope="col">Animal</th>
                <th scope="col">Alimento</th>
                <th scope="col">Periodo</th>
                <th scope="col">Consumo</th>
            </tr>
        </thead>
        <tbody class="text-center">
            <asp:Literal runat="server" ID="ltlConsumo"></asp:Literal>
        </tbody>
    </table>
        <div class="footer-wrap  mt-3">
            <!--		Start Pagination -->
            <div class="pagination-container">
                <nav>
                    <ul class="pagination">
                        <!--	Here the JS Function Will Add the Rows -->
                    </ul>
                </nav>
            </div>
            <div class="rows_count">Mostrando de 11 a 20 de 91 entradas</div>
        </div>
    </div>
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnTotalAli" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnAli1" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnAli2" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnAli3" />
    <script src="../js/consumo.js"></script>
</asp:Content>
