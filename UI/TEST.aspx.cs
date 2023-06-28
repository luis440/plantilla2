using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class TEST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string DETALLE = "ªSER0002ºSERVICIO CUADRILLA | SERVICIO :CARGA | NRO PERSONAS :fdg | DETALLE :dfgdf | LUGAR :fdggfdºUNDº1º67º12.06º79.06ªSER0004ºSERVICIO AGENCIAMIENTO DE ADUANA | ADUANA :d | MANIFIESTO :fsdf | REGIMEN :a | DAM :asd | CANAL :fgdf | FECHA ARRIBO :sf | FECHA RETIRO :dfd | ALMACEN :as | VALOR FOB :fdg | VALOR CIF :fdg | EMPRESA :dfgºUNDº1º77º13.86º90.86";
            string[] valores = DETALLE.Split('ª');

            foreach (string a in valores)
            {
                if (a != "")
                {
                    string[] valores2 = a.Split('º');

                    string id = valores2[0].ToString();


                }

               
            }


        }
    }
}