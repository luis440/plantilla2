using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class BE_Alumnos
    {
        public int ID { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRES { get; set; }
        public string SEXO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string NIVEL { get; set; }
        public string GRADO { get; set; }
        public string SECCION { get; set; }
        public string FECHA_CREACION { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public string ESTADO { get; set; }
        public string NOMBRE_ORIGINAL_FOTO_ALUMNO { get; set; }
        public string NOMBRE_GENERADO_FOTO_ALUMNO { get; set; }
        public string RUTA_FOTO_ALUMNO { get; set; }

        public string NOMBRE_CODIGO_QR_ALUMNO { get; set; }
        public string RUTA_CODIGO_QR_ALUMNO { get; set; }
        public string URL_QR_ALUMNO { get; set; }
        public string CODIGO_NIVEL { get; set; }
        public string DESCRIPCION_NIVEL { get; set; }

        public string CODIGO_GRADO { get; set; }
        public string DESCRIPCION_GRADO { get; set; }

        public string CODIGO_SECCION { get; set; }
        public string DESCRIPCION_SECCION { get; set; }

    }
}