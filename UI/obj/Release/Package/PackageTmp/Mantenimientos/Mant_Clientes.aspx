﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Mernu.Master" AutoEventWireup="true" CodeBehind="Mant_Clientes.aspx.cs" Inherits="UI.Mantenimientos.Mant_Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Gestionar Clientes</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../Principal.aspx">Inicio</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>Mantenimiento</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Gestionar Clientes</strong>
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
                            <h5>Gestionar Clientes <small></small></h5>
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
                 Tipo Documento :
                <select class="form-control" id="ddltipo_documento_buscar"    >
                 <option value="B"> << SELECCIONAR >> </option>
                    <option value="RUC">RUC</option>
                    <option value="DNI">DNI</option>
                    <option value="CEX">CARNET EXT.</option>
                      <option value="PASAPORTE">PASAPORTE</option>
                      <option value="OTROS">OTROS</option>
          
           </select>
                 </div>
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                 Nro Documento :
                 <input type="text"  class="form-control" id="txtnro_documento_buscar"/>
                 </div>

                    
                     <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12" >
                        Razon Social :
                          <input type="text"  class="form-control" id="txtrazon_social_buscar"/>
                 </div>
                  <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" >
                        Estado : 
          <select class="form-control" id="ddlestado_buscar"    >
          
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
 
                                 

            <table id="Tabla_Clientes" class="table table-hover  table-striped compact nowrap" style="display:none" >
                <thead>
                    <tr>
                          <th>ID</th>
                          <th>TIPO DOC</th>    
                          <th>NRO DOC</th>    
                         <th>RAZON SOCIAL</th>               
                          <th>ESTADO</th>                       
                          <th>EDITAR</th>
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

       
       
        <div  id="divcodigo" class="row"  style="display:none">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
           Codigo : 
              <input type="text" class="form-control" id="txtcodigo"/> 
         </div>
        </div>           
       <div  class="row" >
          <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
            Tipo Documento :
                <select class="form-control" id="ddltipo_documento"    >
          
           <option value="RUC">RUC</option>
           <option value="DNI">DNI</option>
                    <option value="CEX">CARNET EXT.</option>
                      <option value="PASAPORTE">PASAPORTE</option>
                      <option value="OTROS">OTROS</option>
          
           </select>

          </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
               Nro Doc : 
              <input type="text" class="form-control" id="txtnrodoc"/> 
          </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
             Razon Social : 
              <input type="text" class="form-control" id="txtrazon_social"/> 
          </div>
    </div>

            <br />
       <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Departamento : 
             <select class="form-control" id="ddldepartamento">    
              <option value="0" ><<  SELECCIONAR  >></option>
           </select>   
         
           
           
          </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              Provincia : 
           <select class="form-control" id="ddlprovincia">    
              <option value="0" ><<  SELECCIONAR  >></option>
           </select>
          </div>
                 <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                    Distrito : 
           <select class="form-control" id="ddldistrito">    
              <option value="0" ><<  SELECCIONAR  >></option>
           </select>
         </div>

    </div>
      <br />
              <div  class="row" >
        
          
            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
             Domicilio 1 : 
                <input type="text" class="form-control" id="txtdomicilio_1"/> 
          </div>
            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
               Domicilio 2 : 
              <input type="text" class="form-control" id="txtdomicilio_2"/>
          </div>
                   <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
          Telefono : 
              <input type="text" class="form-control" id="txttelefono"/>
          </div>

    </div>
       <br />
       <div  class="row" >
        
          
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
             Celular : 
                <input type="text" class="form-control" id="txtcelular"/> 
          </div>
            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
              Correo : 
              <input type="text" class="form-control" id="txtcorreo"/>
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
               <div  class="row" >
                      
           <div  class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
               Observacion
          <textarea id="txtobservacion" class="form-control" rows="3">

          </textarea>
          
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


    <script src="../js/Mantenimiento/Js_Mant_Clientes.js"></script>
</asp:Content>
