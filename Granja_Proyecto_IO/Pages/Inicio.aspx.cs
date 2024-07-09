using System;
using DTO;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Granja_Proyecto_IO.Pages
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GenerarSolucion()
        {
            DTOB dtoBase = new DTOB();
            CTRLingo ctrSol = new CTRLingo();
            //DtoPuntuacion dtoPuntuacion = new DtoPuntuacion();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try {
                ctrSol.Main(dtoBase);
                return js.Serialize(dtoBase);
            }
            catch (Exception)
            {
                return js.Serialize(dtoBase);
            }
        }
    }
}