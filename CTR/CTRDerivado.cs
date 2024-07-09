using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTR
{
    public class CTRAbastecedor_Comida
    {
        public DTOAbastecedor_Comida selectAbastecedorComida(DTOB dtoBase)
        {
            return new DAODerivado().Select_Abastecedor_Comida(dtoBase);
        }

        public DTOAnimal_Comida selectAnimalComida(DTOB dtoBase)
        {
            return new DAODerivado().Select_Animal_Comida(dtoBase);
        }

        public DTOAnimal_Temporada selectAnimalTemporada(DTOB dtoBase)
        {
            return new DAODerivado().Select_Animal_Temporada(dtoBase);
        }
    }
}
