using System;
using CTR;
using DTO;

namespace Granja_Proyecto_IO.Pages.DetalleReporte
{
    public partial class Inventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAlmacenamiento();
            }
        }

        public void cargarAlmacenamiento()
        {
            DTOReporte dtoReporte = new DTOReporte();
            dtoReporte = new CTRReporte().Select_Reporte_Almacenamiento(dtoReporte);

            if (string.IsNullOrEmpty(dtoReporte.Msj))
            {
                string reporte = string.Empty;
                for (int i = 0; i < dtoReporte.reportes.Count; i++)
                {
                    reporte += @"<tr>
                                        <td><span>"
                                               + dtoReporte.reportes[i].comida + @"
                                        </span></td>
                                        <td><span>"
                                                + dtoReporte.reportes[i].temporada + @"
                                        </span></td>
                                        <td> <span class='kg'>"
                                                + dtoReporte.reportes[i].almacenamientoFin + @"
                                         </span></td>
                                         <td> <span class='price'>"
                                                + dtoReporte.reportes[i].costoAlmacenamiento + @"
                                         </span></td>
                                   </tr>";
                }
                ltlInventario.Text = reporte;
            }
        }
    }
}