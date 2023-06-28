using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class BE_Facturacion
    {
        public int ID { get; set; }
        public string SERIE { get; set; }
        public string NUMERO { get; set; }
        public string TOTAL_GENERAL { get; set; }
        public string FECHA { get; set; }
        public string ESTADO { get; set; }
        public string TIPO_COMPROBANTE { get; set; }
        public string DESCRIPCION { get; set; }
        public string CLIENTE { get; set; }
        public string TIPO_OPERACION { get; set; }
        public string MONEDA { get; set; }
        public string IGV { get; set; }
        public string TIPO_DOC_CLIENTE { get; set; }
        public string NUM_DOC_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string DIRECCION_CLIENTE { get; set; }
        public string SERIE_DOC_REL { get; set; }
        public string NUM_DOC_REL { get; set; }
        public string FECHA_DOC_REL { get; set; }
        public string TIPO_IMPUESTO { get; set; }
        public string INCL_IGV { get; set; }
      
        public string FECHA_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public string FORMA_PAGO { get; set; }
        public string TOTAL_IGV { get; set; }

        public string CODIGO { get; set; }
        public string SERVICIO { get; set; }
        public string UNIDAD { get; set; }
        public string CANTIDAD { get; set; }
        public string PRECIO { get; set; }
     
        public string TOTAL { get; set; }
        public string SUBTOTAL_GENERAL { get; set; }
        public string SUBTOTAL { get; set; }

        public string GLOSA { get; set; }
        
    }
}