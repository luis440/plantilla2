using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DA;
using BE;
namespace UI.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de SW_Usuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class SW_Usuarios : System.Web.Services.WebService
    {

        DA_Usuarios obj_DA = new DA_Usuarios();

        [WebMethod]
        public List<BE_Usuarios> Validar_Login(string USUARIO, string CONTRASEÑA)
        {
            return obj_DA.Validar_Login(USUARIO, CONTRASEÑA);

        }

        [WebMethod]
        public List<BE_Usuarios> Buscar_Usuarios(string APELLIDOS, string NOMBRES, string ESTADO)
        {
            return obj_DA.BUSCAR_USUARIOS(APELLIDOS, NOMBRES, ESTADO);
        }


        [WebMethod]
        public int Eliminar_Usuarios(int ID)
        {
            return obj_DA.ELIMINAR_USUARIOS(ID);
        }

        [WebMethod]
        public List<BE_Usuarios> Obtener_Usuarios(int ID)
        {
            return obj_DA.OBTENER_USUARIOS(ID);
        }

        [WebMethod]
        public int Grabar_Usuarios(string APELLIDOS, string NOMBRES, string CORREO, string USUARIO,
                    string CONTRASEÑA,string PERFIL)
        {
            return obj_DA.GRABAR_USUARIOS(APELLIDOS, NOMBRES, CORREO, USUARIO, CONTRASEÑA, PERFIL);
        }


        [WebMethod]
        public int Actualizar_Usuarios(int ID, string APELLIDOS, string NOMBRES, string CORREO, string USUARIO,
                    string CONTRASEÑA, string ESTADO,string PERFIL)
        {
            return obj_DA.ACTUALIZAR_USUARIOS(ID, APELLIDOS, NOMBRES, CORREO, USUARIO, CONTRASEÑA, ESTADO, PERFIL);
        }

        [WebMethod]
        public int Cambiar_contraseña(int ID, string CLAVE1, string USUARIO)
        {
            return obj_DA.CAMBIAR_CONTRASEÑA(ID, CLAVE1, USUARIO);
        }





    }
}
