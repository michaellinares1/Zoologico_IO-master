using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOAnimal_Comida : DTOB
    {
        public string animal { get; set;  }
        public string comida { get; set; }
        public decimal dietaKg { get; set; }
        public List<DTOAnimal_Comida> animalComidas { get; set; }

    }
}
