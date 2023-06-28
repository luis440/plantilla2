using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Reportes
{
    public partial class Reporte_Salida : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER_NIVEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(dt);

                ddlnivel_buscar.DataSource = dt;
                ddlnivel_buscar.DataTextField = "NIVEL";
                ddlnivel_buscar.DataValueField = "CODIGO";
                ddlnivel_buscar.DataBind();
                ddlnivel_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));
                con.Close();

                ddlgrado_buscar.Items.Clear();
                ddlseccion_buscar.Items.Clear();

                ddlgrado_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));
                ddlseccion_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));



                txtfecha_inicio_buscar.Value = DateTime.Now.ToShortDateString();
                txtfecha_fin_buscar.Value = DateTime.Now.ToShortDateString();

            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
           // if (!IsPostBack)
           // {
                try
                {
                    string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                    int ID = Convert.ToInt32(Request.QueryString["CODIGO"]);
                    var tipo = "";
                    var contrato = "";


                    SqlConnection con = new SqlConnection(conexion);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_REPORTE_SALIDA_ALUMNOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FEC_INI",Convert.ToDateTime(txtfecha_inicio_buscar.Value).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                    cmd.Parameters.AddWithValue("@FEC_FIN", Convert.ToDateTime(txtfecha_fin_buscar.Value).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@NRO_DOC", txtnro_documento_buscar.Value.Trim());
                    cmd.Parameters.AddWithValue("@NOMBRES", txtnombres_buscar.Value.Trim());
                    cmd.Parameters.AddWithValue("@NIVEL", ddlnivel_buscar.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@GRADO", ddlgrado_buscar.SelectedValue.Trim());
                    cmd.Parameters.AddWithValue("@SECCION", ddlseccion_buscar.SelectedValue.Trim());
                    SqlDataAdapter oda = new SqlDataAdapter(cmd);
                   
                DataSet2.Reporte_SalidaDataTable dtfacturaCabecera = new DataSet2.Reporte_SalidaDataTable();
                    oda.Fill(dtfacturaCabecera);
                   

                    ///Mostrar datos en el reporte
                    ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Informes.Reporte_Salida_Alumnos.rdlc";
                    ReportDataSource rds1 = new ReportDataSource("DataSet2", (DataTable)dtfacturaCabecera);
                   
                    ReportViewer1.LocalReport.DataSources.Clear();
                   
                    ReportViewer1.LocalReport.DataSources.Add(rds1);
                    //   byte[] pdf = ReportViewer1.LocalReport.Render("PDF");
                    ReportViewer1.LocalReport.Refresh();

              
                // Documento.Close();
                // Documento.Dispose();
                // var bytes = ReportViewer1.LocalReport.Render("PDF");
                //  Response.Buffer = true;
                // Response.Clear();
                // Response.ContentType = "application/pdf";
                // Response.AddHeader("content-disposition", "inline; filename=" + dtfacturaCabecera[0][1].ToString() + "-" + dtfacturaCabecera[0][2].ToString() + ".pdf");
                //  Response.BinaryWrite(bytes);
                // Response.Flush();
                // Response.End();
                //Response.Close();
            }
                catch (Exception ex)
                {

                }
           // }
        }

        protected void ddlnivel_buscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nivel = ddlnivel_buscar.SelectedValue;

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_OBTENER_GRADO", con);
            cmd.Parameters.AddWithValue("@NIVEL", nivel.Trim());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oda = new SqlDataAdapter(cmd);
            oda.Fill(dt);

            ddlgrado_buscar.DataSource = dt;
            ddlgrado_buscar.DataTextField = "GRADO";
            ddlgrado_buscar.DataValueField = "CODIGO";
            ddlgrado_buscar.DataBind();
            ddlgrado_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));


            if (nivel=="B")
            {
                ddlgrado_buscar.Items.Clear();
                ddlseccion_buscar.Items.Clear();
                ddlgrado_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));
                ddlseccion_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));
            }
        }

        protected void ddlgrado_buscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string grado = ddlgrado_buscar.SelectedValue;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_OBTENER_SECCION", con);
          
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oda = new SqlDataAdapter(cmd);
            oda.Fill(dt);

            ddlseccion_buscar.DataSource = dt;
            ddlseccion_buscar.DataTextField = "SECCION";
            ddlseccion_buscar.DataValueField = "CODIGO";
            ddlseccion_buscar.DataBind();
            ddlseccion_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));


            if (grado == "B")
            {
               
                ddlseccion_buscar.Items.Clear();
              
                ddlseccion_buscar.Items.Insert(0, new ListItem("<< Seleccione >>", "B"));
            }
        }
    }
}