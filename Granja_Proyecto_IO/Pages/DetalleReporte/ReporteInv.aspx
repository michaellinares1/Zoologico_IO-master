<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ReporteInv.aspx.cs" Inherits="Granja_Proyecto_IO.Pages.DetalleReporte.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top-title mb-4">
        <a href="../Reporte" class="back-to"><i class="icon-back mr-2"></i> <span>Volver</span></a>
        <h3>Inventario</h3>
    </div>
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
                <th scope="col">Alimento</th>
                <th scope="col">Periodo</th>
                <th scope="col">Inventario</th>
                <th scope="col">Costo</th>
            </tr>
        </thead>
        <tbody class="text-center">
            <asp:Literal runat="server" ID="ltlInventario"></asp:Literal>
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
</asp:Content>
