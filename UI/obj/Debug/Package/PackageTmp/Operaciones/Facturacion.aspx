<%@ Page Title="" Language="C#" MasterPageFile="~/Mernu.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="UI.Operaciones.Facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Gestionar Comprobantes</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../Principal.aspx">Inicio</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>Operaciones</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Gestionar Comprobantes</strong>
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
                            <h5>Gestionar Comprobantes <small></small></h5>
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
                Tipo Comprobante : 
               <select class="form-control" id="ddltipo_comprobante_buscar"    >
                 
                     
          
           </select>
                 </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
              Serie : 
               <select class="form-control" id="ddlserie_buscar" >
                 <option value="0"> << SELECCIONAR >> </option>
                  </select>
          </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                  Nro de Documento : 
                 <input type="text"  class="form-control" id="nro_doc_buscar"/>
                 </div>

                    
                     <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12" >
                        Razon Social :
                          <input type="text"  class="form-control" id="razon_social_buscar"/>
                 </div>
                 
             

                     <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12" >
                         <br />
                         <button id="btnbuscar" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Buscar</button>
                 </div>

                 </div>
                     <div class="row" style="margin:2px">
         
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                      Fecha Inicio :
               <input type="text"  class="form-control" id="fecha_inicio_comprobante_buscar"/>
                 </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
           Fecha Fin :
               <input type="text"  class="form-control" id="fecha_fin_comprobante_buscar"/>
          </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                                      Estado : 
          <select class="form-control" id="ddlestado_buscar"    >
          
           <option value="A">ACTIVO</option>
           <option value="I">INACTIVO</option>
          
           </select>
                 </div>

                    
                     <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12" >
                      
                 </div>
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
      
                 </div>
             

                     <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12" >
                        
                 </div>

                 </div>
            <hr />

        <div class="row" style="margin:2px">
  
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
 
                                 

            <table id="Tabla_Comprobantes" class="table table-hover  table-striped compact nowrap" style="display:none" >
                <thead>
                    <tr>
                          <th>ID</th>
                          <th>TIPO COMPROBANTE</th>    
                          <th>SERIE</th>    
                         <th>NUMERO</th>               
                          <th>RAZON SOCIAL</th>                       
                          <th>TOTAL</th>
                        <th>FECHA</th>
                        <th>ESTADO</th>
                           <th></th>
                        <th></th>
                      
                         
                      
                    </tr>
                 </thead>
                <tbody>
       
               
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
  <div class="modal-dialog modal-xl " role="document">
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
              <input type="text"  class="form-control" id="txt_codigo" style="display:none"/>
          <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12">
            Tipo Comprobante : 
               <select class="form-control" id="ddltipo_comprobante" >
                 <option value="B"> << SELECCIONAR >> </option>
                    
                     
          
           </select>

          </div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12">
              Serie : 
               <select class="form-control" id="ddlserie" >
                 <option value="B"> << SELECCIONAR >> </option>
                  </select>
          </div>
             <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12" id="div_buscar_orden_Servicio" style="display:none">
           Orden de Servicio : 
     
                <div class="input-group"><input type="text" class="form-control" id="txtnrodo"> <span class="input-group-append">
                    <button id="btn_buscar_orden_servicio_principal" type="button" class="btn btn-primary">Buscar</button> </span></div>
          </div>

            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12" id="div_buscar_factura" style="display:none">
           Combrobante : 
     
                <div class="input-group"><input type="text" class="form-control" id="txtnrofactura"> <span class="input-group-append">
                    <button id="btn_buscar_factura_principal" type="button" class="btn btn-primary">Buscar</button> </span></div>
          </div>
           
    </div>

      <br />
      <div  class="row" >
              
             <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12">
               Fecha : 
              <input type="text" class="form-control" id="txtfecha_factura"/> 
          </div>
             <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12">
             Moneda : 
               <select class="form-control" id="ddlmoneda">
                 
                    <option value="PEN" > SOLES </option>
                 <option value="USD"> DOLAR </option>
                   
                    
          
           </select>
          </div>
          <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12">
          Forma de Pago : 
               <select class="form-control" id="ddlforma_pago">
                    <option value="B"> << SELECCIONAR >> </option>

           </select> 
               
          </div>
    </div>
      <br />
  <div  class="row" >
              <input type="text"  class="form-control" id="txt_id_cliente" style="display:none"/>
          <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12">
            Tipo Doc : 
               <select class="form-control" id="ddltipo_documento_buscar_cliente"   disabled>
                 <option value="B"> << SELECCIONAR >> </option>
                    <option value="RUC">RUC</option>
                    <option value="DNI">DNI</option>
                    <option value="CEX">CARNET EXT.</option>
                      <option value="PASAPORTE">PASAPORTE</option>
                      <option value="OTROS">OTROS</option>
          
           </select>

          </div>
            <div class="col-lg-2 col-md-6 col-sm-12 col-xs-12">
               Nro Doc : 
              <input type="text" class="form-control" id="txtnrodoc_buscar_cliente" disabled/> 
          </div>
             <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
             Razon Social : 
              <input type="text" class="form-control" id="txtrazon_social_buscar_cliente" disabled/>   
          </div>
           
   <%--   <div class="col-lg-1 col-md-6 col-sm-1 col-xs-12">
          <br />
               <button id="btn_buscar_cliente" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Buscar</button>
          </div>--%>
    </div>
        <br />
  <div  class="row" >
            
          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
            Direccion : 
               <input type="text" class="form-control" id="txtdireccion" disabled/> 

          </div>
            <div class="col-lg-2 col-md-6 col-sm-12 col-xs-12">
                  <input type="text"  class="form-control" id="serie_factura_relacionada" style="display:none"/>
          </div>
        <div class="col-lg-2 col-md-6 col-sm-12 col-xs-12">
                  <input type="text"  class="form-control" id="numero_factura_relacionada" style="display:none"/>
          </div>
        <div class="col-lg-2 col-md-6 col-sm-12 col-xs-12">
                  <input type="text"  class="form-control" id="fecha_factura_relacionada" style="display:none"/>
          </div>
            
    </div>
        <br />
  <div  class="row" >
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            Referencia : 
               <input type="text" class="form-control" id="txtglosa" /> 

          </div>
            
      </div>
      <div id="contiene_tabla" style="display:none">
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
           <br />

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
      
      <div id="div_Tabla_Detalle_Factura" class="row" >
    
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                  
        <div class="table-responsive"> 
 
                                 
           
            <table id="Tabla_Detalle_Factura" class="table table-hover  table-striped compact " style="display:block; width: 100%;" >
               
                <thead>
                    <tr>
                          <th>CODIGO</th>
                          <th>ID</th>
                          <th >DESCRIPCION</th>    
                          <th>UND</th>      
                          <th>CANT</th>                       
                          <th>PRECIO</th>
                          <th>SUBTOTAL</th>
                          <th>IGV</th>
                          <th>TOTAL</th>
                    </tr>
                 </thead>
               
               <tfoot>
                   <tr> 
                       <td colspan="9" id="txtsub" style="text-align:right" >  </td>
                  </tr>
                   <tr> 
                       <th colspan="9" id="txtsubtotal_general" style="text-align:right" >  </th>
                  </tr>
                   <tr>
                       <th colspan="9" id="txtsubtotal_igv" style="text-align:right" >  </th></tr>
            <tr>
           
                  <th colspan="9" id="txttoal_general" style="text-align:right" >  </th>
                
            </tr>
        </tfoot>
                
            </table>
     
                </div>   
               

           
       </div>
     
            </div>
       
      
       
 <br />


      <div class="modal-footer">
     
        
        <button id="btnGuardar" type="button" class="btn btn-default" style="background-color:#1ab394;color:white;border-color:#1ab394">Guardar</button>
         
          <button id="btnImprimir" type="button" class="btn btn-default active" style="display:none;background-color:#1ab394;color:white;border-color:#1ab394">Imprimir</button>
      <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>
         

   </div>
    </div>    
      
               <!-- Modal Orden  de servicio -->
