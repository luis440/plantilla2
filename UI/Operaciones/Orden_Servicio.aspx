<%@ Page Title="" Language="C#" MasterPageFile="~/Mernu.Master" AutoEventWireup="true" CodeBehind="Orden_Servicio.aspx.cs" Inherits="UI.Orden_Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Gestionar Orden de Servicio</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../Principal.aspx">Inicio</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>Operaciones</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Gestionar Orden de Servicio</strong>
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
                            <h5>Gestionar Orden de Servicio <small></small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                               <%--  <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                               <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#" class="dropdown-item">Config option 1</a>
                                    </li>
                                    <li><a href="#" class="dropdown-item">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>--%>
                            </div>
                        </div>
                        <div class="ibox-content">
                           
                             <div class="row">
      
               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
 
        <div class="row" style="margin:2px;text-align:center">
           
            
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right">
        

           
             <img  id="imgmas" src="../img/mas.png"  style="width:20px;height:20px"/>
             <strong id="btnnuevo">NUEVO</strong>
                
            
               

             </div>
            <hr/>
            </div>
        

             <div class="row" style="margin:2px">
         
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                 Tipo Servicio :
               <select class="form-control" id="ddltipo_servicio_buscar"    >
           <option value="B"> << SELECCIONAR >> </option>
                    <option value="TRANSPORTE">TRANSPORTE</option>
                    <option value="TRANSPORTE1">TRANSPORTE 1</option>
                    <option value="TRANSPORTE2">TRANSPORTE 2</option>
                    <option value="TRANSPORTE3">TRANSPORTE 3</option>
                    <option value="TRANSPORTE4">TRANSPORTE 4</option>
                    <option value="TRANSPORTE5">TRANSPORTE 5</option>
                    <option value="TRANSPORTE6">TRANSPORTE 6</option>
                    <option value="TRANSPORTE7">TRANSPORTE 7</option>
                    <option value="TRANSPORTE8">TRANSPORTE 8</option>
                    <option value="TRANSPORTE9">TRANSPORTE 9</option>
           <option value="CUADRILLA">CUADRILLA</option>
                <option value="RESGUARDO">RESGUARDO</option>
                 <option value="ADUANA">AGENCIAMIENTO ADUANA</option>
                 <option value="CARGA">AGENCIAMIENTO CARGA</option>
                 <option value="OTROS">OTROS</option>
          
           </select>
                 </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                 Nro Orden de Servicio :
                 <input type="text"  class="form-control" id="txt_numero_orden_buscar"/>
                 </div>

                    
                     <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12" >
                        Razon Social :
                          <input type="text"  class="form-control" id="txt_razon_social_buscar"/>
                 </div>
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                        Estado : 
          <select class="form-control" id="ddlestado_orden_servicio_buscar"    >
          
           <option value="A">ACTIVO</option>
           <option value="I">INACTIVO</option>
          
           </select>
                 </div>
             

                     <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                         <br />
                         <button id="btnbuscar" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Buscar</button>
                 </div>

                 </div>
            <hr />

        <div class="row" style="margin:2px">
  
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
 
                                 

            <table id="Tabla_Orden_Servicio" class="table table-hover  table-striped compact nowrap" style="display:none" >
                <thead>
                    <tr>
                          <th>ID</th>
                                     
                          <th>NRO ORDEN SERVICIO</th>    
                         <th>FECHA</th>         
                          <th>TIPO SERVICIO</th>    
                         <th>RAZON SOCIAL</th>               
                          <th>ESTADO</th>                       
                          <th>EDITAR</th>
                          <th>ARCHIVOS</th>
                          <th>ELIMINAR</th>
                      
                    </tr>
                 </thead>
               
            </table>

                </div>   


             </div> 
       </div>
       
    </div>

             </div>











                        </div>
                    </div>
                </div>
            </div>

               <!-- Modal nuevo -->
