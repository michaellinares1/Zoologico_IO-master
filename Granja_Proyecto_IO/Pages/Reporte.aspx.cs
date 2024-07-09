using System;
using CTR;
using DTO;

namespace Granja_Proyecto_IO.Pages
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPrecios();
            }
        }

        public void cargarPrecios()
        {
            DTOReporte dtoReporte = new DTOReporte();
            dtoReporte = new CTRReporte().Select_Reporte_Precio(dtoReporte);

            txtCostoPer1.InnerText = dtoReporte.costTemp1.ToString();
            txtCostoPer2.InnerText = dtoReporte.costTemp2.ToString();
            txtCostoPer3.InnerText = dtoReporte.costTemp3.ToString();

            hdnCostoFinal.Value = dtoReporte.costFin.ToString();
            hdnCost1.Value = dtoReporte.costTemp1.ToString();
            hdnCost2.Value = dtoReporte.costTemp2.ToString();
            hdnCost3.Value = dtoReporte.costTemp3.ToString();

        }
    }
}