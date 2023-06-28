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
    public class DA_Usuarios
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


        public List<BE_Usuarios> Validar_Login(string USUARIO, string CONTRASEÑA)
        {
            List<BE_Usuarios> lista = new List<BE_Usuarios>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_VALIDAR_LOGIN", con))
                {
                    cmd.Parameters.AddWithValue("@USUARIO", USUARIO);
                    cmd.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Usuarios obj_BE = new BE_Usuarios();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.APELLIDOS = lector[1].ToString().Trim();
                        obj_BE.NOMBRES = lector[2].ToString().Trim();
                        obj_BE.CORREO = lector[3].ToString().Trim();
                        obj_BE.USUARIO = lector[4].ToString().Trim();
                        obj_BE.CONTRASEÑA = lector[5].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[6].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[7].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[8].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[9].ToString().Trim();
                        obj_BE.ESTADO = lector[10].ToString().Trim();
                        obj_BE.PERFIL = lector[11].ToString().Trim();

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


        public List<BE_Usuarios> BUSCAR_USUARIOS(string APELLIDOS, string NOMBRES, string ESTADO)
        {
            List<BE_Usuarios> lista = new List<BE_Usuarios>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_USUARIO", con))
                {
                    cmd.Parameters.AddWithValue("@APELLIDOS", APELLIDOS);
                    cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES);
                    cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Usuarios obj_BE = new BE_Usuarios();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.APELLIDOS = lector[1].ToString().Trim();
                        obj_BE.NOMBRES = lector[2].ToString().Trim();
                        obj_BE.CORREO = lector[3].ToString().Trim();
                        obj_BE.USUARIO = lector[4].ToString().Trim();
                        obj_BE.CONTRASEÑA = lector[5].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[6].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[7].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[8].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[9].ToString().Trim();
                        obj_BE.ESTADO = lector[10].ToString().Trim();
                     

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



        public int ELIMINAR_USUARIOS(int ID)
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
                        cmd.CommandText = "SP_ELIMINAR_USUARIO";
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



        public List<BE_Usuarios> OBTENER_USUARIOS(int ID)
        {
            List<BE_Usuarios> lista = new List<BE_Usuarios>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_USUARIO", con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Usuarios obj_BE = new BE_Usuarios();

                        obj_BE.ID = Convert.ToInt32(lector[0].ToString().Trim());
                        obj_BE.APELLIDOS = lector[1].ToString().Trim();
                        obj_BE.NOMBRES = lector[2].ToString().Trim();
                        obj_BE.CORREO = lector[3].ToString().Trim();
                        obj_BE.USUARIO = lector[4].ToString().Trim();
                        obj_BE.CONTRASEÑA = lector[5].ToString().Trim();
                        obj_BE.FECHA_CREACION = lector[6].ToString().Trim();
                        obj_BE.USUARIO_CREACION = lector[7].ToString().Trim();
                        obj_BE.FECHA_MODIFICACION = lector[8].ToString().Trim();
                        obj_BE.USUARIO_MODIFICACION = lector[9].ToString().Trim();
                        obj_BE.ESTADO = lector[10].ToString().Trim();
                        obj_BE.PERFIL = lector[11].ToString().Trim();

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



        public int GRABAR_USUARIOS(string APELLIDOS, string NOMBRES, string CORREO, string USUARIO,
                    string CONTRASEÑA,string PERFIL)
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
                        cmd.CommandText = "SP_INSERTAR_USUARIO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@APELLIDOS", APELLIDOS);
                        cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES);
                        cmd.Parameters.AddWithValue("@CORREO", CORREO);
                        cmd.Parameters.AddWithValue("@USUARIO", USUARIO);
                        cmd.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);
                        cmd.Parameters.AddWithValue("@USUARIO_CREACION", "SYSTEM");
                        cmd.Parameters.AddWithValue("@PERFIL", PERFIL);


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



        public int ACTUALIZAR_USUARIOS(int ID, string APELLIDOS, string NOMBRES, string CORREO, string USUARIO,
                    string CONTRASEÑA, string ESTADO, string PERFIL)
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
                        cmd.CommandText = "SP_ACTUALIZAR_USUARIO";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@APELLIDOS", APELLIDOS);
                        cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES);
                        cmd.Parameters.AddWithValue("@CORREO", CORREO);
                        cmd.Parameters.AddWithValue("@USUARIO", USUARIO);
                        cmd.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);
                        cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", "SYSTEM");
                        cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
                        cmd.Parameters.AddWithValue("@PERFIL", PERFIL);
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


        
    public int CAMBIAR_CONTRASEÑA(int ID, string CLAVE1, string USUARIO)
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
                        cmd.CommandText = "SP_ACTUALIZAR_CLAVE";
                        cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@CLAVE1", CLAVE1);
                        cmd.Parameters.AddWithValue("@USUARIO", USUARIO);                        
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