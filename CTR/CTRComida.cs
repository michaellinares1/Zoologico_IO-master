using DAO;
using DTO;

namespace CTR
{
    public class CTRComida
    {
        public DTOComida Select_Comida(DTOB dtoBase)
        {
            return new DAOComida().Select_Comida(dtoBase);
        }
    }
}
