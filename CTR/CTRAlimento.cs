using DAO;
using DTO;

namespace CTR
{
    public class CTRAlimento
    {
        public DTOComida Select_Alimento(DTOB dtoBase)
        {
            return new DAOAlimento().Select_Alimento(dtoBase);
        }
    }
}
