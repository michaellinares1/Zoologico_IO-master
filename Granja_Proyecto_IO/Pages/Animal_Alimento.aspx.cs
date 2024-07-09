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
    public partial class Animal_Alimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAnimalAlimento();
            }
        }

        public void cargarAnimalAlimento()
        {
            DTOAnimal_Comida dtoAnimalComida = new DTOAnimal_Comida();
            dtoAnimalComida = new CTRAbastecedor_Comida().selectAnimalComida(dtoAnimalComida);
            if (string.IsNullOrEmpty(dtoAnimalComida.Msj))
            {
                string animalComidas = string.Empty;
                for (int i = 0; i < dtoAnimalComida.animalComidas.Count; i++)
                {
                    animalComidas += @"<tr>
                                        <td>"
                                               + dtoAnimalComida.animalComidas[i].comida + @"
                                        </td>
                                        <td>"
                                                + dtoAnimalComida.animalComidas[i].comida + @"
                                        </td>
                                        <td> <span class='kg'>"
                                                + dtoAnimalComida.animalComidas[i].dietaKg + @"
                                        </span></td>
                                   </tr>";
                }
                ltlAnimalAlimento.Text = animalComidas;
            }
        }
    }
}