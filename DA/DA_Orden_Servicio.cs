using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Configuration;
namespace DA
{
    public class DA_Orden_Servicio
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public List<BE_Orden_Servicio> BUSCAR(string TIPO_SERVICIO, string NRO_ORDEN_SERVICIO, string RAZON_SOCIAL, string ESTADO)
        {
            List<BE_Orden_Servicio> lista = new List<BE_Orden_Servicio>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_ORDEN_SERVICIO", con))
                {
                    cmd.Parameters.AddWithValue("@TIPO_SERVICIO", TIPO_SERVICIO);
                    cmd.Parameters.AddWithValue("@NRO_ORDEN", NRO_ORDEN_SERVICIO);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);


                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Orden_Servicio obj_BE = new BE_Orden_Servicio();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.NUM_ORDEN_SERVICIO = lector[1].ToString().Trim();
                        obj_BE.TIPO_SERVICIO = lector[2].ToString().Trim();
                        obj_BE.RAZON_SOCIAL = lector[3].ToString().Trim();
                        obj_BE.ESTADO = lector[4].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[5].ToString().Trim();




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

        
             public List<BE_Orden_Servicio> BUSCAR_ORDEN_SERVICIO(string TIPO_SERVICIO, string NRO_ORDEN_SERVICIO, string RAZON_SOCIAL, string ESTADO)
        {
            List<BE_Orden_Servicio> lista = new List<BE_Orden_Servicio>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_ORDEN_SERVICIO_COMPROBANTES", con))
                {
                    cmd.Parameters.AddWithValue("@TIPO_SERVICIO", TIPO_SERVICIO);
                    cmd.Parameters.AddWithValue("@NRO_ORDEN", NRO_ORDEN_SERVICIO);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);


                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Orden_Servicio obj_BE = new BE_Orden_Servicio();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.NUM_ORDEN_SERVICIO = lector[1].ToString().Trim();
                        obj_BE.TIPO_SERVICIO = lector[2].ToString().Trim();
                        obj_BE.RAZON_SOCIAL = lector[3].ToString().Trim();
                        obj_BE.ESTADO = lector[4].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[5].ToString().Trim();




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
        public List<BE_Orden_Servicio> OBTENER(int ID)
        {
            List<BE_Orden_Servicio> lista = new List<BE_Orden_Servicio>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_ORDEN_SERVICIO", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Orden_Servicio obj_BE = new BE_Orden_Servicio();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());

                        obj_BE.ID_CLIENTE = lector[1].ToString().Trim();
                        obj_BE.TIPO_DOC = lector[2].ToString().Trim();
                        obj_BE.NUM_DOC = lector[3].ToString().Trim();
                        obj_BE.RAZON_SOCIAL = lector[4].ToString().Trim();
                        obj_BE.NUM_ORDEN_SERVICIO = lector[5].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE = lector[6].ToString().Trim();
                        obj_BE.FLAG_CUADRILLA = lector[7].ToString().Trim();
                        obj_BE.FLAG_RESGUARDO = lector[8].ToString().Trim();
                        obj_BE.FLAG_AGE_ADUANA = lector[9].ToString().Trim();
                        obj_BE.FLAG_AGE_CARGA = lector[10].ToString().Trim();
                        obj_BE.FLAG_OTROS = lector[11].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE = lector[12].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE = lector[13].ToString().Trim();
                        obj_BE.TRA_PLACA = lector[14].ToString().Trim();
                        obj_BE.TRA_BREVETE = lector[15].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO = lector[16].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA = lector[17].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA = lector[18].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR = lector[19].ToString().Trim();
                        obj_BE.TRA_PESO = lector[20].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO = lector[21].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO = lector[22].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO = lector[23].ToString().Trim();
                        obj_BE.CUAD_SERVICIO = lector[24].ToString().Trim();
                        obj_BE.CUAD_DETALLE = lector[25].ToString().Trim();
                        obj_BE.CUAD_LUGAR = lector[26].ToString().Trim();
                        obj_BE.CUAD_NUM_PERSONAS = lector[27].ToString().Trim();
                        obj_BE.RESG_PROVEEDOR = lector[28].ToString().Trim();
                        obj_BE.RESG_RUTA = lector[29].ToString().Trim();
                        obj_BE.AGE_ADU_ADUANA = lector[30].ToString().Trim();
                        obj_BE.AGE_ADU_MANIFIESTO = lector[31].ToString().Trim();
                        obj_BE.AGE_ADU_REGIMEN = lector[32].ToString().Trim();
                        obj_BE.AGE_ADU_DAM = lector[33].ToString().Trim();
                        obj_BE.AGE_ADU_CANAL = lector[34].ToString().Trim();
                        obj_BE.AGE_ADU_EMPRESA = lector[35].ToString().Trim();
                        obj_BE.AGE_ADU_FEC_ARRIBO = lector[36].ToString().Trim();
                        obj_BE.AGE_ADU_FEC_RETIRO = lector[37].ToString().Trim();
                        obj_BE.AGE_ADU_ALMACEN = lector[38].ToString().Trim();
                        obj_BE.AGE_ADU_VALORFOB = lector[39].ToString().Trim();
                        obj_BE.AGE_ADU_VALORCIF = lector[40].ToString().Trim();
                        obj_BE.AGE_CAR_ADUANA = lector[41].ToString().Trim();
                        obj_BE.AGE_CAR_MANIFIESTO = lector[42].ToString().Trim();
                        obj_BE.AGE_CAR_PUERTO_ORIGEN = lector[43].ToString().Trim();
                        obj_BE.AGE_CAR_PAIS = lector[44].ToString().Trim();
                        obj_BE.AGE_CAR_EMP_TRANSP = lector[45].ToString().Trim();
                        obj_BE.AGE_CAR_EMPRESA = lector[46].ToString().Trim();
                        obj_BE.AGE_CAR_FEC_ARRIBO = lector[47].ToString().Trim();
                        obj_BE.AGE_CAR_FEC_RETIRO = lector[48].ToString().Trim();
                        obj_BE.AGE_CAR_PESO = lector[49].ToString().Trim();
                        obj_BE.AGE_CAR_VOLUMEN = lector[50].ToString().Trim();
                        obj_BE.AGE_CAR_NUM_BULTO = lector[51].ToString().Trim();
                        obj_BE.AGE_CAR_ALMACEN = lector[52].ToString().Trim();
                        obj_BE.OTRO_DETALLE = lector[53].ToString().Trim();
                        obj_BE.OTRO_OBSERVACION = lector[54].ToString().Trim();
                        obj_BE.ESTADO = lector[55].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[56].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[57].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[58].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[59].ToString().Trim();
                        obj_BE.DIRECCION_CLIENTE = lector[60].ToString().Trim();

                        obj_BE.TRA_NUM_GR_REMITENTE1 = lector[61].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE1 = lector[62].ToString().Trim();
                        obj_BE.TRA_PLACA1 = lector[63].ToString().Trim();
                        obj_BE.TRA_BREVETE1 = lector[64].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO1 = lector[65].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA1 = lector[66].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA1 = lector[67].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR1 = lector[68].ToString().Trim();
                        obj_BE.TRA_PESO1 = lector[69].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO1 = lector[70].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO1 = lector[71].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO1 = lector[72].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE2 = lector[73].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE2 = lector[74].ToString().Trim();
                        obj_BE.TRA_PLACA2 = lector[75].ToString().Trim();
                        obj_BE.TRA_BREVETE2 = lector[76].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO2 = lector[77].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA2 = lector[78].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA2 = lector[79].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR2 = lector[80].ToString().Trim();
                        obj_BE.TRA_PESO2 = lector[81].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO2 = lector[82].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO2 = lector[83].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO2 = lector[84].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE3 = lector[85].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE3 = lector[86].ToString().Trim();
                        obj_BE.TRA_PLACA3 = lector[87].ToString().Trim();
                        obj_BE.TRA_BREVETE3 = lector[88].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO3 = lector[89].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA3 = lector[90].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA3 = lector[91].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR3 = lector[92].ToString().Trim();
                        obj_BE.TRA_PESO3 = lector[93].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO3 = lector[94].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO3 = lector[95].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO3 = lector[96].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE4 = lector[97].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE4 = lector[98].ToString().Trim();
                        obj_BE.TRA_PLACA4 = lector[99].ToString().Trim();
                        obj_BE.TRA_BREVETE4 = lector[100].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO4 = lector[101].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA4 = lector[102].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA4 = lector[103].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR4 = lector[104].ToString().Trim();
                        obj_BE.TRA_PESO4 = lector[105].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO4 = lector[106].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO4 = lector[107].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO4 = lector[108].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE5 = lector[109].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE5 = lector[110].ToString().Trim();
                        obj_BE.TRA_PLACA5 = lector[111].ToString().Trim();
                        obj_BE.TRA_BREVETE5 = lector[112].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO5 = lector[113].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA5 = lector[114].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA5 = lector[115].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR5 = lector[116].ToString().Trim();
                        obj_BE.TRA_PESO5 = lector[117].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO5 = lector[118].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO5 = lector[119].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO5 = lector[120].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE6 = lector[121].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE6 = lector[122].ToString().Trim();
                        obj_BE.TRA_PLACA6 = lector[123].ToString().Trim();
                        obj_BE.TRA_BREVETE6 = lector[124].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO6 = lector[125].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA6 = lector[126].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA6 = lector[127].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR6 = lector[128].ToString().Trim();
                        obj_BE.TRA_PESO6 = lector[129].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO6 = lector[130].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO6 = lector[131].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO6 = lector[132].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE7 = lector[133].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE7 = lector[134].ToString().Trim();
                        obj_BE.TRA_PLACA7 = lector[135].ToString().Trim();
                        obj_BE.TRA_BREVETE7 = lector[136].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO7 = lector[137].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA7 = lector[138].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA7 = lector[139].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR7 = lector[140].ToString().Trim();
                        obj_BE.TRA_PESO7 = lector[141].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO7 = lector[142].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO7 = lector[143].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO7 = lector[144].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE8 = lector[145].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE8 = lector[146].ToString().Trim();
                        obj_BE.TRA_PLACA8 = lector[147].ToString().Trim();
                        obj_BE.TRA_BREVETE8 = lector[148].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO8 = lector[149].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA8 = lector[150].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA8 = lector[151].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR8 = lector[152].ToString().Trim();
                        obj_BE.TRA_PESO8 = lector[153].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO8 = lector[154].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO8 = lector[155].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO8 = lector[156].ToString().Trim();
                        obj_BE.TRA_NUM_GR_REMITENTE9 = lector[157].ToString().Trim();
                        obj_BE.TRA_NUM_GR_TRANSPORTE9 = lector[158].ToString().Trim();
                        obj_BE.TRA_PLACA9 = lector[159].ToString().Trim();
                        obj_BE.TRA_BREVETE9 = lector[160].ToString().Trim();
                        obj_BE.TRA_DIRECCION_INICIO9 = lector[161].ToString().Trim();
                        obj_BE.TRA_DIRECCION_LLEGADA9 = lector[162].ToString().Trim();
                        obj_BE.TRA_TIPO_CARGA9 = lector[163].ToString().Trim();
                        obj_BE.TRA_NUM_CONTENEDOR9 = lector[164].ToString().Trim();
                        obj_BE.TRA_PESO9 = lector[165].ToString().Trim();
                        obj_BE.TRA_FECHA_SERVICIO9 = lector[166].ToString().Trim();
                        obj_BE.TRA_TIPO_BULTO9 = lector[167].ToString().Trim();
                        obj_BE.TRA_NUM_BULTO9 = lector[168].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE1 = lector[169].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE2 = lector[170].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE3 = lector[171].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE4 = lector[172].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE5 = lector[173].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE6 = lector[174].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE7 = lector[175].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE8 = lector[176].ToString().Trim();
                        obj_BE.FLAG_TRANSPORTE9 = lector[177].ToString().Trim();

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

        
               public List<BE_Orden_Servicio> OBTENER_DETALLE(int ID)
        {
            List<BE_Orden_Servicio> lista = new List<BE_Orden_Servicio>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_ORDEN_SERVICIO_DETALLE", con))
                {
                    cmd.Parameters.AddWithValue("@ID_ORDEN", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Orden_Servicio obj_BE = new BE_Orden_Servicio();

                        obj_BE.ID =Convert.ToInt32( lector[0].ToString().Trim());
                        obj_BE.CODIGO_SERVICIO = lector[1].ToString().Trim();
                        obj_BE.DESCRIPCION_SERVICIO = lector[3].ToString().Trim();
                        


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


        public int GRABAR(int ID_CLIENTE,string TIPO_DOC,string NUM_DOC,string RAZON_SOCIAL,
        string FLAG_TRANSPORTE,string FLAG_CUADRILLA,string FLAG_RESGUARDO,string FLAG_AGE_ADUANA,string FLAG_AGE_CARGA,string FLAG_OTROS,
        string TRA_NUM_GR_REMITENTE,string TRA_NUM_GR_TRANSPORTE,string TRA_PLACA,string TRA_BREVETE,string TRA_DIRECCION_INICIO,string TRA_DIRECCION_LLEGADA,
        string TRA_TIPO_CARGA,string TRA_NUM_CONTENEDOR,string TRA_PESO,string TRA_FECHA_SERVICIO,string TRA_TIPO_BULTO,string TRA_NUM_BULTO,string CUAD_SERVICIO,
        string CUAD_DETALLE,string CUAD_LUGAR,string CUAD_NUM_PERSONAS,string RESG_PROVEEDOR,string RESG_RUTA,string AGE_ADU_ADUANA,string AGE_ADU_MANIFIESTO,string AGE_ADU_REGIMEN,
        string AGE_ADU_DAM,string AGE_ADU_CANAL,string AGE_ADU_EMPRESA,string AGE_ADU_FEC_ARRIBO,string AGE_ADU_FEC_RETIRO,string AGE_ADU_ALMACEN,string AGE_ADU_VALORFOB,
        string AGE_ADU_VALORCIF,string AGE_CAR_ADUANA,string AGE_CAR_MANIFIESTO,string AGE_CAR_PUERTO_ORIGEN,string AGE_CAR_PAIS,string AGE_CAR_EMP_TRANSP,string AGE_CAR_EMPRESA,
        string AGE_CAR_FEC_ARRIBO,string AGE_CAR_FEC_RETIRO,string AGE_CAR_PESO,string AGE_CAR_VOLUMEN,string AGE_CAR_NUM_BULTO,string AGE_CAR_ALMACEN,string OTRO_DETALLE,
        string OTRO_OBSERVACION,string USUARIO_CREACION,
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
            int val = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_INSERTAR_ORDEN_SERVICIO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
                        cmd.Parameters.AddWithValue("@TIPO_DOC", TIPO_DOC);
                        cmd.Parameters.AddWithValue("@NUM_DOC", NUM_DOC);
                        cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE", FLAG_TRANSPORTE);
                        cmd.Parameters.AddWithValue("@FLAG_CUADRILLA", FLAG_CUADRILLA);
                        cmd.Parameters.AddWithValue("@FLAG_RESGUARDO", FLAG_RESGUARDO);
                        cmd.Parameters.AddWithValue("@FLAG_AGE_ADUANA", FLAG_AGE_ADUANA);
                        cmd.Parameters.AddWithValue("@FLAG_AGE_CARGA", FLAG_AGE_CARGA);
                        cmd.Parameters.AddWithValue("@FLAG_OTROS", FLAG_OTROS);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE", TRA_NUM_GR_REMITENTE);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE", TRA_NUM_GR_TRANSPORTE);
                        cmd.Parameters.AddWithValue("@TRA_PLACA", TRA_PLACA);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE", TRA_BREVETE);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO", TRA_DIRECCION_INICIO);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA", TRA_DIRECCION_LLEGADA);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA", TRA_TIPO_CARGA);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR", TRA_NUM_CONTENEDOR);
                        cmd.Parameters.AddWithValue("@TRA_PESO", TRA_PESO);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO", TRA_FECHA_SERVICIO);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO", TRA_TIPO_BULTO);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO", TRA_NUM_BULTO);
                        cmd.Parameters.AddWithValue("@CUAD_SERVICIO", CUAD_SERVICIO);
                        cmd.Parameters.AddWithValue("@CUAD_DETALLE", CUAD_DETALLE);
                        cmd.Parameters.AddWithValue("@CUAD_LUGAR", CUAD_LUGAR);
                        cmd.Parameters.AddWithValue("@CUAD_NUM_PERSONAS", CUAD_NUM_PERSONAS);
                        cmd.Parameters.AddWithValue("@RESG_PROVEEDOR", RESG_PROVEEDOR);
                        cmd.Parameters.AddWithValue("@RESG_RUTA", RESG_RUTA);
                        cmd.Parameters.AddWithValue("@AGE_ADU_ADUANA", AGE_ADU_ADUANA);
                        cmd.Parameters.AddWithValue("@AGE_ADU_MANIFIESTO", AGE_ADU_MANIFIESTO);
                        cmd.Parameters.AddWithValue("@AGE_ADU_REGIMEN", AGE_ADU_REGIMEN);
                        cmd.Parameters.AddWithValue("@AGE_ADU_DAM", AGE_ADU_DAM);
                        cmd.Parameters.AddWithValue("@AGE_ADU_CANAL", AGE_ADU_CANAL);
                        cmd.Parameters.AddWithValue("@AGE_ADU_EMPRESA", AGE_ADU_EMPRESA);
                        cmd.Parameters.AddWithValue("@AGE_ADU_FEC_ARRIBO", AGE_ADU_FEC_ARRIBO);
                        cmd.Parameters.AddWithValue("@AGE_ADU_FEC_RETIRO", AGE_ADU_FEC_RETIRO);
                        cmd.Parameters.AddWithValue("@AGE_ADU_ALMACEN", AGE_ADU_ALMACEN);
                        cmd.Parameters.AddWithValue("@AGE_ADU_VALORFOB", AGE_ADU_VALORFOB);
                        cmd.Parameters.AddWithValue("@AGE_ADU_VALORCIF", AGE_ADU_VALORCIF);
                        cmd.Parameters.AddWithValue("@AGE_CAR_ADUANA", AGE_CAR_ADUANA);
                        cmd.Parameters.AddWithValue("@AGE_CAR_MANIFIESTO", AGE_CAR_MANIFIESTO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_PUERTO_ORIGEN", AGE_CAR_PUERTO_ORIGEN);
                        cmd.Parameters.AddWithValue("@AGE_CAR_PAIS", AGE_CAR_PAIS);
                        cmd.Parameters.AddWithValue("@AGE_CAR_EMP_TRANSP", AGE_CAR_EMP_TRANSP);
                        cmd.Parameters.AddWithValue("@AGE_CAR_EMPRESA", AGE_CAR_EMPRESA);
                        cmd.Parameters.AddWithValue("@AGE_CAR_FEC_ARRIBO", AGE_CAR_FEC_ARRIBO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_FEC_RETIRO", AGE_CAR_FEC_RETIRO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_PESO", AGE_CAR_PESO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_VOLUMEN", AGE_CAR_VOLUMEN);
                        cmd.Parameters.AddWithValue("@AGE_CAR_NUM_BULTO", AGE_CAR_NUM_BULTO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_ALMACEN", AGE_CAR_ALMACEN);
                        cmd.Parameters.AddWithValue("@OTRO_DETALLE", OTRO_DETALLE);
                        cmd.Parameters.AddWithValue("@OTRO_OBSERVACION", OTRO_OBSERVACION);
                        cmd.Parameters.AddWithValue("@USUARIO_CREACION", USUARIO_CREACION);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE1", FLAG_TRANSPORTE1);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE2", FLAG_TRANSPORTE2);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE3", FLAG_TRANSPORTE3);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE4", FLAG_TRANSPORTE4);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE5", FLAG_TRANSPORTE5);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE6", FLAG_TRANSPORTE6);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE7", FLAG_TRANSPORTE7);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE8", FLAG_TRANSPORTE8);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE9", FLAG_TRANSPORTE9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE1", TRA_NUM_GR_REMITENTE1);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE1", TRA_NUM_GR_TRANSPORTE1);
                        cmd.Parameters.AddWithValue("@TRA_PLACA1", TRA_PLACA1);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE1", TRA_BREVETE1);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO1", TRA_DIRECCION_INICIO1);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA1", TRA_DIRECCION_LLEGADA1);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA1", TRA_TIPO_CARGA1);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR1", TRA_NUM_CONTENEDOR1);
                        cmd.Parameters.AddWithValue("@TRA_PESO1", TRA_PESO1);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO1", TRA_FECHA_SERVICIO1);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO1", TRA_TIPO_BULTO1);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO1", TRA_NUM_BULTO1);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE2", TRA_NUM_GR_REMITENTE2);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE2", TRA_NUM_GR_TRANSPORTE2);
                        cmd.Parameters.AddWithValue("@TRA_PLACA2", TRA_PLACA2);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE2", TRA_BREVETE2);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO2", TRA_DIRECCION_INICIO2);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA2", TRA_DIRECCION_LLEGADA2);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA2", TRA_TIPO_CARGA2);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR2", TRA_NUM_CONTENEDOR2);
                        cmd.Parameters.AddWithValue("@TRA_PESO2", TRA_PESO2);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO2", TRA_FECHA_SERVICIO2);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO2", TRA_TIPO_BULTO2);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO2", TRA_NUM_BULTO2);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE3", TRA_NUM_GR_REMITENTE3);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE3", TRA_NUM_GR_TRANSPORTE3);
                        cmd.Parameters.AddWithValue("@TRA_PLACA3", TRA_PLACA3);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE3", TRA_BREVETE3);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO3", TRA_DIRECCION_INICIO3);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA3", TRA_DIRECCION_LLEGADA3);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA3", TRA_TIPO_CARGA3);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR3", TRA_NUM_CONTENEDOR3);
                        cmd.Parameters.AddWithValue("@TRA_PESO3", TRA_PESO3);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO3", TRA_FECHA_SERVICIO3);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO3", TRA_TIPO_BULTO3);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO3", TRA_NUM_BULTO3);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE4", TRA_NUM_GR_REMITENTE4);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE4", TRA_NUM_GR_TRANSPORTE4);
                        cmd.Parameters.AddWithValue("@TRA_PLACA4", TRA_PLACA4);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE4", TRA_BREVETE4);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO4", TRA_DIRECCION_INICIO4);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA4", TRA_DIRECCION_LLEGADA4);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA4", TRA_TIPO_CARGA4);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR4", TRA_NUM_CONTENEDOR4);
                        cmd.Parameters.AddWithValue("@TRA_PESO4", TRA_PESO4);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO4", TRA_FECHA_SERVICIO4);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO4", TRA_TIPO_BULTO4);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO4", TRA_NUM_BULTO4);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE5", TRA_NUM_GR_REMITENTE5);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE5", TRA_NUM_GR_TRANSPORTE5);
                        cmd.Parameters.AddWithValue("@TRA_PLACA5", TRA_PLACA5);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE5", TRA_BREVETE5);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO5", TRA_DIRECCION_INICIO5);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA5", TRA_DIRECCION_LLEGADA5);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA5", TRA_TIPO_CARGA5);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR5", TRA_NUM_CONTENEDOR5);
                        cmd.Parameters.AddWithValue("@TRA_PESO5", TRA_PESO5);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO5", TRA_FECHA_SERVICIO5);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO5", TRA_TIPO_BULTO5);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO5", TRA_NUM_BULTO5);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE6", TRA_NUM_GR_REMITENTE6);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE6", TRA_NUM_GR_TRANSPORTE6);
                        cmd.Parameters.AddWithValue("@TRA_PLACA6", TRA_PLACA6);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE6", TRA_BREVETE6);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO6", TRA_DIRECCION_INICIO6);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA6", TRA_DIRECCION_LLEGADA6);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA6", TRA_TIPO_CARGA6);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR6", TRA_NUM_CONTENEDOR6);
                        cmd.Parameters.AddWithValue("@TRA_PESO6", TRA_PESO6);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO6", TRA_FECHA_SERVICIO6);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO6", TRA_TIPO_BULTO6);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO6", TRA_NUM_BULTO6);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE7", TRA_NUM_GR_REMITENTE7);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE7", TRA_NUM_GR_TRANSPORTE7);
                        cmd.Parameters.AddWithValue("@TRA_PLACA7", TRA_PLACA7);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE7", TRA_BREVETE7);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO7", TRA_DIRECCION_INICIO7);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA7", TRA_DIRECCION_LLEGADA7);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA7", TRA_TIPO_CARGA7);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR7", TRA_NUM_CONTENEDOR7);
                        cmd.Parameters.AddWithValue("@TRA_PESO7", TRA_PESO7);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO7", TRA_FECHA_SERVICIO7);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO7", TRA_TIPO_BULTO7);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO7", TRA_NUM_BULTO7);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE8", TRA_NUM_GR_REMITENTE8);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE8", TRA_NUM_GR_TRANSPORTE8);
                        cmd.Parameters.AddWithValue("@TRA_PLACA8", TRA_PLACA8);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE8", TRA_BREVETE8);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO8", TRA_DIRECCION_INICIO8);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA8", TRA_DIRECCION_LLEGADA8);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA8", TRA_TIPO_CARGA8);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR8", TRA_NUM_CONTENEDOR8);
                        cmd.Parameters.AddWithValue("@TRA_PESO8", TRA_PESO8);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO8", TRA_FECHA_SERVICIO8);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO8", TRA_TIPO_BULTO8);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO8", TRA_NUM_BULTO8);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE9", TRA_NUM_GR_REMITENTE9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE9", TRA_NUM_GR_TRANSPORTE9);
                        cmd.Parameters.AddWithValue("@TRA_PLACA9", TRA_PLACA9);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE9", TRA_BREVETE9);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO9", TRA_DIRECCION_INICIO9);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA9", TRA_DIRECCION_LLEGADA9);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA9", TRA_TIPO_CARGA9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR9", TRA_NUM_CONTENEDOR9);
                        cmd.Parameters.AddWithValue("@TRA_PESO9", TRA_PESO9);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO9", TRA_FECHA_SERVICIO9);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO9", TRA_TIPO_BULTO9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO9", TRA_NUM_BULTO9);

                        val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    transaccion.Commit();

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

        public int ACTUALIZAR(int ID, int ID_CLIENTE, string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL,
       string FLAG_TRANSPORTE, string FLAG_CUADRILLA, string FLAG_RESGUARDO, string FLAG_AGE_ADUANA, string FLAG_AGE_CARGA, string FLAG_OTROS,
       string TRA_NUM_GR_REMITENTE, string TRA_NUM_GR_TRANSPORTE, string TRA_PLACA, string TRA_BREVETE, string TRA_DIRECCION_INICIO, string TRA_DIRECCION_LLEGADA,
       string TRA_TIPO_CARGA, string TRA_NUM_CONTENEDOR, string TRA_PESO, string TRA_FECHA_SERVICIO, string TRA_TIPO_BULTO, string TRA_NUM_BULTO, string CUAD_SERVICIO,
       string CUAD_DETALLE, string CUAD_LUGAR, string CUAD_NUM_PERSONAS, string RESG_PROVEEDOR, string RESG_RUTA, string AGE_ADU_ADUANA, string AGE_ADU_MANIFIESTO, string AGE_ADU_REGIMEN,
       string AGE_ADU_DAM, string AGE_ADU_CANAL, string AGE_ADU_EMPRESA, string AGE_ADU_FEC_ARRIBO, string AGE_ADU_FEC_RETIRO, string AGE_ADU_ALMACEN, string AGE_ADU_VALORFOB,
       string AGE_ADU_VALORCIF, string AGE_CAR_ADUANA, string AGE_CAR_MANIFIESTO, string AGE_CAR_PUERTO_ORIGEN, string AGE_CAR_PAIS, string AGE_CAR_EMP_TRANSP, string AGE_CAR_EMPRESA,
       string AGE_CAR_FEC_ARRIBO, string AGE_CAR_FEC_RETIRO, string AGE_CAR_PESO, string AGE_CAR_VOLUMEN, string AGE_CAR_NUM_BULTO, string AGE_CAR_ALMACEN, string OTRO_DETALLE,
       string OTRO_OBSERVACION, string USUARIO_MODIFICACION, string ESTADO,
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
            int val = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_ACTUALIZAR_ORDEN_SERVICIO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
                        cmd.Parameters.AddWithValue("@TIPO_DOC", TIPO_DOC);
                        cmd.Parameters.AddWithValue("@NUM_DOC", NUM_DOC);
                        cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE", FLAG_TRANSPORTE);
                        cmd.Parameters.AddWithValue("@FLAG_CUADRILLA", FLAG_CUADRILLA);
                        cmd.Parameters.AddWithValue("@FLAG_RESGUARDO", FLAG_RESGUARDO);
                        cmd.Parameters.AddWithValue("@FLAG_AGE_ADUANA", FLAG_AGE_ADUANA);
                        cmd.Parameters.AddWithValue("@FLAG_AGE_CARGA", FLAG_AGE_CARGA);
                        cmd.Parameters.AddWithValue("@FLAG_OTROS", FLAG_OTROS);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE", TRA_NUM_GR_REMITENTE);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE", TRA_NUM_GR_TRANSPORTE);
                        cmd.Parameters.AddWithValue("@TRA_PLACA", TRA_PLACA);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE", TRA_BREVETE);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO", TRA_DIRECCION_INICIO);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA", TRA_DIRECCION_LLEGADA);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA", TRA_TIPO_CARGA);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR", TRA_NUM_CONTENEDOR);
                        cmd.Parameters.AddWithValue("@TRA_PESO", TRA_PESO);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO", TRA_FECHA_SERVICIO);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO", TRA_TIPO_BULTO);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO", TRA_NUM_BULTO);
                        cmd.Parameters.AddWithValue("@CUAD_SERVICIO", CUAD_SERVICIO);
                        cmd.Parameters.AddWithValue("@CUAD_DETALLE", CUAD_DETALLE);
                        cmd.Parameters.AddWithValue("@CUAD_LUGAR", CUAD_LUGAR);
                        cmd.Parameters.AddWithValue("@CUAD_NUM_PERSONAS", CUAD_NUM_PERSONAS);
                        cmd.Parameters.AddWithValue("@RESG_PROVEEDOR", RESG_PROVEEDOR);
                        cmd.Parameters.AddWithValue("@RESG_RUTA", RESG_RUTA);
                        cmd.Parameters.AddWithValue("@AGE_ADU_ADUANA", AGE_ADU_ADUANA);
                        cmd.Parameters.AddWithValue("@AGE_ADU_MANIFIESTO", AGE_ADU_MANIFIESTO);
                        cmd.Parameters.AddWithValue("@AGE_ADU_REGIMEN", AGE_ADU_REGIMEN);
                        cmd.Parameters.AddWithValue("@AGE_ADU_DAM", AGE_ADU_DAM);
                        cmd.Parameters.AddWithValue("@AGE_ADU_CANAL", AGE_ADU_CANAL);
                        cmd.Parameters.AddWithValue("@AGE_ADU_EMPRESA", AGE_ADU_EMPRESA);
                        cmd.Parameters.AddWithValue("@AGE_ADU_FEC_ARRIBO", AGE_ADU_FEC_ARRIBO);
                        cmd.Parameters.AddWithValue("@AGE_ADU_FEC_RETIRO", AGE_ADU_FEC_RETIRO);
                        cmd.Parameters.AddWithValue("@AGE_ADU_ALMACEN", AGE_ADU_ALMACEN);
                        cmd.Parameters.AddWithValue("@AGE_ADU_VALORFOB", AGE_ADU_VALORFOB);
                        cmd.Parameters.AddWithValue("@AGE_ADU_VALORCIF", AGE_ADU_VALORCIF);
                        cmd.Parameters.AddWithValue("@AGE_CAR_ADUANA", AGE_CAR_ADUANA);
                        cmd.Parameters.AddWithValue("@AGE_CAR_MANIFIESTO", AGE_CAR_MANIFIESTO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_PUERTO_ORIGEN", AGE_CAR_PUERTO_ORIGEN);
                        cmd.Parameters.AddWithValue("@AGE_CAR_PAIS", AGE_CAR_PAIS);
                        cmd.Parameters.AddWithValue("@AGE_CAR_EMP_TRANSP", AGE_CAR_EMP_TRANSP);
                        cmd.Parameters.AddWithValue("@AGE_CAR_EMPRESA", AGE_CAR_EMPRESA);
                        cmd.Parameters.AddWithValue("@AGE_CAR_FEC_ARRIBO", AGE_CAR_FEC_ARRIBO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_FEC_RETIRO", AGE_CAR_FEC_RETIRO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_PESO", AGE_CAR_PESO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_VOLUMEN", AGE_CAR_VOLUMEN);
                        cmd.Parameters.AddWithValue("@AGE_CAR_NUM_BULTO", AGE_CAR_NUM_BULTO);
                        cmd.Parameters.AddWithValue("@AGE_CAR_ALMACEN", AGE_CAR_ALMACEN);
                        cmd.Parameters.AddWithValue("@OTRO_DETALLE", OTRO_DETALLE);
                        cmd.Parameters.AddWithValue("@OTRO_OBSERVACION", OTRO_OBSERVACION);
                        cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", USUARIO_MODIFICACION);
                        cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE1", FLAG_TRANSPORTE1);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE2", FLAG_TRANSPORTE2);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE3", FLAG_TRANSPORTE3);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE4", FLAG_TRANSPORTE4);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE5", FLAG_TRANSPORTE5);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE6", FLAG_TRANSPORTE6);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE7", FLAG_TRANSPORTE7);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE8", FLAG_TRANSPORTE8);
                        cmd.Parameters.AddWithValue("@FLAG_TRANSPORTE9", FLAG_TRANSPORTE9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE1", TRA_NUM_GR_REMITENTE1);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE1", TRA_NUM_GR_TRANSPORTE1);
                        cmd.Parameters.AddWithValue("@TRA_PLACA1", TRA_PLACA1);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE1", TRA_BREVETE1);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO1", TRA_DIRECCION_INICIO1);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA1", TRA_DIRECCION_LLEGADA1);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA1", TRA_TIPO_CARGA1);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR1", TRA_NUM_CONTENEDOR1);
                        cmd.Parameters.AddWithValue("@TRA_PESO1", TRA_PESO1);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO1", TRA_FECHA_SERVICIO1);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO1", TRA_TIPO_BULTO1);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO1", TRA_NUM_BULTO1);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE2", TRA_NUM_GR_REMITENTE2);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE2", TRA_NUM_GR_TRANSPORTE2);
                        cmd.Parameters.AddWithValue("@TRA_PLACA2", TRA_PLACA2);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE2", TRA_BREVETE2);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO2", TRA_DIRECCION_INICIO2);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA2", TRA_DIRECCION_LLEGADA2);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA2", TRA_TIPO_CARGA2);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR2", TRA_NUM_CONTENEDOR2);
                        cmd.Parameters.AddWithValue("@TRA_PESO2", TRA_PESO2);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO2", TRA_FECHA_SERVICIO2);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO2", TRA_TIPO_BULTO2);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO2", TRA_NUM_BULTO2);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE3", TRA_NUM_GR_REMITENTE3);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE3", TRA_NUM_GR_TRANSPORTE3);
                        cmd.Parameters.AddWithValue("@TRA_PLACA3", TRA_PLACA3);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE3", TRA_BREVETE3);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO3", TRA_DIRECCION_INICIO3);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA3", TRA_DIRECCION_LLEGADA3);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA3", TRA_TIPO_CARGA3);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR3", TRA_NUM_CONTENEDOR3);
                        cmd.Parameters.AddWithValue("@TRA_PESO3", TRA_PESO3);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO3", TRA_FECHA_SERVICIO3);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO3", TRA_TIPO_BULTO3);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO3", TRA_NUM_BULTO3);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE4", TRA_NUM_GR_REMITENTE4);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE4", TRA_NUM_GR_TRANSPORTE4);
                        cmd.Parameters.AddWithValue("@TRA_PLACA4", TRA_PLACA4);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE4", TRA_BREVETE4);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO4", TRA_DIRECCION_INICIO4);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA4", TRA_DIRECCION_LLEGADA4);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA4", TRA_TIPO_CARGA4);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR4", TRA_NUM_CONTENEDOR4);
                        cmd.Parameters.AddWithValue("@TRA_PESO4", TRA_PESO4);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO4", TRA_FECHA_SERVICIO4);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO4", TRA_TIPO_BULTO4);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO4", TRA_NUM_BULTO4);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE5", TRA_NUM_GR_REMITENTE5);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE5", TRA_NUM_GR_TRANSPORTE5);
                        cmd.Parameters.AddWithValue("@TRA_PLACA5", TRA_PLACA5);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE5", TRA_BREVETE5);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO5", TRA_DIRECCION_INICIO5);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA5", TRA_DIRECCION_LLEGADA5);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA5", TRA_TIPO_CARGA5);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR5", TRA_NUM_CONTENEDOR5);
                        cmd.Parameters.AddWithValue("@TRA_PESO5", TRA_PESO5);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO5", TRA_FECHA_SERVICIO5);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO5", TRA_TIPO_BULTO5);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO5", TRA_NUM_BULTO5);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE6", TRA_NUM_GR_REMITENTE6);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE6", TRA_NUM_GR_TRANSPORTE6);
                        cmd.Parameters.AddWithValue("@TRA_PLACA6", TRA_PLACA6);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE6", TRA_BREVETE6);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO6", TRA_DIRECCION_INICIO6);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA6", TRA_DIRECCION_LLEGADA6);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA6", TRA_TIPO_CARGA6);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR6", TRA_NUM_CONTENEDOR6);
                        cmd.Parameters.AddWithValue("@TRA_PESO6", TRA_PESO6);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO6", TRA_FECHA_SERVICIO6);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO6", TRA_TIPO_BULTO6);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO6", TRA_NUM_BULTO6);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE7", TRA_NUM_GR_REMITENTE7);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE7", TRA_NUM_GR_TRANSPORTE7);
                        cmd.Parameters.AddWithValue("@TRA_PLACA7", TRA_PLACA7);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE7", TRA_BREVETE7);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO7", TRA_DIRECCION_INICIO7);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA7", TRA_DIRECCION_LLEGADA7);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA7", TRA_TIPO_CARGA7);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR7", TRA_NUM_CONTENEDOR7);
                        cmd.Parameters.AddWithValue("@TRA_PESO7", TRA_PESO7);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO7", TRA_FECHA_SERVICIO7);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO7", TRA_TIPO_BULTO7);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO7", TRA_NUM_BULTO7);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE8", TRA_NUM_GR_REMITENTE8);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE8", TRA_NUM_GR_TRANSPORTE8);
                        cmd.Parameters.AddWithValue("@TRA_PLACA8", TRA_PLACA8);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE8", TRA_BREVETE8);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO8", TRA_DIRECCION_INICIO8);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA8", TRA_DIRECCION_LLEGADA8);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA8", TRA_TIPO_CARGA8);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR8", TRA_NUM_CONTENEDOR8);
                        cmd.Parameters.AddWithValue("@TRA_PESO8", TRA_PESO8);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO8", TRA_FECHA_SERVICIO8);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO8", TRA_TIPO_BULTO8);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO8", TRA_NUM_BULTO8);

                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_REMITENTE9", TRA_NUM_GR_REMITENTE9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_GR_TRANSPORTE9", TRA_NUM_GR_TRANSPORTE9);
                        cmd.Parameters.AddWithValue("@TRA_PLACA9", TRA_PLACA9);
                        cmd.Parameters.AddWithValue("@TRA_BREVETE9", TRA_BREVETE9);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_INICIO9", TRA_DIRECCION_INICIO9);
                        cmd.Parameters.AddWithValue("@TRA_DIRECCION_LLEGADA9", TRA_DIRECCION_LLEGADA9);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_CARGA9", TRA_TIPO_CARGA9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_CONTENEDOR9", TRA_NUM_CONTENEDOR9);
                        cmd.Parameters.AddWithValue("@TRA_PESO9", TRA_PESO9);
                        cmd.Parameters.AddWithValue("@TRA_FECHA_SERVICIO9", TRA_FECHA_SERVICIO9);
                        cmd.Parameters.AddWithValue("@TRA_TIPO_BULTO9", TRA_TIPO_BULTO9);
                        cmd.Parameters.AddWithValue("@TRA_NUM_BULTO9", TRA_NUM_BULTO9);


                        val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    transaccion.Commit();

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
        public int ELIMINAR(int ID)
        {
            int val = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_ELIMINAR_ORDEN_SERVICIO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    transaccion.Commit();

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



        public int GRABAR_ARCHIVOS(int ID,
        string ARCHIVO1_NOMBRE_ORIGINAL, string ARCHIVO1_NOMBRE_GENERADO, string ARCHIVO1_RUTA,
        string ARCHIVO2_NOMBRE_ORIGINAL, string ARCHIVO2_NOMBRE_GENERADO, string ARCHIVO2_RUTA,
        string ARCHIVO3_NOMBRE_ORIGINAL, string ARCHIVO3_NOMBRE_GENERADO, string ARCHIVO3_RUTA,
        string ARCHIVO4_NOMBRE_ORIGINAL, string ARCHIVO4_NOMBRE_GENERADO, string ARCHIVO4_RUTA,
        string ARCHIVO5_NOMBRE_ORIGINAL, string ARCHIVO5_NOMBRE_GENERADO, string ARCHIVO5_RUTA,
        string ARCHIVO6_NOMBRE_ORIGINAL, string ARCHIVO6_NOMBRE_GENERADO, string ARCHIVO6_RUTA)
        {
            int val = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {

                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_INSERTAR_ARCHIVO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@ARCHIVO1_NOMBRE_ORIGINAL", ARCHIVO1_NOMBRE_ORIGINAL.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO1_NOMBRE_GENERADO", ARCHIVO1_NOMBRE_GENERADO.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO1_RUTA", ARCHIVO1_RUTA.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO2_NOMBRE_ORIGINAL", ARCHIVO2_NOMBRE_ORIGINAL.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO2_NOMBRE_GENERADO", ARCHIVO2_NOMBRE_GENERADO.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO2_RUTA", ARCHIVO2_RUTA.Trim());

                        cmd.Parameters.AddWithValue("@ARCHIVO3_NOMBRE_ORIGINAL", ARCHIVO3_NOMBRE_ORIGINAL.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO3_NOMBRE_GENERADO", ARCHIVO3_NOMBRE_GENERADO.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO3_RUTA", ARCHIVO3_RUTA.Trim());

                        cmd.Parameters.AddWithValue("@ARCHIVO4_NOMBRE_ORIGINAL", ARCHIVO4_NOMBRE_ORIGINAL.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO4_NOMBRE_GENERADO", ARCHIVO4_NOMBRE_GENERADO.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO4_RUTA", ARCHIVO4_RUTA.Trim());

                        cmd.Parameters.AddWithValue("@ARCHIVO5_NOMBRE_ORIGINAL", ARCHIVO5_NOMBRE_ORIGINAL.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO5_NOMBRE_GENERADO", ARCHIVO5_NOMBRE_GENERADO.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO5_RUTA", ARCHIVO5_RUTA.Trim());

                        cmd.Parameters.AddWithValue("@ARCHIVO6_NOMBRE_ORIGINAL", ARCHIVO6_NOMBRE_ORIGINAL.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO6_NOMBRE_GENERADO", ARCHIVO6_NOMBRE_GENERADO.Trim());
                        cmd.Parameters.AddWithValue("@ARCHIVO6_RUTA", ARCHIVO6_RUTA.Trim());

                        val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    transaccion.Commit();

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



        public List<BE_Orden_Servicio> OBTENER_ARCHIVOS(int ID)
        {
            List<BE_Orden_Servicio> lista = new List<BE_Orden_Servicio>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_ARCHIVOS", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Orden_Servicio obj_BE = new BE_Orden_Servicio();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());

                        obj_BE.ARCHIVO1_NOMBRE_ORIGINAL = lector[1].ToString().Trim();
                        obj_BE.ARCHIVO1_NOMBRE_GENERADO = lector[2].ToString().Trim();
                        obj_BE.ARCHIVO1_RUTA = lector[3].ToString().Trim();

                        obj_BE.ARCHIVO2_NOMBRE_ORIGINAL = lector[4].ToString().Trim();
                        obj_BE.ARCHIVO2_NOMBRE_GENERADO = lector[5].ToString().Trim();
                        obj_BE.ARCHIVO2_RUTA = lector[6].ToString().Trim();

                        obj_BE.ARCHIVO3_NOMBRE_ORIGINAL = lector[7].ToString().Trim();
                        obj_BE.ARCHIVO3_NOMBRE_GENERADO = lector[8].ToString().Trim();
                        obj_BE.ARCHIVO3_RUTA = lector[9].ToString().Trim();

                        obj_BE.ARCHIVO4_NOMBRE_ORIGINAL = lector[10].ToString().Trim();
                        obj_BE.ARCHIVO4_NOMBRE_GENERADO = lector[11].ToString().Trim();
                        obj_BE.ARCHIVO4_RUTA = lector[12].ToString().Trim();

                        obj_BE.ARCHIVO5_NOMBRE_ORIGINAL = lector[13].ToString().Trim();
                        obj_BE.ARCHIVO5_NOMBRE_GENERADO = lector[14].ToString().Trim();
                        obj_BE.ARCHIVO5_RUTA = lector[15].ToString().Trim();

                        obj_BE.ARCHIVO6_NOMBRE_ORIGINAL = lector[16].ToString().Trim();
                        obj_BE.ARCHIVO6_NOMBRE_GENERADO = lector[17].ToString().Trim();
                        obj_BE.ARCHIVO6_RUTA = lector[18].ToString().Trim();


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






    }
}