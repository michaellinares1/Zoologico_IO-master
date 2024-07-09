using System;
using CTR;
using DTO;

namespace Granja_Proyecto_IO.Pages.DetalleReporte
{
    public partial class Consumo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReporteIngesta();
                cargarIngesta();
            }
        }
        public void CargarReporteIngesta()
        {
            DTOReporte dtoReporte = new DTOReporte();
            dtoReporte = new CTRReporte().Select_Reporte_Comida_Ingesta(dtoReporte);
            txtAli1.InnerText = dtoReporte.comi1.ToString();
            txtAli2.InnerText = dtoReporte.comi2.ToString();
            txtAli3.InnerText = dtoReporte.comi3.ToString();

            hdnTotalAli.Value = dtoReporte.totalComi.ToString();
            hdnAli1.Value = dtoReporte.comi1.ToString();
            hdnAli2.Value = dtoReporte.comi2.ToString();
            hdnAli3.Value = dtoReporte.comi3.ToString();
        }
        public void cargarIngesta()
        {
            DTOReporte dtoReporte = new DTOReporte();
            dtoReporte = new CTRReporte().Select_IngestaAnimales(dtoReporte);

            if (string.IsNullOrEmpty(dtoReporte.Msj))
            {
                string reporte = string.Empty;
                for (int i = 0; i < dtoReporte.reportes.Count; i++)
                {
                    reporte += @"<tr>
                                        <td><span>"
                                               + dtoReporte.reportes[i].animal + @"
                                        </span></td>
                                        <td><span>"
                                                + dtoReporte.reportes[i].comida + @"
                                        </span></td>
                                        <td><span>"
                                                + dtoReporte.reportes[i].temporada + @"
                                        </span></td>
                                        <td> <span class='kg'>"
                                                + dtoReporte.reportes[i].ingestaAni + @"
                                         </span></td>
                                   </tr>";
                }
               ltlConsumo.Text = reporte;
                
                
            }
        }
    }
}