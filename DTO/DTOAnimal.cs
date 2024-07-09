using System.Collections.Generic;

namespace DTO
{
    public class DTOAnimal : DTOB
    {
        public int idAnimal { get; set; }
        public string nombre { get; set; }
        public string alerta { get; set; }
        public List<DTOAnimal> animales { get; set; }
    }
}
