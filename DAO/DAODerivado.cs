using DTO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAODerivado : DAOB
    {

        public DTOAbastecedor_Comida Select_Abastecedor_Comida(DTOB dtoBase)
        {
            DTOAbastecedor_Comida dto = (DTOAbastecedor_Comida)dtoBase;
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Abastecedor_Comida");
                List<DTOAbastecedor_Comida> listAbaComida = new List<DTOAbastecedor_Comida>();
                while (reader.Read())
                {
                    dto = new DTOAbastecedor_Comida()
                    {
                        comida = getValue("comida",reader).Value_String,
                        abastecedor = getValue("abastecedor", reader).Value_String,
                        almMin = getValue("almMin", reader).Value_Int64,
                        almMax = getValue("almMax", reader).Value_Int64,
                        costoKg = getValue("costoKg", reader).Value_Int64,
                    };
                    listAbaComida.Add(dto);
                }
                dto.aba_comidas = listAbaComida;
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error abastecedor comida";
            }
            objCn.Close();
            return dto;

        }

        public DTOAnimal_Comida Select_Animal_Comida(DTOB dtoBase)
        {
            DTOAnimal_Comida dto = (DTOAnimal_Comida)dtoBase;
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Animal_Comida");
                List<DTOAnimal_Comida> listAbaComida = new List<DTOAnimal_Comida>();
                while (reader.Read())
                {
                    dto = new DTOAnimal_Comida()
                    {
                        comida = getValue("comida", reader).Value_String,
                        animal = getValue("animal", reader).Value_String,
                        dietaKg = getValue("dieta", reader).Value_Int64,
                    };
                    listAbaComida.Add(dto);
                }
                dto.animalComidas = listAbaComida;
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error animal comida";
            }
            objCn.Close();
            return dto;
        }

        public DTOAnimal_Temporada Select_Animal_Temporada(DTOB dtoBase)
        {
            DTOAnimal_Temporada dto = (DTOAnimal_Temporada)dtoBase;
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "Select_Animal_Temporada");
                List<DTOAnimal_Temporada> listAnimalTemporada = new List<DTOAnimal_Temporada>();
                while (reader.Read())
                {
                    dto = new DTOAnimal_Temporada()
                    {
                        descripcion = getValue("descripcion", reader).Value_String,
                        animal = getValue("animal", reader).Value_String,
                        cantidadAnimal = getValue("cantidadAni", reader).Value_Int64,
                    };
                    listAnimalTemporada.Add(dto);
                }
                dto.animalTemporada = listAnimalTemporada;
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error animal comida";
            }
            objCn.Close();
            return dto;
        }

    }
}
