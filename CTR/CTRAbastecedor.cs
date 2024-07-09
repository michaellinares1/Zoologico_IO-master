using DAO;
using DTO;

namespace CTR
{
    public class CTRAbastecedor
    {
        public DTOAbastecedor selectAbastecedor(DTOB dtoBase)
        {
            return new DAOAbastecedor().selectAbastecedor(dtoBase);
        }
    }
}
