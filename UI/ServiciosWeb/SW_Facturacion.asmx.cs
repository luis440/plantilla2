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
    /// Descripción breve de SW_Facturacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class SW_Facturacion : System.Web.Services.WebService
    {

        DA_Facturacion obj_DA = new DA_Facturacion();

        [WebMethod]
        public List<BE_Facturacion> Obtener_Series(int TIPO_DOCUMENTO)
        {
            return obj_DA.OBTENER_SERIES(TIPO_DOCUMENTO);
        }
        
  [WebMethod]
        public List<BE_Facturacion> Obtener_Tipo_Comprobantes()
        {
            return obj_DA.OBTENER_TIPO_COMPROBANTES();
        }
        [WebMethod]
        public List<BE_Facturacion> Obtener_Forma_Pago()
        {
            return obj_DA.OBTENER_FORMA_PAGO();
        }

        [WebMethod]
        public int Grabar(string TIPO_COMPROBANTE, string SERIE, string NRO_ORDEN, string FECHA,
     string MONEDA, string FORMA_PAGO, string TIPO_DOC_CLIENTE, string NUM_DOC_CLIENTE, string RAZON_SOCIAL, string DIRECCION,
     string DETALLE, string USUARIO_CREACION,string TOTAL_GENERAL,string TOTAL_IGV,string SUBTOTAL_GENERAL,string GLOSA,string FORMA_PAGO_DESCRIPCION)
        {
            return obj_DA.GRABAR(TIPO_COMPROBANTE, SERIE, NRO_ORDEN, FECHA,
      MONEDA,  FORMA_PAGO,  TIPO_DOC_CLIENTE,  NUM_DOC_CLIENTE,  RAZON_SOCIAL,  DIRECCION,
      DETALLE,  USUARIO_CREACION, TOTAL_GENERAL, TOTAL_IGV, SUBTOTAL_GENERAL, GLOSA, FORMA_PAGO_DESCRIPCION);
        }
        
            [WebMethod]
        public int Grabar_Nota(string TIPO_COMPROBANTE, string SERIE, string SERIE_FACURA, string NRO_FACURA, string FECHA_FACURA, string FECHA,
     string MONEDA, string FORMA_PAGO, string TIPO_DOC_CLIENTE, string NUM_DOC_CLIENTE, string RAZON_SOCIAL, string DIRECCION,
     string DETALLE, string USUARIO_CREACION, string TOTAL_GENERAL, string TOTAL_IGV, string SUBTOTAL_GENERAL,string GLOSA, string FORMA_PAGO_DESCRIPCION)
        {
            return obj_DA.GRABAR_NOTA(TIPO_COMPROBANTE, SERIE, SERIE_FACURA, NRO_FACURA,  FECHA_FACURA, FECHA,
      MONEDA, FORMA_PAGO, TIPO_DOC_CLIENTE, NUM_DOC_CLIENTE, RAZON_SOCIAL, DIRECCION,
      DETALLE, USUARIO_CREACION, TOTAL_GENERAL, TOTAL_IGV, SUBTOTAL_GENERAL, GLOSA, FORMA_PAGO_DESCRIPCION);
        }

        
               [WebMethod]
        public int Anular_Comprobante(int ID,string TIPO_COMPROBANTE,string SERIE,string NUMERO)
        {
            return obj_DA.ANULAR_COMPROBANTE(ID,TIPO_COMPROBANTE,SERIE,NUMERO);
        }
        [WebMethod]
        public List<BE_Facturacion> Buscar(string TIPO_COMPROBANTE, string SERIE, string NUMERO, string RAZON_SOCIAL, string ESTADO,string FECHA_INI,string FECHA_FIN)
        {
            return obj_DA.BUSCAR(TIPO_COMPROBANTE, SERIE, NUMERO, RAZON_SOCIAL, ESTADO, FECHA_INI, FECHA_FIN);
        }
        
             [WebMethod]
        public List<BE_Facturacion> Reporte_Ventas(string FEC_INI, string FEC_FIN, string RAZON_SOCIAL, string ESTADO)
        {
            return obj_DA.REPORTE_VENTAS(FEC_INI, FEC_FIN,RAZON_SOCIAL, ESTADO);
        }
        [WebMethod]
        public List<BE_Facturacion> Buscar_comprobantes(string TIPO_COMPROBANTE, string SERIE, string NUMERO, string RAZON_SOCIAL, string ESTADO, string FECHA_INI, string FECHA_FIN)
        {
            return obj_DA.BUSCAR_COMPROBANTES(TIPO_COMPROBANTE, SERIE, NUMERO, RAZON_SOCIAL, ESTADO, FECHA_INI, FECHA_FIN);
        }
        [WebMethod]
        public List<BE_Facturacion> Obtener(int ID)
        {
            return obj_DA.OBTENER(ID);
        }
        [WebMethod]
        public List<BE_Facturacion> Obtener_Detalle(int ID)
        {
            return obj_DA.OBTENER_DETALLE(ID);
        }

        
   [WebMethod]
        public List<BE_Facturacion> Imprimir(int ID)
        {
            return obj_DA.IMPRIMIR(ID);
        }

      
        /*
                [WebMethod]
                public int Eliminar(int ID)
                {
                    return obj_DA.ELIMINAR(ID);
                }

                [WebMethod]
                public int Grabar(int ID_CLIENTE, string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL,
                string FLAG_TRANSPORTE, string FLAG_CUADRILLA, string FLAG_RESGUARDO, string FLAG_AGE_ADUANA, string FLAG_AGE_CARGA, string FLAG_OTROS,
                string TRA_NUM_GR_REMITENTE, string TRA_NUM_GR_TRANSPORTE, string TRA_PLACA, string TRA_BREVETE, string TRA_DIRECCION_INICIO, string TRA_DIRECCION_LLEGADA,
                string TRA_TIPO_CARGA, string TRA_NUM_CONTENEDOR, string TRA_PESO, string TRA_FECHA_SERVICIO, string TRA_TIPO_BULTO, string TRA_NUM_BULTO, string CUAD_SERVICIO,
                string CUAD_DETALLE, string CUAD_LUGAR, string CUAD_NUM_PERSONAS, string RESG_PROVEEDOR, string RESG_RUTA, string AGE_ADU_ADUANA, string AGE_ADU_MANIFIESTO, string AGE_ADU_REGIMEN,
                string AGE_ADU_DAM, string AGE_ADU_CANAL, string AGE_ADU_EMPRESA, string AGE_ADU_FEC_ARRIBO, string AGE_ADU_FEC_RETIRO, string AGE_ADU_ALMACEN, string AGE_ADU_VALORFOB,
                string AGE_ADU_VALORCIF, string AGE_CAR_ADUANA, string AGE_CAR_MANIFIESTO, string AGE_CAR_PUERTO_ORIGEN, string AGE_CAR_PAIS, string AGE_CAR_EMP_TRANSP, string AGE_CAR_EMPRESA,
                string AGE_CAR_FEC_ARRIBO, string AGE_CAR_FEC_RETIRO, string AGE_CAR_PESO, string AGE_CAR_VOLUMEN, string AGE_CAR_NUM_BULTO, string AGE_CAR_ALMACEN, string OTRO_DETALLE,
                string OTRO_OBSERVACION, string USUARIO_CREACION)
                {
                    return obj_DA.GRABAR(ID_CLIENTE, TIPO_DOC, NUM_DOC, RAZON_SOCIAL,
                 FLAG_TRANSPORTE, FLAG_CUADRILLA, FLAG_RESGUARDO, FLAG_AGE_ADUANA, FLAG_AGE_CARGA, FLAG_OTROS,
                 TRA_NUM_GR_REMITENTE, TRA_NUM_GR_TRANSPORTE, TRA_PLACA, TRA_BREVETE, TRA_DIRECCION_INICIO, TRA_DIRECCION_LLEGADA,
                 TRA_TIPO_CARGA, TRA_NUM_CONTENEDOR, TRA_PESO, TRA_FECHA_SERVICIO, TRA_TIPO_BULTO, TRA_NUM_BULTO, CUAD_SERVICIO,
                 CUAD_DETALLE, CUAD_LUGAR, CUAD_NUM_PERSONAS, RESG_PROVEEDOR, RESG_RUTA, AGE_ADU_ADUANA, AGE_ADU_MANIFIESTO, AGE_ADU_REGIMEN,
                 AGE_ADU_DAM, AGE_ADU_CANAL, AGE_ADU_EMPRESA, AGE_ADU_FEC_ARRIBO, AGE_ADU_FEC_RETIRO, AGE_ADU_ALMACEN, AGE_ADU_VALORFOB,
                 AGE_ADU_VALORCIF, AGE_CAR_ADUANA, AGE_CAR_MANIFIESTO, AGE_CAR_PUERTO_ORIGEN, AGE_CAR_PAIS, AGE_CAR_EMP_TRANSP, AGE_CAR_EMPRESA,
                 AGE_CAR_FEC_ARRIBO, AGE_CAR_FEC_RETIRO, AGE_CAR_PESO, AGE_CAR_VOLUMEN, AGE_CAR_NUM_BULTO, AGE_CAR_ALMACEN, OTRO_DETALLE,
                 OTRO_OBSERVACION, USUARIO_CREACION);
                }


                [WebMethod]
                public int Actualizar(int ID, int ID_CLIENTE, string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL,
               string FLAG_TRANSPORTE, string FLAG_CUADRILLA, string FLAG_RESGUARDO, string FLAG_AGE_ADUANA, string FLAG_AGE_CARGA, string FLAG_OTROS,
               string TRA_NUM_GR_REMITENTE, string TRA_NUM_GR_TRANSPORTE, string TRA_PLACA, string TRA_BREVETE, string TRA_DIRECCION_INICIO, string TRA_DIRECCION_LLEGADA,
               string TRA_TIPO_CARGA, string TRA_NUM_CONTENEDOR, string TRA_PESO, string TRA_FECHA_SERVICIO, string TRA_TIPO_BULTO, string TRA_NUM_BULTO, string CUAD_SERVICIO,
               string CUAD_DETALLE, string CUAD_LUGAR, string CUAD_NUM_PERSONAS, string RESG_PROVEEDOR, string RESG_RUTA, string AGE_ADU_ADUANA, string AGE_ADU_MANIFIESTO, string AGE_ADU_REGIMEN,
               string AGE_ADU_DAM, string AGE_ADU_CANAL, string AGE_ADU_EMPRESA, string AGE_ADU_FEC_ARRIBO, string AGE_ADU_FEC_RETIRO, string AGE_ADU_ALMACEN, string AGE_ADU_VALORFOB,
               string AGE_ADU_VALORCIF, string AGE_CAR_ADUANA, string AGE_CAR_MANIFIESTO, string AGE_CAR_PUERTO_ORIGEN, string AGE_CAR_PAIS, string AGE_CAR_EMP_TRANSP, string AGE_CAR_EMPRESA,
               string AGE_CAR_FEC_ARRIBO, string AGE_CAR_FEC_RETIRO, string AGE_CAR_PESO, string AGE_CAR_VOLUMEN, string AGE_CAR_NUM_BULTO, string AGE_CAR_ALMACEN, string OTRO_DETALLE,
               string OTRO_OBSERVACION, string USUARIO_MODIFICACION, string ESTADO)
                {
                    return obj_DA.ACTUALIZAR(ID, ID_CLIENTE, TIPO_DOC, NUM_DOC, RAZON_SOCIAL,
                    FLAG_TRANSPORTE, FLAG_CUADRILLA, FLAG_RESGUARDO, FLAG_AGE_ADUANA, FLAG_AGE_CARGA, FLAG_OTROS,
                    TRA_NUM_GR_REMITENTE, TRA_NUM_GR_TRANSPORTE, TRA_PLACA, TRA_BREVETE, TRA_DIRECCION_INICIO, TRA_DIRECCION_LLEGADA,
                    TRA_TIPO_CARGA, TRA_NUM_CONTENEDOR, TRA_PESO, TRA_FECHA_SERVICIO, TRA_TIPO_BULTO, TRA_NUM_BULTO, CUAD_SERVICIO,
                    CUAD_DETALLE, CUAD_LUGAR, CUAD_NUM_PERSONAS, RESG_PROVEEDOR, RESG_RUTA, AGE_ADU_ADUANA, AGE_ADU_MANIFIESTO, AGE_ADU_REGIMEN,
                    AGE_ADU_DAM, AGE_ADU_CANAL, AGE_ADU_EMPRESA, AGE_ADU_FEC_ARRIBO, AGE_ADU_FEC_RETIRO, AGE_ADU_ALMACEN, AGE_ADU_VALORFOB,
                    AGE_ADU_VALORCIF, AGE_CAR_ADUANA, AGE_CAR_MANIFIESTO, AGE_CAR_PUERTO_ORIGEN, AGE_CAR_PAIS, AGE_CAR_EMP_TRANSP, AGE_CAR_EMPRESA,
                    AGE_CAR_FEC_ARRIBO, AGE_CAR_FEC_RETIRO, AGE_CAR_PESO, AGE_CAR_VOLUMEN, AGE_CAR_NUM_BULTO, AGE_CAR_ALMACEN, OTRO_DETALLE,
                    OTRO_OBSERVACION, USUARIO_MODIFICACION, ESTADO);
                }

                */


    }
}
