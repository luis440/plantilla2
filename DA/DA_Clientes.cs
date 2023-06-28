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
    public class DA_Clientes
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


        public List<BE_Clientes> BUSCAR_CLIENTES(string TIPO_DOC, string NRO_DOC, string RAZON_SOCIAL, string ESTADO)
        {
            List<BE_Clientes> lista = new List<BE_Clientes>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_CLIENTES", con))
                {
                    cmd.Parameters.AddWithValue("@TIPO_DOC", TIPO_DOC);
                    cmd.Parameters.AddWithValue("@NUM_DOC", NRO_DOC);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Clientes obj_BE = new BE_Clientes();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.TIPO_DOC = lector[1].ToString().Trim();
                        obj_BE.NUM_DOC = lector[2].ToString().Trim();
                        obj_BE.RAZON_SOCIAL = lector[3].ToString().Trim();
                        obj_BE.DOMICILIO1 = lector[4].ToString().Trim();
                        obj_BE.DOMICILIO2 = lector[5].ToString().Trim();
                        obj_BE.ESTADO = lector[6].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[7].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[8].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[9].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[10].ToString().Trim();
                      


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



        public int ELIMINAR_CLIENTES(int ID)
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
                        cmd.CommandText = "SP_ELIMINAR_CLIENTE";
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



        public List<BE_Clientes> OBTENER_CLIENTES(int ID)
        {
            List<BE_Clientes> lista = new List<BE_Clientes>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_CLIENTE", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Clientes obj_BE = new BE_Clientes();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.TIPO_DOC = lector[1].ToString().Trim();
                        obj_BE.NUM_DOC = lector[2].ToString().Trim();
                        obj_BE.RAZON_SOCIAL = lector[3].ToString().Trim();
                        obj_BE.DOMICILIO1 = lector[4].ToString().Trim();
                        obj_BE.DOMICILIO2 = lector[5].ToString().Trim();
                        obj_BE.ESTADO = lector[6].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[7].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[8].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[9].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[10].ToString().Trim();
                        obj_BE.TELEFONO = lector[11].ToString().Trim();
                        obj_BE.CELULAR = lector[12].ToString().Trim();
                        obj_BE.CORREO = lector[13].ToString().Trim();
                        obj_BE.DEPARTAMENTO = lector[14].ToString().Trim();
                        obj_BE.PROVINCIA = lector[15].ToString().Trim();
                        obj_BE.DISTRITO = lector[16].ToString().Trim();
                        obj_BE.OBSERVACION = lector[17].ToString().Trim();

                       



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



        public int GRABAR_CLIENTES(string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL, string DOMICILIO1,
                    string DOMICILIO2, string TELEFONO, string CELULAR, string CORREO, string USUARIO_CREACION,string DEPARTAMENTO,
                    string PROVINCIA,string DISTRITO,string OBSERVACION)
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
                        cmd.CommandText = "SP_INSERTAR_CLIENTE";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TIPO_DOC", TIPO_DOC);
                        cmd.Parameters.AddWithValue("@NUM_DOC", NUM_DOC);
                        cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                        cmd.Parameters.AddWithValue("@DOMICILIO1", DOMICILIO1);
                        cmd.Parameters.AddWithValue("@DOMICILIO2", DOMICILIO2);
                        cmd.Parameters.AddWithValue("@TELEFONO", TELEFONO);
                        cmd.Parameters.AddWithValue("@CELULAR", CELULAR);
                        cmd.Parameters.AddWithValue("@CORREO", CORREO);
                        cmd.Parameters.AddWithValue("@USUARIO_CREACION", USUARIO_CREACION);
                        cmd.Parameters.AddWithValue("@DEPARTAMENTO", DEPARTAMENTO);
                        cmd.Parameters.AddWithValue("@PROVINCIA", PROVINCIA);
                        cmd.Parameters.AddWithValue("@DISTRITO", DISTRITO);
                        cmd.Parameters.AddWithValue("@OBSERVACION", OBSERVACION);


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



        public int ACTUALIZAR_CLIENTES(int ID, string TIPO_DOC, string NUM_DOC, string RAZON_SOCIAL, string DOMICILIO1,
                    string DOMICILIO2, string TELEFONO, string CELULAR, string CORREO, string USUARIO_MODIFICACION,
                    string DEPARTAMENTO, string PROVINCIA, string DISTRITO, string OBSERVACION, string ESTADO)
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
                        cmd.CommandText = "SP_ACTUALIZAR_CLIENTE";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@TIPO_DOC", TIPO_DOC);
                        cmd.Parameters.AddWithValue("@NUM_DOC", NUM_DOC);
                        cmd.Parameters.AddWithValue("@RAZON_SOCIAL", RAZON_SOCIAL);
                        cmd.Parameters.AddWithValue("@DOMICILIO1", DOMICILIO1);
                        cmd.Parameters.AddWithValue("@DOMICILIO2", DOMICILIO2);
                        cmd.Parameters.AddWithValue("@TELEFONO", TELEFONO);
                        cmd.Parameters.AddWithValue("@CELULAR", CELULAR);
                        cmd.Parameters.AddWithValue("@CORREO", CORREO);
                        cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", USUARIO_MODIFICACION);
                        cmd.Parameters.AddWithValue("@DEPARTAMENTO", DEPARTAMENTO);
                        cmd.Parameters.AddWithValue("@PROVINCIA", PROVINCIA);
                        cmd.Parameters.AddWithValue("@DISTRITO", DISTRITO);
                        cmd.Parameters.AddWithValue("@OBSERVACION", OBSERVACION);
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

        public List<BE_Clientes> OBTENER_DEPARTAMENTO()
        {
            List<BE_Clientes> lista = new List<BE_Clientes>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DEPARTAMENTO", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Clientes obj_BE = new BE_Clientes();

                        obj_BE.DEPARTAMENTO = lector[0].ToString().Trim();
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
        public List<BE_Clientes> OBTENER_PROVINCIA(string DEPARTAMENTO)
        {
            List<BE_Clientes> lista = new List<BE_Clientes>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_PROVINCIA", con))
                {
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", DEPARTAMENTO);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Clientes obj_BE = new BE_Clientes();
                        obj_BE.PROVINCIA = lector[0].ToString().Trim();
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
        public List<BE_Clientes> OBTENER_DISTRITO(string DEPARTAMENTO, string PROVINCIA)
        {
            List<BE_Clientes> lista = new List<BE_Clientes>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DISTRITO", con))
                {
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", DEPARTAMENTO);
                    cmd.Parameters.AddWithValue("@PROVINCIA", PROVINCIA);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Clientes obj_BE = new BE_Clientes();
                        obj_BE.DISTRITO = lector[0].ToString().Trim();
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

    }
}