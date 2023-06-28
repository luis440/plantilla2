using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BE;
using DA;
namespace UI.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de SW_Plantilla
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class SW_Plantilla : System.Web.Services.WebService
    {
        DA_Plantilla obj_DA = new DA_Plantilla();

        [WebMethod]
        public List<BE_Alumnos> Obtener_Datos_Plantilla(string CODIGO)
        {
            return obj_DA.OBTENER_DATOS_PLANTILLA(CODIGO);
        }
    }
}