<div class="modal fade animated bounceIn"  id="modal_orden" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog modal-xl " role="document">
    <div class="modal-content " style="border-radius: 5px;">
     
   <div class="modal-header" style="background-color:#1ab394;color:white">
        <h5 class="modal-title" id="Titulo_Panel_Orden">Buscar Orden de Servicio</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>

     <div class="modal-body">
  <div class="container-fluid">
    
          <div class="row"  >
         
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12" >
                 Tipo Servicio :
               <select class="form-control" id="ddltipo_servicio_buscar"    >
           <option value="B"> << SELECCIONAR >> </option>
           <option value="TRANSPORTE">TRANSPORTE</option>
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

                    
                     <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12" >
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
                         <button id="btnbuscar_orden_servicio" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Buscar</button>
                 </div>

                 </div>
            <hr />

        <div class="row" style="margin:2px">
  
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
 
                                 

            <table id="Tabla_Orden_Servicio" class="table table-hover  table-striped compact nowrap" style="display:none;" >
                <thead>
                    <tr>
                          <th>ID</th>
                                     
                          <th>NRO ORDEN SERVICIO</th>    
                         <th>FECHA</th>         
                          <th>TIPO SERVICIO</th>    
                         <th>RAZON SOCIAL</th>               
                          <th>ESTADO</th>                       
                          <th>SELECCIONAR</th>
                         
                      
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
    

       <!-- Modal Comprobante -->
