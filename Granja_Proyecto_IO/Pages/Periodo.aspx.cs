using CTR;
using DTO;
using System;

namespace Granja_Proyecto_IO.Pages.Periodo
{
    public partial class Periodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTemporada();
            }
        }

        public void cargarTemporada()
        {
            DTOTemporada dtoTemporada = new DTOTemporada();
            dtoTemporada = new CTRTemporada().selectTemporada(dtoTemporada);
            if (string.IsNullOrEmpty(dtoTemporada.Msj))
            {
                string temporadas = string.Empty;
                for (int i = 0; i < dtoTemporada.temporadas.Count; i++)
                {
                    temporadas += @"<tr>
                                        <td>"
                                               + dtoTemporada.temporadas[i].idTemporada + @"
                                        </td>
                                        <td>"
                                                + dtoTemporada.temporadas[i].descripcion + @"
                                        </td>
                                   </tr>";
                }
                ltlPeriodos.Text = temporadas;
            }
        }
    }
}