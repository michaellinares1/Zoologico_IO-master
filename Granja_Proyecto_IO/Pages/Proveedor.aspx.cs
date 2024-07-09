using CTR;
using DTO;
using System;

namespace Granja_Proyecto_IO.Pages.Proveedor
{
    public partial class Proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProveedor();
            }
        }

        public void cargarProveedor()
        {
            DTOAbastecedor dtoAbastecedor = new DTOAbastecedor();
            dtoAbastecedor = new CTRAbastecedor().selectAbastecedor(dtoAbastecedor);
            if (string.IsNullOrEmpty(dtoAbastecedor.Msj))
            {
                string abastecedores = string.Empty;
                for (int i = 0; i < dtoAbastecedor.abastecedores.Count; i++)
                {
                    abastecedores += @"<tr>
                                        <td>"
                                               + dtoAbastecedor.abastecedores[i].idAbastecedor + @"
                                        </td>
                                        <td>"
                                               + dtoAbastecedor.abastecedores[i].categoria + @"
                                        </td>
                                        <td> <span class='price'>"
                                                + dtoAbastecedor.abastecedores[i].costoEnvio+ @"
                                        </span></td>
                                        
                                   </tr>";
                }
                ltlProveedores.Text = abastecedores;
            }
        }
    }
}