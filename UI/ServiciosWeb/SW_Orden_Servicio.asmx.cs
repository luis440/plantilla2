using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DA;
using BE;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Newtonsoft.Json;
namespace UI.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de SW_Orden_Servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class SW_Orden_Servicio : System.Web.Services.WebService
    {

        DA_Orden_Servicio obj_DA = new DA_Orden_Servicio();
        [WebMethod]
        public List<BE_Orden_Servicio> Buscar(string TIPO_SERVICIO, string NRO_ORDEN_SERVICIO,string RAZON_SOCIAL,string ESTADO)
        {
            return obj_DA.BUSCAR(TIPO_SERVICIO,NRO_ORDEN_SERVICIO,RAZON_SOCIAL,ESTADO);
        }
        
             [WebMethod]
        public List<BE_Orden_Servicio> Buscar_Orden_servicio(string TIPO_SERVICIO, string NRO_ORDEN_SERVICIO, string RAZON_SOCIAL, string ESTADO)
        {
            return obj_DA.BUSCAR_ORDEN_SERVICIO(TIPO_SERVICIO, NRO_ORDEN_SERVICIO, RAZON_SOCIAL, ESTADO);
        }
        [WebMethod]
        public List<BE_Orden_Servicio> Obtener(int ID)
        {
            return obj_DA.OBTENER(ID);
        }
        
             [WebMethod]
        public List<BE_Orden_Servicio> Obtener_Detalle(int ID)
        {
            return obj_DA.OBTENER_DETALLE(ID);
        }
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
        string OTRO_OBSERVACION, string USUARIO_CREACION,
        string FLAG_TRANSPORTE1, string FLAG_TRANSPORTE2, string FLAG_TRANSPORTE3, string FLAG_TRANSPORTE4, string FLAG_TRANSPORTE5, string FLAG_TRANSPORTE6, string FLAG_TRANSPORTE7,
        string FLAG_TRANSPORTE8, string FLAG_TRANSPORTE9,
        string TRA_NUM_GR_REMITENTE1, string TRA_NUM_GR_TRANSPORTE1, string TRA_PLACA1, string TRA_BREVETE1, string TRA_DIRECCION_INICIO1, string TRA_DIRECCION_LLEGADA1,
        string TRA_TIPO_CARGA1, string TRA_NUM_CONTENEDOR1, string TRA_PESO1, string TRA_FECHA_SERVICIO1, string TRA_TIPO_BULTO1, string TRA_NUM_BULTO1,
        string TRA_NUM_GR_REMITENTE2, string TRA_NUM_GR_TRANSPORTE2, string TRA_PLACA2, string TRA_BREVETE2, string TRA_DIRECCION_INICIO2, string TRA_DIRECCION_LLEGADA2,
        string TRA_TIPO_CARGA2, string TRA_NUM_CONTENEDOR2, string TRA_PESO2, string TRA_FECHA_SERVICIO2, string TRA_TIPO_BULTO2, string TRA_NUM_BULTO2,
        string TRA_NUM_GR_REMITENTE3, string TRA_NUM_GR_TRANSPORTE3, string TRA_PLACA3, string TRA_BREVETE3, string TRA_DIRECCION_INICIO3, string TRA_DIRECCION_LLEGADA3,
        string TRA_TIPO_CARGA3, string TRA_NUM_CONTENEDOR3, string TRA_PESO3, string TRA_FECHA_SERVICIO3, string TRA_TIPO_BULTO3, string TRA_NUM_BULTO3,
        string TRA_NUM_GR_REMITENTE4, string TRA_NUM_GR_TRANSPORTE4, string TRA_PLACA4, string TRA_BREVETE4, string TRA_DIRECCION_INICIO4, string TRA_DIRECCION_LLEGADA4,
        string TRA_TIPO_CARGA4, string TRA_NUM_CONTENEDOR4, string TRA_PESO4, string TRA_FECHA_SERVICIO4, string TRA_TIPO_BULTO4, string TRA_NUM_BULTO4,
        string TRA_NUM_GR_REMITENTE5, string TRA_NUM_GR_TRANSPORTE5, string TRA_PLACA5, string TRA_BREVETE5, string TRA_DIRECCION_INICIO5, string TRA_DIRECCION_LLEGADA5,
        string TRA_TIPO_CARGA5, string TRA_NUM_CONTENEDOR5, string TRA_PESO5, string TRA_FECHA_SERVICIO5, string TRA_TIPO_BULTO5, string TRA_NUM_BULTO5,
        string TRA_NUM_GR_REMITENTE6, string TRA_NUM_GR_TRANSPORTE6, string TRA_PLACA6, string TRA_BREVETE6, string TRA_DIRECCION_INICIO6, string TRA_DIRECCION_LLEGADA6,
        string TRA_TIPO_CARGA6, string TRA_NUM_CONTENEDOR6, string TRA_PESO6, string TRA_FECHA_SERVICIO6, string TRA_TIPO_BULTO6, string TRA_NUM_BULTO6,
        string TRA_NUM_GR_REMITENTE7, string TRA_NUM_GR_TRANSPORTE7, string TRA_PLACA7, string TRA_BREVETE7, string TRA_DIRECCION_INICIO7, string TRA_DIRECCION_LLEGADA7,
        string TRA_TIPO_CARGA7, string TRA_NUM_CONTENEDOR7, string TRA_PESO7, string TRA_FECHA_SERVICIO7, string TRA_TIPO_BULTO7, string TRA_NUM_BULTO7,
        string TRA_NUM_GR_REMITENTE8, string TRA_NUM_GR_TRANSPORTE8, string TRA_PLACA8, string TRA_BREVETE8, string TRA_DIRECCION_INICIO8, string TRA_DIRECCION_LLEGADA8,
        string TRA_TIPO_CARGA8, string TRA_NUM_CONTENEDOR8, string TRA_PESO8, string TRA_FECHA_SERVICIO8, string TRA_TIPO_BULTO8, string TRA_NUM_BULTO8,
        string TRA_NUM_GR_REMITENTE9, string TRA_NUM_GR_TRANSPORTE9, string TRA_PLACA9, string TRA_BREVETE9, string TRA_DIRECCION_INICIO9, string TRA_DIRECCION_LLEGADA9,
        string TRA_TIPO_CARGA9, string TRA_NUM_CONTENEDOR9, string TRA_PESO9, string TRA_FECHA_SERVICIO9, string TRA_TIPO_BULTO9, string TRA_NUM_BULTO9)
        {
            return obj_DA.GRABAR( ID_CLIENTE,  TIPO_DOC,  NUM_DOC,  RAZON_SOCIAL,
         FLAG_TRANSPORTE,  FLAG_CUADRILLA,  FLAG_RESGUARDO,  FLAG_AGE_ADUANA,  FLAG_AGE_CARGA,  FLAG_OTROS,
         TRA_NUM_GR_REMITENTE,  TRA_NUM_GR_TRANSPORTE,  TRA_PLACA,  TRA_BREVETE,  TRA_DIRECCION_INICIO,  TRA_DIRECCION_LLEGADA,
         TRA_TIPO_CARGA,  TRA_NUM_CONTENEDOR,  TRA_PESO,  TRA_FECHA_SERVICIO,  TRA_TIPO_BULTO,  TRA_NUM_BULTO,  CUAD_SERVICIO,
         CUAD_DETALLE,  CUAD_LUGAR,  CUAD_NUM_PERSONAS,  RESG_PROVEEDOR,  RESG_RUTA,  AGE_ADU_ADUANA,  AGE_ADU_MANIFIESTO,  AGE_ADU_REGIMEN,
         AGE_ADU_DAM,  AGE_ADU_CANAL,  AGE_ADU_EMPRESA,  AGE_ADU_FEC_ARRIBO,  AGE_ADU_FEC_RETIRO,  AGE_ADU_ALMACEN,  AGE_ADU_VALORFOB,
         AGE_ADU_VALORCIF,  AGE_CAR_ADUANA,  AGE_CAR_MANIFIESTO,  AGE_CAR_PUERTO_ORIGEN,  AGE_CAR_PAIS,  AGE_CAR_EMP_TRANSP,  AGE_CAR_EMPRESA,
         AGE_CAR_FEC_ARRIBO,  AGE_CAR_FEC_RETIRO,  AGE_CAR_PESO,  AGE_CAR_VOLUMEN,  AGE_CAR_NUM_BULTO,  AGE_CAR_ALMACEN,  OTRO_DETALLE,
         OTRO_OBSERVACION,  USUARIO_CREACION, FLAG_TRANSPORTE1, FLAG_TRANSPORTE2, FLAG_TRANSPORTE3, FLAG_TRANSPORTE4, FLAG_TRANSPORTE5, FLAG_TRANSPORTE6, FLAG_TRANSPORTE7,
         FLAG_TRANSPORTE8, FLAG_TRANSPORTE9, 
         TRA_NUM_GR_REMITENTE1,  TRA_NUM_GR_TRANSPORTE1,  TRA_PLACA1,  TRA_BREVETE1,  TRA_DIRECCION_INICIO1,  TRA_DIRECCION_LLEGADA1,
         TRA_TIPO_CARGA1,  TRA_NUM_CONTENEDOR1,  TRA_PESO1,  TRA_FECHA_SERVICIO1,  TRA_TIPO_BULTO1,  TRA_NUM_BULTO1,
         TRA_NUM_GR_REMITENTE2,  TRA_NUM_GR_TRANSPORTE2,  TRA_PLACA2,  TRA_BREVETE2,  TRA_DIRECCION_INICIO2,  TRA_DIRECCION_LLEGADA2,
         TRA_TIPO_CARGA2,  TRA_NUM_CONTENEDOR2,  TRA_PESO2,  TRA_FECHA_SERVICIO2,  TRA_TIPO_BULTO2,  TRA_NUM_BULTO2,
         TRA_NUM_GR_REMITENTE3,  TRA_NUM_GR_TRANSPORTE3,  TRA_PLACA3,  TRA_BREVETE3,  TRA_DIRECCION_INICIO3,  TRA_DIRECCION_LLEGADA3,
         TRA_TIPO_CARGA3,  TRA_NUM_CONTENEDOR3,  TRA_PESO3,  TRA_FECHA_SERVICIO3,  TRA_TIPO_BULTO3,  TRA_NUM_BULTO3,
         TRA_NUM_GR_REMITENTE4,  TRA_NUM_GR_TRANSPORTE4,  TRA_PLACA4,  TRA_BREVETE4,  TRA_DIRECCION_INICIO4,  TRA_DIRECCION_LLEGADA4,
         TRA_TIPO_CARGA4,  TRA_NUM_CONTENEDOR4,  TRA_PESO4,  TRA_FECHA_SERVICIO4,  TRA_TIPO_BULTO4,  TRA_NUM_BULTO4,
         TRA_NUM_GR_REMITENTE5,  TRA_NUM_GR_TRANSPORTE5,  TRA_PLACA5,  TRA_BREVETE5,  TRA_DIRECCION_INICIO5,  TRA_DIRECCION_LLEGADA5,
         TRA_TIPO_CARGA5,  TRA_NUM_CONTENEDOR5,  TRA_PESO5,  TRA_FECHA_SERVICIO5,  TRA_TIPO_BULTO5,  TRA_NUM_BULTO5,
         TRA_NUM_GR_REMITENTE6,  TRA_NUM_GR_TRANSPORTE6,  TRA_PLACA6,  TRA_BREVETE6,  TRA_DIRECCION_INICIO6,  TRA_DIRECCION_LLEGADA6,
         TRA_TIPO_CARGA6,  TRA_NUM_CONTENEDOR6,  TRA_PESO6,  TRA_FECHA_SERVICIO6,  TRA_TIPO_BULTO6,  TRA_NUM_BULTO6,
         TRA_NUM_GR_REMITENTE7,  TRA_NUM_GR_TRANSPORTE7,  TRA_PLACA7,  TRA_BREVETE7,  TRA_DIRECCION_INICIO7,  TRA_DIRECCION_LLEGADA7,
         TRA_TIPO_CARGA7,  TRA_NUM_CONTENEDOR7,  TRA_PESO7,  TRA_FECHA_SERVICIO7,  TRA_TIPO_BULTO7,  TRA_NUM_BULTO7,
         TRA_NUM_GR_REMITENTE8,  TRA_NUM_GR_TRANSPORTE8,  TRA_PLACA8,  TRA_BREVETE8,  TRA_DIRECCION_INICIO8,  TRA_DIRECCION_LLEGADA8,
         TRA_TIPO_CARGA8,  TRA_NUM_CONTENEDOR8,  TRA_PESO8,  TRA_FECHA_SERVICIO8,  TRA_TIPO_BULTO8,  TRA_NUM_BULTO8,
         TRA_NUM_GR_REMITENTE9,  TRA_NUM_GR_TRANSPORTE9,  TRA_PLACA9,  TRA_BREVETE9,  TRA_DIRECCION_INICIO9,  TRA_DIRECCION_LLEGADA9,
         TRA_TIPO_CARGA9,  TRA_NUM_CONTENEDOR9,  TRA_PESO9,  TRA_FECHA_SERVICIO9,  TRA_TIPO_BULTO9,  TRA_NUM_BULTO9);
        }


        [WebMethod]
        public int Actualizar(int ID,int ID_CLIENTE, string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL,
       string FLAG_TRANSPORTE, string FLAG_CUADRILLA, string FLAG_RESGUARDO, string FLAG_AGE_ADUANA, string FLAG_AGE_CARGA, string FLAG_OTROS,
       string TRA_NUM_GR_REMITENTE, string TRA_NUM_GR_TRANSPORTE, string TRA_PLACA, string TRA_BREVETE, string TRA_DIRECCION_INICIO, string TRA_DIRECCION_LLEGADA,
       string TRA_TIPO_CARGA, string TRA_NUM_CONTENEDOR, string TRA_PESO, string TRA_FECHA_SERVICIO, string TRA_TIPO_BULTO, string TRA_NUM_BULTO, string CUAD_SERVICIO,
       string CUAD_DETALLE, string CUAD_LUGAR, string CUAD_NUM_PERSONAS, string RESG_PROVEEDOR, string RESG_RUTA, string AGE_ADU_ADUANA, string AGE_ADU_MANIFIESTO, string AGE_ADU_REGIMEN,
       string AGE_ADU_DAM, string AGE_ADU_CANAL, string AGE_ADU_EMPRESA, string AGE_ADU_FEC_ARRIBO, string AGE_ADU_FEC_RETIRO, string AGE_ADU_ALMACEN, string AGE_ADU_VALORFOB,
       string AGE_ADU_VALORCIF, string AGE_CAR_ADUANA, string AGE_CAR_MANIFIESTO, string AGE_CAR_PUERTO_ORIGEN, string AGE_CAR_PAIS, string AGE_CAR_EMP_TRANSP, string AGE_CAR_EMPRESA,
       string AGE_CAR_FEC_ARRIBO, string AGE_CAR_FEC_RETIRO, string AGE_CAR_PESO, string AGE_CAR_VOLUMEN, string AGE_CAR_NUM_BULTO, string AGE_CAR_ALMACEN, string OTRO_DETALLE,
       string OTRO_OBSERVACION, string USUARIO_MODIFICACION,string ESTADO,
       string FLAG_TRANSPORTE1, string FLAG_TRANSPORTE2, string FLAG_TRANSPORTE3, string FLAG_TRANSPORTE4, string FLAG_TRANSPORTE5, string FLAG_TRANSPORTE6, string FLAG_TRANSPORTE7,
        string FLAG_TRANSPORTE8, string FLAG_TRANSPORTE9,
        string TRA_NUM_GR_REMITENTE1, string TRA_NUM_GR_TRANSPORTE1, string TRA_PLACA1, string TRA_BREVETE1, string TRA_DIRECCION_INICIO1, string TRA_DIRECCION_LLEGADA1,
        string TRA_TIPO_CARGA1, string TRA_NUM_CONTENEDOR1, string TRA_PESO1, string TRA_FECHA_SERVICIO1, string TRA_TIPO_BULTO1, string TRA_NUM_BULTO1,
        string TRA_NUM_GR_REMITENTE2, string TRA_NUM_GR_TRANSPORTE2, string TRA_PLACA2, string TRA_BREVETE2, string TRA_DIRECCION_INICIO2, string TRA_DIRECCION_LLEGADA2,
        string TRA_TIPO_CARGA2, string TRA_NUM_CONTENEDOR2, string TRA_PESO2, string TRA_FECHA_SERVICIO2, string TRA_TIPO_BULTO2, string TRA_NUM_BULTO2,
        string TRA_NUM_GR_REMITENTE3, string TRA_NUM_GR_TRANSPORTE3, string TRA_PLACA3, string TRA_BREVETE3, string TRA_DIRECCION_INICIO3, string TRA_DIRECCION_LLEGADA3,
        string TRA_TIPO_CARGA3, string TRA_NUM_CONTENEDOR3, string TRA_PESO3, string TRA_FECHA_SERVICIO3, string TRA_TIPO_BULTO3, string TRA_NUM_BULTO3,
        string TRA_NUM_GR_REMITENTE4, string TRA_NUM_GR_TRANSPORTE4, string TRA_PLACA4, string TRA_BREVETE4, string TRA_DIRECCION_INICIO4, string TRA_DIRECCION_LLEGADA4,
        string TRA_TIPO_CARGA4, string TRA_NUM_CONTENEDOR4, string TRA_PESO4, string TRA_FECHA_SERVICIO4, string TRA_TIPO_BULTO4, string TRA_NUM_BULTO4,
        string TRA_NUM_GR_REMITENTE5, string TRA_NUM_GR_TRANSPORTE5, string TRA_PLACA5, string TRA_BREVETE5, string TRA_DIRECCION_INICIO5, string TRA_DIRECCION_LLEGADA5,
        string TRA_TIPO_CARGA5, string TRA_NUM_CONTENEDOR5, string TRA_PESO5, string TRA_FECHA_SERVICIO5, string TRA_TIPO_BULTO5, string TRA_NUM_BULTO5,
        string TRA_NUM_GR_REMITENTE6, string TRA_NUM_GR_TRANSPORTE6, string TRA_PLACA6, string TRA_BREVETE6, string TRA_DIRECCION_INICIO6, string TRA_DIRECCION_LLEGADA6,
        string TRA_TIPO_CARGA6, string TRA_NUM_CONTENEDOR6, string TRA_PESO6, string TRA_FECHA_SERVICIO6, string TRA_TIPO_BULTO6, string TRA_NUM_BULTO6,
        string TRA_NUM_GR_REMITENTE7, string TRA_NUM_GR_TRANSPORTE7, string TRA_PLACA7, string TRA_BREVETE7, string TRA_DIRECCION_INICIO7, string TRA_DIRECCION_LLEGADA7,
        string TRA_TIPO_CARGA7, string TRA_NUM_CONTENEDOR7, string TRA_PESO7, string TRA_FECHA_SERVICIO7, string TRA_TIPO_BULTO7, string TRA_NUM_BULTO7,
        string TRA_NUM_GR_REMITENTE8, string TRA_NUM_GR_TRANSPORTE8, string TRA_PLACA8, string TRA_BREVETE8, string TRA_DIRECCION_INICIO8, string TRA_DIRECCION_LLEGADA8,
        string TRA_TIPO_CARGA8, string TRA_NUM_CONTENEDOR8, string TRA_PESO8, string TRA_FECHA_SERVICIO8, string TRA_TIPO_BULTO8, string TRA_NUM_BULTO8,
        string TRA_NUM_GR_REMITENTE9, string TRA_NUM_GR_TRANSPORTE9, string TRA_PLACA9, string TRA_BREVETE9, string TRA_DIRECCION_INICIO9, string TRA_DIRECCION_LLEGADA9,
        string TRA_TIPO_CARGA9, string TRA_NUM_CONTENEDOR9, string TRA_PESO9, string TRA_FECHA_SERVICIO9, string TRA_TIPO_BULTO9, string TRA_NUM_BULTO9)
        {
            return obj_DA.ACTUALIZAR(ID,ID_CLIENTE,TIPO_DOC,NUM_DOC,RAZON_SOCIAL,
            FLAG_TRANSPORTE,FLAG_CUADRILLA,FLAG_RESGUARDO,FLAG_AGE_ADUANA,FLAG_AGE_CARGA,FLAG_OTROS,
            TRA_NUM_GR_REMITENTE,TRA_NUM_GR_TRANSPORTE,TRA_PLACA,TRA_BREVETE,TRA_DIRECCION_INICIO,TRA_DIRECCION_LLEGADA,
            TRA_TIPO_CARGA,TRA_NUM_CONTENEDOR,TRA_PESO,TRA_FECHA_SERVICIO,TRA_TIPO_BULTO,TRA_NUM_BULTO,CUAD_SERVICIO,
            CUAD_DETALLE,CUAD_LUGAR,CUAD_NUM_PERSONAS,RESG_PROVEEDOR,RESG_RUTA,AGE_ADU_ADUANA,AGE_ADU_MANIFIESTO,AGE_ADU_REGIMEN,
            AGE_ADU_DAM,AGE_ADU_CANAL,AGE_ADU_EMPRESA,AGE_ADU_FEC_ARRIBO,AGE_ADU_FEC_RETIRO,AGE_ADU_ALMACEN,AGE_ADU_VALORFOB,
            AGE_ADU_VALORCIF,AGE_CAR_ADUANA,AGE_CAR_MANIFIESTO,AGE_CAR_PUERTO_ORIGEN,AGE_CAR_PAIS,AGE_CAR_EMP_TRANSP,AGE_CAR_EMPRESA,
            AGE_CAR_FEC_ARRIBO,AGE_CAR_FEC_RETIRO,AGE_CAR_PESO,AGE_CAR_VOLUMEN,AGE_CAR_NUM_BULTO,AGE_CAR_ALMACEN,OTRO_DETALLE,
            OTRO_OBSERVACION,USUARIO_MODIFICACION,ESTADO,
             FLAG_TRANSPORTE1, FLAG_TRANSPORTE2, FLAG_TRANSPORTE3, FLAG_TRANSPORTE4, FLAG_TRANSPORTE5, FLAG_TRANSPORTE6, FLAG_TRANSPORTE7,
         FLAG_TRANSPORTE8, FLAG_TRANSPORTE9,
         TRA_NUM_GR_REMITENTE1, TRA_NUM_GR_TRANSPORTE1, TRA_PLACA1, TRA_BREVETE1, TRA_DIRECCION_INICIO1, TRA_DIRECCION_LLEGADA1,
         TRA_TIPO_CARGA1, TRA_NUM_CONTENEDOR1, TRA_PESO1, TRA_FECHA_SERVICIO1, TRA_TIPO_BULTO1, TRA_NUM_BULTO1,
         TRA_NUM_GR_REMITENTE2, TRA_NUM_GR_TRANSPORTE2, TRA_PLACA2, TRA_BREVETE2, TRA_DIRECCION_INICIO2, TRA_DIRECCION_LLEGADA2,
         TRA_TIPO_CARGA2, TRA_NUM_CONTENEDOR2, TRA_PESO2, TRA_FECHA_SERVICIO2, TRA_TIPO_BULTO2, TRA_NUM_BULTO2,
         TRA_NUM_GR_REMITENTE3, TRA_NUM_GR_TRANSPORTE3, TRA_PLACA3, TRA_BREVETE3, TRA_DIRECCION_INICIO3, TRA_DIRECCION_LLEGADA3,
         TRA_TIPO_CARGA3, TRA_NUM_CONTENEDOR3, TRA_PESO3, TRA_FECHA_SERVICIO3, TRA_TIPO_BULTO3, TRA_NUM_BULTO3,
         TRA_NUM_GR_REMITENTE4, TRA_NUM_GR_TRANSPORTE4, TRA_PLACA4, TRA_BREVETE4, TRA_DIRECCION_INICIO4, TRA_DIRECCION_LLEGADA4,
         TRA_TIPO_CARGA4, TRA_NUM_CONTENEDOR4, TRA_PESO4, TRA_FECHA_SERVICIO4, TRA_TIPO_BULTO4, TRA_NUM_BULTO4,
         TRA_NUM_GR_REMITENTE5, TRA_NUM_GR_TRANSPORTE5, TRA_PLACA5, TRA_BREVETE5, TRA_DIRECCION_INICIO5, TRA_DIRECCION_LLEGADA5,
         TRA_TIPO_CARGA5, TRA_NUM_CONTENEDOR5, TRA_PESO5, TRA_FECHA_SERVICIO5, TRA_TIPO_BULTO5, TRA_NUM_BULTO5,
         TRA_NUM_GR_REMITENTE6, TRA_NUM_GR_TRANSPORTE6, TRA_PLACA6, TRA_BREVETE6, TRA_DIRECCION_INICIO6, TRA_DIRECCION_LLEGADA6,
         TRA_TIPO_CARGA6, TRA_NUM_CONTENEDOR6, TRA_PESO6, TRA_FECHA_SERVICIO6, TRA_TIPO_BULTO6, TRA_NUM_BULTO6,
         TRA_NUM_GR_REMITENTE7, TRA_NUM_GR_TRANSPORTE7, TRA_PLACA7, TRA_BREVETE7, TRA_DIRECCION_INICIO7, TRA_DIRECCION_LLEGADA7,
         TRA_TIPO_CARGA7, TRA_NUM_CONTENEDOR7, TRA_PESO7, TRA_FECHA_SERVICIO7, TRA_TIPO_BULTO7, TRA_NUM_BULTO7,
         TRA_NUM_GR_REMITENTE8, TRA_NUM_GR_TRANSPORTE8, TRA_PLACA8, TRA_BREVETE8, TRA_DIRECCION_INICIO8, TRA_DIRECCION_LLEGADA8,
         TRA_TIPO_CARGA8, TRA_NUM_CONTENEDOR8, TRA_PESO8, TRA_FECHA_SERVICIO8, TRA_TIPO_BULTO8, TRA_NUM_BULTO8,
         TRA_NUM_GR_REMITENTE9, TRA_NUM_GR_TRANSPORTE9, TRA_PLACA9, TRA_BREVETE9, TRA_DIRECCION_INICIO9, TRA_DIRECCION_LLEGADA9,
         TRA_TIPO_CARGA9, TRA_NUM_CONTENEDOR9, TRA_PESO9, TRA_FECHA_SERVICIO9, TRA_TIPO_BULTO9, TRA_NUM_BULTO9);
        }

        
             [WebMethod]
        public int Grabar_Archivos(int ID, 
        string ARCHIVO1_NOMBRE_ORIGINAL, string ARCHIVO1_NOMBRE_GENERADO,string ARCHIVO1_RUTA,
        string ARCHIVO2_NOMBRE_ORIGINAL, string ARCHIVO2_NOMBRE_GENERADO,string ARCHIVO2_RUTA,
        string ARCHIVO3_NOMBRE_ORIGINAL, string ARCHIVO3_NOMBRE_GENERADO, string ARCHIVO3_RUTA,
        string ARCHIVO4_NOMBRE_ORIGINAL, string ARCHIVO4_NOMBRE_GENERADO, string ARCHIVO4_RUTA,
        string ARCHIVO5_NOMBRE_ORIGINAL, string ARCHIVO5_NOMBRE_GENERADO, string ARCHIVO5_RUTA,
        string ARCHIVO6_NOMBRE_ORIGINAL, string ARCHIVO6_NOMBRE_GENERADO, string ARCHIVO6_RUTA
)
        {
            return obj_DA.GRABAR_ARCHIVOS(ID,ARCHIVO1_NOMBRE_ORIGINAL,ARCHIVO1_NOMBRE_GENERADO,
          ARCHIVO1_RUTA,ARCHIVO2_NOMBRE_ORIGINAL,ARCHIVO2_NOMBRE_GENERADO,
          ARCHIVO2_RUTA,ARCHIVO3_NOMBRE_ORIGINAL,ARCHIVO3_NOMBRE_GENERADO,ARCHIVO3_RUTA,
         ARCHIVO4_NOMBRE_ORIGINAL,ARCHIVO4_NOMBRE_GENERADO,ARCHIVO4_RUTA,
         ARCHIVO5_NOMBRE_ORIGINAL,ARCHIVO5_NOMBRE_GENERADO,ARCHIVO5_RUTA,
         ARCHIVO6_NOMBRE_ORIGINAL,ARCHIVO6_NOMBRE_GENERADO,ARCHIVO6_RUTA);
        }
        [WebMethod]
        public List<BE_Orden_Servicio> Obtener_Archivos(int ID)
        {
            return obj_DA.OBTENER_ARCHIVOS(ID);
        }





        /* ARCHIVO 1 */
        [WebMethod]
        public void Subir_Imagen_Logo()
        {
            var fileName = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var countFiles = HttpContext.Current.Request.Files.Count;


                for (var i = 0; i <= countFiles - 1; i++)
                {
                    var g = Guid.NewGuid();
                    var httpPostedFile = HttpContext.Current.Request.Files[0].InputStream;
                    var nombre_archivo_original = HttpContext.Current.Request.Files[0].FileName;
                    var extension = HttpContext.Current.Request.Files[0].FileName.Split('.').GetValue(1);
                    
                    if (Convert.ToString(extension) == "pdf")
                    {
                        fileName = g.ToString() + "." + extension;

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                        var httpPostedFile2 = System.Web.HttpContext.Current.Request.Files[0];
                        httpPostedFile2.SaveAs(fileSavePath);
                    }

                    else
                    {
                        var imagenOriginal = new Bitmap(httpPostedFile);
                        //var imagenRedimensionada = ScaleImage(imagenOriginal, 942, 530);
                        //using (var gr = Graphics.FromImage(imagenRedimensionada))
                        //{
                        //    gr.DrawImage(imagenOriginal, 0, 0, imagenRedimensionada.Width, imagenRedimensionada.Height);
                        //}

                        using (imagenOriginal)
                        {
                            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            var myEncoder = Encoder.Quality;
                            var myEncoderParameters = new EncoderParameters(1);
                            var myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            fileName = g.ToString() + "." + extension;



                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                            imagenOriginal.Save(fileSavePath);

                        }


                    }






                    List<Datos_Archivo> lista = new List<Datos_Archivo>();


                    Datos_Archivo obj = new Datos_Archivo()
                    {
                        nombre_imagen_generado = fileName,
                        nombre_imagen_original = nombre_archivo_original,
                        ruta_imagen = "../Archivos/" + fileName
                    };

                    lista.Add(obj);


                    string output = JsonConvert.SerializeObject(obj);


                    HttpContext.Current.Response.ContentType = "application/json";
                    HttpContext.Current.Response.Write(output);
                }



            }

        }
        [WebMethod]
        public void Eliminar_Imagen_Logo()
        {
            HttpContext.Current.Response.Write("{}");
        }
        /***********************************************/

        /* ARCHIVO 2 */
        [WebMethod]
        public void Subir_Imagen_Fondo()
        {
            var fileName = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var countFiles = HttpContext.Current.Request.Files.Count;

                var g = Guid.NewGuid();
                var httpPostedFile = HttpContext.Current.Request.Files[0].InputStream;
                var nombre_archivo_original = HttpContext.Current.Request.Files[0].FileName;
                var extension = HttpContext.Current.Request.Files[0].FileName.Split('.').GetValue(1);
                for (var i = 0; i <= countFiles - 1; i++)
                {
                   

                  
                    //var imagenRedimensionada = ScaleImage(imagenOriginal, 942, 530);
                    //using (var gr = Graphics.FromImage(imagenRedimensionada))
                    //{
                    //    gr.DrawImage(imagenOriginal, 0, 0, imagenRedimensionada.Width, imagenRedimensionada.Height);
                    //}

                    if (Convert.ToString(extension) == "pdf")
                    {
                        fileName = g.ToString() + "." + extension;

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                        var httpPostedFile2 = System.Web.HttpContext.Current.Request.Files[0];
                        httpPostedFile2.SaveAs(fileSavePath);
                    }

                    else
                    {
                        var imagenOriginal = new Bitmap(httpPostedFile);
                        using (imagenOriginal)
                        {
                            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            var myEncoder = Encoder.Quality;
                            var myEncoderParameters = new EncoderParameters(1);
                            var myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            fileName = g.ToString() + "." + extension;



                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                            imagenOriginal.Save(fileSavePath);

                        }
                       
                    }

                }


                List<Datos_Archivo> lista = new List<Datos_Archivo>();


                Datos_Archivo obj = new Datos_Archivo()
                {
                    nombre_imagen_generado = fileName,
                    nombre_imagen_original = nombre_archivo_original,
                    ruta_imagen = "../Archivos/" + fileName
                };

                lista.Add(obj);


                string output = JsonConvert.SerializeObject(obj);


                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(output);






            }

        }
        [WebMethod]
        public void Eliminar_Imagen_Fondo()
        {
            HttpContext.Current.Response.Write("{}");
        }
        /***********************************************/


        /* ARCHIVO 3 */

        [WebMethod]
        public void Subir_Imagen_Archivo3()
        {
            var fileName = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var countFiles = HttpContext.Current.Request.Files.Count;

                var g = Guid.NewGuid();
                var httpPostedFile = HttpContext.Current.Request.Files[0].InputStream;
                var nombre_archivo_original = HttpContext.Current.Request.Files[0].FileName;
                var extension = HttpContext.Current.Request.Files[0].FileName.Split('.').GetValue(1);
                for (var i = 0; i <= countFiles - 1; i++)
                {

                    if (Convert.ToString(extension) == "pdf")
                    {
                        fileName = g.ToString() + "." + extension;

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                        var httpPostedFile2 = System.Web.HttpContext.Current.Request.Files[0];
                        httpPostedFile2.SaveAs(fileSavePath);
                    }

                    else
                    {
                        var imagenOriginal = new Bitmap(httpPostedFile);
                        using (imagenOriginal)
                        {
                            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            var myEncoder = Encoder.Quality;
                            var myEncoderParameters = new EncoderParameters(1);
                            var myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            fileName = g.ToString() + "." + extension;



                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                            imagenOriginal.Save(fileSavePath);

                        }

                    }

                }


                List<Datos_Archivo> lista = new List<Datos_Archivo>();


                Datos_Archivo obj = new Datos_Archivo()
                {
                    nombre_imagen_generado = fileName,
                    nombre_imagen_original = nombre_archivo_original,
                    ruta_imagen = "../Archivos/" + fileName
                };

                lista.Add(obj);


                string output = JsonConvert.SerializeObject(obj);


                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(output);






            }

        }
        [WebMethod]
        public void Eliminar_Imagen_Archivo3()
        {
            HttpContext.Current.Response.Write("{}");
        }
        /***********************************************/

        /* ARCHIVO 4 */

        [WebMethod]
        public void Subir_Imagen_Archivo4()
        {
            var fileName = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var countFiles = HttpContext.Current.Request.Files.Count;

                var g = Guid.NewGuid();
                var httpPostedFile = HttpContext.Current.Request.Files[0].InputStream;
                var nombre_archivo_original = HttpContext.Current.Request.Files[0].FileName;
                var extension = HttpContext.Current.Request.Files[0].FileName.Split('.').GetValue(1);
                for (var i = 0; i <= countFiles - 1; i++)
                {

                    if (Convert.ToString(extension) == "pdf")
                    {
                        fileName = g.ToString() + "." + extension;

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                        var httpPostedFile2 = System.Web.HttpContext.Current.Request.Files[0];
                        httpPostedFile2.SaveAs(fileSavePath);
                    }

                    else
                    {
                        var imagenOriginal = new Bitmap(httpPostedFile);
                        using (imagenOriginal)
                        {
                            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            var myEncoder = Encoder.Quality;
                            var myEncoderParameters = new EncoderParameters(1);
                            var myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            fileName = g.ToString() + "." + extension;



                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                            imagenOriginal.Save(fileSavePath);

                        }

                    }

                }


                List<Datos_Archivo> lista = new List<Datos_Archivo>();


                Datos_Archivo obj = new Datos_Archivo()
                {
                    nombre_imagen_generado = fileName,
                    nombre_imagen_original = nombre_archivo_original,
                    ruta_imagen = "../Archivos/" + fileName
                };

                lista.Add(obj);


                string output = JsonConvert.SerializeObject(obj);


                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(output);






            }

        }
        [WebMethod]
        public void Eliminar_Imagen_Archivo4()
        {
            HttpContext.Current.Response.Write("{}");
        }
        /***********************************************/


        /* ARCHIVO 5 */

        [WebMethod]
        public void Subir_Imagen_Archivo5()
        {
            var fileName = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var countFiles = HttpContext.Current.Request.Files.Count;

                var g = Guid.NewGuid();
                var httpPostedFile = HttpContext.Current.Request.Files[0].InputStream;
                var nombre_archivo_original = HttpContext.Current.Request.Files[0].FileName;
                var extension = HttpContext.Current.Request.Files[0].FileName.Split('.').GetValue(1);
                for (var i = 0; i <= countFiles - 1; i++)
                {

                    if (Convert.ToString(extension) == "pdf")
                    {
                        fileName = g.ToString() + "." + extension;

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                        var httpPostedFile2 = System.Web.HttpContext.Current.Request.Files[0];
                        httpPostedFile2.SaveAs(fileSavePath);
                    }

                    else
                    {
                        var imagenOriginal = new Bitmap(httpPostedFile);
                        using (imagenOriginal)
                        {
                            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            var myEncoder = Encoder.Quality;
                            var myEncoderParameters = new EncoderParameters(1);
                            var myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            fileName = g.ToString() + "." + extension;



                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                            imagenOriginal.Save(fileSavePath);

                        }

                    }

                }


                List<Datos_Archivo> lista = new List<Datos_Archivo>();


                Datos_Archivo obj = new Datos_Archivo()
                {
                    nombre_imagen_generado = fileName,
                    nombre_imagen_original = nombre_archivo_original,
                    ruta_imagen = "../Archivos/" + fileName
                };

                lista.Add(obj);


                string output = JsonConvert.SerializeObject(obj);


                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(output);






            }

        }
        [WebMethod]
        public void Eliminar_Imagen_Archivo5()
        {
            HttpContext.Current.Response.Write("{}");
        }
        /***********************************************/

        /* ARCHIVO 6 */

        [WebMethod]
        public void Subir_Imagen_Archivo6()
        {
            var fileName = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var countFiles = HttpContext.Current.Request.Files.Count;

                var g = Guid.NewGuid();
                var httpPostedFile = HttpContext.Current.Request.Files[0].InputStream;
                var nombre_archivo_original = HttpContext.Current.Request.Files[0].FileName;
                var extension = HttpContext.Current.Request.Files[0].FileName.Split('.').GetValue(1);
                for (var i = 0; i <= countFiles - 1; i++)
                {

                    if (Convert.ToString(extension) == "pdf")
                    {
                        fileName = g.ToString() + "." + extension;

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                        var httpPostedFile2 = System.Web.HttpContext.Current.Request.Files[0];
                        httpPostedFile2.SaveAs(fileSavePath);
                    }

                    else
                    {
                        var imagenOriginal = new Bitmap(httpPostedFile);
                        using (imagenOriginal)
                        {
                            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            var myEncoder = Encoder.Quality;
                            var myEncoderParameters = new EncoderParameters(1);
                            var myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            fileName = g.ToString() + "." + extension;



                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos"), fileName);
                            imagenOriginal.Save(fileSavePath);

                        }

                    }

                }


                List<Datos_Archivo> lista = new List<Datos_Archivo>();


                Datos_Archivo obj = new Datos_Archivo()
                {
                    nombre_imagen_generado = fileName,
                    nombre_imagen_original = nombre_archivo_original,
                    ruta_imagen = "../Archivos/" + fileName
                };

                lista.Add(obj);


                string output = JsonConvert.SerializeObject(obj);


                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(output);






            }

        }
        [WebMethod]
        public void Eliminar_Imagen_Archivo6()
        {
            HttpContext.Current.Response.Write("{}");
        }
        /***********************************************/
        public class Datos_Archivo
        {

            public string nombre_imagen_generado { get; set; }
            public string nombre_imagen_original { get; set; }
            public string ruta_imagen { get; set; }
        }


        public Bitmap ScaleImage(System.Drawing.Image OldImage, int TargetHeight, int TargetWidth)
        {
            int NewHeight = TargetHeight;
            int NewWidth = (int)(((float)NewHeight / (float)OldImage.Height) * (float)OldImage.Width);

            if (NewWidth > TargetWidth)
            {
                NewWidth = TargetWidth;
                NewHeight = (int)(((float)NewWidth / (float)OldImage.Width) * (float)OldImage.Height);
            }
            var result = new Bitmap(NewWidth, NewHeight);
            return result;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if ((codec.FormatID == format.Guid))
                {
                    return codec;
                }
            }
            return null;
        }


    }
}
