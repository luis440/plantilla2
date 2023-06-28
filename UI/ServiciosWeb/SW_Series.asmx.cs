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
    /// Descripción breve de SW_Series
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SW_Series : System.Web.Services.WebService
    {
        DA_Series obj_DA = new DA_Series();

        [WebMethod]
        public List<BE_Series> Obtener_Tipo_Comprobante()
        {
            return obj_DA.OBTENER_TIPO_COMPROBANTE();
        }

        [WebMethod]
        public List<BE_Series> Obtener_Empresa()
        {
            return obj_DA.OBTENER_EMPRESA();
        }

        [WebMethod]
        public int Grabar_Series(string TIPO_COMPROBANTE, string SERIE, string NUMERO,string USUARIO_CREACION)
        {
            return obj_DA.GRABAR_SERIES(TIPO_COMPROBANTE,SERIE,NUMERO,USUARIO_CREACION);
        }

        [WebMethod]
        public int Actualizar_Series(int ID, string TIPO_COMPROBANTE, string SERIE, string NUMERO, string USUARIO_MODIFICACION, string ESTADO)
        {
            return obj_DA.ACTUALIZAR_SERIES(ID,TIPO_COMPROBANTE,SERIE,NUMERO,USUARIO_MODIFICACION,ESTADO);
        }


        [WebMethod]
        public List<BE_Series> Obtener_Series(int ID)
        {
            return obj_DA.OBTENER_SERIES(ID);
        }

        [WebMethod]
        public List<BE_Series> Buscar_Series(string TIPO_COMPROBANTE, string SERIE,string ESTADO)
        {
            return obj_DA.BUSCAR_SERIES(TIPO_COMPROBANTE, SERIE, ESTADO);
        }

        [WebMethod]
        public int Eliminar_Serie(int ID)
        {
            return obj_DA.ELIMINAR_SERIE(ID);
        }



    }
}
