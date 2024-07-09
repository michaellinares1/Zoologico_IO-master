using System.Collections.Generic;

namespace DTO
{
    public class DTOReporte : DTOB
    {
        public string comida { get; set; }
        public string animal { get; set; }
        public string temporada { get; set; }
        public string abastecedor { get; set; }

        public decimal costFin { get; set; }
        public decimal costTemp1 { get; set; }
        public decimal costTemp2 { get; set; }
        public decimal costTemp3 { get; set; }
        public decimal ingestaAni { get; set; }
        public decimal kgAbastecidos { get; set; }
        public decimal costoComida { get; set; }
        public decimal almacenamientoFin { get; set; }
        public decimal costoAlmacenamiento { get; set; }

        public decimal totalComi { get; set; }
        public decimal comi1 { get; set; }
        public decimal comi2 { get; set; }
        public decimal comi3 { get; set; }

        public string msje { get; set; }
        public List<DTOReporte> reportes { get; set; }
    }
}
