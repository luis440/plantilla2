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
    public class DA_Series
    {

        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public List<BE_Series> BUSCAR_SERIES(string TIPO_COMPROBANTE, string SERIE, string ESTADO)
        {
            List<BE_Series> lista = new List<BE_Series>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_SERIES", con))
                {
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@SERIE", SERIE);                 
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Series obj_BE = new BE_Series();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                      
                        obj_BE.TIPO_DOCUMENTO = lector[1].ToString().Trim();
                        obj_BE.SERIE = lector[2].ToString().Trim();
                        obj_BE.NUMERO = lector[3].ToString().Trim();
                        obj_BE.ESTADO = lector[4].ToString().Trim();                      
                        obj_BE.FECHA_CREACION = lector[5].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[6].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[7].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[8].ToString().Trim();



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

        public List<BE_Series> OBTENER_TIPO_COMPROBANTE()
        {
            List<BE_Series> lista = new List<BE_Series>();
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
                        BE_Series obj_BE = new BE_Series();

                        obj_BE.CODIGO_TIPO_COMPROBANTE = lector[0].ToString().Trim();
                        obj_BE.DESCRIPCION_TIPO_COMPROBANTE = lector[1].ToString().Trim();



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
        public List<BE_Series> OBTENER_EMPRESA()
        {
            List<BE_Series> lista = new List<BE_Series>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_EMPRESA", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Series obj_BE = new BE_Series();

                        obj_BE.CODIGO_EMPRESA = lector[0].ToString().Trim();
                        obj_BE.DESCRIPCION_EMPRESA = lector[1].ToString().Trim();



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

        public int GRABAR_SERIES(string TIPO_COMPROBANTE, string SERIE, string NUMERO, string USUARIO_CREACION)
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
                        cmd.CommandText = "SP_INSERTAR_SERIE";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_COMPROBANTE);
                        cmd.Parameters.AddWithValue("@SERIE", SERIE);
                        cmd.Parameters.AddWithValue("@NUMERO", NUMERO);                  
                        cmd.Parameters.AddWithValue("@USUARIO_CREACION", USUARIO_CREACION);
                     


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

        public int ACTUALIZAR_SERIES(int ID, string TIPO_COMPROBANTE, string SERIE, string NUMERO, string USUARIO_MODIFICACION, string ESTADO)
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
                        cmd.CommandText = "SP_ACTUALIZAR_SERIE";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                    
                        cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_COMPROBANTE);
                        cmd.Parameters.AddWithValue("@SERIE", SERIE);
                        cmd.Parameters.AddWithValue("@NUMERO", NUMERO);
                        cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", USUARIO_MODIFICACION);
                        cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
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


        public List<BE_Series> OBTENER_SERIES(int ID)
        {
            List<BE_Series> lista = new List<BE_Series>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_SERIE", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Series obj_BE = new BE_Series();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                     
                        obj_BE.TIPO_DOCUMENTO = lector[1].ToString().Trim();
                        obj_BE.SERIE = lector[2].ToString().Trim();
                        obj_BE.NUMERO = lector[3].ToString().Trim();
                        obj_BE.ESTADO = lector[4].ToString().Trim();                      
                        obj_BE.FECHA_CREACION = lector[5].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[6].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[7].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[8].ToString().Trim();

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

        public int ELIMINAR_SERIE(int ID)
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
                        cmd.CommandText = "SP_ELIMINAR_SERIE";
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





    }
}