<div class="modal fade "  id="modal_nuevo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" style="overflow-y: scroll;">
  <div class="modal-dialog modal-lg " role="document">
    <div class="modal-content " style="border-radius: 5px;">
     
   <div class="modal-header" style="background-color:#1ab394;color:white">
        <h5 class="modal-title" id="Titulo_Panel">Nuevo Usuario</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>

     <div class="modal-body">
  <div class="container-fluid">
       <div  class="row" >
             <input type="text"  class="form-control" id="txtcodigo" style="display:none"/>
              <input type="text"  class="form-control" id="txt_id_cliente" style="display:none"/>
          <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
            Tipo Doc : 
               <select class="form-control" id="ddltipo_documento_buscar_cliente"    >
                 <option value="B"> << SELECCIONAR >> </option>
                    <option value="RUC">RUC</option>
                    <option value="DNI">DNI</option>
                    <option value="CEX">CARNET EXT.</option>
                      <option value="PASAPORTE">PASAPORTE</option>
                      <option value="OTROS">OTROS</option>
          
           </select>

          </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
               Nro Doc : 
              <input type="text" class="form-control" id="txtnrodoc_buscar_cliente"/> 
          </div>
             <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
             Razon Social : 
              <input type="text" class="form-control" id="txtrazon_social_buscar_cliente"/>   
          </div>
            <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">
          <br />
               <button id="btn_buscar_cliente" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Buscar</button>
          </div>
           <div id="div_estado_buscar" class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                    Estado : 
          <select class="form-control" id="ddlestado">          
           <option value="A">ACTIVO</option>
           <option value="I">INACTIVO</option>         
           </select>
         </div>
    </div>
      <br />
      <div class="row" id="contiene_tabla" style="display:none">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
       <table id="Tabla_Clientes_Buscar" class="table table-hover  table-striped compact nowrap"  >
                <thead>
                    <tr>
                          <th>ID</th>
                          <th>TIPO DOC</th>    
                          <th>NRO DOC</th>    
                         <th>RAZON SOCIAL</th>                                       
                          <th>SELECCIONAR</th>
                      
                    </tr>
                 </thead>
               
            </table>
            </div>
                </div>
          </div>
      <br />
       <div class="row">
                <div class="col-lg-12">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Tipo de Servicio</h5>
                             <div class="row">
                           <div class="col-lg-6">
          <select class="form-control" id="ddltipo_servicio"    >
          
           <option value="TRANSPORTE">TRANSPORTE</option>
              <option value="TRANSPORTE1">TRANSPORTE 1</option>
                    <option value="TRANSPORTE2">TRANSPORTE 2</option>
                    <option value="TRANSPORTE3">TRANSPORTE 3</option>
                    <option value="TRANSPORTE4">TRANSPORTE 4</option>
                    <option value="TRANSPORTE5">TRANSPORTE 5</option>
                    <option value="TRANSPORTE6">TRANSPORTE 6</option>
                    <option value="TRANSPORTE7">TRANSPORTE 7</option>
                    <option value="TRANSPORTE8">TRANSPORTE 8</option>
                    <option value="TRANSPORTE9">TRANSPORTE 9</option>
                <option value="CUADRILLA">CUADRILLA</option>
                <option value="RESGUARDO">RESGUARDO</option>
                 <option value="ADUANA">AGENCIAMIENTO ADUANA</option>
                 <option value="CARGA">AGENCIAMIENTO CARGA</option>
                 <option value="OTROS">OTROS</option>
          
           </select>
                               </div>
                           <div class="col-lg-6">
                                 <button id="btnagregar" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Agregar</button>
                               <input type="text" class="form-control" id="flag_transporte"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte1"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte2"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte3"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte4"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte5"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte6"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte7"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte8"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_transporte9"  style="display:none"/> 
                               <input type="text" class="form-control" id="flag_cuadrilla" style="display:none"/> 
                               <input type="text" class="form-control" id="flag_resguardo" style="display:none"/> 
                               <input type="text" class="form-control" id="flag_aduana" style="display:none"/> 
                               <input type="text" class="form-control" id="flag_carga" style="display:none"/> 
                               <input type="text" class="form-control" id="flag_otros" style="display:none"/> 
                               </div>
                          
                      </div>
                     
           

                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                             
                               
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="panel-body">
                                
                                <div class="panel-group" id="accordion">
                                    <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte1" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte1" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne1">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne1" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte1"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte1"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte1"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte1"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte1"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte1"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte1">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte1"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte1"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte1">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte1"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte1"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte2" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte2" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne2">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne2" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte2"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte2"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte2"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte2"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte2"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte2"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte2">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte2"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte2"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte2">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte2"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte2"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte3" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte3" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne3">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne3" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte3"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte3"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte3"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte3"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte3"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte3"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte3">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte3"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte3"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte3">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte3"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte3"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte4" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte4" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne4">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne4" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte4"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte4"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte4"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte4"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte4"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte4"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte4">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte4"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte4"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte4">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte4"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte4"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                     <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte5" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte5" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne5">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne5" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte5"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte5"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte5"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte5"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte5"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte5"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte5">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte5"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte5"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte5">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte5"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte5"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                     <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte6" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte6" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne6">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne6" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte6"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte6"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte6"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte6"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte6"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte6"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte6">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte6"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte6"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte6">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte6"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte6"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                     <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte7" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte7" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne7">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne7" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte7"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte7"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte7"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte7"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte7"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte7"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte7">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte7"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte7"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte7">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte7"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte7"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                     <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte8" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte8" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne8">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne8" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte8"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte8"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte8"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte8"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte8"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte8"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte8">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte8"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte8"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte8">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte8"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte8"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel panel-primary animated lightSpeedIn" id="panel_transporte9" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_transporte9" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h5 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne9">Transporte</a>
                                            </h5>

                                        </div>
                                        <div id="collapseOne9" class="panel-collapse collapse in">
                                            <div class="panel-body">

                                                      
                                            <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro G/RR : 
              <input type="text" class="form-control" id="txtnro_grr_transporte9"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro G/RT : 
              <input type="text" class="form-control" id="txtnro_grt_transporte9"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Placa : 
              <input type="text" class="form-control" id="txt_placa_transporte9"/>   
          </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
          Brevete : 
              <input type="text" class="form-control" id="txt_brevete_transporte9"/>   
          </div>
    </div>
                                                <br />
                                                <div class="row">
                                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Direccion Inicio : 
              <input type="text" class="form-control" id="txt_direccion_inicio_transporte9"/> 
          </div>
            
                                                </div>

                                                 <br />
                                                 <div class="row">
                                                        
                                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Direccion Llegada : 
              <input type="text" class="form-control" id="txt_direccion_llegada_transporte9"/> 
          </div>
                                                </div>

                                              
                                                <br />
                                            <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo de Carga : 
             <select class="form-control" id="ddl_tipo_carga_transporte9">    
              <option value="0" ><<  SELECCIONAR  >></option>
                 <option value="CONTENEDOR" >CONTENEDOR</option>
                 <option value="SUELTA" >SUELTA</option>
                 <option value="BB" >BB</option>
                   <option value="OTROS" >OTROS</option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Nro Contenedor : 
              <input type="text" class="form-control" id="txt_nro_contenedor_transporte9"/>  
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                     Peso : 
              <input type="text" class="form-control" id="txt_nro_peso_transporte9"/> 
         </div>

    </div>
                                           <br />
                                                   <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Tipo Bulto : 
           <select class="form-control" id="ddl_tipo_bulto_transporte9">    
              <option value="0" ><<  SELECCIONAR  >></option>
               <option value="CAJA" >CAJA</option>
               <option value="PALETA" >PALETA</option>
               <option value="SACO" >SACO</option>
           </select>
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Nro Bultos : 
                <input type="text" class="form-control" id="txt_nro_bulto_transporte9"/> 
          </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
        Fecha Servicio : 
              <input type="text" class="form-control" id="txt_fecha_servicio_transporte9"/> 
          </div>
  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
       
          </div>
    </div>
                                            <br />
                                          
                                              
                                            </div>
                                        </div>
                                    </div>


                                    <div class="panel panel-default animated flipInY" id="panel_cuadrilla" style="display:none">
                                        <div class="panel-heading">
                                             <button id="cerrar_panel_cuadrilla" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:black">&times;</span>
                                                </button>
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Cuadrilla</a>
                                            </h4>
                                        </div>
                                        <div id="collapseTwo" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                    
       <div  class="row" >
          <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
            Servicio :
                <select class="form-control" id="ddlservicio_cuadrilla"    >
           <option value="0" ><<  SELECCIONAR  >></option>
           <option value="CARGA">CARGA</option>
           <option value="DESCARGA">DESCARGA</option>
           <option value="CARGA/DESCARGA">CARGA/DESCARGA</option>
                     
          
           </select>

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro Personas : 
              <input type="text" class="form-control" id="txt_nro_personas_cuadrilla"/> 
          </div>
            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
             Detalle : 
              <input type="text" class="form-control" id="txt_Detalle_cuadrilla"/> 
          </div>
           
    </div>

            <br />
       <div  class="row" >
        
          
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             Lugar de Servicio : 
            <input type="text" class="form-control" id="txt_lugar_Servicio_cuadrilla"/>  
         
           
           
          </div>
        

    </div>
      <br />
   
                                        </div>
                                    </div>
                                        </div>
                                    <div class="panel panel-primary animated flipInY" id="panel_resguardo" style="display:none">
                                        <div class="panel-heading">
                                             <button id="cerrar_panel_resguardo" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTree">Resguardo</a>
                                            </h4>
                                        </div>
                                        <div id="collapseTree" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                    
       <div  class="row" >
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Proveedor/Empresa :
                <input type="text" class="form-control" id="txt_proveedor_resguardo"/> 
          </div>

          </div>
            
                <br />
  <div  class="row" >
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Ruta :
                <input type="text" class="form-control" id="txt_ruta_resguardo"/> 
          </div>

          </div>
    </div>

       
      <br />
   
                                        </div>
                                    </div>
                                       
                                    <div class="panel panel-default animated lightSpeedIn" id="panel_aduana" style="display:none">
                                        <div class="panel-heading">
                                              <button id="cerrar_panel_aduana" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:black">&times;</span>
                                                </button>
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapsefour">Agenciamiento Aduana</a>
                                            </h4>
                                        </div>
                                        <div id="collapsefour" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                             
       <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Aduana : 
              <input type="text" class="form-control" id="txt_aduana_aduana"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro Manifiesto : 
              <input type="text" class="form-control" id="txt_manifiesto_aduana"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Regimen : 
              <input type="text" class="form-control" id="txt_regimen_aduana"/> 
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             DAM : 
              <input type="text" class="form-control" id="txt_dam_aduana"/> 
          </div>
    </div>

            <br />
     <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Canal : 
              <input type="text" class="form-control" id="txt_canal_aduana"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
              Fecha Arribo : 
              <input type="text" class="form-control" id="txt_fecha_arribo_aduana"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                Fecha Retiro : 
              <input type="text" class="form-control" id="txt_fecha_retiro_aduana"/> 
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Almacen : 
              <input type="text" class="form-control" id="txt_almacen_aduana"/> 
          </div>
    </div>
                                                   <br />
     <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
           Valor FOB :
              <input type="text" class="form-control" id="txt_fob_aduana"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Valor CIF : 
              <input type="text" class="form-control" id="txt_cif_aduana"/> 
          </div>
             <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
             Empresa :
              <input type="text" class="form-control" id="txt_empresa_aduana"/> 
          </div>
         
    </div>
                                                <br />
                                             
         
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-primary animated flipInY" id="panel_carga" style="display:none">
                                        <div class="panel-heading">
                                            <button id="cerrar_panel_carga" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:white">&times;</span>
                                                </button>
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">Agenciamiento Carga</a>
                                            </h4>
                                        </div>
                                        <div id="collapseSix" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                          
       <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Aduana : 
              <input type="text" class="form-control" id="txt_aduana_carga"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro Manifiesto : 
              <input type="text" class="form-control" id="txt_manifiesto_carga"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Puerto Origen : 
              <input type="text" class="form-control" id="txt_puerto_origen_carga"/> 
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Pais : 
              <input type="text" class="form-control" id="txt_pais_carga"/> 
          </div>
    </div>

            <br />
      <div  class="row" >
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            Empresa de Transporte : 
              <input type="text" class="form-control" id="txt_empresa_transporte_carga"/> 

          </div>
            
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Peso : 
              <input type="text" class="form-control" id="txt_peso_Carga"/> 
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Volumen : 
              <input type="text" class="form-control" id="txt_volumen_carga"/> 
          </div>
    </div>
                                                <br />
                                                <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Nro Bultos : 
              <input type="text" class="form-control" id="txt_nro_bultos_Carga"/> 

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Fecha Arribo : 
              <input type="text" class="form-control" id="txt_fecha_Arribo_carga"/> 
          </div>
             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Fecha Retiro : 
              <input type="text" class="form-control" id="txt_fecha_retiro_carga"/> 
          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
             Almacen : 
              <input type="text" class="form-control" id="txt_almacen_carga"/> 
          </div>
    </div>
                                                 <br />
                                                <div  class="row" >
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
               Empresa : 
              <input type="text" class="form-control" id="txt_empresa_carga"/> 
          </div>    </div>
  

         
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default animated lightSpeedIn" id="panel_otros" style="display:none">
                                        <div class="panel-heading">
                                               <button id="cerrar_panel_otros" type="button" class="close"  aria-label="Close">
                                                  <span aria-hidden="true" style="color:black">&times;</span>
                                                </button>
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">Otros</a>
                                            </h4>
                                        </div>
                                        <div id="collapseSeven" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                       
       <div  class="row" >
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Detalle : 
              <input type="text" class="form-control" id="txt_detalle_otros"/> 

          </div>
           
    </div>
            <br />
               <div  class="row" >
                      
           <div  class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
               Observacion
          <textarea id="txtobservacion_otros" class="form-control" rows="3">

          </textarea>
          
         </div>
                  
                
                  
 
            </div>
         
                                            </div>
                                        </div>
                                    </div>
                                     </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               
            </div>
       
    
       
 <br />


      <div class="modal-footer">
     
        
        <button id="btnGuardar" type="button" class="btn btn-default" style="background-color:#1ab394;color:white;border-color:#1ab394">Guardar</button>
          <button id="btnActualizar" type="button" class="btn btn-default active" style="display:none;background-color:#1ab394;color:white;border-color:#1ab394">Actualizar</button>
      <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>
         

   </div>
        
      <!-- Modal Archivos -->
