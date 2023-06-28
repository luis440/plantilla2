using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;

namespace DA
{
    public class DA_Plantilla
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public List<BE_Alumnos> OBTENER_DATOS_PLANTILLA(string CODIGO)
        {
            List<BE_Alumnos> lista = new List<BE_Alumnos>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_DATOS_PLANTILLA", con))
                {
                    cmd.Parameters.AddWithValue("@CODIGO_GENERADO_ALUMNO", CODIGO);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Alumnos obj_BE = new BE_Alumnos();
                        obj_BE.CODIGO = lector[0].ToString().Trim();
                        obj_BE.NOMBRES = lector[1].ToString().Trim();
                        obj_BE.SEXO = lector[2].ToString().Trim();
                        obj_BE.NRO_DOCUMENTO = lector[3].ToString().Trim();
                        obj_BE.NIVEL = lector[4].ToString().Trim();
                        obj_BE.GRADO = lector[5].ToString().Trim();
                        obj_BE.SECCION = lector[6].ToString().Trim();
                        obj_BE.ESTADO = lector[7].ToString().Trim();
                        obj_BE.RUTA_FOTO_ALUMNO = lector[8].ToString().Trim();

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