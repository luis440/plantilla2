using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class BE_Tipo_Cambio
    {
        public int ID { get; set; }
         public string MONEDA { get; set; }
        public string FECHA { get; set; }
        public string COMPRA { get; set; }
        public string VENTA { get; set; }
        public string FECHA_CREACION { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
    }
}