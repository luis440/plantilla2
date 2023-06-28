$(document).ready(function () {
    //var f = new Date();
    //$("#txtfecha_buscar").val(f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear());


    var ID = ($.session.get('SESSION_ID'));
    var USUARIO = ($.session.get('SESSION_USUARIO'));
    var NOMBRES = ($.session.get('SESSION_NOMBRES'));
    var PERFIL = ($.session.get('SESSION_PERFIL'));
    var APELLIDOS = ($.session.get('SESSION_APELLIDOS'));
    var CORREO = ($.session.get('SESSION_CORREO'));


     


    //$("#txtnombre_completo").text(NOMBRES + ' ' + APELLIDOS);
    //$("#txtperfil").text(PERFIL);
    //$("#txtcorreo").text(CORREO);
    //$("#txtusuario").text(USUARIO);


    //if (typeof NOMBRES === "undefined") {
    //    location.href = 'Login.aspx';

    //}

    //if (USUARIO != 'admin') {
    //    location.href = 'Login.aspx';

    //}


    //OBTENER_COMBO_EMPRESA();
    //$('#txtfecnac').datetimepicker({
    //    //format: 'YYYY-MM-DD HH:mm'
    //    format: 'DD/MM/YYYY'
    //});
    //$('#txtfecnac').data("DateTimePicker").show();


    $("#btnnuevo").css('cursor', 'pointer');
    function BUSCAR_CLIENTE() {

        var TIPO_DOC = $('#ddltipo_documento_buscar_cliente').val();
        var NRO_DOC = $('#txtnrodoc_buscar_cliente').val();
        var RAZON_SOCIAL = $('#txtrazon_social_buscar_cliente').val();
        var ESTADO = 'A';

        var table = $('#Tabla_Clientes_Buscar').DataTable();
        table.clear().draw();

        var ajax_data = { "TIPO_DOC": TIPO_DOC, "NRO_DOC": NRO_DOC, "RAZON_SOCIAL": RAZON_SOCIAL, "ESTADO": ESTADO };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Clientes.asmx/Buscar_Clientes',
            data: JSON.stringify(ajax_data),
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


                    $('#Tabla_Clientes_Buscar').dataTable({
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].TIPO_DOC,
                        datos[i].NUM_DOC,
                        datos[i].RAZON_SOCIAL,
                        "<img src='../img/check1.png' class='seleccionar_cliente' style='width:20px;height:20px' />"
                       
                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#contiene_tabla").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });


    }
    function BUSCAR() {

        var TIPO_SERVICIO = $('#ddltipo_servicio_buscar').val();
        var NRO_ORDEN_SERVICIO = $('#txt_numero_orden_buscar').val();
        var RAZON_SOCIAL = $('#txt_razon_social_buscar').val();
        var ESTADO = $('#ddlestado_orden_servicio_buscar').val();

        var table = $('#Tabla_Orden_Servicio').DataTable();
        table.clear().draw();

        var ajax_data = { "TIPO_SERVICIO": TIPO_SERVICIO, "NRO_ORDEN_SERVICIO": NRO_ORDEN_SERVICIO, "RAZON_SOCIAL": RAZON_SOCIAL, "ESTADO": ESTADO };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Buscar',
            data: JSON.stringify(ajax_data),
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


                    $('#Tabla_Orden_Servicio').dataTable({
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5,6] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].NUM_ORDEN_SERVICIO,
                        datos[i].TIPO_SERVICIO,
                        datos[i].RAZON_SOCIAL,
                        datos[i].ESTADO,
                        "<img src='../img/editar_2.png' class='editar' style='width:20px;height:20px' />",
                            "<img src='../img/ELIMINAR.png' class='eliminar' style='width:20px;height:20px'/>"
                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#Tabla_Orden_Servicio").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> ", "error");
            }
        });


    }
    $("#cerrar_panel_transporte").click(function (e) {
    
        $("#panel_transporte").hide("slow");
        $("#flag_transporte").val('');
    });
    $("#cerrar_panel_cuadrilla").click(function (e) {

        $("#panel_cuadrilla").hide("slow");
        $("#flag_cuadrilla").val('');
    });
    $("#cerrar_panel_aduana").click(function (e) {

        $("#panel_aduana").hide("slow");
        $("#flag_aduana").val('');
    });
    $("#cerrar_panel_carga").click(function (e) {

        $("#panel_carga").hide("slow");
        $("#flag_carga").val('');
    });
    $("#cerrar_panel_otros").click(function (e) {

        $("#panel_otros").hide("slow");
        $("#flag_otros").val('');
    });
    $("#cerrar_panel_resguardo").click(function (e) {

        $("#panel_resguardo").hide("slow");
        $("#flag_resguardo").val('');
    });

    $("#btnagregar").click(function (e) {
        var TIPO_SERVICIO = $("#ddltipo_servicio").val();
        if (TIPO_SERVICIO == 'TRANSPORTE')
        {
            $("#panel_transporte").show();
            $("#flag_transporte").val('1');
        }
        if (TIPO_SERVICIO == 'CUADRILLA') {
            $("#panel_cuadrilla").show();
            $("#flag_cuadrilla").val('1');
        }
        if (TIPO_SERVICIO == 'RESGUARDO') {
            $("#panel_resguardo").show();
            $("#flag_resguardo").val('1');
        }
        if (TIPO_SERVICIO == 'ADUANA') {
            $("#panel_aduana").show();
            $("#flag_aduana").val('1');
        }
        if (TIPO_SERVICIO == 'CARGA') {
            $("#panel_carga").show();
            $("#flag_carga").val('1');
        }
        if (TIPO_SERVICIO == 'OTROS') {
            $("#panel_otros").show();
            $("#flag_otros").val('1');
        }

    });
  

    $("#btnnuevo").click(function (e) {
        $("#Titulo_Panel").text('Nuevo Orden de Servicio');

        $("#txtfecha_tipo_cambio").val('');
        $("#txtcompra").val('');
        $("#txtventa").val('');

        var f = new Date();
        $("#txtfecha_tipo_cambio").val(f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear());




        $("#div_estado_buscar").hide();
        $("#btnGuardar").show();
        $("#btnActualizar").hide();

        $('#modal_nuevo').modal();

        /*Eliminar las clases de error*/
        $("#txtfecha_tipo_cambio").removeClass('error_campo_vacio');
        $("#txtcompra").removeClass('error_campo_vacio');
        $("#txtventa").removeClass('error_campo_vacio');




    });

    $("#btnbuscar").click(function (e) {

        BUSCAR();

    });

    $("#btn_buscar_cliente").click(function (e) {

        BUSCAR_CLIENTE();

    });

    $(document).on('click', '.editar', function (e) {


        /*Eliminar las clases de error*/
        $("#txtapellidos").removeClass('error_campo_vacio');
        $("#txtnombres").removeClass('error_campo_vacio');
        $("#txt_usuario").removeClass('error_campo_vacio');
        $("#txtclave").removeClass('error_campo_vacio');


        $("#Titulo_Panel").text('Actualizar Tipo de Cambio');
        $("#div_estado_buscar").show();

        $("#btnGuardar").hide();
        $("#btnActualizar").show();

        var ajax_data = {
            "ID": $(this).parents("tr").find("td").eq(0).html(),
        };


        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Obtener',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (respuesta) {
                var datos = (typeof respuesta.d) == 'string' ?
                    eval('(' + respuesta.d + ')') :
                    respuesta.d;

                for (var i = 0; i < datos.length; i++) {



                   
                    $("#txtcodigo").val(datos[i].ID);
                    $("#txt_id_cliente").val(datos[i].ID_CLIENTE);
                    $("#ddltipo_documento_buscar_cliente").val(datos[i].TIPO_DOC);
                    $("#txtnrodoc_buscar_cliente").val(datos[i].NUM_DOC);
                    $("#txtrazon_social_buscar_cliente").val(datos[i].RAZON_SOCIAL);
                    $("#flag_transporte").val(datos[i].FLAG_TRANSPORTE);
                    $("#flag_cuadrilla").val(datos[i].FLAG_CUADRILLA);
                    $("#flag_resguardo").val(datos[i].FLAG_RESGUARDO);
                    $("#flag_aduana").val(datos[i].FLAG_AGE_ADUANA);
                    $("#flag_carga").val(datos[i].FLAG_AGE_CARGA);
                    $("#flag_otros").val(datos[i].FLAG_OTROS);
                    $("#txtnro_grr_transporte").val(datos[i].TRA_NUM_GR_REMITENTE);
                    $("#txtnro_grt_transporte").val(datos[i].TRA_NUM_GR_TRANSPORTE);
                    $("#txt_placa_transporte").val(datos[i].TRA_PLACA);
                    $("#txt_brevete_transporte").val(datos[i].TRA_BREVETE);
                    $("#txt_direccion_inicio_transporte").val(datos[i].TRA_DIRECCION_INICIO);
                    $("#txt_direccion_llegada_transporte").val(datos[i].TRA_DIRECCION_LLEGADA);
                    $("#ddl_tipo_carga_transporte").val(datos[i].TRA_TIPO_CARGA);
                    $("#txt_nro_contenedor_transporte").val(datos[i].TRA_NUM_CONTENEDOR);
                    $("#txt_nro_peso_transporte").val(datos[i].TRA_PESO);
                    $("#txt_fecha_servicio_transporte").val(datos[i].TRA_FECHA_SERVICIO);
                    $("#ddl_tipo_bulto_transporte").val(datos[i].TRA_TIPO_BULTO);
                    $("#txt_nro_bulto_transporte").val(datos[i].TRA_NUM_BULTO);
                    $("#ddlservicio_cuadrilla").val(datos[i].CUAD_SERVICIO);
                    $("#txt_Detalle_cuadrilla").val(datos[i].CUAD_DETALLE);
                    $("#txt_lugar_Servicio_cuadrilla").val(datos[i].CUAD_LUGAR);
                    $("#txt_nro_personas_cuadrilla").val(datos[i].CUAD_NUM_PERSONAS);
                    $("#txt_proveedor_resguardo").val(datos[i].RESG_PROVEEDOR);
                    $("#txt_ruta_resguardo").val(datos[i].RESG_RUTA);
                    $("#txt_aduana_aduana").val(datos[i].AGE_ADU_ADUANA);
                    $("#txt_manifiesto_aduana").val(datos[i].AGE_ADU_MANIFIESTO);
                    $("#txt_regimen_aduana").val(datos[i].AGE_ADU_REGIMEN);
                    $("#txt_dam_aduana").val(datos[i].AGE_ADU_DAM);
                    $("#txt_canal_aduana").val(datos[i].AGE_ADU_CANAL);
                    $("#txt_empresa_aduana").val(datos[i].AGE_ADU_EMPRESA);
                    $("#txt_fecha_arribo_aduana").val(datos[i].AGE_ADU_FEC_ARRIBO);
                    $("#txt_fecha_retiro_aduana").val(datos[i].AGE_ADU_FEC_RETIRO);
                    $("#txt_almacen_aduana").val(datos[i].AGE_ADU_ALMACEN);
                    $("#txt_fob_aduana").val(datos[i].AGE_ADU_VALORFOB);
                    $("#txt_cif_aduana").val(datos[i].AGE_ADU_VALORCIF);
                    $("#txt_aduana_carga").val(datos[i].AGE_CAR_ADUANA);
                    $("#txt_manifiesto_carga").val(datos[i].AGE_CAR_MANIFIESTO);
                    $("#txt_puerto_origen_carga").val(datos[i].AGE_CAR_PUERTO_ORIGEN);
                    $("#txt_pais_carga").val(datos[i].AGE_CAR_PAIS);
                    $("#txt_empresa_transporte_carga").val(datos[i].AGE_CAR_EMP_TRANSP);
                    $("#txt_empresa_carga").val(datos[i].AGE_CAR_EMPRESA);
                    $("#txt_fecha_Arribo_carga").val(datos[i].AGE_CAR_FEC_ARRIBO);
                    $("#txt_fecha_retiro_carga").val(datos[i].AGE_CAR_FEC_RETIRO);
                    $("#txt_peso_Carga").val(datos[i].AGE_CAR_PESO);
                    $("#txt_volumen_carga").val(datos[i].AGE_CAR_VOLUMEN);
                    $("#txt_nro_bultos_Carga").val(datos[i].AGE_CAR_NUM_BULTO);
                    $("#txt_almacen_carga").val(datos[i].AGE_CAR_ALMACEN);
                    $("#txt_detalle_otros").val(datos[i].OTRO_DETALLE);
                    $("#txtobservacion_otros").val(datos[i].OTRO_OBSERVACION);
                    $("#ddlestado").val(datos[i].ESTADO);
                    



                    
                }

                if ($("#flag_transporte").val() == 1) { $("#panel_transporte").show(); } else { $("#panel_transporte").hide(); }
                if ($("#flag_cuadrilla").val() == 1) { $("#panel_cuadrilla").show(); } else { $("#panel_cuadrilla").hide(); }
                if ($("#flag_resguardo").val() == 1) { $("#panel_resguardo").show(); } else { $("#panel_resguardo").hide(); }
                if ($("#flag_aduana").val() == 1) { $("#panel_aduana").show(); } else { $("#panel_aduana").hide(); }
                if ($("#flag_carga").val() == 1) { $("#panel_carga").show(); } else { $("#panel_carga").hide(); }
                if ($("#flag_otros").val() == 1) { $("#panel_otros").show(); } else { $("#panel_otros").hide(); }


               
                $('#modal_nuevo').modal();
                


            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });



    });

    $("#btnGuardar").click(function (e) {



        var ID_CLIENTE = $("#txt_id_cliente").val();
        var TIPO_DOC = $("#ddltipo_documento_buscar_cliente").val();
        var NUM_DOC = $("#txtnrodoc_buscar_cliente").val();
        var RAZON_SOCIAL = $("#txtrazon_social_buscar_cliente").val();
        //var NUM_ORDEN_SERVICIO = $("#ddlmoneda").val();
        var FLAG_TRANSPORTE = $("#flag_transporte").val();
        var FLAG_CUADRILLA = $("#flag_cuadrilla").val();
        var FLAG_RESGUARDO = $("#flag_resguardo").val();
        var FLAG_AGE_ADUANA = $("#flag_aduana").val();
        var FLAG_AGE_CARGA = $("#flag_carga").val();
        var FLAG_OTROS = $("#flag_otros").val();
        var TRA_NUM_GR_REMITENTE = $("#txtnro_grr_transporte").val();
        var TRA_NUM_GR_TRANSPORTE = $("#txtnro_grt_transporte").val();
        var TRA_PLACA = $("#txt_placa_transporte").val();
        var TRA_BREVETE = $("#txt_brevete_transporte").val();
        var TRA_DIRECCION_INICIO = $("#txt_direccion_inicio_transporte").val();
        var TRA_DIRECCION_LLEGADA = $("#txt_direccion_llegada_transporte").val();
        var TRA_TIPO_CARGA = $("#ddl_tipo_carga_transporte").val();
        var TRA_NUM_CONTENEDOR = $("#txt_nro_contenedor_transporte").val();
        var TRA_PESO = $("#txt_nro_peso_transporte").val();
        var TRA_FECHA_SERVICIO = $("#txt_fecha_servicio_transporte").val();
        var TRA_TIPO_BULTO = $("#ddl_tipo_bulto_transporte").val();
        var TRA_NUM_BULTO = $("#txt_nro_bulto_transporte").val();
        var CUAD_SERVICIO = $("#ddlservicio_cuadrilla").val();
        var CUAD_DETALLE = $("#txt_Detalle_cuadrilla").val();
        var CUAD_LUGAR = $("#txt_lugar_Servicio_cuadrilla").val();
        var CUAD_NUM_PERSONAS = $("#txt_nro_personas_cuadrilla").val();
        var RESG_PROVEEDOR = $("#txt_proveedor_resguardo").val();
        var RESG_RUTA = $("#txt_ruta_resguardo").val();
        var AGE_ADU_ADUANA = $("#txt_aduana_aduana").val();
        var AGE_ADU_MANIFIESTO = $("#txt_manifiesto_aduana").val();
        var AGE_ADU_REGIMEN = $("#txt_regimen_aduana").val();
        var AGE_ADU_DAM = $("#txt_dam_aduana").val();
        var AGE_ADU_CANAL = $("#txt_canal_aduana").val();
        var AGE_ADU_EMPRESA = $("#txt_empresa_aduana").val();
        var AGE_ADU_FEC_ARRIBO = $("#txt_fecha_arribo_aduana").val();
        var AGE_ADU_FEC_RETIRO = $("#txt_fecha_retiro_aduana").val();
        var AGE_ADU_ALMACEN = $("#txt_almacen_aduana").val();
        var AGE_ADU_VALORFOB = $("#txt_fob_aduana").val();
        var AGE_ADU_VALORCIF = $("#txt_cif_aduana").val();
        var AGE_CAR_ADUANA = $("#txt_aduana_carga").val();
        var AGE_CAR_MANIFIESTO = $("#txt_manifiesto_carga").val();
        var AGE_CAR_PUERTO_ORIGEN = $("#txt_puerto_origen_carga").val();
        var AGE_CAR_PAIS = $("#txt_pais_carga").val();
        var AGE_CAR_EMP_TRANSP = $("#txt_empresa_transporte_carga").val();
        var AGE_CAR_EMPRESA = $("#txt_empresa_carga").val();
        var AGE_CAR_FEC_ARRIBO = $("#txt_fecha_Arribo_carga").val();
        var AGE_CAR_FEC_RETIRO = $("#txt_fecha_retiro_carga").val();
        var AGE_CAR_PESO = $("#txt_peso_Carga").val();
        var AGE_CAR_VOLUMEN = $("#txt_volumen_carga").val();
        var AGE_CAR_NUM_BULTO = $("#txt_nro_bultos_Carga").val();
        var AGE_CAR_ALMACEN = $("#txt_almacen_carga").val();
        var OTRO_DETALLE = $("#txt_detalle_otros").val();
        var OTRO_OBSERVACION = $("#txtobservacion_otros").val();
        var USUARIO_CREACION = USUARIO; 

            var ajax_data = {

                "ID_CLIENTE": ID_CLIENTE,
                "TIPO_DOC": TIPO_DOC,
                "NUM_DOC": NUM_DOC,
                "RAZON_SOCIAL": RAZON_SOCIAL,
                "FLAG_TRANSPORTE": FLAG_TRANSPORTE,
                "FLAG_CUADRILLA": FLAG_CUADRILLA,
                "FLAG_RESGUARDO": FLAG_RESGUARDO,
                "FLAG_AGE_ADUANA": FLAG_AGE_ADUANA,
                "FLAG_AGE_CARGA": FLAG_AGE_CARGA,
                "FLAG_OTROS": FLAG_OTROS,
                "TRA_NUM_GR_REMITENTE": TRA_NUM_GR_REMITENTE,
                "TRA_NUM_GR_TRANSPORTE": TRA_NUM_GR_TRANSPORTE,
                "TRA_PLACA": TRA_PLACA,
                "TRA_BREVETE": TRA_BREVETE,
                "TRA_DIRECCION_INICIO": TRA_DIRECCION_INICIO,
                "TRA_DIRECCION_LLEGADA": TRA_DIRECCION_LLEGADA,
                "TRA_TIPO_CARGA": TRA_TIPO_CARGA,
                "TRA_NUM_CONTENEDOR": TRA_NUM_CONTENEDOR,
                "TRA_PESO": TRA_PESO,
                "TRA_FECHA_SERVICIO": TRA_FECHA_SERVICIO,
                "TRA_TIPO_BULTO": TRA_TIPO_BULTO,
                "TRA_NUM_BULTO": TRA_NUM_BULTO,
                "CUAD_SERVICIO": CUAD_SERVICIO,
                "CUAD_DETALLE": CUAD_DETALLE,
                "CUAD_LUGAR": CUAD_LUGAR,
                "CUAD_NUM_PERSONAS": CUAD_NUM_PERSONAS,
                "RESG_PROVEEDOR": RESG_PROVEEDOR,
                "RESG_RUTA": RESG_RUTA,
                "AGE_ADU_ADUANA": AGE_ADU_ADUANA,
                "AGE_ADU_MANIFIESTO": AGE_ADU_MANIFIESTO,
                "AGE_ADU_REGIMEN": AGE_ADU_REGIMEN,
                "AGE_ADU_DAM": AGE_ADU_DAM,
                "AGE_ADU_CANAL": AGE_ADU_CANAL,
                "AGE_ADU_EMPRESA": AGE_ADU_EMPRESA,
                "AGE_ADU_FEC_ARRIBO": AGE_ADU_FEC_ARRIBO,
                "AGE_ADU_FEC_RETIRO": AGE_ADU_FEC_RETIRO,
                "AGE_ADU_ALMACEN": AGE_ADU_ALMACEN,
                "AGE_ADU_VALORFOB": AGE_ADU_VALORFOB,
                "AGE_ADU_VALORCIF": AGE_ADU_VALORCIF,
                "AGE_CAR_ADUANA": AGE_CAR_ADUANA,
                "AGE_CAR_MANIFIESTO": AGE_CAR_MANIFIESTO,
                "AGE_CAR_PUERTO_ORIGEN": AGE_CAR_PUERTO_ORIGEN,
                "AGE_CAR_PAIS": AGE_CAR_PAIS,
                "AGE_CAR_EMP_TRANSP": AGE_CAR_EMP_TRANSP,
                "AGE_CAR_EMPRESA": AGE_CAR_EMPRESA,
                "AGE_CAR_FEC_ARRIBO": AGE_CAR_FEC_ARRIBO,
                "AGE_CAR_FEC_RETIRO": AGE_CAR_FEC_RETIRO,
                "AGE_CAR_PESO": AGE_CAR_PESO,
                "AGE_CAR_VOLUMEN": AGE_CAR_VOLUMEN,
                "AGE_CAR_NUM_BULTO": AGE_CAR_NUM_BULTO,
                "AGE_CAR_ALMACEN": AGE_CAR_ALMACEN,
                "OTRO_DETALLE": OTRO_DETALLE,
                "OTRO_OBSERVACION": OTRO_OBSERVACION,
                "USUARIO_CREACION": USUARIO_CREACION

            };
            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Grabar',
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
                    //BUSCAR();

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });

        




    });
    
    $("#btnActualizar").click(function (e) {

        var resultado_validacion = validar_input_vacios();


        if (resultado_validacion == 0) {

            var ID = $("#txtcodigo").val();
            var ID_CLIENTE = $("#txt_id_cliente").val();
            var TIPO_DOC = $("#ddltipo_documento_buscar_cliente").val();
            var NUM_DOC = $("#txtnrodoc_buscar_cliente").val();
            var RAZON_SOCIAL = $("#txtrazon_social_buscar_cliente").val();
            //var NUM_ORDEN_SERVICIO = $("#ddlmoneda").val();
            var FLAG_TRANSPORTE = $("#flag_transporte").val();
            var FLAG_CUADRILLA = $("#flag_cuadrilla").val();
            var FLAG_RESGUARDO = $("#flag_resguardo").val();
            var FLAG_AGE_ADUANA = $("#flag_aduana").val();
            var FLAG_AGE_CARGA = $("#flag_carga").val();
            var FLAG_OTROS = $("#flag_otros").val();
            var TRA_NUM_GR_REMITENTE = $("#txtnro_grr_transporte").val();
            var TRA_NUM_GR_TRANSPORTE = $("#txtnro_grt_transporte").val();
            var TRA_PLACA = $("#txt_placa_transporte").val();
            var TRA_BREVETE = $("#txt_brevete_transporte").val();
            var TRA_DIRECCION_INICIO = $("#txt_direccion_inicio_transporte").val();
            var TRA_DIRECCION_LLEGADA = $("#txt_direccion_llegada_transporte").val();
            var TRA_TIPO_CARGA = $("#ddl_tipo_carga_transporte").val();
            var TRA_NUM_CONTENEDOR = $("#txt_nro_contenedor_transporte").val();
            var TRA_PESO = $("#txt_nro_peso_transporte").val();
            var TRA_FECHA_SERVICIO = $("#txt_fecha_servicio_transporte").val();
            var TRA_TIPO_BULTO = $("#ddl_tipo_bulto_transporte").val();
            var TRA_NUM_BULTO = $("#txt_nro_bulto_transporte").val();
            var CUAD_SERVICIO = $("#ddlservicio_cuadrilla").val();
            var CUAD_DETALLE = $("#txt_Detalle_cuadrilla").val();
            var CUAD_LUGAR = $("#txt_lugar_Servicio_cuadrilla").val();
            var CUAD_NUM_PERSONAS = $("#txt_nro_personas_cuadrilla").val();
            var RESG_PROVEEDOR = $("#txt_proveedor_resguardo").val();
            var RESG_RUTA = $("#txt_ruta_resguardo").val();
            var AGE_ADU_ADUANA = $("#txt_aduana_aduana").val();
            var AGE_ADU_MANIFIESTO = $("#txt_manifiesto_aduana").val();
            var AGE_ADU_REGIMEN = $("#txt_regimen_aduana").val();
            var AGE_ADU_DAM = $("#txt_dam_aduana").val();
            var AGE_ADU_CANAL = $("#txt_canal_aduana").val();
            var AGE_ADU_EMPRESA = $("#txt_empresa_aduana").val();
            var AGE_ADU_FEC_ARRIBO = $("#txt_fecha_arribo_aduana").val();
            var AGE_ADU_FEC_RETIRO = $("#txt_fecha_retiro_aduana").val();
            var AGE_ADU_ALMACEN = $("#txt_almacen_aduana").val();
            var AGE_ADU_VALORFOB = $("#txt_fob_aduana").val();
            var AGE_ADU_VALORCIF = $("#txt_cif_aduana").val();
            var AGE_CAR_ADUANA = $("#txt_aduana_carga").val();
            var AGE_CAR_MANIFIESTO = $("#txt_manifiesto_carga").val();
            var AGE_CAR_PUERTO_ORIGEN = $("#txt_puerto_origen_carga").val();
            var AGE_CAR_PAIS = $("#txt_pais_carga").val();
            var AGE_CAR_EMP_TRANSP = $("#txt_empresa_transporte_carga").val();
            var AGE_CAR_EMPRESA = $("#txt_empresa_carga").val();
            var AGE_CAR_FEC_ARRIBO = $("#txt_fecha_Arribo_carga").val();
            var AGE_CAR_FEC_RETIRO = $("#txt_fecha_retiro_carga").val();
            var AGE_CAR_PESO = $("#txt_peso_Carga").val();
            var AGE_CAR_VOLUMEN = $("#txt_volumen_carga").val();
            var AGE_CAR_NUM_BULTO = $("#txt_nro_bultos_Carga").val();
            var AGE_CAR_ALMACEN = $("#txt_almacen_carga").val();
            var OTRO_DETALLE = $("#txt_detalle_otros").val();
            var OTRO_OBSERVACION = $("#txtobservacion_otros").val();
            var ESTADO = $("#ddlestado").val();
            var USUARIO_MODIFICACION = USUARIO;

            var ajax_data = {
                "ID": ID,
                "ID_CLIENTE": ID_CLIENTE,
                "TIPO_DOC": TIPO_DOC,
                "NUM_DOC": NUM_DOC,
                "RAZON_SOCIAL": RAZON_SOCIAL,
                "FLAG_TRANSPORTE": FLAG_TRANSPORTE,
                "FLAG_CUADRILLA": FLAG_CUADRILLA,
                "FLAG_RESGUARDO": FLAG_RESGUARDO,
                "FLAG_AGE_ADUANA": FLAG_AGE_ADUANA,
                "FLAG_AGE_CARGA": FLAG_AGE_CARGA,
                "FLAG_OTROS": FLAG_OTROS,
                "TRA_NUM_GR_REMITENTE": TRA_NUM_GR_REMITENTE,
                "TRA_NUM_GR_TRANSPORTE": TRA_NUM_GR_TRANSPORTE,
                "TRA_PLACA": TRA_PLACA,
                "TRA_BREVETE": TRA_BREVETE,
                "TRA_DIRECCION_INICIO": TRA_DIRECCION_INICIO,
                "TRA_DIRECCION_LLEGADA": TRA_DIRECCION_LLEGADA,
                "TRA_TIPO_CARGA": TRA_TIPO_CARGA,
                "TRA_NUM_CONTENEDOR": TRA_NUM_CONTENEDOR,
                "TRA_PESO": TRA_PESO,
                "TRA_FECHA_SERVICIO": TRA_FECHA_SERVICIO,
                "TRA_TIPO_BULTO": TRA_TIPO_BULTO,
                "TRA_NUM_BULTO": TRA_NUM_BULTO,
                "CUAD_SERVICIO": CUAD_SERVICIO,
                "CUAD_DETALLE": CUAD_DETALLE,
                "CUAD_LUGAR": CUAD_LUGAR,
                "CUAD_NUM_PERSONAS": CUAD_NUM_PERSONAS,
                "RESG_PROVEEDOR": RESG_PROVEEDOR,
                "RESG_RUTA": RESG_RUTA,
                "AGE_ADU_ADUANA": AGE_ADU_ADUANA,
                "AGE_ADU_MANIFIESTO": AGE_ADU_MANIFIESTO,
                "AGE_ADU_REGIMEN": AGE_ADU_REGIMEN,
                "AGE_ADU_DAM": AGE_ADU_DAM,
                "AGE_ADU_CANAL": AGE_ADU_CANAL,
                "AGE_ADU_EMPRESA": AGE_ADU_EMPRESA,
                "AGE_ADU_FEC_ARRIBO": AGE_ADU_FEC_ARRIBO,
                "AGE_ADU_FEC_RETIRO": AGE_ADU_FEC_RETIRO,
                "AGE_ADU_ALMACEN": AGE_ADU_ALMACEN,
                "AGE_ADU_VALORFOB": AGE_ADU_VALORFOB,
                "AGE_ADU_VALORCIF": AGE_ADU_VALORCIF,
                "AGE_CAR_ADUANA": AGE_CAR_ADUANA,
                "AGE_CAR_MANIFIESTO": AGE_CAR_MANIFIESTO,
                "AGE_CAR_PUERTO_ORIGEN": AGE_CAR_PUERTO_ORIGEN,
                "AGE_CAR_PAIS": AGE_CAR_PAIS,
                "AGE_CAR_EMP_TRANSP": AGE_CAR_EMP_TRANSP,
                "AGE_CAR_EMPRESA": AGE_CAR_EMPRESA,
                "AGE_CAR_FEC_ARRIBO": AGE_CAR_FEC_ARRIBO,
                "AGE_CAR_FEC_RETIRO": AGE_CAR_FEC_RETIRO,
                "AGE_CAR_PESO": AGE_CAR_PESO,
                "AGE_CAR_VOLUMEN": AGE_CAR_VOLUMEN,
                "AGE_CAR_NUM_BULTO": AGE_CAR_NUM_BULTO,
                "AGE_CAR_ALMACEN": AGE_CAR_ALMACEN,
                "OTRO_DETALLE": OTRO_DETALLE,
                "OTRO_OBSERVACION": OTRO_OBSERVACION,
                "USUARIO_MODIFICACION": USUARIO_MODIFICACION,
                "ESTADO": ESTADO
            };

            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Actualizar',
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
                    BUSCAR();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });

        }






    });


    function validar_input_vacios() {
        /*Eliminar las clases de error*/

        $("#txtfecha_tipo_cambio").removeClass('error_campo_vacio');
        $("#txtcompra").removeClass('error_campo_vacio');
        $("#txtventa").removeClass('error_campo_vacio');


        var validar = 0;

        var FECHA = $("#txtfecha_tipo_cambio").val();
        var COMPRA = $("#txtcompra").val();
        var VENTA = $("#txtventa").val();






        if (FECHA == '') {
            validar = 1;

            alertify.error('El Campo <b> Fecha </b> no debe estar vacio.!');
            $("#txtfecha_tipo_cambio").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtfecha_tipo_cambio").removeClass('error_campo_vacio'); }

        if (COMPRA == '') {
            validar = 1;

            alertify.error('El Campo <b> Tipo Cambio Compra </b> no debe estar vacio.!');
            $("#txtcompra").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtcompra").removeClass('error_campo_vacio'); }

        if (VENTA == '') {
            validar = 1;

            alertify.error('El Campo <b> Tipo Cambio Venta  </b> no debe estar vacio.!');
            $("#txtventa").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtventa").removeClass('error_campo_vacio'); }


        return validar;
    }

    $(document).on('click', '.seleccionar_cliente', function (e) {


       

        var ajax_data = {
            "ID": $(this).parents("tr").find("td").eq(0).html(),
        };


        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Clientes.asmx/Obtener_Clientes',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (respuesta) {
                var datos = (typeof respuesta.d) == 'string' ?
                    eval('(' + respuesta.d + ')') :
                    respuesta.d;

                for (var i = 0; i < datos.length; i++) {

                    $("#txt_id_cliente").val(datos[i].ID);
                    $("#ddltipo_documento_buscar_cliente").val(datos[i].TIPO_DOC);
                    $("#txtnrodoc_buscar_cliente").val(datos[i].NUM_DOC);
                    $("#txtrazon_social_buscar_cliente").val(datos[i].RAZON_SOCIAL);

                }
                var table = $('#Tabla_Clientes_Buscar').DataTable();
                table.clear().draw();
                $('#contiene_tabla').hide();
               
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });



    });

    $("#btncerrar").click(function (e) {

        window.location.href = "Principal.aspx";

    });

    $(document).on('click', '.eliminar', function (e) {
        var ID, NRO_ORDEN_SERVICIO;
        ID = $(this).parents("tr").find("td").eq(0).html();
        NRO_ORDEN_SERVICIO = $(this).parents("tr").find("td").eq(1).html();




        Swal.fire({
            title: 'Eliminar Registro?',
            text: "¿Estás seguro de eliminar la Orden de Servicio  :  " + NRO_ORDEN_SERVICIO + " ?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#1ab394',
            cancelButtonColor: '#6c757d',
            confirmButtonText: 'Si, Eliminar !'
        }).then((result) => {
            if (result.value) {


                var ajax_data = {
                    "ID": ID

                };

                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Eliminar',
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
                        $('#Tabla_Orden_Servicio').dataTable().fnClearTable();
                        BUSCAR();
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



});