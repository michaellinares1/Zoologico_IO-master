using DTO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOAnimal : DAOB
    {
        public DTOAnimal selectAnimal(DTOB dtoBase)
        {
            DTOAnimal dto = (DTOAnimal)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_AnimalTipo", pr);
                List<DTOAnimal> listAnimales = new List<DTOAnimal>();
                while (reader.Read())
                {
                    dto = new DTOAnimal()
                    {
                        idAnimal = getValue("idAnimal", reader).Value_Int32,
                        nombre = getValue("nombre", reader).Value_String
                    };
                    listAnimales.Add(dto);
                }
                dto.animales = listAnimales;
            }catch(Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error alimento";
            }
            objCn.Close();
            return dto;
        }
    }
}
