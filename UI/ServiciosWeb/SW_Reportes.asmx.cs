using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DA;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Web.UI;

namespace UI.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de SW_Reportes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class SW_Reportes : System.Web.Services.WebService
    {
        DA_Reportes obj_DA = new DA_Reportes();

        [WebMethod]
        public List<BE_Reportes> Reporte_Salida(string FECHA_INICIO, string FECHA_FIN, string NRO_DOC, string NOMBRES, string NIVEL, string GRADO, string SECCION)
        {
            return obj_DA.REPORTE_SALIDA(FECHA_INICIO, FECHA_FIN, NRO_DOC,NOMBRES, NIVEL, GRADO, SECCION);
        }

       




    }
}
