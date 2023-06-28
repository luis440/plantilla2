using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class BE_Series
    {

        public string CODIGO_TIPO_COMPROBANTE { get; set; }
        public string DESCRIPCION_TIPO_COMPROBANTE { get; set; }

        public string CODIGO_EMPRESA { get; set; }
        public string DESCRIPCION_EMPRESA { get; set; }

       public int  ID { get; set; }
        public string EMPRESA { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string SERIE { get; set; }
        public string NUMERO { get; set; }
        public string ESTADO { get; set; }
        public string FECHA_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
    }
}