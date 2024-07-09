using DTO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOReporte : DAOB
    {
        public DTOReporte Select_Reporte_Comida(DTOB dtoBase)
        {
            DTOReporte dto = (DTOReporte)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                pr[0] = new SqlParameter("@msje", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Reporte_Comida", pr);
                if (pr[0].Value == null)
                {
                    List<DTOReporte> listReporte = new List<DTOReporte>();
                    while (reader.Read())
                    {
                        dto = new DTOReporte()
                        {
                            comida = getValue("nombre", reader).Value_String,
                            abastecedor = getValue("idAbastecedor", reader).Value_String,
                            temporada = getValue("descripcion", reader).Value_String,
                            kgAbastecidos = getValue("kgAbastecidos", reader).Value_Decimal,
                            costoComida = getValue("costoFinalComi", reader).Value_Decimal
                        };
                        listReporte.Add(dto);
                    }
                    dto.reportes = listReporte;
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
                dto.ErrorMsj = "Error Reporte";
            }
            objCn.Close();
            return dto;
        }
        public DTOReporte Select_Reporte_Comida_Ingesta(DTOB dtoBase)
        {
            DTOReporte dto = (DTOReporte)dtoBase;
            SqlParameter[] pr = new SqlParameter[5];
            try
            {
                pr[0] = new SqlParameter("@msje", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("@total", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                pr[2] = new SqlParameter("@ali1", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                pr[3] = new SqlParameter("@ali2", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                pr[4] = new SqlParameter("@ali3", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Reporte_Alimento_Consumo", pr);

                if (pr[0].Value != null)
                {
                    dto.totalComi = Convert.ToDecimal(pr[1].Value.ToString());
                    dto.comi1 = Convert.ToDecimal(pr[2].Value.ToString());
                    dto.comi2 = Convert.ToDecimal(pr[3].Value.ToString());
                    dto.comi3 = Convert.ToDecimal(pr[4].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error Reporte";
            }
            objCn.Close();
            return dto;
        }
        public DTOReporte Select_IngestaAnimales(DTOB dtoBase)
        {
            DTOReporte dto = (DTOReporte)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                pr[0] = new SqlParameter("@msje", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_IngestaAnimales", pr);
                if (pr[0].Value == null)
                {
                    List<DTOReporte> listReporte = new List<DTOReporte>();
                    while (reader.Read())
                    {
                        dto = new DTOReporte()
                        {
                            animal = getValue("nombre", reader).Value_String,
                            comida = getValue("nombre", reader).Value_String,
                            temporada = getValue("descripcion", reader).Value_String,
                            ingestaAni = getValue("ingestaAni", reader).Value_Decimal
                        };
                        listReporte.Add(dto);
                    }
                    dto.reportes = listReporte;
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
                dto.ErrorMsj = "Error Reporte";
            }
            objCn.Close();
            return dto;
        }

        public DTOReporte Select_Reporte_Almacenamiento(DTOB dtoBase)
        {
            DTOReporte dto = (DTOReporte)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                pr[0] = new SqlParameter("@msje", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Reporte_Almacenamiento", pr);
                if (pr[0].Value == null)
                {
                    List<DTOReporte> listReporte = new List<DTOReporte>();
                    while (reader.Read())
                    {
                        dto = new DTOReporte()
                        {
                            comida = getValue("nombre", reader).Value_String,
                            temporada = getValue("descripcion", reader).Value_String,
                            almacenamientoFin = getValue("almFinal", reader).Value_Decimal,
                            costoAlmacenamiento = getValue("costoFinalAlm", reader).Value_Decimal
                        };
                        listReporte.Add(dto);
                    }
                    dto.reportes = listReporte;
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
                dto.ErrorMsj = "Error Reporte";
            }
            objCn.Close();
            return dto;
        }

        public DTOReporte Select_Reporte_Precio(DTOB dtoBase)
        {
            DTOReporte dto = (DTOReporte)dtoBase;
            SqlParameter[] pr = new SqlParameter[4];
            try
            {
                pr[0] = new SqlParameter("@costFin", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("@costPer1", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                pr[2] = new SqlParameter("@costPer2", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                pr[3] = new SqlParameter("@costPer3", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Reporte_Costos", pr);
                //if (pr[0].Value != null)
                //{
                dto.costFin = Convert.ToDecimal(pr[0].Value);
                dto.costTemp1 = Convert.ToDecimal(pr[1].Value);
                dto.costTemp2 = Convert.ToDecimal(pr[2].Value);
                dto.costTemp3 = Convert.ToDecimal(pr[3].Value);
                //}
                //else if (pr[0].Value != null)
                //{
                //    dto.Msj = pr[0].Value.ToString();
                //}
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error Reporte";
            }
            objCn.Close();
            return dto;
        }
    }
}
