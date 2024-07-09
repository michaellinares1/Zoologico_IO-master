using DAO;
using DTO;

namespace CTR
{
    public class CTRAnimal
    {
        public DTOAnimal selectAnimal(DTOB dtoBase)
        {
            return new DAOAnimal().selectAnimal(dtoBase);
        }
    }
}
