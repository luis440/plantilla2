<%@ Page Title="" Language="C#" MasterPageFile="~/Mernu.Master" AutoEventWireup="true" CodeBehind="Reporte_Salida.aspx.cs" Inherits="UI.Reportes.Reporte_Salida" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Reporte de Salida</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../Principal.aspx">Inicio</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>Reportes</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Reporte de Salida</strong>
                        </li>
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>
    <br />
     <div class="row">
                <div class="col-lg-12">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Reporte de Salida <small></small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                              
                            </div>
                        </div>
                        <div class="ibox-content">
                           
                             <div class="row">
      
               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
 
       <%-- <div class="row" style="margin:2px;text-align:center">
           
            
           
            <hr/>
            </div>--%>
        

             <div class="row" style="margin:2px">
  
                  <div id="data_1" class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                 Fecha Inicio :
                       <div class="input-group date">
                  <span class="input-group-addon"><i class="fa fa-calendar"></i></span><input type="text"  class="form-control" id="txtfecha_inicio_buscar" runat="server" enableviewstate="True" />
                           </div>
                 </div>
                   <div id="data_2" class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                 Fecha Fin :
                         <div class="input-group date">
                  <span class="input-group-addon"><i class="fa fa-calendar"></i></span> <input type="text"  class="form-control" id="txtfecha_fin_buscar" runat="server"/>
                 </div>
                         </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                 Nro Documento :
                 <input type="text"  class="form-control" id="txtnro_documento_buscar" runat="server"/>
                 </div>

                    
                     <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12" >
                        Nombres :
                          <input type="text"  class="form-control" id="txtnombres_buscar" runat="server"/>
                 </div>
          
             

                     <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                         
                 </div>

                 </div>
                   <br />
                     <div class="row" style="margin:2px">
                                            <div  class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                Nivel :
                                          
                                                <asp:DropDownList ID="ddlnivel_buscar" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlnivel_buscar_SelectedIndexChanged">
                                                    

                                                </asp:DropDownList>
                                             </div>
                                           <div  class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                 Grado : 
                                              
                                               <asp:DropDownList ID="ddlgrado_buscar" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlgrado_buscar_SelectedIndexChanged"></asp:DropDownList>
                                             </div>
                                           <div  class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                               Seccion : 
                                          
                                                 <asp:DropDownList ID="ddlseccion_buscar" class="form-control" runat="server"></asp:DropDownList>
                                             </div>
                                            <div  class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                              <br />
                         <%--<button id="btnbuscar" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Buscar</button>--%>
                                                 <asp:Button ID="Button1" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" runat="server" Text="Buscar" OnClick="Button1_Click" />
                                                </div>
                        
                                          </div>
            <hr />
                   <div class="row" style="margin:2px">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
 <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Style="width: 100%; height: 500px">

            </rsweb:ReportViewer>
            </div>
                           </div>
                   </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       <%-- <div class="row" style="margin:2px">
  
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
 
                                 

            <table id="Tabla_Reporte" class="table table-hover  table-striped compact nowrap" style="display:none" >
                <thead>
                    <tr>
                         
                          <th>CODIGO</th>    
                          <th>NOMBRES</th>  
                          <th>SEXO</th>  
                        <th>TIP DOC</th>    
                          <th>NRO DOCUMENTO</th>                       
                          <th>NIVEL</th>
                          <th>GRADO</th>
                            <th>SECCION</th>
                            <th>HORA</th>
                            <th>FECHA</th>
                           
                      
                    </tr>
                 </thead>
               
            </table>

                </div>   


             </div> 
       </div>--%>
       
 <div class="row" style="margin:2px">
  
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
 
                                 
            
         

               
 
                                 

           

                </div>   


             </div> 
       </div>


    </div>

             </div>











                        </div>
                    </div>
                </div>
            </div>


    
    <style>
    .editar {
       cursor:pointer 
    }
   
  .eliminar {
       cursor:pointer 
    }
    .error_campo_vacio {
        
        box-shadow: 0 0 5px #CD2F0D;
        border-color:red;
        }
    .map-responsive {
            overflow: hidden;
            padding-bottom: 56.25%;
            position: relative;
            height: 0;
        }

            .map-responsive iframe {
                left: 0;
                top: 0;
                height: 100%;
                width: 100%;
                position: absolute;
            }
  

    </style>


    <script src="../js/Reportes/Js_Reporte_Salida.js"></script>
</asp:Content>
