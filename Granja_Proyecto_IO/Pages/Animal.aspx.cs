using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Granja_Proyecto_IO.Pages.Animal
{
    public partial class Animal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAnimal();
            }
        }

        public void cargarAnimal()
        {
            DTOAnimal dtoAnimal = new DTOAnimal();
            dtoAnimal = new CTRAnimal().selectAnimal(dtoAnimal);
            if (string.IsNullOrEmpty(dtoAnimal.Msj))
            {
                string animales = string.Empty;
                for (int i = 0; i < dtoAnimal.animales.Count; i++)
                {
                    animales += @"<tr>
                                        <td>"
                                               + dtoAnimal.animales[i].idAnimal + @"
                                        </td>
                                        <td>"
                                                + dtoAnimal.animales[i].nombre + @"
                                        </td>
                                   </tr>";
                }
                ltlAnimales.Text = animales;
            }
        }
    }
}