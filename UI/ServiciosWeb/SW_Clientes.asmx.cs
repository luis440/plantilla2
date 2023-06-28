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
    /// Descripción breve de SW_Clientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class SW_Clientes : System.Web.Services.WebService
    {

        DA_Clientes obj_DA = new DA_Clientes();

        [WebMethod]
        public List<BE_Clientes> Buscar_Clientes(string TIPO_DOC, string NRO_DOC, string RAZON_SOCIAL, string ESTADO)
        {
            return obj_DA.BUSCAR_CLIENTES(TIPO_DOC, NRO_DOC, RAZON_SOCIAL, ESTADO);
        }

        [WebMethod]
        public int Eliminar_Clientes(int ID)
        {
            return obj_DA.ELIMINAR_CLIENTES(ID);
        }

        [WebMethod]
        public List<BE_Clientes> Obtener_Clientes(int ID)
        {
            return obj_DA.OBTENER_CLIENTES(ID);
        }

        [WebMethod]
        public int Grabar_Clientes(string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL, string DOMICILIO1,
                    string DOMICILIO2, string TELEFONO, string CELULAR, string CORREO, string USUARIO_CREACION,
                    string DEPARTAMENTO,string PROVINCIA, string DISTRITO, string OBSERVACION)
        {
            return obj_DA.GRABAR_CLIENTES( TIPO_DOC,  NUM_DOC,  RAZON_SOCIAL,  DOMICILIO1,
                     DOMICILIO2,  TELEFONO,  CELULAR,  CORREO, USUARIO_CREACION , DEPARTAMENTO,
                    PROVINCIA, DISTRITO, OBSERVACION);
        }


        [WebMethod]
        public int Actualizar_Clientes(int ID, string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL, string DOMICILIO1,
                    string DOMICILIO2, string TELEFONO, string CELULAR, string CORREO, string USUARIO_MODIFICACION,
                    string DEPARTAMENTO, string PROVINCIA, string DISTRITO, string OBSERVACION,string ESTADO)
        {
            return obj_DA.ACTUALIZAR_CLIENTES(ID, TIPO_DOC, NUM_DOC, RAZON_SOCIAL, DOMICILIO1,
                     DOMICILIO2, TELEFONO, CELULAR, CORREO, USUARIO_MODIFICACION, DEPARTAMENTO,
                    PROVINCIA, DISTRITO, OBSERVACION, ESTADO);
        }


        [WebMethod]
        public List<BE_Clientes> Obtener_Departamento()
        {
            return obj_DA.OBTENER_DEPARTAMENTO();
        }


        [WebMethod]
        public List<BE_Clientes> Obtener_Provincia(string DEPARTAMENTO)
        {
            return obj_DA.OBTENER_PROVINCIA(DEPARTAMENTO);
        }

        [WebMethod]
        public List<BE_Clientes> Obtener_Distrito(string DEPARTAMENTO, string PROVINCIA)
        {
            return obj_DA.OBTENER_DISTRITO(DEPARTAMENTO, PROVINCIA);
        }

    }
}
