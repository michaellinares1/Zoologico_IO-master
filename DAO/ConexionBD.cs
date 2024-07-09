using System.Configuration;

namespace DAO
{
    public class ConexionBD
    {
        public string StrConL { get; set; }
        public string StrConI { get; set; }
        public string StrConMySQL { get; set; }
        #region Conexion
        public ConexionBD()
        {
            StrConL = ConfigurationManager.ConnectionStrings["ZOOLOGICO_IO_G6"].ConnectionString;
        }
        #endregion
    }
}
