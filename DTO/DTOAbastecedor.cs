using System.Collections.Generic;

namespace DTO
{
    public class DTOAbastecedor : DTOB
    {
        public int idAbastecedor { get; set; }
        public string categoria { get; set; }
        public int costoEnvio { get; set; }
        
        public List<DTOAbastecedor> abastecedores { get; set; }
    }
}
