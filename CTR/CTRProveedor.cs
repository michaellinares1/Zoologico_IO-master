using DAO;
using DTO;

namespace CTR
{
    public class CTRProveedor
    {
        public DTOProveedor selectAbastecedor(DTOB dtoBase)
        {
            return new DAOProveedor().selectAbastecedor(dtoBase);
        }
    }
}
