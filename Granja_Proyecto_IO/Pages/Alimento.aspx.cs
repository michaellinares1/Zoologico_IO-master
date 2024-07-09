using System;
using CTR;
using DTO;

namespace Granja_Proyecto_IO.Pages.Alimento
{
    public partial class Animal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAlimento();
            }
        }
        public void cargarAlimento()
        {
            DTOComida dtoComida = new DTOComida();
            dtoComida = new CTRComida().Select_Comida(dtoComida);

            if (string.IsNullOrEmpty(dtoComida.Msj))
            {
                string comidas = string.Empty;
                for (int i = 0; i < dtoComida.comidas.Count; i++)
                {
                    comidas += @"<tr>
                                        <td><span>"
                                               + dtoComida.comidas[i].idComida + @"
                                        </span></td>
                                        <td><span>"
                                                + dtoComida.comidas[i].nombre + @"
                                        </span></td>
                                        <td> <span class='price'>"
                                                + dtoComida.comidas[i].costoRegist + @"
                                         </span></td>
                                   </tr>";
                }
               
                ltlAlimentos.Text = comidas;
            }
        }
    }
}