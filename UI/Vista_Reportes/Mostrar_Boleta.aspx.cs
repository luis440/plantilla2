using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using Microsoft.Reporting.WebForms;
namespace UI.Vista_Reportes
{
    public partial class Mostrar_Boleta : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int ID = Convert.ToInt32(Request.QueryString["CODIGO"]);
                    var tipo = "";
                    var contrato = "";


                    SqlConnection con = new SqlConnection(conexion);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_OBTENER_COMPROBANTE_CAB_REPORTE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    SqlDataAdapter oda = new SqlDataAdapter(cmd);
                    DataSet1.FACTURADataTable dtfacturaCabecera = new DataSet1.FACTURADataTable();
                    oda.Fill(dtfacturaCabecera);

                    cmd.Parameters.Clear();
                    SqlCommand cmd2 = new SqlCommand("SP_OBTENER_COMPROBANTE_DET_REPORTE", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@ID", ID);
                    SqlDataAdapter oda2 = new SqlDataAdapter(cmd2);
                    DataSet1.FACTURA_DETDataTable dtfacturaDetalle = new DataSet1.FACTURA_DETDataTable();
                    oda2.Fill(dtfacturaDetalle);



                    // DataSet1 ds = new DataSet1();
                    //ds.Tables[0].Merge(dtfacturaCabecera);
                    //ds.Tables[1].Merge(dtfacturaDetalle);


                    ///Mostrar datos en el reporte
                    ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Comprobantes.Boleta.rdlc";
                    ReportDataSource rds1 = new ReportDataSource("DataSet1", (DataTable)dtfacturaCabecera);
                    ReportDataSource rds2 = new ReportDataSource("DataSet2", (DataTable)dtfacturaDetalle);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds1);
                    ReportViewer1.LocalReport.DataSources.Add(rds2);
                    //   byte[] pdf = ReportViewer1.LocalReport.Render("PDF");
                    ReportViewer1.LocalReport.Refresh();


                    // Documento.Close();
                    // Documento.Dispose();
                    var bytes = ReportViewer1.LocalReport.Render("PDF");
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "inline; filename="+ dtfacturaCabecera[0][1].ToString()+"-"+dtfacturaCabecera[0][2].ToString() + ".pdf");
                    Response.BinaryWrite(bytes);
                   // Response.Flush();
                    Response.End();
                    //Response.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}