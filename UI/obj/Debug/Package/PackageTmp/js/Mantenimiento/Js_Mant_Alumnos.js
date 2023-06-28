$(document).ready(function () {


    var ID = ($.session.get('SESSION_ID'));
    var USUARIO = ($.session.get('SESSION_USUARIO'));
    var NOMBRES = ($.session.get('SESSION_NOMBRES'));
    var PERFIL = ($.session.get('SESSION_PERFIL'));
    var APELLIDOS = ($.session.get('SESSION_APELLIDOS'));
    var CORREO = ($.session.get('SESSION_CORREO'));


    OBTENER_NIVEL();


    //$("#txtnombre_completo").text(NOMBRES + ' ' + APELLIDOS);
    //$("#txtperfil").text(PERFIL);
    //$("#txtcorreo").text(CORREO);
    //$("#txtusuario").text(USUARIO);


    if (typeof NOMBRES === "undefined") {
        location.href = '../Login.aspx';

    }

    //if (USUARIO != 'admin') {
    //    location.href = 'Login.aspx';

    //}


    //OBTENER_COMBO_EMPRESA();
    //$('#txtfecnac').datetimepicker({
    //    //format: 'YYYY-MM-DD HH:mm'
    //    format: 'DD/MM/YYYY'
    //});
    //$('#txtfecnac').data("DateTimePicker").show();

    $("#id_panel_qr").click(function (e) {
        var CODIGO = $('#txtcodigo').val();
        if (CODIGO == '') {
            Swal.fire('Advertencia!', 'El código QR se generara automáticamente al guardar la tarjeta digital.!', 'warning');
        }

    });
    $("#btnnuevo").css('cursor', 'pointer');

    //function BUSCAR_ALUMNOS() {

    //    var TIPO_DOC = $('#ddltipo_documento_buscar').val();
    //    var NRO_DOC = $('#txtnro_documento_buscar').val();
    //    var MONBRES = $('#txtnombres_buscar').val();
    //    var ESTADO = $('#ddlestado_buscar').val();

    //    var table = $('#Tabla_Alumnos').DataTable();
    //    table.clear().draw();

    //    var ajax_data = { "TIPO_DOC": TIPO_DOC, "NRO_DOC": NRO_DOC, "MONBRES": MONBRES, "ESTADO": ESTADO };
    //    $.ajax({
    //        type: "POST",
    //        url: '../ServiciosWeb/SW_Alumnos.asmx/Buscar_Alumnos',
    //        data: JSON.stringify(ajax_data),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        async: true,
    //        beforeSend: function () {
    //            $('body').addClass('loading');
    //        },
    //        success: function (respuesta) {
    //            var datos = (typeof respuesta.d) == 'string' ?
    //                eval('(' + respuesta.d + ')') :
    //                respuesta.d;

    //            for (var i = 0; i < datos.length; i++) {


    //                $('#Tabla_Alumnos').dataTable({
    //                    columnDefs: [
    //                        { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6] }

    //                    ],
    //                    destroy: true

    //                }).fnAddData([

    //                    datos[i].CODIGO,
    //                    datos[i].TIPO_DOCUMENTO,
    //                    datos[i].NRO_DOCUMENTO,
    //                    datos[i].NOMBRES,
    //                    datos[i].ESTADO,
    //                    "<img src='../img/editar_2.png' class='editar' style='width:20px;height:20px' />",
    //                    "<img src='../img/ELIMINAR.png' class='eliminar' style='width:20px;height:20px'/>"
    //                ]);

    //            }
    //            $('body').removeClass('loading'); //Removemos la clase loading
    //            $("#Tabla_Alumnos").show();
    //        },
    //        error: function (XMLHttpRequest, textStatus, errorThrown) {
    //            var error = eval("(" + XMLHttpRequest.responseText + ")");
    //            // alert(error.Message);
    //            swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
    //        }
    //    });


    //}

    function BUSCAR_ALUMNOS() {

        var TIPO_DOC = $('#ddltipo_documento_buscar').val();
        var NRO_DOC = $('#txtnro_documento_buscar').val();
        var NOMBRES = $('#txtnombres_buscar').val();
        var ESTADO = $('#ddlestado_buscar').val();
        var ajax_data = { "TIPO_DOC": TIPO_DOC, "NRO_DOC": NRO_DOC, "NOMBRES": NOMBRES, "ESTADO": ESTADO };
        var table = $('#Tabla_Alumnos').DataTable();
        table.clear().draw();
        $('#Tabla_Alumnos').DataTable({
            
            destroy: true,
         
            "processing": true,
            "serverSide": true,
            ajax: {
                type: "POST",
                url: "../ServiciosWeb/SW_Alumnos.asmx/obtener",
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                data: function (dtParms) {
                    //enviamos al servidor
                    return JSON.stringify({ ClientParameters: JSON.stringify(dtParms), ajax_data: JSON.stringify(ajax_data) });
                },
                dataFilter: function (res) {
                    //recibimos del servidor
                    var parsed = JSON.parse(res);
                    return JSON.stringify(parsed.d);
                },
                error: function (x, y) {
                    console.log(x);
                }
            },
            "filter": true,
            columns: [
                { "data": "CODIGO" },
                { "data": "TIPO_DOCUMENTO" },
                { "data": "NRO_DOCUMENTO" },
                { "data": "NOMBRES" },
                { "data": "ESTADO" },
                {
                    "render": function (data, type, JsonResultRow, meta) {
                        return "<img src='../img/editar_2.png' class='editar' style='width: 20px; height: 20px' />";
                    }
                },
                {
                    "render": function (data, type, JsonResultRow, meta) {
                        return "<img src='../img/ELIMINAR.png' class='eliminar' style='width: 20px; height: 20px' />";
                    }
                }
          
              
                       
            ],
            columnDefs: [
                           { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6] }

                      ],
          
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
           
           
        });
        $('body').removeClass('loading'); //Removemos la clase loading
               $("#Tabla_Alumnos").show();

    }


 


    $("#btnnuevo").click(function (e) {
        $("#Titulo_Panel").text('Nuevo Alumno');
        $("#ddltipo_documento").val('DNI');
        $("#txtcodigo").val('');
        $("#txtnombres").val('');
        $("#txtnrodocumento").val('');
        $("#ddlnivel").val('B');
        $("#ddlgrado").val('B');
        $("#ddlseccion").val('B');
        $("#ddlestado").val('A');
        $("#nombre_foto_original_imagen_alumno").val('');
        $("#nombre_generado_foto_imagen_alumno").val('');
        $("#ruta_foto_imagen_alumno").val('');
        $("#id_panel_qr").addClass('disabled');
        $("#a_panel_QR").removeAttr('data-toggle', 'tab');
        $('.nav-tabs a[href="#panel_principal"]').tab('show');
        $("#div_estado_buscar").hide();
        $("#btnGuardar").show();
        $("#btnActualizar").hide();
        $("#txtcodigo").prop("disabled", false);
        $('#modal_nuevo').modal();

        /*Eliminar las clases de error*/
        LIMPIAR_ERRORES();
        /****************************/

        /*FILE UPLOAD ALUMNO*/
        $('#file-alumno').fileinput('destroy');
        var tipos = ['jpeg', 'jpg', 'png', 'gif'];
        $('#file-alumno').fileinput({
            language: 'es',
            uploadUrl: '../ServiciosWeb/SW_Alumnos.asmx/Subir_Imagen_alumno',
            uploadAsync: false,
            maxFileCount: 1,
            removeFromPreviewOnError: true,
            allowedFileExtensions: tipos
        });
        $('#file-alumno').on('filebatchuploadsuccess', function (event, data, previewId, index) {
            var respuesta = data.response;

            $('#nombre_foto_original_imagen_alumno').val(respuesta.nombre_imagen_original);
            $('#nombre_generado_foto_imagen_alumno').val(respuesta.nombre_imagen_generado);
            $('#ruta_foto_imagen_alumno').val(respuesta.ruta_imagen);
            Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
        });
        $('#file-alumno').on('fileuploaded', function (event, data, previewId, index) {

            var respuesta = data.response;
            $('#nombre_foto_original_imagen_alumno').val(respuesta.nombre_imagen_original);
            $('#nombre_generado_foto_imagen_alumno').val(respuesta.nombre_imagen_generado);
            $('#ruta_foto_imagen_alumno').val(respuesta.ruta_imagen);
            Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
        });
        $('#file-alumno').on('filecleared', function (event) {
            $('#nombre_foto_original_imagen_alumno').val('');
            $('#nombre_generado_foto_imagen_alumno').val('');
            $('#ruta_foto_imagen_alumno').val('');
        });
        $('#file-alumno').on('filesuccessremove', function (event, id) {
            $('#nombre_foto_original_imagen_alumno').val('');
            $('#nombre_generado_foto_imagen_alumno').val('');
            $('#ruta_foto_imagen_alumno').val('');
        });
        $('#file-alumno').on('filezoomshow', function (event, params) {
            $('#modal_nuevo').css('overflow-y', 'scroll');
        });
         /***************/


    });

    $("#btnbuscar").click(function (e) {

        BUSCAR_ALUMNOS();

    });

    $(document).on('click', '.eliminar', function (e) {
        var ID, NOMBRES;
        CODIGO = $(this).parents("tr").find("td").eq(0).html();
        NOMBRES = $(this).parents("tr").find("td").eq(3).html();




        Swal.fire({
            title: 'Eliminar Registro?',
            text: "¿Estás seguro de eliminar al Alumno  :  " + NOMBRES + " ?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#1ab394',
            cancelButtonColor: '#6c757d',
            confirmButtonText: 'Si, Eliminar !'
        }).then((result) => {
            if (result.value) {


                var ajax_data = {
                    "CODIGO": CODIGO

                };

                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Alumnos.asmx/Eliminar_Alumno',
                    data: JSON.stringify(ajax_data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    beforeSend: function () {
                        $('body').addClass('loading');
                    },
                    success: function (respuesta) {
                        var num = respuesta.d;
                        if (num > 0) {

                            Swal.fire('Eliminado !', 'El Registro ha sido eliminado.', 'success');
                        }
                        $('#Tabla_Alumnos').dataTable().fnClearTable();
                        BUSCAR_ALUMNOS();
                        $('body').removeClass('loading'); //Removemos la clase loading
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        alert(error.Message);
                    }
                });




            }
        })


    });

    $(document).on('click', '.editar', function (e) {

        $('.nav-tabs a[href="#panel_principal"]').tab('show');
        $("#id_panel_qr").removeClass('disabled');
        $("#a_panel_QR").attr('data-toggle', 'tab');
       
        /*Eliminar las clases de error*/
        LIMPIAR_ERRORES();
        /****************************/

        $("#txtcodigo").prop("disabled", true);
        $("#Titulo_Panel").text('Actualizar Alumno');
        $("#div_estado_buscar").show();

        $("#btnGuardar").hide();
        $("#btnActualizar").show();

        var ajax_data = {
            "CODIGO": $(this).parents("tr").find("td").eq(0).html(),
        };


        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Alumnos.asmx/Obtener_Alumnos',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (respuesta) {
                var datos = (typeof respuesta.d) == 'string' ?
                    eval('(' + respuesta.d + ')') :
                    respuesta.d;

                for (var i = 0; i < datos.length; i++) {


                    $("#txtcodigo").val(datos[i].CODIGO);
                    $("#txtnombres").val(datos[i].NOMBRES);
                    $("#ddlsexo").val(datos[i].SEXO);
                    $("#ddltipo_documento").val(datos[i].TIPO_DOCUMENTO);
                    $("#txtnrodocumento").val(datos[i].NRO_DOCUMENTO);
                    $("#ddlestado").val(datos[i].ESTADO);
                    $("#ddlnivel").val(datos[i].NIVEL);
                    $("#ddlgrado").val(datos[i].GRADO);
                    $("#ddlseccion").val(datos[i].SECCION);
                    $("#nombre_foto_original_imagen_alumno").val(datos[i].NOMBRE_ORIGINAL_FOTO_ALUMNO);
                    $("#nombre_generado_foto_imagen_alumno").val(datos[i].NOMBRE_GENERADO_FOTO_ALUMNO);
                    $("#ruta_foto_imagen_alumno").val(datos[i].RUTA_FOTO_ALUMNO);
                    $("#txtusuario_registra").val(datos[i].USUARIO_CREACION);
                    $("#txtxfecha_registra").val(datos[i].FECHA_CREACION);
                    $("#txtusuario_modifica").val(datos[i].USUARIO_MODIFICACION);
                    $("#txt_fecha_modifica").val(datos[i].FECHA_MODIFICACION);
                    $("#url_qr").val(datos[i].URL_QR_ALUMNO);
                    
                    $('#file-alumno').fileinput('destroy');


                    if (datos[i].RUTA_FOTO_ALUMNO.trim().length < 1) {

                        var tipos = ['jpeg', 'jpg', 'png', 'gif'];
                        $('#file-alumno').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Alumnos.asmx/Subir_Imagen_alumno',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos
                        });

                    }
                    else {
                        $('#file-alumno').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Alumnos.asmx/Subir_Imagen_alumno',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos,
                            initialPreview: [datos[i].RUTA_FOTO_ALUMNO],
                            initialPreviewAsData: true,

                            validateInitialCount: true,
                            initialPreviewConfig: [
                                { caption: datos[i].NOMBRE_ORIGINAL_FOTO_ALUMNO, downloadUrl: datos[i].RUTA_FOTO_ALUMNO, size: 930321, url: '../ServiciosWeb/SW_Alumnos.asmx/Eliminar_Imagen', width: "120px", key: 1 }
                            ],
                            overwriteInitial: false,
                            // initialCaption: datos[i].NOMBRE_ORIGINAL_FOTO

                        });

                    }



                    $('#file-alumno').on('filepredelete', function (event, key, jqXHR, data) {
                        $('#nombre_foto_original_imagen_alumno').val('');
                        $('#nombre_generado_foto_imagen_alumno').val('');
                        $('#ruta_foto_imagen_alumno').val('');
                        $('#file-es').val('');
                    });
                    $('#file-alumno').on('filebatchuploadsuccess', function (event, data, previewId, index) {
                        var respuesta = data.response;

                        $('#nombre_foto_original_imagen_alumno').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_alumno').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_alumno').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-alumno').on('fileuploaded', function (event, data, previewId, index) {

                        var respuesta = data.response;
                        $('#nombre_imagen').val(respuesta.nombre_archivo);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-alumno').on('filecleared', function (event) {
                        $('#nombre_foto_original_imagen_alumno').val('');
                        $('#nombre_generado_foto_imagen_alumno').val('');
                        $('#ruta_foto_imagen_alumno').val('');
                    });

                    $('#file-alumno').on('filesuccessremove', function (event, id) {
                        $('#nombre_foto_original_imagen_alumno').val('');
                        $('#nombre_generado_foto_imagen_alumno').val('');
                        $('#ruta_foto_imagen_alumno').val('');
                    });

                    $('#file-alumno').on('filezoomshow', function (event, params) {
                        $('#modal_nuevo').css('overflow-y', 'scroll');
                    });


                    /**/


                    /*QR*/
                    $('#imagen_qr').attr("src", datos[i].RUTA_CODIGO_QR_ALUMNO);



                    
                    var nivel = datos[i].NIVEL;
                    var grado = datos[i].GRADO;
                    var seccion = datos[i].SECCION;
                    OBTENER_GRADO_SECCION(nivel, grado, seccion);
                    

                    $('#modal_nuevo').modal();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });



    });

    $("#btnGuardar").click(function (e) {


        var URL_DOMINIO = window.location.host;

        var resultado_validacion = validar_input_vacios();



        if (resultado_validacion == 0) {

            var CODIGO = $("#txtcodigo").val();
            var NOMBRES = $("#txtnombres").val();
            var SEXO = $("#ddlsexo").val();
            var TIPO_DOCUMENTO = $("#ddltipo_documento").val();
            var NRO_DOCUMENTO = $("#txtnrodocumento").val();
            var ESTADO = $("#ddlestado").val();
            var NIVEL = $("#ddlnivel").val();
            var GRADO = $("#ddlgrado").val();
            var SECCION = $("#ddlseccion").val();
            var NOMBRE_FOTO_ORIGINAL = $("#nombre_foto_original_imagen_alumno").val();
            var NOMBRE_FOTO_GENERADO = $("#nombre_generado_foto_imagen_alumno").val();
            var RUTA_FOTO = $("#ruta_foto_imagen_alumno").val();
            
            var USUARIO_CREACION = USUARIO;


            //  var EMPRESA = $("#ddlempresa").val();
            // var USUARIO_CREACION = $.session.get('SESSION_USUARIO');

            var ajax_data = {
                "CODIGO": CODIGO,
                "NOMBRES": NOMBRES,
                "SEXO": SEXO,
                "TIPO_DOCUMENTO": TIPO_DOCUMENTO,
                "NRO_DOCUMENTO": NRO_DOCUMENTO,
                "ESTADO": ESTADO,
                "NIVEL": NIVEL,
                "GRADO": GRADO,
                "SECCION": SECCION,               
                "USUARIO_CREACION": USUARIO_CREACION,
                "NOMBRE_FOTO_ORIGINAL": NOMBRE_FOTO_ORIGINAL,
                "NOMBRE_FOTO_GENERADO": NOMBRE_FOTO_GENERADO,
                "RUTA_FOTO": RUTA_FOTO,
                "URL_DOMINIO": URL_DOMINIO

            };
            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Alumnos.asmx/Grabar_Alumnos',
                data: JSON.stringify(ajax_data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                beforeSend: function () {
                    $('body').addClass('loading');
                },
                success: function (resultado) {
                    var num = resultado.d;
                    if (num > 0) {
                        $('#modal_nuevo').modal('hide');
                        Swal.fire('Excelente!', 'El registro se Grabo Satisfactoriamente.!', 'success')
                    }

                    else {
                        Swal.fire('Error!', 'El registro no Grabo.!', 'error')
                        $('#modal_nuevo').modal('hide');
                    }
                    $('body').removeClass('loading'); //Removemos la clase loading
                    BUSCAR_ALUMNOS();

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });

        }




    });

    $("#btnActualizar").click(function (e) {

        var resultado_validacion = validar_input_vacios();
        var URL_DOMINIO = window.location.host;

        if (resultado_validacion == 0) {

            var CODIGO = $("#txtcodigo").val();
            var NOMBRES = $("#txtnombres").val();
            var SEXO = $("#ddlsexo").val();
            var TIPO_DOCUMENTO = $("#ddltipo_documento").val();
            var NRO_DOCUMENTO = $("#txtnrodocumento").val();
            var ESTADO = $("#ddlestado").val();
            var NIVEL = $("#ddlnivel").val();
            var GRADO = $("#ddlgrado").val();
            var SECCION = $("#ddlseccion").val();
            var NOMBRE_FOTO_ORIGINAL = $("#nombre_foto_original_imagen_alumno").val();
            var NOMBRE_FOTO_GENERADO = $("#nombre_generado_foto_imagen_alumno").val();
            var RUTA_FOTO = $("#ruta_foto_imagen_alumno").val();
            var USUARIO_MODIFICACION = USUARIO;

            var ajax_data = {
                "CODIGO": CODIGO,
                "NOMBRES": NOMBRES,
                "SEXO": SEXO,
                "TIPO_DOCUMENTO": TIPO_DOCUMENTO,
                "NRO_DOCUMENTO": NRO_DOCUMENTO,
                "ESTADO": ESTADO,
                "NIVEL": NIVEL,
                "GRADO": GRADO,
                "SECCION": SECCION,
                "USUARIO_MODIFICACION": USUARIO_MODIFICACION,
                "NOMBRE_FOTO_ORIGINAL": NOMBRE_FOTO_ORIGINAL,
                "NOMBRE_FOTO_GENERADO": NOMBRE_FOTO_GENERADO,
                "RUTA_FOTO": RUTA_FOTO,
                "URL_DOMINIO": URL_DOMINIO,
                "ESTADO": ESTADO
            };

           
            if ($("#url_qr").val() == '' )
            {
                
                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Alumnos.asmx/Actualizar_Alumnos_QR',
                    data: JSON.stringify(ajax_data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    beforeSend: function () {
                        $('body').addClass('loading');
                    },
                    success: function (resultado) {
                        var num = resultado.d;
                        if (num > 0) {

                            $('#modal_nuevo').modal('hide');

                            Swal.fire('Excelente!', 'El registro se Actualizó Satisfactoriamente.!', 'success')
                        }

                        else {

                            Swal.fire('Error!', 'El registro no Grabo.!', 'error')
                            $('#modal_nuevo').modal('hide');
                        }
                        $('body').removeClass('loading'); //Removemos la clase loading
                      //  BUSCAR_ALUMNOS();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        alert(error.Message);
                    }
                });
            }
            else {
             
               
                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Alumnos.asmx/Actualizar_Alumnos',
                    data: JSON.stringify(ajax_data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    beforeSend: function () {
                        $('body').addClass('loading');
                    },
                    success: function (resultado) {
                        var num = resultado.d;
                        if (num > 0) {

                            $('#modal_nuevo').modal('hide');

                            Swal.fire('Excelente!', 'El registro se Actualizó Satisfactoriamente.!', 'success')
                        }

                        else {

                            Swal.fire('Error!', 'El registro no Grabo.!', 'error')
                            $('#modal_nuevo').modal('hide');
                        }
                        $('body').removeClass('loading'); //Removemos la clase loading
                        BUSCAR_ALUMNOS();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        alert(error.Message);
                    }
                });
            }


           

        }

        




    });


    function validar_input_vacios() {
        /*Eliminar las clases de error*/
        $("#txtcodigo").removeClass('error_campo_vacio');
        $("#txtnombres").removeClass('error_campo_vacio');
        $("#txtnrodocumento").removeClass('error_campo_vacio');

        var validar = 0;

        var NRO_DOC = $("#txtnrodocumento").val();
        var NOMBRES = $("#txtnombres").val();
        var CODIGO = $("#txtcodigo").val();

        if (CODIGO == '') {
            validar = 1;

            alertify.error('El Campo <b> Codigo </b> no debe estar vacio.!');
            $("#txtcodigo").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtcodigo").removeClass('error_campo_vacio'); }

        if (NRO_DOC == '') {
            validar = 1;

            alertify.error('El Campo <b> Nro Documento </b> no debe estar vacio.!');
            $("#txtnrodoc").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtnrodoc").removeClass('error_campo_vacio'); }

        if (NOMBRES == '') {
            validar = 1;

            alertify.error('El Campo <b> Nombres </b> no debe estar vacio.!');
            $("#txtnombres").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtnombres").removeClass('error_campo_vacio'); }


       

        return validar;
    }



    function LIMPIAR_ERRORES()
    {
        $("#txtcodigo").removeClass('error_campo_vacio');
        $("#txtnrodoc").removeClass('error_campo_vacio');
        $("#txtnombres").removeClass('error_campo_vacio');
    }



    $("#btncerrar").click(function (e) {

        window.location.href = "Principal.aspx";

    });





    function OBTENER_NIVEL() {

        $('#ddlnivel').empty().append('<option value=B> << Seleccionar >> </option>');
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Alumnos.asmx/Obtener_Nivel',
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () {
                $('body').addClass('loading');
            },
            success: function (respuesta) {
                var datos = (typeof respuesta.d) == 'string' ?
                    eval('(' + respuesta.d + ')') :
                    respuesta.d;

                for (var i = 0; i < datos.length; i++) {

                    $('#ddlnivel').append('<option value="' + datos[i].CODIGO_NIVEL + '">' + datos[i].DESCRIPCION_NIVEL + '</option>');

                }
                $('body').removeClass('loading'); //Removemos la clase loading

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });


    }

    $('#ddlnivel').change(function () {

        $('#ddlgrado').empty().append('<option value=B> << Seleccionar >> </option>');
        $('#ddlseccion').empty().append('<option value=B> << Seleccionar >> </option>');
        var NIVEL = $('#ddlnivel').val();

        var ajax_data = { "CODIGO_NIVEL": NIVEL };

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Alumnos.asmx/Obtener_Grado',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlgrado').append('<option value="' + data[i].CODIGO_GRADO + '">' + data[i].DESCRIPCION_GRADO + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });

    $('#ddlgrado').change(function () {

        $('#ddlseccion').empty().append('<option value=B> << Seleccionar >> </option>');


        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Alumnos.asmx/Obtener_Seccion',
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlseccion').append('<option value="' + data[i].CODIGO_SECCION + '">' + data[i].DESCRIPCION_SECCION + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });

    function OBTENER_GRADO_SECCION(nivel, grado, seccion) {
      
        $('#ddlgrado').empty().append('<option value=B> << Seleccionar >> </option>');
        $('#ddlseccion').empty().append('<option value=B> << Seleccionar >> </option>');
        var ajax_data = { "CODIGO_NIVEL": nivel };

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Alumnos.asmx/Obtener_Grado',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlgrado').append('<option value="' + data[i].CODIGO_GRADO + '">' + data[i].DESCRIPCION_GRADO + '</option>');
                }

                $('#ddlgrado').val(grado);
                $('body').removeClass('loading');

              
                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Alumnos.asmx/Obtener_Seccion',
                    data: JSON.stringify(),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    beforeSend: function () { $('body').addClass('loading'); },
                    success: function (respuesta) {
                        var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                        for (var i = 0; i < data.length; i++) {

                            $('#ddlseccion').append('<option value="' + data[i].CODIGO_SECCION + '">' + data[i].DESCRIPCION_SECCION + '</option>');
                        }

                        $('#ddlseccion').val(seccion);
                        $('body').removeClass('loading');
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
                    }
                });


            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });
    }





});
