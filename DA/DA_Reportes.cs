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
    public class DA_Reportes
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public List<BE_Reportes> REPORTE_SALIDA(string FECHA_INICIO, string FECHA_FIN, string NRO_DOC, string NOMBRES, string NIVEL, string GRADO, string SECCION)
        {
            List<BE_Reportes> lista = new List<BE_Reportes>();
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SP_REPORTE_SALIDA_ALUMNOS", con))
                {
                    cmd.Parameters.AddWithValue("@FEC_INI", FECHA_INICIO);
                    cmd.Parameters.AddWithValue("@FEC_FIN", FECHA_FIN);
                    cmd.Parameters.AddWithValue("@NRO_DOC", NRO_DOC);
                    cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES);
                    cmd.Parameters.AddWithValue("@NIVEL", NIVEL);
                    cmd.Parameters.AddWithValue("@GRADO", GRADO);
                    cmd.Parameters.AddWithValue("@SECCION", SECCION);



                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (lector.Read())
                    {
                        BE_Reportes obj_BE = new BE_Reportes();
                        obj_BE.CODIGO = lector[0].ToString().Trim();
                        obj_BE.NOMBRES = lector[1].ToString().Trim();
                        obj_BE.SEXO = lector[2].ToString().Trim();
                        obj_BE.TIPO_DOCUMENTO = lector[3].ToString().Trim();
                        obj_BE.NRO_DOCUMENTO = lector[4].ToString().Trim();
                        obj_BE.NIVEL = lector[5].ToString().Trim();
                        obj_BE.GRADO = lector[6].ToString().Trim();
                        obj_BE.SECCION = lector[7].ToString().Trim();
                        obj_BE.HORA = lector[8].ToString().Trim();
                        obj_BE.FECHA = lector[9].ToString().Trim();


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



