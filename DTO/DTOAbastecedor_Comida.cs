using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOAbastecedor_Comida : DTOB
    {

        public string comida { get; set; }
        public string abastecedor { get; set; }
        public decimal almMin { get; set; }
        public decimal almMax { get; set; }
        public decimal costoKg { get; set; }
        public List<DTOAbastecedor_Comida> aba_comidas { get; set; }

    }
}
