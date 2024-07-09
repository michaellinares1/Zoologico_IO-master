using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Granja_Proyecto_IO
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Inicio", "Inicio", "~/Pages/Inicio.aspx", true);
            routes.MapPageRoute("Alimento", "Alimento", "~/Pages/Alimento.aspx", true);
            routes.MapPageRoute("Animal", "Animal", "~/Pages/Animal.aspx", true);
            routes.MapPageRoute("Periodo", "Periodo", "~/Pages/Periodo.aspx", true);
            routes.MapPageRoute("Proveedor", "Proveedor", "~/Pages/Proveedor.aspx", true);
            routes.MapPageRoute("Reporte", "Reporte", "~/Pages/Reporte.aspx", true);

            routes.MapPageRoute("Provedor_Alimento", "Provedor_Alimento", "~/Pages/Provedor_Alimento.aspx", true);
            routes.MapPageRoute("Animal_Alimento", "Animal_Alimento", "~/Pages/Animal_Alimento.aspx", true);
            routes.MapPageRoute("Animal_Periodo", "Animal_Periodo", "~/Pages/Animal_Periodo.aspx", true);

            routes.MapPageRoute("Reporte/Abastecimiento", "Reporte/Alimento", "~/Pages/DetalleReporte/ReporteAli.aspx", true);
            routes.MapPageRoute("Reporte/Consumo", "Reporte/Consumo", "~/Pages/DetalleReporte/Consumo.aspx", true);
            routes.MapPageRoute("Reporte/Inventario", "Reporte/Inventario", "~/Pages/DetalleReporte/ReporteInv.aspx", true);
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}