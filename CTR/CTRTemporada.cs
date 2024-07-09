using DAO;
using DTO;

namespace CTR
{
    public class CTRTemporada
    {
        public DTOTemporada selectTemporada(DTOB dtoBase)
        {
            return new DAOTemporada().selectTemporada(dtoBase);
        }
    }
}
