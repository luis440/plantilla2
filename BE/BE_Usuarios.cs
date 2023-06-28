using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class BE_Usuarios
    {
        public int ID { get; set; }
        public string APELLIDOS { get; set; }

        public string NOMBRES { get; set; }
        public string CORREO { get; set; }
        public string USUARIO { get; set; }
        public string CONTRASEÑA { get; set; }


        public string FECHA_CREACION { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public string ESTADO { get; set; }
        public string EMPRESA { get; set; }

        public string PERFIL { get; set; }
        public int COD_EMPRESA { get; set; }
       
    }
}