using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class BE_Clientes
    {
        public int ID { get; set; }
        public string TIPO_DOC { get; set; }
        public string NUM_DOC { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string DOMICILIO1 { get; set; }
        public string DOMICILIO2 { get; set; }
        public string ESTADO { get; set; }
        public string FECHA_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string PROVINCIA { get; set; }
        public string DISTRITO { get; set; }

        public string DESCRIPCION { get; set; }

        public string TELEFONO { get; set; }
        public string CELULAR { get; set; }
        public string CORREO { get; set; }
        public string OBSERVACION { get; set; }



    }
}