using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using BE;
namespace DA
{
    public class DA_Alumnos
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


        public int GRABAR_ALUMNOS(string CODIGO, string NOMBRES, string SEXO, string TIPO_DOCUMENTO,
                   string NRO_DOCUMENTO, string ESTADO, string NIVEL, string GRADO, string SECCION,
                   string USUARIO_CREACION, string NOMBRE_FOTO_ORIGINAL, string NOMBRE_FOTO_GENERADO, string RUTA_FOTO,string URL_DOMINIO)


        {

            var CODIGO_GENERADO_TARJETA = Guid.NewGuid().ToString("N").Substring(0, 15);

            int val = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {
                    string res = Generar_QR(URL_DOMINIO + "/Plantilla.aspx?Codigo=", CODIGO_GENERADO_TARJETA);

                    string[] datos_respuesta_generas_QR = res.Split('|');


                    string URL_QR = datos_respuesta_generas_QR[1];
                    string NOMBRE_IMAGEN_CODIGO_QR = datos_respuesta_generas_QR[0];
                    string RUTA_IMAGEN_CODIGO_QR = "../Img_QR_Alumno/" + NOMBRE_IMAGEN_CODIGO_QR;




                    if (res != "")
                    {
                        using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                        {
                            val = 0;
                            cmd.CommandText = "INSERTAR_ALUMNO";
                            cmd.Transaction = transaccion;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CODIGO", CODIGO.Trim());
                            cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES.Trim());
                            cmd.Parameters.AddWithValue("@SEXO", SEXO.Trim());
                            cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_DOCUMENTO.Trim());
                            cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", NRO_DOCUMENTO.Trim());
                            cmd.Parameters.AddWithValue("@NIVEL", NIVEL.Trim());
                            cmd.Parameters.AddWithValue("@GRADO", GRADO.Trim());
                            cmd.Parameters.AddWithValue("@SECCION", SECCION.Trim());
                            cmd.Parameters.AddWithValue("@USUARIO_CREACION", USUARIO_CREACION.Trim());
                            cmd.Parameters.AddWithValue("@NOMBRE_ORIGINAL_FOTO_ALUMNO", NOMBRE_FOTO_ORIGINAL.Trim());
                            cmd.Parameters.AddWithValue("@NOMBRE_GENERADO_FOTO_ALUMNO", NOMBRE_FOTO_GENERADO.Trim());
                            cmd.Parameters.AddWithValue("@RUTA_FOTO_ALUMNO", RUTA_FOTO.Trim());
                            cmd.Parameters.AddWithValue("@NOMBRE_CODIGO_QR_ALUMNO", NOMBRE_IMAGEN_CODIGO_QR.Trim());
                            cmd.Parameters.AddWithValue("@RUTA_CODIGO_QR_ALUMNO", RUTA_IMAGEN_CODIGO_QR.Trim());
                            cmd.Parameters.AddWithValue("@URL_QR_ALUMNO", URL_QR.Trim());
                            cmd.Parameters.AddWithValue("@CODIGO_GENERADO_ALUMNO", CODIGO_GENERADO_TARJETA.Trim());

                            val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                      
                        transaccion.Commit();

                    }
                    else { val = -1; }


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

        public int ACTUALIZAR_ALUMNOS(string CODIGO, string NOMBRES, string SEXO, string TIPO_DOCUMENTO,
                  string NRO_DOCUMENTO, string ESTADO, string NIVEL, string GRADO, string SECCION,
                  string USUARIO_MODIFICACION, string NOMBRE_FOTO_ORIGINAL, string NOMBRE_FOTO_GENERADO, string RUTA_FOTO, string URL_DOMINIO)

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
                            cmd.CommandText = "SP_ACTUALIZAR_ALUMNO";
                            cmd.Transaction = transaccion;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CODIGO", CODIGO.Trim());
                            cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES.Trim());
                            cmd.Parameters.AddWithValue("@SEXO", SEXO.Trim());
                            cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_DOCUMENTO.Trim());
                            cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", NRO_DOCUMENTO.Trim());
                            cmd.Parameters.AddWithValue("@NIVEL", NIVEL.Trim());
                            cmd.Parameters.AddWithValue("@GRADO", GRADO.Trim());
                            cmd.Parameters.AddWithValue("@SECCION", SECCION.Trim());
                            cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", USUARIO_MODIFICACION.Trim());
                            cmd.Parameters.AddWithValue("@NOMBRE_ORIGINAL_FOTO_ALUMNO", NOMBRE_FOTO_ORIGINAL.Trim());
                            cmd.Parameters.AddWithValue("@NOMBRE_GENERADO_FOTO_ALUMNO", NOMBRE_FOTO_GENERADO.Trim());
                            cmd.Parameters.AddWithValue("@RUTA_FOTO_ALUMNO", RUTA_FOTO.Trim());
                            cmd.Parameters.AddWithValue("@ESTADO", ESTADO.Trim());


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


        public int ACTUALIZAR_ALUMNOS_QR(string CODIGO, string NOMBRES, string SEXO, string TIPO_DOCUMENTO,
                  string NRO_DOCUMENTO, string ESTADO, string NIVEL, string GRADO, string SECCION,
                  string USUARIO_MODIFICACION, string NOMBRE_FOTO_ORIGINAL, string NOMBRE_FOTO_GENERADO, string RUTA_FOTO, string URL_DOMINIO)

        {

            int val = 0;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            using (SqlTransaction transaccion = con.BeginTransaction())
            {
                try
                {
                    var CODIGO_GENERADO_TARJETA = Guid.NewGuid().ToString("N").Substring(0, 15);
                  
                    string res = Generar_QR(URL_DOMINIO + "/Plantilla.aspx?Codigo=", CODIGO_GENERADO_TARJETA);
                    string[] datos_respuesta_generas_QR = res.Split('|');


                    string URL_QR = datos_respuesta_generas_QR[1];
                    string NOMBRE_IMAGEN_CODIGO_QR = datos_respuesta_generas_QR[0];
                    string RUTA_IMAGEN_CODIGO_QR = "../Img_QR_Alumno/" + NOMBRE_IMAGEN_CODIGO_QR;


                    using (SqlCommand cmd = transaccion.Connection.CreateCommand())
                    {
                        val = 0;
                        cmd.CommandText = "SP_ACTUALIZAR_ALUMNO_QR";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CODIGO", CODIGO.Trim());
                        cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES.Trim());
                        cmd.Parameters.AddWithValue("@SEXO", SEXO.Trim());
                        cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_DOCUMENTO.Trim());
                        cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", NRO_DOCUMENTO.Trim());
                        cmd.Parameters.AddWithValue("@NIVEL", NIVEL.Trim());
                        cmd.Parameters.AddWithValue("@GRADO", GRADO.Trim());
                        cmd.Parameters.AddWithValue("@SECCION", SECCION.Trim());
                        cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", USUARIO_MODIFICACION.Trim());
                        cmd.Parameters.AddWithValue("@NOMBRE_ORIGINAL_FOTO_ALUMNO", NOMBRE_FOTO_ORIGINAL.Trim());
                        cmd.Parameters.AddWithValue("@NOMBRE_GENERADO_FOTO_ALUMNO", NOMBRE_FOTO_GENERADO.Trim());
                        cmd.Parameters.AddWithValue("@RUTA_FOTO_ALUMNO", RUTA_FOTO.Trim());                     
                        cmd.Parameters.AddWithValue("@NOMBRE_CODIGO_QR_ALUMNO", NOMBRE_IMAGEN_CODIGO_QR.Trim());
                        cmd.Parameters.AddWithValue("@RUTA_CODIGO_QR_ALUMNO", RUTA_IMAGEN_CODIGO_QR.Trim());
                        cmd.Parameters.AddWithValue("@URL_QR_ALUMNO", URL_QR.Trim());
                        cmd.Parameters.AddWithValue("@ESTADO", ESTADO.Trim());
                        cmd.Parameters.AddWithValue("@CODIGO_GENERADO_ALUMNO", CODIGO_GENERADO_TARJETA.Trim());

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

        public string Generar_QR(string LINK_QR, string CODIGO_GENERADO_TARJETA)
        {
            string fileName = "";
            var NOMBRE_QR = "";
            var URL = LINK_QR + CODIGO_GENERADO_TARJETA;
            try
            {
                
                QRCodeEncoder encoder = new QRCodeEncoder();
                encoder.QRCodeScale = 20;
                Bitmap img = encoder.Encode(URL);
                Image QR = (System.Drawing.Image)img;
                NOMBRE_QR = Guid.NewGuid().ToString().Trim();
                fileName = "~/Img_QR_Alumno/" + NOMBRE_QR + ".png";
                // img.Save( Server.MapPath(fileName));
                img.Save(System.Web.Hosting.HostingEnvironment.MapPath(fileName));
            }
            catch (Exception ex)
            {
                NOMBRE_QR = "";
            }
            return NOMBRE_QR + ".png|" + URL;

        }


        public List<BE_Alumnos> OBTENER_NIVEL()
        {
            List<BE_Alumnos> lista = new List<BE_Alumnos>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_NIVEL", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Alumnos obj_BE = new BE_Alumnos();

                        obj_BE.CODIGO_NIVEL = lector[0].ToString().Trim();
                        obj_BE.DESCRIPCION_NIVEL = lector[1].ToString().Trim();



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
        public List<BE_Alumnos> OBTENER_GRADO(string CODIGO_NIVEL)
        {
            List<BE_Alumnos> lista = new List<BE_Alumnos>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_GRADO", con))
                {
                    cmd.Parameters.AddWithValue("@NIVEL", CODIGO_NIVEL);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Alumnos obj_BE = new BE_Alumnos();
                        obj_BE.CODIGO_GRADO = lector[0].ToString().Trim();
                        obj_BE.DESCRIPCION_GRADO = lector[1].ToString().Trim();

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

        public List<BE_Alumnos> OBTENER_SECCION()
        {
            List<BE_Alumnos> lista = new List<BE_Alumnos>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_SECCION", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Alumnos obj_BE = new BE_Alumnos();
                        obj_BE.CODIGO_SECCION = lector[0].ToString().Trim();
                        obj_BE.DESCRIPCION_SECCION = lector[1].ToString().Trim();

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
        //public List<BE_Alumnos> BUSCAR_ALUMNOS(string TIPO_DOC, string NRO_DOC, string MONBRES, string ESTADO)
        //{
        //    List<BE_Alumnos> lista = new List<BE_Alumnos>();
        //    try
        //    {

        //        SqlConnection con = new SqlConnection(conexion);
        //        con.Open();

        //        using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_ALUMNOS", con))
        //        {

        //            cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_DOC);
        //            cmd.Parameters.AddWithValue("@DOCUMENTO", NRO_DOC);
        //            cmd.Parameters.AddWithValue("@NOMBRES", MONBRES);
        //            cmd.Parameters.AddWithValue("@ESTADO", ESTADO);



        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //            while (lector.Read())
        //            {
        //                BE_Alumnos obj_BE = new BE_Alumnos();
        //                obj_BE.CODIGO = lector[0].ToString().Trim();
        //                obj_BE.TIPO_DOCUMENTO = lector[3].ToString().Trim();
        //                obj_BE.NRO_DOCUMENTO = lector[4].ToString().Trim();
        //                obj_BE.NOMBRES = lector[1].ToString().Trim();
        //                obj_BE.ESTADO = lector[12].ToString().Trim();


        //                lista.Add(obj_BE);
        //            }

        //            lector.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        StackTrace st = new StackTrace(ex, true);
        //        StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
        //             && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
        //             && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
        //             && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

        //        string MachineName = System.Environment.MachineName;
        //        string UserName = System.Environment.UserName.ToUpper();
        //        string Mensaje = ex.Message;
        //        int LineaError = frame.GetFileLineNumber();
        //        string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
        //        string Clase = frame.GetMethod().DeclaringType.Name;
        //        string metodo = frame.GetMethod().Name;
        //        string codigoError = Convert.ToString(frame.GetHashCode());
        //    }
        //    return lista;
        //}


        public List<BE_Alumnos> obtener(int ignorar_primeros, int cantidad_filas, string filtro, string TIPO_DOC, string NRO_DOC, string NOMBRES, string ESTADO)
        {

            List<BE_Alumnos> lista = new List<BE_Alumnos>();
           
            using (SqlConnection cn = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("SP_BUSCAR_ALUMNOS", cn);
                cmd.Parameters.AddWithValue("ignorar_primeros", ignorar_primeros);
                cmd.Parameters.AddWithValue("cantidad_filas", cantidad_filas);

                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", string.IsNullOrEmpty(TIPO_DOC) ? "": TIPO_DOC.Trim()) ;
                cmd.Parameters.AddWithValue("@DOCUMENTO", string.IsNullOrEmpty(NRO_DOC) ? "" : NRO_DOC.Trim());
                cmd.Parameters.AddWithValue("@NOMBRES", string.IsNullOrEmpty(NOMBRES) ? "" : NOMBRES.Trim());
                cmd.Parameters.AddWithValue("@ESTADO", string.IsNullOrEmpty(ESTADO) ? "" : ESTADO.Trim());
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new BE_Alumnos()
                        {
                            CODIGO = dr["CODIGO"].ToString(),
                            TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString(),
                            NRO_DOCUMENTO = dr["NRO_DOCUMENTO"].ToString(),
                            NOMBRES = dr["NOMBRES"].ToString(),
                            ESTADO = dr["ESTADO"].ToString()
                        });

                    }

                }

            }

            return lista;
        }


        public int obtenerTotal(string TIPO_DOC, string NRO_DOC, string NOMBRES, string ESTADO)
        {
            int total = 0;

            using (SqlConnection cn = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("select dbo.fn_obtenertotal(@TIPO_DOCUMENTO,@DOCUMENTO,@NOMBRES,@ESTADO)", cn);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", string.IsNullOrEmpty(TIPO_DOC) ? "" : TIPO_DOC.Trim());
                cmd.Parameters.AddWithValue("@DOCUMENTO", string.IsNullOrEmpty(NRO_DOC) ? "" : NRO_DOC.Trim());
                cmd.Parameters.AddWithValue("@NOMBRES", string.IsNullOrEmpty(NOMBRES) ? "" : NOMBRES.Trim());
                cmd.Parameters.AddWithValue("@ESTADO", string.IsNullOrEmpty(ESTADO) ? "" : ESTADO.Trim());
                cmd.CommandType = CommandType.Text;

                cn.Open();

                total = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }


            return total;

        }

        public List<BE_Alumnos> OBTENER_ALUMNOS(string CODIGO)
        {
            List<BE_Alumnos> lista = new List<BE_Alumnos>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_ALUMNOS", con))
                {
                    cmd.Parameters.AddWithValue("@CODIGO", CODIGO);
                 

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Alumnos obj_BE = new BE_Alumnos();
                        obj_BE.CODIGO = lector[0].ToString().Trim();
                        obj_BE.NOMBRES = lector[1].ToString().Trim();
                        obj_BE.SEXO = lector[2].ToString().Trim();
                        obj_BE.TIPO_DOCUMENTO = lector[3].ToString().Trim();
                        obj_BE.NRO_DOCUMENTO = lector[4].ToString().Trim();
                        obj_BE.NIVEL = lector[5].ToString().Trim();
                        obj_BE.GRADO = lector[6].ToString().Trim();
                        obj_BE.SECCION = lector[7].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[8].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[9].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[10].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[11].ToString().Trim();
                        obj_BE.ESTADO = lector[12].ToString().Trim();
                        obj_BE.NOMBRE_ORIGINAL_FOTO_ALUMNO = lector[13].ToString().Trim();
                        obj_BE.NOMBRE_GENERADO_FOTO_ALUMNO = lector[14].ToString().Trim();
                        obj_BE.RUTA_FOTO_ALUMNO = lector[15].ToString().Trim();
                        obj_BE.NOMBRE_CODIGO_QR_ALUMNO = lector[16].ToString().Trim();
                        obj_BE.RUTA_CODIGO_QR_ALUMNO = lector[17].ToString().Trim();
                        obj_BE.URL_QR_ALUMNO = lector[18].ToString().Trim();







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

    


        public int ELIMINAR_ALUMNO(string CODIGO)
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
                        cmd.CommandText = "SP_ELIMINAR_ALUMNO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CODIGO", CODIGO);
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
    }
}