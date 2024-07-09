using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOAnimal_Temporada : DTOB
    {
        public string descripcion { get; set; }
        public string animal { get;set; }
        public decimal cantidadAnimal { get; set; }
        public List<DTOAnimal_Temporada> animalTemporada { get; set; }
         
    }
}