<div class="modal fade animated bounceIn"  id="modal_comprobantes" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog modal-xl " role="document">
    <div class="modal-content " style="border-radius: 5px;">
     
   <div class="modal-header" style="background-color:#1ab394;color:white">
        <h5 class="modal-title" id="Titulo_Panel_Comprobantes">Buscar Comprobantes</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>

     <div class="modal-body">
  <div class="container-fluid">
    
          <div class="row" style="margin:2px">
         
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                Tipo Comprobante : 
               <select class="form-control" id="ddltipo_comprobante_buscar2"    >
                 <option value="0"> << SELECCIONAR >> </option>
                     <option value="01">FACTURA</option>
           <option value="03">BOLETA</option>
          
           </select>
                 </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
              Serie : 
               <select class="form-control" id="ddlserie_buscar2" >
                 <option value="0"> << SELECCIONAR >> </option>
                  </select>
          </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                  Nro de Documento : 
                 <input type="text"  class="form-control" id="nro_doc_buscar2"/>
                 </div>

                    
                     <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12" >
                        Razon Social :
                          <input type="text"  class="form-control" id="razon_social_buscar2"/>
                 </div>
                 
             

                     <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12" >
                         <br />
                         <button id="btnbuscar_comprobantes" type="button" class="btn btn-warning"  style="background-color:#1ab394;color:white;border-color:#1ab394" >Buscar</button>
                 </div>

                 </div>
                     <div class="row" style="margin:2px">
         
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                      Fecha Inicio :
               <input type="text"  class="form-control" id="fecha_inicio_comprobante_buscar2"/>
                 </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
           Fecha Fin :
               <input type="text"  class="form-control" id="fecha_fin_comprobante_buscar2"/>
          </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                                      Estado : 
          <select class="form-control" id="ddlestado_buscar2"    >
          
           <option value="A">ACTIVO</option>
           <option value="I">INACTIVO</option>
          
           </select>
                 </div>

                    
                     <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12" >
                     
           
                 </div>
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
      
                 </div>
             

                     <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12" >
                        
                 </div>

                 </div>
            <hr />

        <div class="row" style="margin:2px">
  
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        <div class="table-responsive"> 
 
                                 

            <table id="Tabla_Comprobantes2" class="table table-hover  table-striped compact nowrap" style="display:none" >
                <thead>
                    <tr>
                          <th>ID</th>
                          <th>TIPO COMPROBANTE</th>    
                          <th>SERIE</th>    
                         <th>NUMERO</th>               
                          <th>RAZON SOCIAL</th>                       
                          <th>TOTAL</th>
                        <th>FECHA</th>
                        <th>ESTADO</th>
                           <th></th>

                    </tr>
                 </thead>
                <tbody>
       
               
            </table>

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
   .seleccionar_cliente
   {
       cursor:pointer 
    }
   .ver
   {
       cursor:pointer 
    }
  .eliminar {
       cursor:pointer 
    }
  .seleccionar_orden {
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
    table.dataTable tfoot th, table.dataTable tfoot td {
    padding: 10px 18px 6px 18px;
    border-top: 1px solid rgba(0, 0, 0, 0.08);
}
    </style>
    <script src="../js/Operaciones/Js_Facturacion.js"></script>
</asp:Content>
