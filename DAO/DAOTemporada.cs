using DTO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOTemporada : DAOB
    {
        public DTOTemporada selectTemporada(DTOB dtoBase)
        {
            DTOTemporada dto = (DTOTemporada)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Temporada", pr);
                List<DTOTemporada> listPeriodos = new List<DTOTemporada>();
                while (reader.Read())
                {
                    dto = new DTOTemporada()
                    {
                        idTemporada = getValue("idTemporada", reader).Value_Int32,
                        descripcion = getValue("descripcion", reader).Value_String
                    };
                    listPeriodos.Add(dto);
                }
                dto.temporadas = listPeriodos;
            }
            catch (Exception ex)
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