<div class="modal fade "  id="modal_archivos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" style="overflow-y: scroll;">
  <div class="modal-dialog modal-lg " role="document">
    <div class="modal-content " style="border-radius: 5px;">
     
   <div class="modal-header" style="background-color:#1ab394;color:white">
        <h5 class="modal-title" id="Titulo_Panel_2">Subir Archivo</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>




     <div class="modal-body">
           <input type="text"  class="form-control" id="txtid" style="display:none"/>

         <div class="wrapper wrapper-content animated fadeIn">

        <div class="row">
                <div class="col-lg-12">
                    <div class="tabs-container">
                        <ul class="nav nav-tabs" role="tablist">
                            <li><a class="nav-link active" data-toggle="tab" href="#tab-1"> Archivo 1</a></li>
                            <li><a class="nav-link" data-toggle="tab" href="#tab-2">Archivo 2</a></li>
                            <li><a class="nav-link" data-toggle="tab" href="#tab-3">Archivo 3</a></li>
                            <li><a class="nav-link" data-toggle="tab" href="#tab-4">Archivo 4</a></li>
                            <li><a class="nav-link" data-toggle="tab" href="#tab-5">Archivo 5</a></li>
                            <li><a class="nav-link" data-toggle="tab" href="#tab-6">Archivo 6</a></li>
                        
                        </ul>
                        <div class="tab-content">
                            <div role="tabpanel" id="tab-1" class="tab-pane active">
                                <div class="panel-body">
                                <div class="row">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="panel panel-primary">
                                       <div class="panel-heading" >Archivo 1</div>
                                       <div class="panel-body">
                                          <div class="row">
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="file-logo" role="button">Seleccionar Archivo</label>
                                                <input id="file-logo" name="file-logo[]" type="file" multiple>
                                                <small class="form-text text-muted">Seleccionar pdf </small>
                                                <input type="text" id="nombre_foto_original_imagen_logo" class="form-control" style="display: none" />
                                                <input type="text" id="nombre_generado_foto_imagen_logo" class="form-control" style="display: none" />
                                                <input type="text" id="ruta_foto_imagen_logo" class="form-control" style="display: none" />
                                             </div>
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                              </div>
                                </div>
                            </div>
                            <div role="tabpanel" id="tab-2" class="tab-pane">
                                <div class="panel-body">
                                    <div  class="row">
         
                         
                           
                                 <div class="col-md-12">
                                    <div class="panel panel-primary">
                                       <div class="panel-heading">Archivo 2</div>
                                       <div class="panel-body">
                                          <div class="row">
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="file-fondo" role="button">Seleccionar Archivo</label>
                                                <input id="file-fondo" name="file-fondo[]" type="file" multiple>
                                                <small class="form-text text-muted">Seleccionar pdf</small>
                                                <input type="text" id="nombre_foto_original_imagen_fondo" class="form-control" style="display: none" />
                                                <input type="text" id="nombre_generado_foto_imagen_fondo" class="form-control" style="display: none" />
                                                <input type="text" id="ruta_foto_imagen_fondo" class="form-control" style="display: none" />
                                             </div>
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                             
                        
    </div>
                                </div>
                            </div>
                              <div role="tabpanel" id="tab-3" class="tab-pane">
                                <div class="panel-body">
                                    <div  class="row">
         
                         
                           
                                 <div class="col-md-12">
                                    <div class="panel panel-primary">
                                       <div class="panel-heading">Archivo 3</div>
                                       <div class="panel-body">
                                          <div class="row">
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="file-fondo3" role="button">Seleccionar Archivo</label>
                                                <input id="file-fondo3" name="file-fondo3[]" type="file" multiple>
                                                <small class="form-text text-muted">Seleccionar pdf</small>
                                                <input type="text" id="nombre_foto_original_imagen_fondo3" class="form-control" style="display: none" />
                                                <input type="text" id="nombre_generado_foto_imagen_fondo3" class="form-control" style="display: none" />
                                                <input type="text" id="ruta_foto_imagen_fondo3" class="form-control" style="display: none" />
                                             </div>
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                             
                        
    </div>
                                </div>
                            </div>
                             <div role="tabpanel" id="tab-4" class="tab-pane">
                                <div class="panel-body">
                                    <div  class="row">
         
                         
                           
                                 <div class="col-md-12">
                                    <div class="panel panel-primary">
                                       <div class="panel-heading">Archivo 4</div>
                                       <div class="panel-body">
                                          <div class="row">
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="file-fondo4" role="button">Seleccionar Archivo</label>
                                                <input id="file-fondo4" name="file-fondo4[]" type="file" multiple>
                                                <small class="form-text text-muted">Seleccionar pdf</small>
                                                <input type="text" id="nombre_foto_original_imagen_fondo4" class="form-control" style="display: none" />
                                                <input type="text" id="nombre_generado_foto_imagen_fondo4" class="form-control" style="display: none" />
                                                <input type="text" id="ruta_foto_imagen_fondo4" class="form-control" style="display: none" />
                                             </div>
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                             
                        
    </div>
                                </div>
                            </div>
                             <div role="tabpanel" id="tab-5" class="tab-pane">
                                <div class="panel-body">
                                    <div  class="row">
         
                         
                           
                                 <div class="col-md-12">
                                    <div class="panel panel-primary">
                                       <div class="panel-heading">Archivo 5</div>
                                       <div class="panel-body">
                                          <div class="row">
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="file-fondo5" role="button">Seleccionar Archivo</label>
                                                <input id="file-fondo5" name="file-fondo5[]" type="file" multiple>
                                                <small class="form-text text-muted">Seleccionar pdf</small>
                                                <input type="text" id="nombre_foto_original_imagen_fondo5" class="form-control" style="display: none" />
                                                <input type="text" id="nombre_generado_foto_imagen_fondo5" class="form-control" style="display: none" />
                                                <input type="text" id="ruta_foto_imagen_fondo5" class="form-control" style="display: none" />
                                             </div>
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                             
                        
    </div>
                                </div>
                            </div>
                                <div role="tabpanel" id="tab-6" class="tab-pane">
                                <div class="panel-body">
                                    <div  class="row">
         
                         
                           
                                 <div class="col-md-12">
                                    <div class="panel panel-primary">
                                       <div class="panel-heading">Archivo 6</div>
                                       <div class="panel-body">
                                          <div class="row">
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="file-fondo6" role="button">Seleccionar Archivo</label>
                                                <input id="file-fondo6" name="file-fondo6[]" type="file" multiple>
                                                <small class="form-text text-muted">Seleccionar pdf</small>
                                                <input type="text" id="nombre_foto_original_imagen_fondo6" class="form-control" style="display: none" />
                                                <input type="text" id="nombre_generado_foto_imagen_fondo6" class="form-control" style="display: none" />
                                                <input type="text" id="ruta_foto_imagen_fondo6" class="form-control" style="display: none" />
                                             </div>
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                             
                        
    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
             
            </div>

           

      




        </div>






    </div>

  
 <br />
      <div class="modal-footer">
     
        
        <button id="btnGuardar_Archivo" type="button" class="btn btn-default" style="background-color:#1ab394;color:white;border-color:#1ab394">Guardar</button>
          <button id="btnActualizar_Archivo" type="button" class="btn btn-default active" style="display:none;background-color:#1ab394;color:white;border-color:#1ab394">Actualizar</button>
      <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
      </div>



  </div>
</div>
         

   </div>
   
    
    <style>
    .editar {
       cursor:pointer 
    }
   .seleccionar_cliente
   {
       cursor:pointer 
    }
  .eliminar {
       cursor:pointer 
    }
  .ver {
       cursor:pointer 
    }
    .error_campo_vacio {
        
        box-shadow: 0 0 5px #CD2F0D;
        border-color:red;
        }
  
    /*.panel-primary>.panel-heading {
    color: #fff;
    background-color: rgba(34, 45, 50, 0.61);
    border-color: #222d32;
}*/
    </style>
   
    <script src="../js/Operaciones/Js_Orden_Servicio.js"></script>
</asp:Content>
