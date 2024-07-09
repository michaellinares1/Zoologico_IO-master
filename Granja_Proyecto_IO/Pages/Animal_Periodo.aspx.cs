using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Granja_Proyecto_IO.Pages
{
    public partial class Anima_Periodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAnimalTemporada();
            }
        }

        public void cargarAnimalTemporada()
        {
            DTOAnimal_Temporada dtoAnimalTemporada = new DTOAnimal_Temporada();
            dtoAnimalTemporada = new CTRAbastecedor_Comida().selectAnimalTemporada(dtoAnimalTemporada);
            if (string.IsNullOrEmpty(dtoAnimalTemporada.Msj))
            {
                string animalTemporada = string.Empty;
                for (int i = 0; i < dtoAnimalTemporada.animalTemporada .Count; i++)
                {
                    animalTemporada += @"<tr>
                                        <td>"
                                               + dtoAnimalTemporada.animalTemporada[i].descripcion + @"
                                        </td>
                                        <td>"
                                                + dtoAnimalTemporada.animalTemporada[i].animal + @"
                                        </td>
                                        <td>"
                                                + dtoAnimalTemporada.animalTemporada[i].cantidadAnimal + @"
                                        </td>
                                   </tr>";
                }
                ltlAnimalPeriodo.Text = animalTemporada;
            }
        }
    }
}