using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class DAOAbastecedor:DAOB
    {
         public DTOAbastecedor selectAbastecedor(DTOB dtoBase)
        {
            DTOAbastecedor dto = (DTOAbastecedor)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Abastecedor", pr);
            List<DTOAbastecedor> listAbastecedores = new List<DTOAbastecedor>();
            while (reader.Read())
            {
                dto = new DTOAbastecedor()
                {
                    idAbastecedor = getValue("idAbastecedor", reader).Value_Int32,
                    categoria = getValue("categoria", reader).Value_String,
                    costoEnvio = getValue("costoEnvio", reader).Value_Int32,
                };
                listAbastecedores.Add(dto);
            }
            dto.abastecedores = listAbastecedores;
            return dto;
        }
    }
}
