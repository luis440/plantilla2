using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DA;
using BE;

namespace UI.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de SW_Tipo_Cambio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class SW_Tipo_Cambio : System.Web.Services.WebService
    {

        DA_Tipo_Cambio obj_DA = new DA_Tipo_Cambio();

        

        [WebMethod]
        public int Grabar(string MONEDA, string FECHA, string COMPRA,string VENTA, string USUARIO_CREACION)
        {
            return obj_DA.GRABAR(MONEDA,FECHA,COMPRA,VENTA,USUARIO_CREACION);
        }

        [WebMethod]
        public int Actualizar(int ID, string MONEDA, string FECHA, string COMPRA, string VENTA, string USUARIO_MODIFICACION)
        {
            return obj_DA.ACTUALIZAR(ID, MONEDA,FECHA,COMPRA,VENTA, USUARIO_MODIFICACION);
        }


        [WebMethod]
        public List<BE_Tipo_Cambio> Obtener(int ID)
        {
            return obj_DA.OBTENER(ID);
        }

        [WebMethod]
        public List<BE_Tipo_Cambio> Buscar(string MONEDA, string FECHA)
        {
            return obj_DA.BUSCAR(MONEDA,FECHA);
        }


    }
}
