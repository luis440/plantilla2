﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Mernu.Master" AutoEventWireup="true" CodeBehind="Cambio_Clave.aspx.cs" Inherits="UI.Seguridad.Cambio_Clave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Cambio de Clave</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="index.html">Principal</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>Seguridad</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Cambio de Clave</strong>
                        </li>
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>
    <br />
      <div class="wrapper wrapper-content animated fadeInRight">


           <%-- <div class="row m-b-lg m-t-lg">
                <div class="col-md-3">
                  
                </div>
                <div class="col-md-6">

                    <div class="profile-image">
                        <img src="../img/user2.png" class="rounded-circle circle-border m-b-md" alt="profile">
                    </div>
                    <div class="profile-info">
                        <div class="">
                            <div>
                                <h2 class="no-margins">
                                    Luis Miguel Mackinder Quispe Quispe
                                </h2>
                                <h4>Administrador</h4>
                                <h4>
                                    Luis_4_40@hotmail.com
                                </h4>
                                <p class="small font-bold">
                                <span ><i class="fa fa-circle text-navy"></i> En Linea</span>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-3">
                    
                </div>


            </div>--%>
            <div class="row">

                <div class="col-lg-3">

              
                </div>

                <div class="col-lg-6">

                   
                  
                 <div class="ibox ">
                    <div class="ibox-title">
                        <h5>Cambio de Clave</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                          
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-6 b-r">
                                <div class="profile-image" >
                        <img src="../img/seguridad.gif" class="rounded-circle circle-border m-b-md" alt="profile">
                    </div>
                                <br />
                    <div class="profile-info">
                        <div class="">
                            <div>
                                <h3 class="no-margins" id="txtnombre_completo">
                                   
                                </h3> <br />
                                
                                <h4 id="txtperfil"></h4> 
                                <h4 id="txtcorreo">
                                    
                                </h4>
                                 <b id="txtusuario"></b>
                                <p class="small font-bold">
                                <span ><i class="fa fa-circle text-navy"></i> En Linea</span>
                                </p>
                            </div>
                        </div>
                    </div>
                            </div>
                            <div class="col-sm-6">
                             <%--  <h3 class="m-t-none m-b">Sign in</h3>
                                <p>Sign in today for more expirience.</p>--%>
                                <form role="form">
                                  
                                    <br /><br />
                                    <b>Nueva Contraseña :</b>
                                    <div class="input-group" id="show_hide_password">
                                  <input id="txtnuevacontraseña1" class="form-control" type="password" placeholder="Ingrese Contraseña">
                                  <div class="input-group-addon">
                                      <a href="#"><i style="color: #6c757d" class="fa fa-eye-slash" aria-hidden="true"></i></a>
                                  </div>
                              </div><br />
                                    <b>Repita Contraseña :</b>
                                     <div class="input-group" id="show_hide_password2">
                                  <input id="txtnuevacontraseña2" class="form-control" type="password" placeholder="Ingrese Contraseña">
                                  <div class="input-group-addon">
                                      <a href="#"><i style="color: #6c757d" class="fa fa-eye-slash" aria-hidden="true"></i></a>
                                  </div>
                              </div>
                                    <br />   <hr />
                                    <div style="text-align:right">
                                        <button id="btn_guardar_cambio_clave" type="button" class="btn btn-default" style="background-color:#1ab394;color:white;border-color:#1ab394">Guardar</button>
          
      <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>



                </div>
                <div class="col-lg-3 m-b-lg">
                 

                </div>

            </div>

        </div>
    
   
    <style>
        .box.box-primary {
    border-top-color: #52006c;
}
    </style>

    <script src="../js/Mantenimiento/Js_Usuarios.js"></script>
</asp:Content>
