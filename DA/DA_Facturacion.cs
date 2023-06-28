using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace DA
{
    public class DA_Facturacion
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        string conexion2 = ConfigurationManager.ConnectionStrings["conexion2"].ConnectionString;

        public List<BE_Facturacion> OBTENER_SERIES(int TIPO_DOCUMENTO)
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_SERIES", con))
                {
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_DOCUMENTO);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.SERIE = lector[1].ToString().Trim();


                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }
        public List<BE_Facturacion> OBTENER_TIPO_COMPROBANTES()
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_TIPO_COMPROBANTE", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.CODIGO = lector[0].ToString().Trim();
                        obj_BE.TIPO_COMPROBANTE = lector[1].ToString().Trim();


                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }
        public List<BE_Facturacion> OBTENER_FORMA_PAGO()
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_FORMA_PAGO", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.DESCRIPCION = lector[1].ToString().Trim();


                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }

        public int GRABAR(string TIPO_COMPROBANTE, string SERIE, string NRO_ORDEN, string FECHA,
         string MONEDA, string FORMA_PAGO, string TIPO_DOC_CLIENTE, string NUM_DOC_CLIENTE, string RAZON_SOCIAL, string DIRECCION,
         string DETALLE, string USUARIO_CREACION, string TOTAL_GENERAL, string TOTAL_IGV, string SUBTOTAL_GENERAL, string GLOSA, string FORMA_PAGO_DESCRIPCION)
        {

            Numero n = new Numero();




            int val = 0, val2 = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {
                    int ID, CORRELATIVO;

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_INSERTAR_FACTURACION_CAB";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", TIPO_COMPROBANTE);
                        cmd.Parameters.AddWithValue("@SERIE", SERIE);
                        cmd.Parameters.AddWithValue("@NUM_DOC_REL", NRO_ORDEN);
                        cmd.Parameters.AddWithValue("@FECHA", FECHA);
                        cmd.Parameters.AddWithValue("@MONEDA", MONEDA);
                        cmd.Parameters.AddWithValue("@FORMA_PAGO", FORMA_PAGO);
                        cmd.Parameters.AddWithValue("@TIPO_DOC_CLIENTE", TIPO_DOC_CLIENTE);
                        cmd.Parameters.AddWithValue("@NUM_DOC_CLIENTE", NUM_DOC_CLIENTE);
                        cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", RAZON_SOCIAL.Trim());
                        cmd.Parameters.AddWithValue("@DIRECCION_CLIENTE", DIRECCION.Trim());
                        cmd.Parameters.AddWithValue("@USUARIO_CREACION", USUARIO_CREACION);
                        cmd.Parameters.AddWithValue("@TOTAL_IGV", TOTAL_IGV.Trim());
                        cmd.Parameters.AddWithValue("@TOTAL_GENERAL", TOTAL_GENERAL.Trim());
                        cmd.Parameters.AddWithValue("@SUBTOTAL_GENERAL", SUBTOTAL_GENERAL.Trim());
                        cmd.Parameters.AddWithValue("@TOTAL_GENERAL_LETRAS", n.ConvertirAImporteLetras(TOTAL_GENERAL));
                        cmd.Parameters.AddWithValue("@GLOSA", GLOSA.Trim());
                        cmd.Parameters.Add("@ID_", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CORRELATIVO_", SqlDbType.Int).Direction = ParameterDirection.Output;

                        val = cmd.ExecuteNonQuery();

                        ID = Convert.ToInt32(cmd.Parameters["@ID_"].Value);
                        CORRELATIVO = Convert.ToInt32(cmd.Parameters["@CORRELATIVO_"].Value);
                        cmd.Parameters.Clear();




                        if (val >= 1)
                        {


                            #region Generando QR
                            //Variable que crea QR

                            var writer = new BarcodeWriter()
                            {
                                Format = BarcodeFormat.QR_CODE,
                                Options = new EncodingOptions()
                                {
                                    Height = 300,
                                    Width = 300,
                                    Margin = 1
                                }
                            };
                            writer.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.Q);
                            string tipo_docU = "";
                            if (TIPO_DOC_CLIENTE == "DNI")
                            {
                                tipo_docU = "1";
                            }
                            else if (TIPO_DOC_CLIENTE == "RUC")
                            {
                                tipo_docU = "6";
                            }
                            //Valor de QR
                            string valorQR = "20553080712" + "|" + TIPO_COMPROBANTE + "|" + SERIE + "|" + CORRELATIVO + "|" + TOTAL_IGV + "|" + TOTAL_GENERAL + "|" + FECHA + "|" + tipo_docU + "|" + NUM_DOC_CLIENTE;

                            //Generando QR como bytes
                            byte[] CodigoQR;
                            MemoryStream loFlujoMemoria = new MemoryStream();
                            writer.Write(valorQR).Save(loFlujoMemoria, ImageFormat.Jpeg);
                            CodigoQR = loFlujoMemoria.ToArray();

                            #endregion

                            cmd.CommandText = "SP_ACTUALIZAR_CODIGO_QR";
                            cmd.Transaction = transaccion;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_FACTURACION_CAB", ID);
                            cmd.Parameters.AddWithValue("@CODIGO_QR", CodigoQR);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            string[] valores = DETALLE.Split('ª');

                            foreach (string a in valores)
                            {
                                if (a != "")
                                {
                                    string[] valores2 = a.Split('º');

                                    val2 = 0;
                                    cmd.CommandText = "SP_INSERTAR_FACTURACION_DET";
                                    cmd.Transaction = transaccion;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@ID_FACTURACION_CAB", ID);
                                    cmd.Parameters.AddWithValue("@CORRELATIVO", valores2[0].ToString());
                                    cmd.Parameters.AddWithValue("@CODIGO", valores2[1].ToString());
                                    cmd.Parameters.AddWithValue("@SERVICIO", valores2[2].ToString());
                                    cmd.Parameters.AddWithValue("@UM", valores2[3].ToString());
                                    cmd.Parameters.AddWithValue("@CANTIDAD", valores2[4].ToString());
                                    cmd.Parameters.AddWithValue("@PRECIO", valores2[5].ToString());
                                    cmd.Parameters.AddWithValue("@IGV", valores2[6].ToString());
                                    cmd.Parameters.AddWithValue("@TOTAL", valores2[7].ToString());
                                    val2 = cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                } } }

                        //ENVIO AL FACTURADOR
                        //            int respuesta = GRABAR_FACTURACION_INTEGRACION(CORRELATIVO, TIPO_COMPROBANTE, SERIE, NRO_ORDEN, FECHA,
                        //MONEDA, FORMA_PAGO, TIPO_DOC_CLIENTE, NUM_DOC_CLIENTE, RAZON_SOCIAL, DIRECCION,
                        //DETALLE, USUARIO_CREACION, TOTAL_GENERAL, TOTAL_IGV, SUBTOTAL_GENERAL, FORMA_PAGO_DESCRIPCION);
                        int respuesta = 1;


                        if (respuesta == 0)
                        {
                            val2 = 0;
                        }
                        else
                        {
                            val2 = 1;
                            transaccion.Commit();
                        }
                    }





                }
                catch (Exception ex)
                {

                    StackTrace st = new StackTrace(ex, true);
                    StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                         && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                         && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                         && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                    string MachineName = System.Environment.MachineName;
                    string UserName = System.Environment.UserName.ToUpper();
                    string Mensaje = ex.Message;
                    int LineaError = frame.GetFileLineNumber();
                    string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                    string Clase = frame.GetMethod().DeclaringType.Name;
                    string metodo = frame.GetMethod().Name;
                    string codigoError = Convert.ToString(frame.GetHashCode());
                    transaccion.Rollback();
                }
            }

            return val2;

        }
        public int GRABAR_NOTA(string TIPO_COMPROBANTE, string SERIE, string SERIE_FACURA, string NRO_FACURA, string FECHA_FACURA, string FECHA,
     string MONEDA, string FORMA_PAGO, string TIPO_DOC_CLIENTE, string NUM_DOC_CLIENTE, string RAZON_SOCIAL, string DIRECCION,
     string DETALLE, string USUARIO_CREACION, string TOTAL_GENERAL, string TOTAL_IGV, string SUBTOTAL_GENERAL, string GLOSA, string FORMA_PAGO_DESCRIPCION)
        {

            Numero n = new Numero();




            int val = 0, val2 = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {
                    int ID, CORRELATIVO;

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_INSERTAR_FACTURACION_CAB_NOTA";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", TIPO_COMPROBANTE);
                        cmd.Parameters.AddWithValue("@SERIE", SERIE);
                        cmd.Parameters.AddWithValue("@SERIE_DOC_REL", SERIE_FACURA);
                        cmd.Parameters.AddWithValue("@NUM_DOC_REL", NRO_FACURA);
                        cmd.Parameters.AddWithValue("@FECHA_DOC_REL", FECHA_FACURA);
                        cmd.Parameters.AddWithValue("@FECHA", FECHA);
                        cmd.Parameters.AddWithValue("@MONEDA", MONEDA);
                        cmd.Parameters.AddWithValue("@FORMA_PAGO", FORMA_PAGO);
                        cmd.Parameters.AddWithValue("@TIPO_DOC_CLIENTE", TIPO_DOC_CLIENTE);
                        cmd.Parameters.AddWithValue("@NUM_DOC_CLIENTE", NUM_DOC_CLIENTE);
                        cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", RAZON_SOCIAL.Trim());
                        cmd.Parameters.AddWithValue("@DIRECCION_CLIENTE", DIRECCION.Trim());
                        cmd.Parameters.AddWithValue("@USUARIO_CREACION", USUARIO_CREACION);
                        cmd.Parameters.AddWithValue("@TOTAL_IGV", TOTAL_IGV);
                        cmd.Parameters.AddWithValue("@TOTAL_GENERAL", TOTAL_GENERAL.Trim());
                        cmd.Parameters.AddWithValue("@SUBTOTAL_GENERAL", SUBTOTAL_GENERAL.Trim());
                        cmd.Parameters.AddWithValue("@TOTAL_GENERAL_LETRAS", n.ConvertirAImporteLetras(TOTAL_GENERAL));
                        cmd.Parameters.AddWithValue("@GLOSA", GLOSA.Trim());
                        cmd.Parameters.Add("@ID_", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CORRELATIVO_", SqlDbType.Int).Direction = ParameterDirection.Output;

                        val = cmd.ExecuteNonQuery();

                        ID = Convert.ToInt32(cmd.Parameters["@ID_"].Value);
                        CORRELATIVO = Convert.ToInt32(cmd.Parameters["@CORRELATIVO_"].Value);
                        cmd.Parameters.Clear();



                        if (val >= 1)
                        {

                            #region Generando QR
                            //Variable que crea QR

                            var writer = new BarcodeWriter()
                            {
                                Format = BarcodeFormat.QR_CODE,
                                Options = new EncodingOptions()
                                {
                                    Height = 300,
                                    Width = 300,
                                    Margin = 1
                                }
                            };
                            writer.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.Q);
                            //Valor de QR
                            string tipo_docu2 = "";
                            if (TIPO_DOC_CLIENTE == "DNI")
                            {
                                tipo_docu2 = "1";
                            }
                            else if (TIPO_DOC_CLIENTE == "RUC")
                            {
                                tipo_docu2 = "6";
                            }
                            string valorQR = "20553080712" + "|" + TIPO_COMPROBANTE + "|" + SERIE + "|" + CORRELATIVO + "|" + TOTAL_IGV + "|" + TOTAL_GENERAL + "|" + FECHA + "|" + tipo_docu2 + "|" + NUM_DOC_CLIENTE;

                            //Generando QR como bytes
                            byte[] CodigoQR;
                            MemoryStream loFlujoMemoria = new MemoryStream();
                            writer.Write(valorQR).Save(loFlujoMemoria, ImageFormat.Jpeg);
                            CodigoQR = loFlujoMemoria.ToArray();

                            #endregion

                            cmd.CommandText = "SP_ACTUALIZAR_CODIGO_QR";
                            cmd.Transaction = transaccion;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_FACTURACION_CAB", ID);
                            cmd.Parameters.AddWithValue("@CODIGO_QR", CodigoQR);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();


                            string[] valores = DETALLE.Split('ª');

                            foreach (string a in valores)
                            {
                                if (a != "")
                                {
                                    string[] valores2 = a.Split('º');

                                    val2 = 0;
                                    cmd.CommandText = "SP_INSERTAR_FACTURACION_DET";
                                    cmd.Transaction = transaccion;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@ID_FACTURACION_CAB", ID);
                                    cmd.Parameters.AddWithValue("@CORRELATIVO", valores2[0].ToString());
                                    cmd.Parameters.AddWithValue("@CODIGO", valores2[1].ToString());
                                    cmd.Parameters.AddWithValue("@SERVICIO", valores2[2].ToString());
                                    cmd.Parameters.AddWithValue("@UM", valores2[3].ToString());
                                    cmd.Parameters.AddWithValue("@CANTIDAD", valores2[4].ToString());
                                    cmd.Parameters.AddWithValue("@PRECIO", valores2[5].ToString());
                                    cmd.Parameters.AddWithValue("@IGV", valores2[6].ToString());
                                    cmd.Parameters.AddWithValue("@TOTAL", valores2[7].ToString());
                                    val2 = cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                            }
                        }

                        int respuesta = GRABAR_FACTURACION_INTEGRACION_NOTA(CORRELATIVO, TIPO_COMPROBANTE, SERIE, SERIE_FACURA, NRO_FACURA, FECHA_FACURA, FECHA,
            MONEDA, FORMA_PAGO, TIPO_DOC_CLIENTE, NUM_DOC_CLIENTE, RAZON_SOCIAL, DIRECCION,
            DETALLE, USUARIO_CREACION, TOTAL_GENERAL, TOTAL_IGV, SUBTOTAL_GENERAL, FORMA_PAGO_DESCRIPCION);

                      
                        if (respuesta == 0)
                        {
                            val2 = 0;
                        }
                        else
                        {
                            val2 = 1;
                            transaccion.Commit();
                        }





                    }





                }
                catch (Exception ex)
                {

                    StackTrace st = new StackTrace(ex, true);
                    StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                         && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                         && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                         && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                    string MachineName = System.Environment.MachineName;
                    string UserName = System.Environment.UserName.ToUpper();
                    string Mensaje = ex.Message;
                    int LineaError = frame.GetFileLineNumber();
                    string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                    string Clase = frame.GetMethod().DeclaringType.Name;
                    string metodo = frame.GetMethod().Name;
                    string codigoError = Convert.ToString(frame.GetHashCode());
                    transaccion.Rollback();
                }



            }




            return val2;

        }
        public int GRABAR_FACTURACION_INTEGRACION(int CORRELATIVO, string TIPO_COMPROBANTE, string SERIE, string NRO_ORDEN, string FECHA,
       string MONEDA, string FORMA_PAGO, string TIPO_DOC_CLIENTE, string NUM_DOC_CLIENTE, string RAZON_SOCIAL, string DIRECCION,
       string DETALLE, string USUARIO_CREACION, string TOTAL_GENERAL, string TOTAL_IGV, string SUBTOTAL_GENERAL, string FORMA_PAGO_DESCRIPCION)
        {

            Numero n = new Numero();
            string tipo_doc_final = "", forma_pago_final = "";

            if (TIPO_DOC_CLIENTE == "DNI")
            {
                tipo_doc_final = "1";
            }
            else if (TIPO_DOC_CLIENTE == "RUC")
            {
                tipo_doc_final = "6";
            }
            if (FORMA_PAGO == "1" || FORMA_PAGO == "2")
            {
                forma_pago_final = "0";
            }
            else
            {
                forma_pago_final = "1";
            }







            int val = 0, val2 = 0;
            SqlConnection con = new SqlConnection(conexion2);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {
                    int ID;

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "sp_Ventas_Grabar_Cabecera";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdVent", null);
                        cmd.Parameters.AddWithValue("@TipoOpe", "0101");/*Tipo de Operacion 0101 Venta Interna, 0200 Exportacion de Bienes */
                        cmd.Parameters.AddWithValue("@Tico", TIPO_COMPROBANTE);/*Tipo de comprobante 01=FACTURA, 03=BOLETA, 07=NOTA DE CREDITO, 08=NOTA DEDEBITO) */
                        cmd.Parameters.AddWithValue("@Seri", SERIE);
                        cmd.Parameters.AddWithValue("@Nume", Convert.ToInt32(CORRELATIVO));
                        cmd.Parameters.AddWithValue("@Fech", Convert.ToDateTime(FECHA));
                        cmd.Parameters.AddWithValue("@Mone", MONEDA);
                        cmd.Parameters.AddWithValue("@IGV", 18);
                        cmd.Parameters.AddWithValue("@Tidocl", tipo_doc_final); /* Tipo de ocumento (6=RUC, 1=DNI, No Domiciliado=0) */
                        cmd.Parameters.AddWithValue("@Nudocl", NUM_DOC_CLIENTE);/* Numero de Documento*/
                        cmd.Parameters.AddWithValue("@Nomcli", RAZON_SOCIAL);/*Nombre de Cliente */
                        cmd.Parameters.AddWithValue("@Direcc", DIRECCION);/*Direccion de Cliente */
                        cmd.Parameters.AddWithValue("@SeriDR", null); /* Serie de comprobante Solo en el caso sea Nota de Credito o Debito, Serie del documento relacionado */
                        cmd.Parameters.AddWithValue("@NumeDR", null);/* Numero comprobante  Solo en el caso sea Nota de Credito o Debito, Numero del documento relacionado */
                        cmd.Parameters.AddWithValue("@FechDR", null);/* Fecha Comprobante Solo en el caso sea Nota de Credito o Debito, Fecha del documento relacionado */
                        cmd.Parameters.AddWithValue("@ForPag", forma_pago_final); /*  Contado=0, Credito=1 */
                        cmd.Parameters.AddWithValue("@Incl", "0");/*  Si precios Incluye IGV=1, si no 0 */
                        cmd.Parameters.AddWithValue("@Opcion", 1);/* 1 Nuevo comprobante 2 Modifica Comprobante */

                        if (FORMA_PAGO == "1" || FORMA_PAGO == "2")//CONTADO
                        {
                            cmd.Parameters.AddWithValue("@FecPag", null);
                            cmd.Parameters.AddWithValue("@MonPag", null);

                        }
                        else //CREDITO
                        {
                            DateTime FECHA_PAGO_CREDITO;
                            if (FORMA_PAGO == "3")
                            {
                                FECHA_PAGO_CREDITO = Convert.ToDateTime(FECHA);
                            }
                            else
                            {
                                string dias = FORMA_PAGO_DESCRIPCION.Substring(5, 2);

                                FECHA_PAGO_CREDITO = Convert.ToDateTime(FECHA).AddDays(Convert.ToInt32(dias));

                            }


                            cmd.Parameters.AddWithValue("@FecPag", FECHA_PAGO_CREDITO);
                            cmd.Parameters.AddWithValue("@MonPag", TOTAL_GENERAL);
                        }


                        cmd.Parameters.Add("@nReg", SqlDbType.Int).Direction = ParameterDirection.Output;


                        val = cmd.ExecuteNonQuery();

                        ID = Convert.ToInt32(cmd.Parameters["@nReg"].Value);

                        cmd.Parameters.Clear();



                        if (ID >= 1)
                        {
                            string[] valores = DETALLE.Split('ª');

                            foreach (string a in valores)
                            {
                                if (a != "")
                                {
                                    string[] valores2 = a.Split('º');

                                    val2 = 0;
                                    cmd.CommandText = "sp_Ventas_Grabar_Detalle";
                                    cmd.Transaction = transaccion;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@IdVent", ID);
                                    cmd.Parameters.AddWithValue("@Item", valores2[0].ToString());
                                    cmd.Parameters.AddWithValue("@Codi", valores2[1].ToString());
                                    cmd.Parameters.AddWithValue("@Prod", valores2[2].ToString());
                                    cmd.Parameters.AddWithValue("@Unid", "ZZ");
                                    cmd.Parameters.AddWithValue("@Cant", Convert.ToDecimal(valores2[4].ToString()));
                                    cmd.Parameters.AddWithValue("@Prec", Convert.ToDecimal(valores2[5].ToString()));
                                    cmd.Parameters.AddWithValue("@Descuento", 0.00);
                                    cmd.Parameters.AddWithValue("@CodigoSunat", null);
                                    cmd.Parameters.AddWithValue("@TipAfe", "10");
                                    val2 = cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }

                            }



                        }




                        transaccion.Commit();

                    }





                }
                catch (Exception ex)
                {

                    StackTrace st = new StackTrace(ex, true);
                    StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                         && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                         && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                         && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                    string MachineName = System.Environment.MachineName;
                    string UserName = System.Environment.UserName.ToUpper();
                    string Mensaje = ex.Message;
                    int LineaError = frame.GetFileLineNumber();
                    string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                    string Clase = frame.GetMethod().DeclaringType.Name;
                    string metodo = frame.GetMethod().Name;
                    string codigoError = Convert.ToString(frame.GetHashCode());
                    transaccion.Rollback();
                }



            }




            return val2;

        }

        public int GRABAR_FACTURACION_INTEGRACION_NOTA(int CORRELATIVO, string TIPO_COMPROBANTE, string SERIE, string SERIE_FACURA, string NRO_FACURA,
                  string FECHA_FACURA, string FECHA,
           string MONEDA, string FORMA_PAGO, string TIPO_DOC_CLIENTE, string NUM_DOC_CLIENTE, string RAZON_SOCIAL, string DIRECCION,
           string DETALLE, string USUARIO_CREACION, string TOTAL_GENERAL, string TOTAL_IGV, string SUBTOTAL_GENERAL, string FORMA_PAGO_DESCRIPCION)
        {

            Numero n = new Numero();
            string tipo_doc_final = "", forma_pago_final = "";

            if (TIPO_DOC_CLIENTE == "DNI")
            {
                tipo_doc_final = "1";
            }
            else if (TIPO_DOC_CLIENTE == "RUC")
            {
                tipo_doc_final = "6";
            }
            if (FORMA_PAGO == "1" || FORMA_PAGO == "2")
            {
                forma_pago_final = "0";
            }
            else
            {
                forma_pago_final = "1";
            }

            int val = 0, val2 = 0;
            SqlConnection con = new SqlConnection(conexion2);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {
                    int ID;

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "sp_Ventas_Grabar_Cabecera";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdVent", null);
                        cmd.Parameters.AddWithValue("@TipoOpe", "0101");/*Tipo de Operacion 0101 Venta Interna, 0200 Exportacion de Bienes */
                        cmd.Parameters.AddWithValue("@Tico", TIPO_COMPROBANTE);/*Tipo de comprobante 01=FACTURA, 03=BOLETA, 07=NOTA DE CREDITO, 08=NOTA DEDEBITO) */
                        cmd.Parameters.AddWithValue("@Seri", SERIE);
                        cmd.Parameters.AddWithValue("@Nume", Convert.ToInt32(CORRELATIVO));
                        cmd.Parameters.AddWithValue("@Fech", Convert.ToDateTime(FECHA));
                        cmd.Parameters.AddWithValue("@Mone", MONEDA);
                        cmd.Parameters.AddWithValue("@IGV", 18);
                        cmd.Parameters.AddWithValue("@Tidocl", tipo_doc_final); /* Tipo de ocumento (6=RUC, 1=DNI, No Domiciliado=0) */
                        cmd.Parameters.AddWithValue("@Nudocl", NUM_DOC_CLIENTE);/* Numero de Documento*/
                        cmd.Parameters.AddWithValue("@Nomcli", RAZON_SOCIAL);/*Nombre de Cliente */
                        cmd.Parameters.AddWithValue("@Direcc", DIRECCION);/*Direccion de Cliente */
                        cmd.Parameters.AddWithValue("@SeriDR", SERIE_FACURA); /* Serie de comprobante Solo en el caso sea Nota de Credito o Debito, Serie del documento relacionado */
                        cmd.Parameters.AddWithValue("@NumeDR", NRO_FACURA);/* Numero comprobante  Solo en el caso sea Nota de Credito o Debito, Numero del documento relacionado */
                        cmd.Parameters.AddWithValue("@FechDR", Convert.ToDateTime(FECHA_FACURA));/* Fecha Comprobante Solo en el caso sea Nota de Credito o Debito, Fecha del documento relacionado */
                        cmd.Parameters.AddWithValue("@ForPag", forma_pago_final); /*  Contado=0, Credito=1 */
                        cmd.Parameters.AddWithValue("@Incl", "0");/*  Si precios Incluye IGV=1, si no 0 */
                        cmd.Parameters.AddWithValue("@Opcion", 1);/* 1 Nuevo comprobante 2 Modifica Comprobante */
                        if (FORMA_PAGO == "1" || FORMA_PAGO == "2")//CONTADO
                        {
                            cmd.Parameters.AddWithValue("@FecPag", null);
                            cmd.Parameters.AddWithValue("@MonPag", null);

                        }
                        else //CREDITO
                        {
                            //DateTime FECHA_PAGO_CREDITO;
                            //if (FORMA_PAGO == "3")
                            //{
                            //    FECHA_PAGO_CREDITO = Convert.ToDateTime(FECHA);
                            //}
                            //else
                            //{
                            //    string dias = FORMA_PAGO_DESCRIPCION.Substring(5, 2);

                            //    FECHA_PAGO_CREDITO = Convert.ToDateTime(FECHA).AddDays(Convert.ToInt32(dias));

                            //}
                            cmd.Parameters.AddWithValue("@FecPag", Convert.ToDateTime(FECHA));
                            cmd.Parameters.AddWithValue("@MonPag", TOTAL_GENERAL);
                        }
                        cmd.Parameters.Add("@nReg", SqlDbType.Int).Direction = ParameterDirection.Output;
                        val = cmd.ExecuteNonQuery();
                        ID = Convert.ToInt32(cmd.Parameters["@nReg"].Value);
                        cmd.Parameters.Clear();
                        if (ID >= 1)
                        {
                            string[] valores = DETALLE.Split('ª');
                            foreach (string a in valores)
                            {
                                if (a != "")
                                {
                                    string[] valores2 = a.Split('º');

                                    val2 = 0;
                                    cmd.CommandText = "sp_Ventas_Grabar_Detalle";
                                    cmd.Transaction = transaccion;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@IdVent", ID);
                                    cmd.Parameters.AddWithValue("@Item", valores2[0].ToString());
                                    cmd.Parameters.AddWithValue("@Codi", valores2[1].ToString());
                                    cmd.Parameters.AddWithValue("@Prod", valores2[2].ToString());
                                    cmd.Parameters.AddWithValue("@Unid", "ZZ");
                                    cmd.Parameters.AddWithValue("@Cant", Convert.ToDecimal(valores2[4].ToString()));
                                    cmd.Parameters.AddWithValue("@Prec", Convert.ToDecimal(valores2[5].ToString()));
                                    cmd.Parameters.AddWithValue("@Descuento", 0.00);
                                    cmd.Parameters.AddWithValue("@CodigoSunat", null);
                                    cmd.Parameters.AddWithValue("@TipAfe", "10");
                                    val2 = cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                            }
                        }
                        transaccion.Commit();
                    }
                }
                catch (Exception ex)
                {

                    StackTrace st = new StackTrace(ex, true);
                    StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                         && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                         && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                         && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                    string MachineName = System.Environment.MachineName;
                    string UserName = System.Environment.UserName.ToUpper();
                    string Mensaje = ex.Message;
                    int LineaError = frame.GetFileLineNumber();
                    string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                    string Clase = frame.GetMethod().DeclaringType.Name;
                    string metodo = frame.GetMethod().Name;
                    string codigoError = Convert.ToString(frame.GetHashCode());
                    transaccion.Rollback();
                }
            }
            return val2;

        }


        public int ANULAR_COMPROBANTE(int ID, string TIPO_COMPROBANTE, string SERIE, string NUMERO)
        {

            Numero n = new Numero();

            int val = 0, respuesta = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_ANULAR_COMPROBANTE";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        if (val >= 1)
                        {
                            respuesta = ANULAR_COMPROBANTE_INTEGRACION(ID, TIPO_COMPROBANTE, SERIE, NUMERO);

                            if (respuesta == 0)
                            {
                                transaccion.Rollback();
                            }
                            else
                            {
                                transaccion.Commit();
                            }
                        }



                    }
                }
                catch (Exception ex)
                {

                    StackTrace st = new StackTrace(ex, true);
                    StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                         && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                         && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                         && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                    string MachineName = System.Environment.MachineName;
                    string UserName = System.Environment.UserName.ToUpper();
                    string Mensaje = ex.Message;
                    int LineaError = frame.GetFileLineNumber();
                    string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                    string Clase = frame.GetMethod().DeclaringType.Name;
                    string metodo = frame.GetMethod().Name;
                    string codigoError = Convert.ToString(frame.GetHashCode());
                    transaccion.Rollback();
                }



            }

            return respuesta;

        }


        public int ANULAR_COMPROBANTE_INTEGRACION(int ID, string TIPO_COMPROBANTE, string SERIE, string NUMERO)
        {
            string TIP_COMPROBANTE_FINAL = "";

            if (TIPO_COMPROBANTE == "FACTURA")
            {
                TIP_COMPROBANTE_FINAL = "01";
            }
            if (TIPO_COMPROBANTE == "BOLETA")
            {
                TIP_COMPROBANTE_FINAL = "03";
            }
            if (TIPO_COMPROBANTE == "NOTA DE CREDITO")
            {
                TIP_COMPROBANTE_FINAL = "07";
            }
            if (TIPO_COMPROBANTE == "NOTA DE DEBITO")
            {
                TIP_COMPROBANTE_FINAL = "08";
            }


            Numero n = new Numero();

            int val = 0;
            SqlConnection con = new SqlConnection(conexion2);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {


                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_Anular_Comprobante";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", TIP_COMPROBANTE_FINAL);
                        cmd.Parameters.AddWithValue("@SERIE", SERIE);
                        cmd.Parameters.AddWithValue("@NUMERO", NUMERO);
                        val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        if (val >= 1)
                        {
                            transaccion.Commit();

                        }
                        else
                        {
                            transaccion.Rollback();
                        }
                    }

                }
                catch (Exception ex)
                {

                    StackTrace st = new StackTrace(ex, true);
                    StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                         && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                         && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                         && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                    string MachineName = System.Environment.MachineName;
                    string UserName = System.Environment.UserName.ToUpper();
                    string Mensaje = ex.Message;
                    int LineaError = frame.GetFileLineNumber();
                    string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                    string Clase = frame.GetMethod().DeclaringType.Name;
                    string metodo = frame.GetMethod().Name;
                    string codigoError = Convert.ToString(frame.GetHashCode());
                    transaccion.Rollback();
                }



            }

            return val;

        }
        public List<BE_Facturacion> BUSCAR(string TIPO_COMPROBANTE, string SERIE, string NUMERO, string RAZON_SOCIAL, string ESTADO, string FECHA_INI, string FECHA_FIN)
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_FACTURACION_CAB", con))
                {
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", TIPO_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@SERIE", SERIE);
                    cmd.Parameters.AddWithValue("@NUMERO", NUMERO);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
                    cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.TIPO_COMPROBANTE = lector[1].ToString().Trim();
                        obj_BE.SERIE = lector[2].ToString().Trim();
                        obj_BE.NUMERO = lector[3].ToString().Trim();
                        obj_BE.CLIENTE = lector[4].ToString().Trim();
                        obj_BE.TOTAL_GENERAL = lector[5].ToString().Trim();
                        obj_BE.FECHA = lector[6].ToString().Trim();
                        obj_BE.ESTADO = lector[7].ToString().Trim();

                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }
        public List<BE_Facturacion> REPORTE_VENTAS(string FEC_INI, string FEC_FIN, string RAZON_SOCIAL, string ESTADO)
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_REPORTE_VENTAS", con))
                {
                    cmd.Parameters.AddWithValue("@FECINI", FEC_INI);
                    cmd.Parameters.AddWithValue("@FECFIN", FEC_FIN);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.FECHA = lector[0].ToString().Trim();
                        obj_BE.DESCRIPCION = lector[1].ToString().Trim();
                        obj_BE.NUMERO = lector[2].ToString().Trim();
                        obj_BE.TIPO_DOC_CLIENTE = lector[3].ToString().Trim();
                        obj_BE.NUM_DOC_CLIENTE = lector[4].ToString().Trim();
                        obj_BE.NOMBRE_CLIENTE = lector[5].ToString().Trim();
                        obj_BE.TOTAL_IGV = lector[6].ToString().Trim();
                        obj_BE.TOTAL_GENERAL = lector[7].ToString().Trim();

                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }

        public List<BE_Facturacion> BUSCAR_COMPROBANTES(string TIPO_COMPROBANTE, string SERIE, string NUMERO, string RAZON_SOCIAL, string ESTADO, string FECHA_INI, string FECHA_FIN)
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_FACTURACION_CAB_COMPROBANTES", con))
                {
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", TIPO_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@SERIE", SERIE);
                    cmd.Parameters.AddWithValue("@NUMERO", NUMERO);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
                    cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.TIPO_COMPROBANTE = lector[1].ToString().Trim();
                        obj_BE.SERIE = lector[2].ToString().Trim();
                        obj_BE.NUMERO = lector[3].ToString().Trim();
                        obj_BE.CLIENTE = lector[4].ToString().Trim();
                        obj_BE.TOTAL_GENERAL = lector[5].ToString().Trim();
                        obj_BE.FECHA = lector[6].ToString().Trim();
                        obj_BE.ESTADO = lector[7].ToString().Trim();

                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }

        public List<BE_Facturacion> OBTENER(int ID)
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_FACTURACION_CAB", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.TIPO_OPERACION = lector[1].ToString().Trim();
                        obj_BE.TIPO_COMPROBANTE = lector[2].ToString().Trim();
                        obj_BE.SERIE = lector[3].ToString().Trim();
                        obj_BE.NUMERO = lector[4].ToString().Trim();
                        obj_BE.FECHA = lector[5].ToString().Trim();
                        obj_BE.MONEDA = lector[6].ToString().Trim();
                        obj_BE.IGV = lector[7].ToString().Trim();
                        obj_BE.TIPO_DOC_CLIENTE = lector[8].ToString().Trim();
                        obj_BE.NUM_DOC_CLIENTE = lector[9].ToString().Trim();
                        obj_BE.NOMBRE_CLIENTE = lector[10].ToString().Trim();
                        obj_BE.DIRECCION_CLIENTE = lector[11].ToString().Trim();
                        obj_BE.SERIE_DOC_REL = lector[12].ToString().Trim();
                        obj_BE.NUM_DOC_REL = lector[13].ToString().Trim();
                        obj_BE.FECHA_DOC_REL = lector[14].ToString().Trim();
                        obj_BE.TIPO_IMPUESTO = lector[15].ToString().Trim();
                        obj_BE.INCL_IGV = lector[16].ToString().Trim();
                        obj_BE.ESTADO = lector[17].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[18].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[19].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[20].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[21].ToString().Trim();
                        obj_BE.FORMA_PAGO = lector[22].ToString().Trim();
                        obj_BE.TOTAL_IGV = lector[23].ToString().Trim();
                        obj_BE.TOTAL_GENERAL = lector[24].ToString().Trim();
                        obj_BE.SUBTOTAL_GENERAL = lector[25].ToString().Trim();
                        obj_BE.GLOSA = lector[26].ToString().Trim();


                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }


        public List<BE_Facturacion> OBTENER_DETALLE(int ID)
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_FACTURACION_DET", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Facturacion obj_BE = new BE_Facturacion();

                        obj_BE.ID = Convert.ToInt32(lector[4].ToString().Trim());
                        obj_BE.CODIGO = lector[5].ToString().Trim();
                        obj_BE.SERVICIO = lector[6].ToString().Trim();
                        obj_BE.UNIDAD = lector[7].ToString().Trim();
                        obj_BE.CANTIDAD = lector[8].ToString().Trim();
                        obj_BE.PRECIO = lector[9].ToString().Trim();
                        obj_BE.SUBTOTAL = lector[15].ToString().Trim();
                        obj_BE.IGV = lector[10].ToString().Trim();
                        obj_BE.TOTAL = lector[11].ToString().Trim();


                        lista.Add(obj_BE);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }



        public List<BE_Facturacion> IMPRIMIR(int ID)
        {
            List<BE_Facturacion> lista = new List<BE_Facturacion>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER_COMPROBANTE_CAB_REPORTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                DataTable dtfacturaCabecera = new DataTable();
                oda.Fill(dtfacturaCabecera);

                cmd.Parameters.Clear();
                SqlCommand cmd2 = new SqlCommand("SP_OBTENER_COMPROBANTE_DET_REPORTE", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter oda2 = new SqlDataAdapter(cmd2);
                DataTable dtfacturaDetalle = new DataTable();
                oda2.Fill(dtfacturaDetalle);





            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string codigoError = Convert.ToString(frame.GetHashCode());
            }
            return lista;
        }
       
    }
}