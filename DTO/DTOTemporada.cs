using System.Collections.Generic;

namespace DTO
{
    public class DTOTemporada : DTOB
    {
        public int idTemporada { get; set; }
        public string descripcion { get; set; }
        public string msje { get; set; }
        public List<DTOTemporada> temporadas { get; set; }
    }
}
