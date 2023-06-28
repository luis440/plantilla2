using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DA
{
    public class DA_Tipo_Cambio
    {


        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public List<BE_Tipo_Cambio> BUSCAR(string MONEDA, string FECHA)
        {
            List<BE_Tipo_Cambio> lista = new List<BE_Tipo_Cambio>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_TIPO_CAMBIO", con))
                {
                    cmd.Parameters.AddWithValue("@MONEDA", MONEDA);
                    cmd.Parameters.AddWithValue("@FECHA", FECHA);
              
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Tipo_Cambio obj_BE = new BE_Tipo_Cambio();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.MONEDA = lector[1].ToString().Trim();
                        obj_BE.FECHA = lector[2].ToString().Trim();
                        obj_BE.COMPRA = lector[3].ToString().Trim();
                        obj_BE.VENTA = lector[4].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[5].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[6].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[7].ToString().Trim();
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


        public int GRABAR(string MONEDA, string FECHA, string COMPRA, string VENTA, string USUARIO_CREACION)
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
                        cmd.CommandText = "SP_INSERTAR_TIPO_CAMBIO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MONEDA", MONEDA);
                        cmd.Parameters.AddWithValue("@FECHA", FECHA);
                        cmd.Parameters.AddWithValue("@COMPRA", COMPRA);
                        cmd.Parameters.AddWithValue("@VENTA", VENTA);
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

        public int ACTUALIZAR(int ID, string MONEDA, string FECHA, string COMPRA, string VENTA, string USUARIO_MODIFICACION)
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
                        cmd.CommandText = "SP_ACTUALIZAR_TIPO_CAMBIO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);

                        cmd.Parameters.AddWithValue("@MONEDA", MONEDA);
                        cmd.Parameters.AddWithValue("@FECHA", FECHA);
                        cmd.Parameters.AddWithValue("@COMPRA", COMPRA);
                        cmd.Parameters.AddWithValue("@VENTA", VENTA);
                        cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", USUARIO_MODIFICACION);
                    
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


        public List<BE_Tipo_Cambio> OBTENER(int ID)
        {
            List<BE_Tipo_Cambio> lista = new List<BE_Tipo_Cambio>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_TIPO_CAMBIO", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Tipo_Cambio obj_BE = new BE_Tipo_Cambio();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());

                        obj_BE.MONEDA = lector[1].ToString().Trim();
                        obj_BE.FECHA = lector[2].ToString().Trim();
                        obj_BE.COMPRA = lector[3].ToString().Trim();
                        obj_BE.VENTA = lector[4].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[5].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[6].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[7].ToString().Trim();
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

      


    }
}