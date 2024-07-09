using DAO;
using DTO;

namespace CTR
{
    public class CTRReporte
    {
        public DTOReporte Select_Reporte_Comida(DTOB dtoBase)
        {
            return new DAOReporte().Select_Reporte_Comida(dtoBase);
        }

        public DTOReporte Select_IngestaAnimales(DTOB dtoBase)
        {
            return new DAOReporte().Select_IngestaAnimales(dtoBase);
        }

        public DTOReporte Select_Reporte_Almacenamiento(DTOB dtoBase)
        {
            return new DAOReporte().Select_Reporte_Almacenamiento(dtoBase);
        }

        public DTOReporte Select_Reporte_Comida_Ingesta(DTOB dtoBase)
        {
            return new DAOReporte().Select_Reporte_Comida_Ingesta(dtoBase);
        }

        public DTOReporte Select_Reporte_Precio(DTOB dtoBase)
        {
            return new DAOReporte().Select_Reporte_Precio(dtoBase);
        }
    }
}
