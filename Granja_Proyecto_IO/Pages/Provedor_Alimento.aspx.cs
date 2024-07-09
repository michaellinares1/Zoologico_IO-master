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
    public partial class Provedor_Alimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAbastecedorComidas();
            }
        }

        public void cargarAbastecedorComidas()
        {
            DTOAbastecedor_Comida dTOAbastecedor_Comida = new DTOAbastecedor_Comida();
            dTOAbastecedor_Comida = new CTRAbastecedor_Comida().selectAbastecedorComida(dTOAbastecedor_Comida);
            if (string.IsNullOrEmpty(dTOAbastecedor_Comida.Msj))
            {
                string abastecedorComidas = string.Empty;
                for (int i = 0; i < dTOAbastecedor_Comida.aba_comidas.Count; i++)
                {
                    abastecedorComidas += @"<tr>
                                        <td>"
                                               + dTOAbastecedor_Comida.aba_comidas[i].comida + @"
                                        </td>
                                        <td>"
                                                + dTOAbastecedor_Comida.aba_comidas[i].abastecedor + @"
                                        </td>
                                        <td>"
                                                + dTOAbastecedor_Comida.aba_comidas[i].almMin + @"
                                        </td>
                                        <td>"
                                                + dTOAbastecedor_Comida.aba_comidas[i].almMax + @"
                                        </td>
                                        <td> <span class='kg'>"
                                                + dTOAbastecedor_Comida.aba_comidas[i].costoKg + @"
                                        </span></td>
                                   </tr>";
                }
                ltlProvedorAlimentos.Text = abastecedorComidas;
            }
        }
    }
}