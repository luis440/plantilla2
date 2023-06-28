<%@ Page Title="" Language="C#" MasterPageFile="~/Mernu.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="UI.Operaciones.Facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Gestionar Factura</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../Principal.aspx">Inicio</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>Operaciones</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Gestionar Factura</strong>
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
                            <h5>Gestionar Factura <small></small></h5>
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
               <select class="form-control" id="ddltipo_documento_buscar_cliente"    >
                 <option value="B"> << SELECCIONAR >> </option>
                    <option value="RUC">FACTURA</option>
                    <option value="DNI">BOLETA</option>
                    <option value="CEX">NOTA DE CREDITO</option>
                     
          
           </select>
                 </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                  Nro de Documento : 
                 <input type="text"  class="form-control" id="txt_numero_doc_cliente"/>
                 </div>

                    
                     <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12" >
                        Razon Social :
                          <input type="text"  class="form-control" id="txt_razon_social_cliente"/>
                 </div>
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                        Estado : 
          <select class="form-control" id=""    >
          
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
 
                                 

            <table id="Tabla_Clientesd" class="table table-hover  table-striped compact nowrap" style="display:none" >
                <thead>
                    <tr>
                          <th>ITEM</th>
                          <th>CANTIDAD</th>    
                          <th>UND MED</th>    
                         <th>CODIGO</th>               
                          <th>DESCRIPCION</th>                       
                          <th>PRECIO</th>
                         
                      
                    </tr>
                 </thead>
                <tbody>
            <tr>
                <td>1</td>
                <td>1</td>
                <td>Unidad</td>
                <td>001</td>
                <td>Serv. Transporte y Resguardo</td>
                <td>$320,800</td>
            </tr>
                    </tbody>
               
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
<div class="modal fade "  id="modal_nuevo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
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
              <input type="text"  class="form-control" id="txt_id_cliente" style="display:none"/>
          <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
            Tipo Comprobante : 
               <select class="form-control" id="ddltipo_documento_buscar_cliente"    >
                 <option value="B"> << SELECCIONAR >> </option>
                    <option value="RUC">FACTURA</option>
                    <option value="DNI">BOLETA</option>
                    <option value="CEX">NOTA DE CREDITO</option>
                     
          
           </select>

          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Orden de Servicio : 
     
                <div class="input-group"><input type="text" class="form-control" id="txtnrodoc_buscar_cliente"> <span class="input-group-append"> <button type="button" class="btn btn-primary">Buscar
                                        </button> </span></div>
          </div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
           <h1><b>F123-</b>000001</h1> 
          </div>
           
    </div>
      <div  class="row" >
              
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
               Fecha : 
              <input type="text" class="form-control" id="txtnrodoc_buscar_cliente"/> 
          </div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Moneda : 
               <select class="form-control" id="ddlmoneda_buscar">
                    <option value="B"> << SELECCIONAR >> </option>
                    <option value="PEN"> SOLES </option>
                 <option value="USD"> DOLAR </option>
                   
                    
          
           </select>
          </div>
                                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
           Tipo Cambio : 
              <input type="text" class="form-control" id="txtrazon_social_buscar_cliente"/>   
               
          </div>
    </div>
      <br />
  <div  class="row" >
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
    </div>
     
      <div id="contiene_tabla" style="display:none">
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
     <br />
  <div  class="row" >
              <input type="text"  class="form-control" id="txt_id_cliente" style="display:none"/>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            Direccion : 
               <input type="text" class="form-control" id="txtnrodoc_buscar_cliente"/> 

          </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
              
          </div>
            
    </div>
             <br />
      
      <div class="row" >
    
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                  
        <div class="table-responsive"> 
 
                                 
           
            <table id="Tabla_Clientesd" class="table table-hover  table-striped compact nowrap" style="display:block" >
               
                <thead>
                    <tr>
                          <th>ITEM</th>
                          <th>CANTIDAD</th>    
                          <th>UND MED</th>    
                         <th>CODIGO</th>               
                          <th>DESCRIPCION</th>                       
                          <th>PRECIO</th>
                         <td>SUBTOTA</td>
                         <td>IGV</td>
                       <td>TOTAL</td>
                    </tr>
                 </thead>
                <tbody>
            <tr>
                <td>1</td>
                <td>1</td>
                <td>Unidad</td>
                <td>001</td>
                <td>Serv. Transporte y Resguardo</td>
                <td><input type="text" class="form-control"  value="S/.300.00" id=""/> </td>
                <td>S/.300.00</td>
                <td>S/.54.00</td>
                 <td>S/.354.00</td>
            </tr>
                   
                 
                    </tbody>
                
            </table>
     
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
  
    /*.panel-primary>.panel-heading {
    color: #fff;
    background-color: rgba(34, 45, 50, 0.61);
    border-color: #222d32;
}*/
    </style>
    <script src="../js/Operaciones/Js_Facturacion.js"></script>
</asp:Content>
