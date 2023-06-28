using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BE;
using DA;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Diagnostics;

using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UI.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de SW_Alumnos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SW_Alumnos : System.Web.Services.WebService
    {
        DA_Alumnos obj_DA = new DA_Alumnos();

        /* IMAGEN ALUMNO */
        [WebMethod]
        public void Subir_Imagen_alumno()
        {
            try
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



                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Img_Alumno"), fileName);
                            imagenOriginal.Save(fileSavePath);

                        }
                        List<Datos_Archivo> lista = new List<Datos_Archivo>();


                        Datos_Archivo obj = new Datos_Archivo()
                        {
                            nombre_imagen_generado = fileName,
                            nombre_imagen_original = nombre_archivo_original,
                            ruta_imagen = "../Img_Alumno/" + fileName
                        };

                        lista.Add(obj);


                        string output = JsonConvert.SerializeObject(obj);


                        HttpContext.Current.Response.ContentType = "application/json";
                        HttpContext.Current.Response.Write(output);
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
               
            }
        }
        [WebMethod]
        public void Eliminar_Imagen_Logo()
        {
            HttpContext.Current.Response.Write("{}");
        }
        /***********************************************/
        //string TIPO_DOC, string NRO_DOC, string MONBRES, string ESTADO
        [WebMethod]
        public  DataTableResponse<BE_Alumnos> obtener(string ClientParameters,string ajax_data)
        {



            List<BE_Alumnos> Lista = new List<BE_Alumnos>();


            DataTableParameter dtp = JsonConvert.DeserializeObject<DataTableParameter>(ClientParameters);
            DataTableBusqueda BUSQUEDA = JsonConvert.DeserializeObject<DataTableBusqueda>(ajax_data);


            Lista = new DA_Alumnos().obtener(dtp.start, dtp.length, dtp.search.value,BUSQUEDA.TIPO_DOC, BUSQUEDA.NRO_DOC, BUSQUEDA.NOMBRES,BUSQUEDA.ESTADO);

            int total = new DA_Alumnos().obtenerTotal(BUSQUEDA.TIPO_DOC, BUSQUEDA.NRO_DOC, BUSQUEDA.NOMBRES, BUSQUEDA.ESTADO);

            return new DataTableResponse<BE_Alumnos>() { draw = dtp.draw, recordsFiltered = total, recordsTotal = total, data = Lista };
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


        [WebMethod]
        public int Grabar_Alumnos(string CODIGO, string NOMBRES, string SEXO, string TIPO_DOCUMENTO,
                   string NRO_DOCUMENTO, string ESTADO, string NIVEL, string GRADO, string SECCION,
                   string USUARIO_CREACION,string NOMBRE_FOTO_ORIGINAL,string NOMBRE_FOTO_GENERADO,string RUTA_FOTO,string URL_DOMINIO)
        {
            return obj_DA.GRABAR_ALUMNOS( CODIGO,  NOMBRES,  SEXO,  TIPO_DOCUMENTO,
                    NRO_DOCUMENTO,  ESTADO,  NIVEL,  GRADO,  SECCION,
                    USUARIO_CREACION,  NOMBRE_FOTO_ORIGINAL,  NOMBRE_FOTO_GENERADO,  RUTA_FOTO, URL_DOMINIO);
        }
        [WebMethod]
        public int Actualizar_Alumnos(string CODIGO, string NOMBRES, string SEXO, string TIPO_DOCUMENTO,
                  string NRO_DOCUMENTO, string ESTADO, string NIVEL, string GRADO, string SECCION,
                  string USUARIO_MODIFICACION, string NOMBRE_FOTO_ORIGINAL, string NOMBRE_FOTO_GENERADO, string RUTA_FOTO, string URL_DOMINIO)
        {
            return obj_DA.ACTUALIZAR_ALUMNOS(CODIGO, NOMBRES, SEXO, TIPO_DOCUMENTO,
                    NRO_DOCUMENTO, ESTADO, NIVEL, GRADO, SECCION,
                    USUARIO_MODIFICACION, NOMBRE_FOTO_ORIGINAL, NOMBRE_FOTO_GENERADO, RUTA_FOTO, URL_DOMINIO);
        }
        
            [WebMethod]
        public int Actualizar_Alumnos_QR(string CODIGO, string NOMBRES, string SEXO, string TIPO_DOCUMENTO,
                  string NRO_DOCUMENTO, string ESTADO, string NIVEL, string GRADO, string SECCION,
                  string USUARIO_MODIFICACION, string NOMBRE_FOTO_ORIGINAL, string NOMBRE_FOTO_GENERADO, string RUTA_FOTO, string URL_DOMINIO)
        {
            return obj_DA.ACTUALIZAR_ALUMNOS_QR(CODIGO, NOMBRES, SEXO, TIPO_DOCUMENTO,
                    NRO_DOCUMENTO, ESTADO, NIVEL, GRADO, SECCION,
                    USUARIO_MODIFICACION, NOMBRE_FOTO_ORIGINAL, NOMBRE_FOTO_GENERADO, RUTA_FOTO, URL_DOMINIO);
        }

        [WebMethod]
        public List<BE_Alumnos> Obtener_Nivel()
        {
            return obj_DA.OBTENER_NIVEL();
        }

        [WebMethod]
        public List<BE_Alumnos> Obtener_Grado(string CODIGO_NIVEL)
        {
            return obj_DA.OBTENER_GRADO(CODIGO_NIVEL);
        }
        [WebMethod]
        public List<BE_Alumnos> Obtener_Seccion()
        {
            return obj_DA.OBTENER_SECCION();
        }

        
       
        [WebMethod]
        public List<BE_Alumnos> Obtener_Alumnos(string CODIGO)
        {
            return obj_DA.OBTENER_ALUMNOS(CODIGO);
        }
        [WebMethod]
        public void Eliminar_Imagen()
        {/*
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

                    var imagenOriginal = new Bitmap(httpPostedFile);
                    var imagenRedimensionada = ScaleImage(imagenOriginal, 942, 530);
                    using (var gr = Graphics.FromImage(imagenRedimensionada))
                    {
                        gr.DrawImage(imagenOriginal, 0, 0, imagenRedimensionada.Width, imagenRedimensionada.Height);
                    }

                    using (imagenRedimensionada)
                    {
                        var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        var myEncoder = Encoder.Quality;
                        var myEncoderParameters = new EncoderParameters(1);
                        var myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        fileName = g.ToString() + "." + extension;



                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Foto_Principal"), fileName);
                        imagenRedimensionada.Save(fileSavePath);

                    }
                    List<Datos_Archivo> lista = new List<Datos_Archivo>();


                    Datos_Archivo obj = new Datos_Archivo()
                    {
                        nombre_imagen_generado = fileName,
                        nombre_imagen_original = nombre_archivo_original,
                        ruta_imagen = "Foto_Principal/" + fileName
                    };

                    lista.Add(obj);


                    string output = JsonConvert.SerializeObject(obj);


                    HttpContext.Current.Response.ContentType = "application/json";
                    HttpContext.Current.Response.Write(output);
                }



            }
            */
            HttpContext.Current.Response.Write("{}");
        }


        [WebMethod]
        public int Eliminar_Alumno(string CODIGO)
        {
            return obj_DA.ELIMINAR_ALUMNO(CODIGO);
        }


        //[WebMethod]
        //public List<BE_Alumnos> Buscar_Alumnos(string TIPO_DOC, string NRO_DOC, string MONBRES, string ESTADO)
        //{
        //    return obj_DA.BUSCAR_ALUMNOS(TIPO_DOC, NRO_DOC, MONBRES, ESTADO);
        //}






      

        public class DataTableParameter
        {
            public int draw { get; set; }
            public int length { get; set; }
            public int start { get; set; }
            public searchtxt search { get; set; }
         

        }
        public class DataTableBusqueda
        {
           
            public string TIPO_DOC { get; set; }
            public string NRO_DOC { get; set; }
            public string NOMBRES { get; set; }
            public string ESTADO { get; set; }


        }


        public class searchtxt
        {
            public string value { get; set; }
        }

        public struct DataTableResponse<T>
        {
            public int draw;
            public int recordsTotal;
            public int recordsFiltered;
            public List<T> data;
        }







    }
}
