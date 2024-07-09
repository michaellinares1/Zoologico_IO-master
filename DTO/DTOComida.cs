using System.Collections.Generic;

namespace DTO
{
    public class DTOComida : DTOB
    {
        public int idComida { get; set; }
        public string nombre { get; set; }
        public decimal costoRegist { get; set; }
        public List<DTOComida> comidas { get; set; }
    }
}
