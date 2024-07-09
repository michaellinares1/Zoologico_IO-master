using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOComida : DAOB
    {
        public DTOComida Select_Comida(DTOB dtoBase)
        {
            DTOComida dto = (DTOComida)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                pr[0] = new SqlParameter("@msje", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Comida", pr);
                if (pr[0].Value == null)
                {
                    List<DTOComida> listComida = new List<DTOComida>();
                    while (reader.Read())
                    {
                        dto = new DTOComida()
                        {
                            idComida = getValue("idComida", reader).Value_Int32,
                            nombre = getValue("nombre", reader).Value_String,
                            costoRegist = getValue("costoRegist", reader).Value_Decimal
                        };
                        listComida.Add(dto);
                    }
                    dto.comidas = listComida;
                }
                else if (pr[0].Value != null)
                {
                    dto.Msj = pr[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error comida";
            }
            objCn.Close();
            return dto;
        }
    }
}
