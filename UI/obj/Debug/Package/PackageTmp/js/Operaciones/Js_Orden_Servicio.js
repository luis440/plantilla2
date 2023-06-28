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
                        "order": [[1, "desc"]],
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5,6,7] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                       
                        datos[i].NUM_ORDEN_SERVICIO,
                        datos[i].FECHA_CREACION,
                        datos[i].TIPO_SERVICIO,
                        datos[i].RAZON_SOCIAL,
                        datos[i].ESTADO,
                        "<img src='../img/editar_2.png' class='editar' style='width:20px;height:20px' />",
                        "<img src='../img/ver_doc.png' class='ver' style='width:20px;height:20px' />",
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
    $("#cerrar_panel_transporte1").click(function (e) {

        $("#panel_transporte1").hide("slow");
        $("#flag_transporte1").val('');
    });
    $("#cerrar_panel_transporte2").click(function (e) {

        $("#panel_transporte2").hide("slow");
        $("#flag_transporte2").val('');
    });
    $("#cerrar_panel_transporte3").click(function (e) {

        $("#panel_transporte3").hide("slow");
        $("#flag_transporte3").val('');
    });
    $("#cerrar_panel_transporte4").click(function (e) {

        $("#panel_transporte4").hide("slow");
        $("#flag_transporte4").val('');
    });
    $("#cerrar_panel_transporte5").click(function (e) {

        $("#panel_transporte5").hide("slow");
        $("#flag_transporte5").val('');
    });
    $("#cerrar_panel_transporte6").click(function (e) {

        $("#panel_transporte6").hide("slow");
        $("#flag_transporte6").val('');
    });
    $("#cerrar_panel_transporte7").click(function (e) {

        $("#panel_transporte7").hide("slow");
        $("#flag_transporte7").val('');
    });
    $("#cerrar_panel_transporte8").click(function (e) {

        $("#panel_transporte8").hide("slow");
        $("#flag_transporte8").val('');
    });
    $("#cerrar_panel_transporte9").click(function (e) {

        $("#panel_transporte9").hide("slow");
        $("#flag_transporte9").val('');
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
        if (TIPO_SERVICIO == 'TRANSPORTE1') {
            $("#panel_transporte1").show();
            $("#flag_transporte1").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE2') {
            $("#panel_transporte2").show();
            $("#flag_transporte2").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE3') {
            $("#panel_transporte3").show();
            $("#flag_transporte3").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE4') {
            $("#panel_transporte4").show();
            $("#flag_transporte4").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE5') {
            $("#panel_transporte5").show();
            $("#flag_transporte5").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE6') {
            $("#panel_transporte6").show();
            $("#flag_transporte6").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE7') {
            $("#panel_transporte7").show();
            $("#flag_transporte7").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE8') {
            $("#panel_transporte8").show();
            $("#flag_transporte8").val('1');
        }
        if (TIPO_SERVICIO == 'TRANSPORTE9') {
            $("#panel_transporte9").show();
            $("#flag_transporte9").val('1');
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
        $("#panel_transporte").hide();
        $("#panel_transporte1").hide();
        $("#panel_transporte2").hide();
        $("#panel_transporte3").hide();
        $("#panel_transporte4").hide();
        $("#panel_transporte5").hide();
        $("#panel_transporte6").hide();
        $("#panel_transporte7").hide();
        $("#panel_transporte8").hide();
        $("#panel_transporte9").hide();
        $("#panel_cuadrilla").hide();
        $("#panel_aduana").hide();
        $("#panel_carga").hide();
        $("#panel_otros").hide();
        $("#panel_resguardo").hide();
        limpiar();

        $("#div_estado_buscar").hide();
        $("#btnGuardar").show();
        $("#btnActualizar").hide();

        $('#modal_nuevo').modal();

        
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
                    
                    $("#flag_transporte1").val(datos[i].FLAG_TRANSPORTE1);
                    $("#flag_transporte2").val(datos[i].FLAG_TRANSPORTE2);
                    $("#flag_transporte3").val(datos[i].FLAG_TRANSPORTE3);
                    $("#flag_transporte4").val(datos[i].FLAG_TRANSPORTE4);
                    $("#flag_transporte5").val(datos[i].FLAG_TRANSPORTE5);
                    $("#flag_transporte6").val(datos[i].FLAG_TRANSPORTE6);
                    $("#flag_transporte7").val(datos[i].FLAG_TRANSPORTE7);
                    $("#flag_transporte8").val(datos[i].FLAG_TRANSPORTE8);
                    $("#flag_transporte9").val(datos[i].FLAG_TRANSPORTE9);

                    $("#txtnro_grr_transporte1").val(datos[i].TRA_NUM_GR_REMITENTE1);
                    $("#txtnro_grt_transporte1").val(datos[i].TRA_NUM_GR_TRANSPORTE1);
                    $("#txt_placa_transporte1").val(datos[i].TRA_PLACA1);
                    $("#txt_brevete_transporte1").val(datos[i].TRA_BREVETE1);
                    $("#txt_direccion_inicio_transporte1").val(datos[i].TRA_DIRECCION_INICIO1);
                    $("#txt_direccion_llegada_transporte1").val(datos[i].TRA_DIRECCION_LLEGADA1);
                    $("#ddl_tipo_carga_transporte1").val(datos[i].TRA_TIPO_CARGA1);
                    $("#txt_nro_contenedor_transporte1").val(datos[i].TRA_NUM_CONTENEDOR1);
                    $("#txt_nro_peso_transporte1").val(datos[i].TRA_PESO1);
                    $("#txt_fecha_servicio_transporte1").val(datos[i].TRA_FECHA_SERVICIO1);
                    $("#ddl_tipo_bulto_transporte1").val(datos[i].TRA_TIPO_BULTO1);
                    $("#txt_nro_bulto_transporte1").val(datos[i].TRA_NUM_BULTO1);

                    $("#txtnro_grr_transporte2").val(datos[i].TRA_NUM_GR_REMITENTE2);
                    $("#txtnro_grt_transporte2").val(datos[i].TRA_NUM_GR_TRANSPORTE2);
                    $("#txt_placa_transporte2").val(datos[i].TRA_PLACA2);
                    $("#txt_brevete_transporte2").val(datos[i].TRA_BREVETE2);
                    $("#txt_direccion_inicio_transporte2").val(datos[i].TRA_DIRECCION_INICIO2);
                    $("#txt_direccion_llegada_transporte2").val(datos[i].TRA_DIRECCION_LLEGADA2);
                    $("#ddl_tipo_carga_transporte2").val(datos[i].TRA_TIPO_CARGA2);
                    $("#txt_nro_contenedor_transporte2").val(datos[i].TRA_NUM_CONTENEDOR2);
                    $("#txt_nro_peso_transporte2").val(datos[i].TRA_PESO2);
                    $("#txt_fecha_servicio_transporte2").val(datos[i].TRA_FECHA_SERVICIO2);
                    $("#ddl_tipo_bulto_transporte2").val(datos[i].TRA_TIPO_BULTO2);
                    $("#txt_nro_bulto_transporte2").val(datos[i].TRA_NUM_BULTO2);

                    $("#txtnro_grr_transporte3").val(datos[i].TRA_NUM_GR_REMITENTE3);
                    $("#txtnro_grt_transporte3").val(datos[i].TRA_NUM_GR_TRANSPORTE3);
                    $("#txt_placa_transporte3").val(datos[i].TRA_PLACA3);
                    $("#txt_brevete_transporte3").val(datos[i].TRA_BREVETE3);
                    $("#txt_direccion_inicio_transporte3").val(datos[i].TRA_DIRECCION_INICIO3);
                    $("#txt_direccion_llegada_transporte3").val(datos[i].TRA_DIRECCION_LLEGADA3);
                    $("#ddl_tipo_carga_transporte3").val(datos[i].TRA_TIPO_CARGA3);
                    $("#txt_nro_contenedor_transporte3").val(datos[i].TRA_NUM_CONTENEDOR3);
                    $("#txt_nro_peso_transporte3").val(datos[i].TRA_PESO3);
                    $("#txt_fecha_servicio_transporte3").val(datos[i].TRA_FECHA_SERVICIO3);
                    $("#ddl_tipo_bulto_transporte3").val(datos[i].TRA_TIPO_BULTO3);
                    $("#txt_nro_bulto_transporte3").val(datos[i].TRA_NUM_BULTO3);

                    $("#txtnro_grr_transporte4").val(datos[i].TRA_NUM_GR_REMITENTE4);
                    $("#txtnro_grt_transporte4").val(datos[i].TRA_NUM_GR_TRANSPORTE4);
                    $("#txt_placa_transporte4").val(datos[i].TRA_PLACA4);
                    $("#txt_brevete_transporte4").val(datos[i].TRA_BREVETE4);
                    $("#txt_direccion_inicio_transporte4").val(datos[i].TRA_DIRECCION_INICIO4);
                    $("#txt_direccion_llegada_transporte4").val(datos[i].TRA_DIRECCION_LLEGADA4);
                    $("#ddl_tipo_carga_transporte4").val(datos[i].TRA_TIPO_CARGA4);
                    $("#txt_nro_contenedor_transporte4").val(datos[i].TRA_NUM_CONTENEDOR4);
                    $("#txt_nro_peso_transporte4").val(datos[i].TRA_PESO4);
                    $("#txt_fecha_servicio_transporte4").val(datos[i].TRA_FECHA_SERVICIO4);
                    $("#ddl_tipo_bulto_transporte4").val(datos[i].TRA_TIPO_BULTO4);
                    $("#txt_nro_bulto_transporte4").val(datos[i].TRA_NUM_BULTO4);

                    $("#txtnro_grr_transporte5").val(datos[i].TRA_NUM_GR_REMITENTE5);
                    $("#txtnro_grt_transporte5").val(datos[i].TRA_NUM_GR_TRANSPORTE5);
                    $("#txt_placa_transporte5").val(datos[i].TRA_PLACA5);
                    $("#txt_brevete_transporte5").val(datos[i].TRA_BREVETE5);
                    $("#txt_direccion_inicio_transporte5").val(datos[i].TRA_DIRECCION_INICIO5);
                    $("#txt_direccion_llegada_transporte5").val(datos[i].TRA_DIRECCION_LLEGADA5);
                    $("#ddl_tipo_carga_transporte5").val(datos[i].TRA_TIPO_CARGA5);
                    $("#txt_nro_contenedor_transporte5").val(datos[i].TRA_NUM_CONTENEDOR5);
                    $("#txt_nro_peso_transporte5").val(datos[i].TRA_PESO5);
                    $("#txt_fecha_servicio_transporte5").val(datos[i].TRA_FECHA_SERVICIO5);
                    $("#ddl_tipo_bulto_transporte5").val(datos[i].TRA_TIPO_BULTO5);
                    $("#txt_nro_bulto_transporte5").val(datos[i].TRA_NUM_BULTO5);

                    $("#txtnro_grr_transporte6").val(datos[i].TRA_NUM_GR_REMITENTE6);
                    $("#txtnro_grt_transporte6").val(datos[i].TRA_NUM_GR_TRANSPORTE6);
                    $("#txt_placa_transporte6").val(datos[i].TRA_PLACA6);
                    $("#txt_brevete_transporte6").val(datos[i].TRA_BREVETE6);
                    $("#txt_direccion_inicio_transporte6").val(datos[i].TRA_DIRECCION_INICIO6);
                    $("#txt_direccion_llegada_transporte6").val(datos[i].TRA_DIRECCION_LLEGADA6);
                    $("#ddl_tipo_carga_transporte6").val(datos[i].TRA_TIPO_CARGA6);
                    $("#txt_nro_contenedor_transporte6").val(datos[i].TRA_NUM_CONTENEDOR6);
                    $("#txt_nro_peso_transporte6").val(datos[i].TRA_PESO6);
                    $("#txt_fecha_servicio_transporte6").val(datos[i].TRA_FECHA_SERVICIO6);
                    $("#ddl_tipo_bulto_transporte6").val(datos[i].TRA_TIPO_BULTO6);
                    $("#txt_nro_bulto_transporte6").val(datos[i].TRA_NUM_BULTO6);

                    $("#txtnro_grr_transporte7").val(datos[i].TRA_NUM_GR_REMITENTE7);
                    $("#txtnro_grt_transporte7").val(datos[i].TRA_NUM_GR_TRANSPORTE7);
                    $("#txt_placa_transporte7").val(datos[i].TRA_PLACA7);
                    $("#txt_brevete_transporte7").val(datos[i].TRA_BREVETE7);
                    $("#txt_direccion_inicio_transporte7").val(datos[i].TRA_DIRECCION_INICIO7);
                    $("#txt_direccion_llegada_transporte7").val(datos[i].TRA_DIRECCION_LLEGADA7);
                    $("#ddl_tipo_carga_transporte7").val(datos[i].TRA_TIPO_CARGA7);
                    $("#txt_nro_contenedor_transporte7").val(datos[i].TRA_NUM_CONTENEDOR7);
                    $("#txt_nro_peso_transporte7").val(datos[i].TRA_PESO7);
                    $("#txt_fecha_servicio_transporte7").val(datos[i].TRA_FECHA_SERVICIO7);
                    $("#ddl_tipo_bulto_transporte7").val(datos[i].TRA_TIPO_BULTO7);
                    $("#txt_nro_bulto_transporte7").val(datos[i].TRA_NUM_BULTO7);

                    $("#txtnro_grr_transporte8").val(datos[i].TRA_NUM_GR_REMITENTE8);
                    $("#txtnro_grt_transporte8").val(datos[i].TRA_NUM_GR_TRANSPORTE8);
                    $("#txt_placa_transporte8").val(datos[i].TRA_PLACA8);
                    $("#txt_brevete_transporte8").val(datos[i].TRA_BREVETE8);
                    $("#txt_direccion_inicio_transporte8").val(datos[i].TRA_DIRECCION_INICIO8);
                    $("#txt_direccion_llegada_transporte8").val(datos[i].TRA_DIRECCION_LLEGADA8);
                    $("#ddl_tipo_carga_transporte8").val(datos[i].TRA_TIPO_CARGA8);
                    $("#txt_nro_contenedor_transporte8").val(datos[i].TRA_NUM_CONTENEDOR8);
                    $("#txt_nro_peso_transporte8").val(datos[i].TRA_PESO8);
                    $("#txt_fecha_servicio_transporte8").val(datos[i].TRA_FECHA_SERVICIO8);
                    $("#ddl_tipo_bulto_transporte8").val(datos[i].TRA_TIPO_BULTO8);
                    $("#txt_nro_bulto_transporte8").val(datos[i].TRA_NUM_BULTO8);

                    $("#txtnro_grr_transporte9").val(datos[i].TRA_NUM_GR_REMITENTE9);
                    $("#txtnro_grt_transporte9").val(datos[i].TRA_NUM_GR_TRANSPORTE9);
                    $("#txt_placa_transporte9").val(datos[i].TRA_PLACA9);
                    $("#txt_brevete_transporte9").val(datos[i].TRA_BREVETE9);
                    $("#txt_direccion_inicio_transporte9").val(datos[i].TRA_DIRECCION_INICIO9);
                    $("#txt_direccion_llegada_transporte9").val(datos[i].TRA_DIRECCION_LLEGADA9);
                    $("#ddl_tipo_carga_transporte9").val(datos[i].TRA_TIPO_CARGA9);
                    $("#txt_nro_contenedor_transporte9").val(datos[i].TRA_NUM_CONTENEDOR9);
                    $("#txt_nro_peso_transporte9").val(datos[i].TRA_PESO9);
                    $("#txt_fecha_servicio_transporte9").val(datos[i].TRA_FECHA_SERVICIO9);
                    $("#ddl_tipo_bulto_transporte9").val(datos[i].TRA_TIPO_BULTO9);
                    $("#txt_nro_bulto_transporte9").val(datos[i].TRA_NUM_BULTO9);
                    
                }

                if ($("#flag_transporte").val() == 1) { $("#panel_transporte").show(); } else { $("#panel_transporte").hide(); }
                if ($("#flag_transporte1").val() == 1) { $("#panel_transporte1").show(); } else { $("#panel_transporte1").hide(); }
                if ($("#flag_transporte2").val() == 1) { $("#panel_transporte2").show(); } else { $("#panel_transporte2").hide(); }
                if ($("#flag_transporte3").val() == 1) { $("#panel_transporte3").show(); } else { $("#panel_transporte3").hide(); }
                if ($("#flag_transporte4").val() == 1) { $("#panel_transporte4").show(); } else { $("#panel_transporte4").hide(); }
                if ($("#flag_transporte5").val() == 1) { $("#panel_transporte5").show(); } else { $("#panel_transporte5").hide(); }
                if ($("#flag_transporte6").val() == 1) { $("#panel_transporte6").show(); } else { $("#panel_transporte6").hide(); }
                if ($("#flag_transporte7").val() == 1) { $("#panel_transporte7").show(); } else { $("#panel_transporte7").hide(); }
                if ($("#flag_transporte8").val() == 1) { $("#panel_transporte8").show(); } else { $("#panel_transporte8").hide(); }
                if ($("#flag_transporte9").val() == 1) { $("#panel_transporte9").show(); } else { $("#panel_transporte9").hide(); }
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
        var FLAG_TRANSPORTE1 = $("#flag_transporte1").val();
        var FLAG_TRANSPORTE2 = $("#flag_transporte2").val();
        var FLAG_TRANSPORTE3 = $("#flag_transporte3").val();
        var FLAG_TRANSPORTE4 = $("#flag_transporte4").val();
        var FLAG_TRANSPORTE5 = $("#flag_transporte5").val();
        var FLAG_TRANSPORTE6 = $("#flag_transporte6").val();
        var FLAG_TRANSPORTE7 = $("#flag_transporte7").val();
        var FLAG_TRANSPORTE8 = $("#flag_transporte8").val();
        var FLAG_TRANSPORTE9 = $("#flag_transporte9").val();
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

        var TRA_NUM_GR_REMITENTE1 = $("#txtnro_grr_transporte1").val();
        var TRA_NUM_GR_TRANSPORTE1 = $("#txtnro_grt_transporte1").val();
        var TRA_PLACA1 = $("#txt_placa_transporte1").val();
        var TRA_BREVETE1 = $("#txt_brevete_transporte1").val();
        var TRA_DIRECCION_INICIO1 = $("#txt_direccion_inicio_transporte1").val();
        var TRA_DIRECCION_LLEGADA1 = $("#txt_direccion_llegada_transporte1").val();
        var TRA_TIPO_CARGA1 = $("#ddl_tipo_carga_transporte1").val();
        var TRA_NUM_CONTENEDOR1 = $("#txt_nro_contenedor_transporte1").val();
        var TRA_PESO1 = $("#txt_nro_peso_transporte1").val();
        var TRA_FECHA_SERVICIO1 = $("#txt_fecha_servicio_transporte1").val();
        var TRA_TIPO_BULTO1 = $("#ddl_tipo_bulto_transporte1").val();
        var TRA_NUM_BULTO1 = $("#txt_nro_bulto_transporte1").val();

        var TRA_NUM_GR_REMITENTE2 = $("#txtnro_grr_transporte2").val();
        var TRA_NUM_GR_TRANSPORTE2 = $("#txtnro_grt_transporte2").val();
        var TRA_PLACA2 = $("#txt_placa_transporte2").val();
        var TRA_BREVETE2 = $("#txt_brevete_transporte2").val();
        var TRA_DIRECCION_INICIO2 = $("#txt_direccion_inicio_transporte2").val();
        var TRA_DIRECCION_LLEGADA2 = $("#txt_direccion_llegada_transporte2").val();
        var TRA_TIPO_CARGA2 = $("#ddl_tipo_carga_transporte2").val();
        var TRA_NUM_CONTENEDOR2 = $("#txt_nro_contenedor_transporte2").val();
        var TRA_PESO2 = $("#txt_nro_peso_transporte2").val();
        var TRA_FECHA_SERVICIO2 = $("#txt_fecha_servicio_transporte2").val();
        var TRA_TIPO_BULTO2 = $("#ddl_tipo_bulto_transporte2").val();
        var TRA_NUM_BULTO2 = $("#txt_nro_bulto_transporte2").val();

        var TRA_NUM_GR_REMITENTE3 = $("#txtnro_grr_transporte3").val();
        var TRA_NUM_GR_TRANSPORTE3 = $("#txtnro_grt_transporte3").val();
        var TRA_PLACA3 = $("#txt_placa_transporte3").val();
        var TRA_BREVETE3 = $("#txt_brevete_transporte3").val();
        var TRA_DIRECCION_INICIO3 = $("#txt_direccion_inicio_transporte3").val();
        var TRA_DIRECCION_LLEGADA3 = $("#txt_direccion_llegada_transporte3").val();
        var TRA_TIPO_CARGA3 = $("#ddl_tipo_carga_transporte3").val();
        var TRA_NUM_CONTENEDOR3 = $("#txt_nro_contenedor_transporte3").val();
        var TRA_PESO3 = $("#txt_nro_peso_transporte3").val();
        var TRA_FECHA_SERVICIO3 = $("#txt_fecha_servicio_transporte3").val();
        var TRA_TIPO_BULTO3 = $("#ddl_tipo_bulto_transporte3").val();
        var TRA_NUM_BULTO3 = $("#txt_nro_bulto_transporte3").val();

        var TRA_NUM_GR_REMITENTE4 = $("#txtnro_grr_transporte4").val();
        var TRA_NUM_GR_TRANSPORTE4 = $("#txtnro_grt_transporte4").val();
        var TRA_PLACA4 = $("#txt_placa_transporte4").val();
        var TRA_BREVETE4 = $("#txt_brevete_transporte4").val();
        var TRA_DIRECCION_INICIO4 = $("#txt_direccion_inicio_transporte4").val();
        var TRA_DIRECCION_LLEGADA4 = $("#txt_direccion_llegada_transporte4").val();
        var TRA_TIPO_CARGA4 = $("#ddl_tipo_carga_transporte4").val();
        var TRA_NUM_CONTENEDOR4 = $("#txt_nro_contenedor_transporte4").val();
        var TRA_PESO4 = $("#txt_nro_peso_transporte4").val();
        var TRA_FECHA_SERVICIO4 = $("#txt_fecha_servicio_transporte4").val();
        var TRA_TIPO_BULTO4 = $("#ddl_tipo_bulto_transporte4").val();
        var TRA_NUM_BULTO4 = $("#txt_nro_bulto_transporte4").val();

        var TRA_NUM_GR_REMITENTE5 = $("#txtnro_grr_transporte5").val();
        var TRA_NUM_GR_TRANSPORTE5 = $("#txtnro_grt_transporte5").val();
        var TRA_PLACA5 = $("#txt_placa_transporte5").val();
        var TRA_BREVETE5 = $("#txt_brevete_transporte5").val();
        var TRA_DIRECCION_INICIO5 = $("#txt_direccion_inicio_transporte5").val();
        var TRA_DIRECCION_LLEGADA5 = $("#txt_direccion_llegada_transporte5").val();
        var TRA_TIPO_CARGA5 = $("#ddl_tipo_carga_transporte5").val();
        var TRA_NUM_CONTENEDOR5 = $("#txt_nro_contenedor_transporte5").val();
        var TRA_PESO5 = $("#txt_nro_peso_transporte5").val();
        var TRA_FECHA_SERVICIO5 = $("#txt_fecha_servicio_transporte5").val();
        var TRA_TIPO_BULTO5 = $("#ddl_tipo_bulto_transporte5").val();
        var TRA_NUM_BULTO5 = $("#txt_nro_bulto_transporte5").val();

        var TRA_NUM_GR_REMITENTE6 = $("#txtnro_grr_transporte6").val();
        var TRA_NUM_GR_TRANSPORTE6 = $("#txtnro_grt_transporte6").val();
        var TRA_PLACA6 = $("#txt_placa_transporte6").val();
        var TRA_BREVETE6 = $("#txt_brevete_transporte6").val();
        var TRA_DIRECCION_INICIO6 = $("#txt_direccion_inicio_transporte6").val();
        var TRA_DIRECCION_LLEGADA6 = $("#txt_direccion_llegada_transporte6").val();
        var TRA_TIPO_CARGA6 = $("#ddl_tipo_carga_transporte6").val();
        var TRA_NUM_CONTENEDOR6 = $("#txt_nro_contenedor_transporte6").val();
        var TRA_PESO6 = $("#txt_nro_peso_transporte6").val();
        var TRA_FECHA_SERVICIO6 = $("#txt_fecha_servicio_transporte6").val();
        var TRA_TIPO_BULTO6 = $("#ddl_tipo_bulto_transporte6").val();
        var TRA_NUM_BULTO6 = $("#txt_nro_bulto_transporte6").val();

        var TRA_NUM_GR_REMITENTE7 = $("#txtnro_grr_transporte7").val();
        var TRA_NUM_GR_TRANSPORTE7 = $("#txtnro_grt_transporte7").val();
        var TRA_PLACA7 = $("#txt_placa_transporte7").val();
        var TRA_BREVETE7 = $("#txt_brevete_transporte7").val();
        var TRA_DIRECCION_INICIO7 = $("#txt_direccion_inicio_transporte7").val();
        var TRA_DIRECCION_LLEGADA7 = $("#txt_direccion_llegada_transporte7").val();
        var TRA_TIPO_CARGA7 = $("#ddl_tipo_carga_transporte7").val();
        var TRA_NUM_CONTENEDOR7 = $("#txt_nro_contenedor_transporte7").val();
        var TRA_PESO7 = $("#txt_nro_peso_transporte7").val();
        var TRA_FECHA_SERVICIO7 = $("#txt_fecha_servicio_transporte7").val();
        var TRA_TIPO_BULTO7 = $("#ddl_tipo_bulto_transporte7").val();
        var TRA_NUM_BULTO7 = $("#txt_nro_bulto_transporte7").val();

        var TRA_NUM_GR_REMITENTE8 = $("#txtnro_grr_transporte8").val();
        var TRA_NUM_GR_TRANSPORTE8 = $("#txtnro_grt_transporte8").val();
        var TRA_PLACA8 = $("#txt_placa_transporte8").val();
        var TRA_BREVETE8 = $("#txt_brevete_transporte8").val();
        var TRA_DIRECCION_INICIO8 = $("#txt_direccion_inicio_transporte8").val();
        var TRA_DIRECCION_LLEGADA8 = $("#txt_direccion_llegada_transporte8").val();
        var TRA_TIPO_CARGA8 = $("#ddl_tipo_carga_transporte8").val();
        var TRA_NUM_CONTENEDOR8 = $("#txt_nro_contenedor_transporte8").val();
        var TRA_PESO8 = $("#txt_nro_peso_transporte8").val();
        var TRA_FECHA_SERVICIO8 = $("#txt_fecha_servicio_transporte8").val();
        var TRA_TIPO_BULTO8 = $("#ddl_tipo_bulto_transporte8").val();
        var TRA_NUM_BULTO8 = $("#txt_nro_bulto_transporte8").val();

        var TRA_NUM_GR_REMITENTE9 = $("#txtnro_grr_transporte9").val();
        var TRA_NUM_GR_TRANSPORTE9 = $("#txtnro_grt_transporte9").val();
        var TRA_PLACA9 = $("#txt_placa_transporte9").val();
        var TRA_BREVETE9 = $("#txt_brevete_transporte9").val();
        var TRA_DIRECCION_INICIO9 = $("#txt_direccion_inicio_transporte9").val();
        var TRA_DIRECCION_LLEGADA9 = $("#txt_direccion_llegada_transporte9").val();
        var TRA_TIPO_CARGA9 = $("#ddl_tipo_carga_transporte9").val();
        var TRA_NUM_CONTENEDOR9 = $("#txt_nro_contenedor_transporte9").val();
        var TRA_PESO9 = $("#txt_nro_peso_transporte9").val();
        var TRA_FECHA_SERVICIO9 = $("#txt_fecha_servicio_transporte9").val();
        var TRA_TIPO_BULTO9 = $("#ddl_tipo_bulto_transporte9").val();
        var TRA_NUM_BULTO9 = $("#txt_nro_bulto_transporte9").val();

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
                "FLAG_TRANSPORTE1": FLAG_TRANSPORTE1,
                "FLAG_TRANSPORTE2": FLAG_TRANSPORTE2,
                "FLAG_TRANSPORTE3": FLAG_TRANSPORTE3,
                "FLAG_TRANSPORTE4": FLAG_TRANSPORTE4,
                "FLAG_TRANSPORTE5": FLAG_TRANSPORTE5,
                "FLAG_TRANSPORTE6": FLAG_TRANSPORTE6,
                "FLAG_TRANSPORTE7": FLAG_TRANSPORTE7,
                "FLAG_TRANSPORTE8": FLAG_TRANSPORTE8,
                "FLAG_TRANSPORTE9": FLAG_TRANSPORTE9,
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

                "TRA_NUM_GR_REMITENTE1": TRA_NUM_GR_REMITENTE1,
                "TRA_NUM_GR_TRANSPORTE1": TRA_NUM_GR_TRANSPORTE1,
                "TRA_PLACA1": TRA_PLACA1,
                "TRA_BREVETE1": TRA_BREVETE1,
                "TRA_DIRECCION_INICIO1": TRA_DIRECCION_INICIO1,
                "TRA_DIRECCION_LLEGADA1": TRA_DIRECCION_LLEGADA1,
                "TRA_TIPO_CARGA1": TRA_TIPO_CARGA1,
                "TRA_NUM_CONTENEDOR1": TRA_NUM_CONTENEDOR1,
                "TRA_PESO1": TRA_PESO1,
                "TRA_FECHA_SERVICIO1": TRA_FECHA_SERVICIO1,
                "TRA_TIPO_BULTO1": TRA_TIPO_BULTO1,
                "TRA_NUM_BULTO1": TRA_NUM_BULTO1,

                "TRA_NUM_GR_REMITENTE2": TRA_NUM_GR_REMITENTE2,
                "TRA_NUM_GR_TRANSPORTE2": TRA_NUM_GR_TRANSPORTE2,
                "TRA_PLACA2": TRA_PLACA2,
                "TRA_BREVETE2": TRA_BREVETE2,
                "TRA_DIRECCION_INICIO2": TRA_DIRECCION_INICIO2,
                "TRA_DIRECCION_LLEGADA2": TRA_DIRECCION_LLEGADA2,
                "TRA_TIPO_CARGA2": TRA_TIPO_CARGA2,
                "TRA_NUM_CONTENEDOR2": TRA_NUM_CONTENEDOR2,
                "TRA_PESO2": TRA_PESO2,
                "TRA_FECHA_SERVICIO2": TRA_FECHA_SERVICIO2,
                "TRA_TIPO_BULTO2": TRA_TIPO_BULTO2,
                "TRA_NUM_BULTO2": TRA_NUM_BULTO2,

                "TRA_NUM_GR_REMITENTE3": TRA_NUM_GR_REMITENTE3,
                "TRA_NUM_GR_TRANSPORTE3": TRA_NUM_GR_TRANSPORTE3,
                "TRA_PLACA3": TRA_PLACA3,
                "TRA_BREVETE3": TRA_BREVETE3,
                "TRA_DIRECCION_INICIO3": TRA_DIRECCION_INICIO3,
                "TRA_DIRECCION_LLEGADA3": TRA_DIRECCION_LLEGADA3,
                "TRA_TIPO_CARGA3": TRA_TIPO_CARGA3,
                "TRA_NUM_CONTENEDOR3": TRA_NUM_CONTENEDOR3,
                "TRA_PESO3": TRA_PESO3,
                "TRA_FECHA_SERVICIO3": TRA_FECHA_SERVICIO3,
                "TRA_TIPO_BULTO3": TRA_TIPO_BULTO3,
                "TRA_NUM_BULTO3": TRA_NUM_BULTO3,

                "TRA_NUM_GR_REMITENTE4": TRA_NUM_GR_REMITENTE4,
                "TRA_NUM_GR_TRANSPORTE4": TRA_NUM_GR_TRANSPORTE4,
                "TRA_PLACA4": TRA_PLACA4,
                "TRA_BREVETE4": TRA_BREVETE4,
                "TRA_DIRECCION_INICIO4": TRA_DIRECCION_INICIO4,
                "TRA_DIRECCION_LLEGADA4": TRA_DIRECCION_LLEGADA4,
                "TRA_TIPO_CARGA4": TRA_TIPO_CARGA4,
                "TRA_NUM_CONTENEDOR4": TRA_NUM_CONTENEDOR4,
                "TRA_PESO4": TRA_PESO4,
                "TRA_FECHA_SERVICIO4": TRA_FECHA_SERVICIO4,
                "TRA_TIPO_BULTO4": TRA_TIPO_BULTO4,
                "TRA_NUM_BULTO4": TRA_NUM_BULTO4,

                "TRA_NUM_GR_REMITENTE5": TRA_NUM_GR_REMITENTE5,
                "TRA_NUM_GR_TRANSPORTE5": TRA_NUM_GR_TRANSPORTE5,
                "TRA_PLACA5": TRA_PLACA5,
                "TRA_BREVETE5": TRA_BREVETE5,
                "TRA_DIRECCION_INICIO5": TRA_DIRECCION_INICIO5,
                "TRA_DIRECCION_LLEGADA5": TRA_DIRECCION_LLEGADA5,
                "TRA_TIPO_CARGA5": TRA_TIPO_CARGA5,
                "TRA_NUM_CONTENEDOR5": TRA_NUM_CONTENEDOR5,
                "TRA_PESO5": TRA_PESO5,
                "TRA_FECHA_SERVICIO5": TRA_FECHA_SERVICIO5,
                "TRA_TIPO_BULTO5": TRA_TIPO_BULTO5,
                "TRA_NUM_BULTO5": TRA_NUM_BULTO5,

                "TRA_NUM_GR_REMITENTE6": TRA_NUM_GR_REMITENTE6,
                "TRA_NUM_GR_TRANSPORTE6": TRA_NUM_GR_TRANSPORTE6,
                "TRA_PLACA6": TRA_PLACA6,
                "TRA_BREVETE6": TRA_BREVETE6,
                "TRA_DIRECCION_INICIO6": TRA_DIRECCION_INICIO6,
                "TRA_DIRECCION_LLEGADA6": TRA_DIRECCION_LLEGADA6,
                "TRA_TIPO_CARGA6": TRA_TIPO_CARGA6,
                "TRA_NUM_CONTENEDOR6": TRA_NUM_CONTENEDOR6,
                "TRA_PESO6": TRA_PESO6,
                "TRA_FECHA_SERVICIO6": TRA_FECHA_SERVICIO6,
                "TRA_TIPO_BULTO6": TRA_TIPO_BULTO6,
                "TRA_NUM_BULTO6": TRA_NUM_BULTO6,

                "TRA_NUM_GR_REMITENTE7": TRA_NUM_GR_REMITENTE7,
                "TRA_NUM_GR_TRANSPORTE7": TRA_NUM_GR_TRANSPORTE7,
                "TRA_PLACA7": TRA_PLACA7,
                "TRA_BREVETE7": TRA_BREVETE7,
                "TRA_DIRECCION_INICIO7": TRA_DIRECCION_INICIO7,
                "TRA_DIRECCION_LLEGADA7": TRA_DIRECCION_LLEGADA7,
                "TRA_TIPO_CARGA7": TRA_TIPO_CARGA7,
                "TRA_NUM_CONTENEDOR7": TRA_NUM_CONTENEDOR7,
                "TRA_PESO7": TRA_PESO7,
                "TRA_FECHA_SERVICIO7": TRA_FECHA_SERVICIO7,
                "TRA_TIPO_BULTO7": TRA_TIPO_BULTO7,
                "TRA_NUM_BULTO7": TRA_NUM_BULTO7,

                "TRA_NUM_GR_REMITENTE8": TRA_NUM_GR_REMITENTE8,
                "TRA_NUM_GR_TRANSPORTE8": TRA_NUM_GR_TRANSPORTE8,
                "TRA_PLACA8": TRA_PLACA8,
                "TRA_BREVETE8": TRA_BREVETE8,
                "TRA_DIRECCION_INICIO8": TRA_DIRECCION_INICIO8,
                "TRA_DIRECCION_LLEGADA8": TRA_DIRECCION_LLEGADA8,
                "TRA_TIPO_CARGA8": TRA_TIPO_CARGA8,
                "TRA_NUM_CONTENEDOR8": TRA_NUM_CONTENEDOR8,
                "TRA_PESO8": TRA_PESO8,
                "TRA_FECHA_SERVICIO8": TRA_FECHA_SERVICIO8,
                "TRA_TIPO_BULTO8": TRA_TIPO_BULTO8,
                "TRA_NUM_BULTO8": TRA_NUM_BULTO8,

                "TRA_NUM_GR_REMITENTE9": TRA_NUM_GR_REMITENTE9,
                "TRA_NUM_GR_TRANSPORTE9": TRA_NUM_GR_TRANSPORTE9,
                "TRA_PLACA9": TRA_PLACA9,
                "TRA_BREVETE9": TRA_BREVETE9,
                "TRA_DIRECCION_INICIO9": TRA_DIRECCION_INICIO9,
                "TRA_DIRECCION_LLEGADA9": TRA_DIRECCION_LLEGADA9,
                "TRA_TIPO_CARGA9": TRA_TIPO_CARGA9,
                "TRA_NUM_CONTENEDOR9": TRA_NUM_CONTENEDOR9,
                "TRA_PESO9": TRA_PESO9,
                "TRA_FECHA_SERVICIO9": TRA_FECHA_SERVICIO9,
                "TRA_TIPO_BULTO9": TRA_TIPO_BULTO9,
                "TRA_NUM_BULTO9": TRA_NUM_BULTO9,

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
                    BUSCAR();

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
            var FLAG_TRANSPORTE1 = $("#flag_transporte1").val();
            var FLAG_TRANSPORTE2 = $("#flag_transporte2").val();
            var FLAG_TRANSPORTE3 = $("#flag_transporte3").val();
            var FLAG_TRANSPORTE4 = $("#flag_transporte4").val();
            var FLAG_TRANSPORTE5 = $("#flag_transporte5").val();
            var FLAG_TRANSPORTE6 = $("#flag_transporte6").val();
            var FLAG_TRANSPORTE7 = $("#flag_transporte7").val();
            var FLAG_TRANSPORTE8 = $("#flag_transporte8").val();
            var FLAG_TRANSPORTE9 = $("#flag_transporte9").val();
            var TRA_NUM_GR_REMITENTE1 = $("#txtnro_grr_transporte1").val();
            var TRA_NUM_GR_TRANSPORTE1 = $("#txtnro_grt_transporte1").val();
            var TRA_PLACA1 = $("#txt_placa_transporte1").val();
            var TRA_BREVETE1 = $("#txt_brevete_transporte1").val();
            var TRA_DIRECCION_INICIO1 = $("#txt_direccion_inicio_transporte1").val();
            var TRA_DIRECCION_LLEGADA1 = $("#txt_direccion_llegada_transporte1").val();
            var TRA_TIPO_CARGA1 = $("#ddl_tipo_carga_transporte1").val();
            var TRA_NUM_CONTENEDOR1 = $("#txt_nro_contenedor_transporte1").val();
            var TRA_PESO1 = $("#txt_nro_peso_transporte1").val();
            var TRA_FECHA_SERVICIO1 = $("#txt_fecha_servicio_transporte1").val();
            var TRA_TIPO_BULTO1 = $("#ddl_tipo_bulto_transporte1").val();
            var TRA_NUM_BULTO1 = $("#txt_nro_bulto_transporte1").val();

            var TRA_NUM_GR_REMITENTE2 = $("#txtnro_grr_transporte2").val();
            var TRA_NUM_GR_TRANSPORTE2 = $("#txtnro_grt_transporte2").val();
            var TRA_PLACA2 = $("#txt_placa_transporte2").val();
            var TRA_BREVETE2 = $("#txt_brevete_transporte2").val();
            var TRA_DIRECCION_INICIO2 = $("#txt_direccion_inicio_transporte2").val();
            var TRA_DIRECCION_LLEGADA2 = $("#txt_direccion_llegada_transporte2").val();
            var TRA_TIPO_CARGA2 = $("#ddl_tipo_carga_transporte2").val();
            var TRA_NUM_CONTENEDOR2 = $("#txt_nro_contenedor_transporte2").val();
            var TRA_PESO2 = $("#txt_nro_peso_transporte2").val();
            var TRA_FECHA_SERVICIO2 = $("#txt_fecha_servicio_transporte2").val();
            var TRA_TIPO_BULTO2 = $("#ddl_tipo_bulto_transporte2").val();
            var TRA_NUM_BULTO2 = $("#txt_nro_bulto_transporte2").val();

            var TRA_NUM_GR_REMITENTE3 = $("#txtnro_grr_transporte3").val();
            var TRA_NUM_GR_TRANSPORTE3 = $("#txtnro_grt_transporte3").val();
            var TRA_PLACA3 = $("#txt_placa_transporte3").val();
            var TRA_BREVETE3 = $("#txt_brevete_transporte3").val();
            var TRA_DIRECCION_INICIO3 = $("#txt_direccion_inicio_transporte3").val();
            var TRA_DIRECCION_LLEGADA3 = $("#txt_direccion_llegada_transporte3").val();
            var TRA_TIPO_CARGA3 = $("#ddl_tipo_carga_transporte3").val();
            var TRA_NUM_CONTENEDOR3 = $("#txt_nro_contenedor_transporte3").val();
            var TRA_PESO3 = $("#txt_nro_peso_transporte3").val();
            var TRA_FECHA_SERVICIO3 = $("#txt_fecha_servicio_transporte3").val();
            var TRA_TIPO_BULTO3 = $("#ddl_tipo_bulto_transporte3").val();
            var TRA_NUM_BULTO3 = $("#txt_nro_bulto_transporte3").val();

            var TRA_NUM_GR_REMITENTE4 = $("#txtnro_grr_transporte4").val();
            var TRA_NUM_GR_TRANSPORTE4 = $("#txtnro_grt_transporte4").val();
            var TRA_PLACA4 = $("#txt_placa_transporte4").val();
            var TRA_BREVETE4 = $("#txt_brevete_transporte4").val();
            var TRA_DIRECCION_INICIO4 = $("#txt_direccion_inicio_transporte4").val();
            var TRA_DIRECCION_LLEGADA4 = $("#txt_direccion_llegada_transporte4").val();
            var TRA_TIPO_CARGA4 = $("#ddl_tipo_carga_transporte4").val();
            var TRA_NUM_CONTENEDOR4 = $("#txt_nro_contenedor_transporte4").val();
            var TRA_PESO4 = $("#txt_nro_peso_transporte4").val();
            var TRA_FECHA_SERVICIO4 = $("#txt_fecha_servicio_transporte4").val();
            var TRA_TIPO_BULTO4 = $("#ddl_tipo_bulto_transporte4").val();
            var TRA_NUM_BULTO4 = $("#txt_nro_bulto_transporte4").val();

            var TRA_NUM_GR_REMITENTE5 = $("#txtnro_grr_transporte5").val();
            var TRA_NUM_GR_TRANSPORTE5 = $("#txtnro_grt_transporte5").val();
            var TRA_PLACA5 = $("#txt_placa_transporte5").val();
            var TRA_BREVETE5 = $("#txt_brevete_transporte5").val();
            var TRA_DIRECCION_INICIO5 = $("#txt_direccion_inicio_transporte5").val();
            var TRA_DIRECCION_LLEGADA5 = $("#txt_direccion_llegada_transporte5").val();
            var TRA_TIPO_CARGA5 = $("#ddl_tipo_carga_transporte5").val();
            var TRA_NUM_CONTENEDOR5 = $("#txt_nro_contenedor_transporte5").val();
            var TRA_PESO5 = $("#txt_nro_peso_transporte5").val();
            var TRA_FECHA_SERVICIO5 = $("#txt_fecha_servicio_transporte5").val();
            var TRA_TIPO_BULTO5 = $("#ddl_tipo_bulto_transporte5").val();
            var TRA_NUM_BULTO5 = $("#txt_nro_bulto_transporte5").val();

            var TRA_NUM_GR_REMITENTE6 = $("#txtnro_grr_transporte6").val();
            var TRA_NUM_GR_TRANSPORTE6 = $("#txtnro_grt_transporte6").val();
            var TRA_PLACA6 = $("#txt_placa_transporte6").val();
            var TRA_BREVETE6 = $("#txt_brevete_transporte6").val();
            var TRA_DIRECCION_INICIO6 = $("#txt_direccion_inicio_transporte6").val();
            var TRA_DIRECCION_LLEGADA6 = $("#txt_direccion_llegada_transporte6").val();
            var TRA_TIPO_CARGA6 = $("#ddl_tipo_carga_transporte6").val();
            var TRA_NUM_CONTENEDOR6 = $("#txt_nro_contenedor_transporte6").val();
            var TRA_PESO6 = $("#txt_nro_peso_transporte6").val();
            var TRA_FECHA_SERVICIO6 = $("#txt_fecha_servicio_transporte6").val();
            var TRA_TIPO_BULTO6 = $("#ddl_tipo_bulto_transporte6").val();
            var TRA_NUM_BULTO6 = $("#txt_nro_bulto_transporte6").val();

            var TRA_NUM_GR_REMITENTE7 = $("#txtnro_grr_transporte7").val();
            var TRA_NUM_GR_TRANSPORTE7 = $("#txtnro_grt_transporte7").val();
            var TRA_PLACA7 = $("#txt_placa_transporte7").val();
            var TRA_BREVETE7 = $("#txt_brevete_transporte7").val();
            var TRA_DIRECCION_INICIO7 = $("#txt_direccion_inicio_transporte7").val();
            var TRA_DIRECCION_LLEGADA7 = $("#txt_direccion_llegada_transporte7").val();
            var TRA_TIPO_CARGA7 = $("#ddl_tipo_carga_transporte7").val();
            var TRA_NUM_CONTENEDOR7 = $("#txt_nro_contenedor_transporte7").val();
            var TRA_PESO7 = $("#txt_nro_peso_transporte7").val();
            var TRA_FECHA_SERVICIO7 = $("#txt_fecha_servicio_transporte7").val();
            var TRA_TIPO_BULTO7 = $("#ddl_tipo_bulto_transporte7").val();
            var TRA_NUM_BULTO7 = $("#txt_nro_bulto_transporte7").val();

            var TRA_NUM_GR_REMITENTE8 = $("#txtnro_grr_transporte8").val();
            var TRA_NUM_GR_TRANSPORTE8 = $("#txtnro_grt_transporte8").val();
            var TRA_PLACA8 = $("#txt_placa_transporte8").val();
            var TRA_BREVETE8 = $("#txt_brevete_transporte8").val();
            var TRA_DIRECCION_INICIO8 = $("#txt_direccion_inicio_transporte8").val();
            var TRA_DIRECCION_LLEGADA8 = $("#txt_direccion_llegada_transporte8").val();
            var TRA_TIPO_CARGA8 = $("#ddl_tipo_carga_transporte8").val();
            var TRA_NUM_CONTENEDOR8 = $("#txt_nro_contenedor_transporte8").val();
            var TRA_PESO8 = $("#txt_nro_peso_transporte8").val();
            var TRA_FECHA_SERVICIO8 = $("#txt_fecha_servicio_transporte8").val();
            var TRA_TIPO_BULTO8 = $("#ddl_tipo_bulto_transporte8").val();
            var TRA_NUM_BULTO8 = $("#txt_nro_bulto_transporte8").val();

            var TRA_NUM_GR_REMITENTE9 = $("#txtnro_grr_transporte9").val();
            var TRA_NUM_GR_TRANSPORTE9 = $("#txtnro_grt_transporte9").val();
            var TRA_PLACA9 = $("#txt_placa_transporte9").val();
            var TRA_BREVETE9 = $("#txt_brevete_transporte9").val();
            var TRA_DIRECCION_INICIO9 = $("#txt_direccion_inicio_transporte9").val();
            var TRA_DIRECCION_LLEGADA9 = $("#txt_direccion_llegada_transporte9").val();
            var TRA_TIPO_CARGA9 = $("#ddl_tipo_carga_transporte9").val();
            var TRA_NUM_CONTENEDOR9 = $("#txt_nro_contenedor_transporte9").val();
            var TRA_PESO9 = $("#txt_nro_peso_transporte9").val();
            var TRA_FECHA_SERVICIO9 = $("#txt_fecha_servicio_transporte9").val();
            var TRA_TIPO_BULTO9 = $("#ddl_tipo_bulto_transporte9").val();
            var TRA_NUM_BULTO9 = $("#txt_nro_bulto_transporte9").val();
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
                "ESTADO": ESTADO,
                "FLAG_TRANSPORTE1": FLAG_TRANSPORTE1,
                "FLAG_TRANSPORTE2": FLAG_TRANSPORTE2,
                "FLAG_TRANSPORTE3": FLAG_TRANSPORTE3,
                "FLAG_TRANSPORTE4": FLAG_TRANSPORTE4,
                "FLAG_TRANSPORTE5": FLAG_TRANSPORTE5,
                "FLAG_TRANSPORTE6": FLAG_TRANSPORTE6,
                "FLAG_TRANSPORTE7": FLAG_TRANSPORTE7,
                "FLAG_TRANSPORTE8": FLAG_TRANSPORTE8,
                "FLAG_TRANSPORTE9": FLAG_TRANSPORTE9,
                "TRA_NUM_GR_REMITENTE1": TRA_NUM_GR_REMITENTE1,
                "TRA_NUM_GR_TRANSPORTE1": TRA_NUM_GR_TRANSPORTE1,
                "TRA_PLACA1": TRA_PLACA1,
                "TRA_BREVETE1": TRA_BREVETE1,
                "TRA_DIRECCION_INICIO1": TRA_DIRECCION_INICIO1,
                "TRA_DIRECCION_LLEGADA1": TRA_DIRECCION_LLEGADA1,
                "TRA_TIPO_CARGA1": TRA_TIPO_CARGA1,
                "TRA_NUM_CONTENEDOR1": TRA_NUM_CONTENEDOR1,
                "TRA_PESO1": TRA_PESO1,
                "TRA_FECHA_SERVICIO1": TRA_FECHA_SERVICIO1,
                "TRA_TIPO_BULTO1": TRA_TIPO_BULTO1,
                "TRA_NUM_BULTO1": TRA_NUM_BULTO1,

                "TRA_NUM_GR_REMITENTE2": TRA_NUM_GR_REMITENTE2,
                "TRA_NUM_GR_TRANSPORTE2": TRA_NUM_GR_TRANSPORTE2,
                "TRA_PLACA2": TRA_PLACA2,
                "TRA_BREVETE2": TRA_BREVETE2,
                "TRA_DIRECCION_INICIO2": TRA_DIRECCION_INICIO2,
                "TRA_DIRECCION_LLEGADA2": TRA_DIRECCION_LLEGADA2,
                "TRA_TIPO_CARGA2": TRA_TIPO_CARGA2,
                "TRA_NUM_CONTENEDOR2": TRA_NUM_CONTENEDOR2,
                "TRA_PESO2": TRA_PESO2,
                "TRA_FECHA_SERVICIO2": TRA_FECHA_SERVICIO2,
                "TRA_TIPO_BULTO2": TRA_TIPO_BULTO2,
                "TRA_NUM_BULTO2": TRA_NUM_BULTO2,

                "TRA_NUM_GR_REMITENTE3": TRA_NUM_GR_REMITENTE3,
                "TRA_NUM_GR_TRANSPORTE3": TRA_NUM_GR_TRANSPORTE3,
                "TRA_PLACA3": TRA_PLACA3,
                "TRA_BREVETE3": TRA_BREVETE3,
                "TRA_DIRECCION_INICIO3": TRA_DIRECCION_INICIO3,
                "TRA_DIRECCION_LLEGADA3": TRA_DIRECCION_LLEGADA3,
                "TRA_TIPO_CARGA3": TRA_TIPO_CARGA3,
                "TRA_NUM_CONTENEDOR3": TRA_NUM_CONTENEDOR3,
                "TRA_PESO3": TRA_PESO3,
                "TRA_FECHA_SERVICIO3": TRA_FECHA_SERVICIO3,
                "TRA_TIPO_BULTO3": TRA_TIPO_BULTO3,
                "TRA_NUM_BULTO3": TRA_NUM_BULTO3,

                "TRA_NUM_GR_REMITENTE4": TRA_NUM_GR_REMITENTE4,
                "TRA_NUM_GR_TRANSPORTE4": TRA_NUM_GR_TRANSPORTE4,
                "TRA_PLACA4": TRA_PLACA4,
                "TRA_BREVETE4": TRA_BREVETE4,
                "TRA_DIRECCION_INICIO4": TRA_DIRECCION_INICIO4,
                "TRA_DIRECCION_LLEGADA4": TRA_DIRECCION_LLEGADA4,
                "TRA_TIPO_CARGA4": TRA_TIPO_CARGA4,
                "TRA_NUM_CONTENEDOR4": TRA_NUM_CONTENEDOR4,
                "TRA_PESO4": TRA_PESO4,
                "TRA_FECHA_SERVICIO4": TRA_FECHA_SERVICIO4,
                "TRA_TIPO_BULTO4": TRA_TIPO_BULTO4,
                "TRA_NUM_BULTO4": TRA_NUM_BULTO4,

                "TRA_NUM_GR_REMITENTE5": TRA_NUM_GR_REMITENTE5,
                "TRA_NUM_GR_TRANSPORTE5": TRA_NUM_GR_TRANSPORTE5,
                "TRA_PLACA5": TRA_PLACA5,
                "TRA_BREVETE5": TRA_BREVETE5,
                "TRA_DIRECCION_INICIO5": TRA_DIRECCION_INICIO5,
                "TRA_DIRECCION_LLEGADA5": TRA_DIRECCION_LLEGADA5,
                "TRA_TIPO_CARGA5": TRA_TIPO_CARGA5,
                "TRA_NUM_CONTENEDOR5": TRA_NUM_CONTENEDOR5,
                "TRA_PESO5": TRA_PESO5,
                "TRA_FECHA_SERVICIO5": TRA_FECHA_SERVICIO5,
                "TRA_TIPO_BULTO5": TRA_TIPO_BULTO5,
                "TRA_NUM_BULTO5": TRA_NUM_BULTO5,

                "TRA_NUM_GR_REMITENTE6": TRA_NUM_GR_REMITENTE6,
                "TRA_NUM_GR_TRANSPORTE6": TRA_NUM_GR_TRANSPORTE6,
                "TRA_PLACA6": TRA_PLACA6,
                "TRA_BREVETE6": TRA_BREVETE6,
                "TRA_DIRECCION_INICIO6": TRA_DIRECCION_INICIO6,
                "TRA_DIRECCION_LLEGADA6": TRA_DIRECCION_LLEGADA6,
                "TRA_TIPO_CARGA6": TRA_TIPO_CARGA6,
                "TRA_NUM_CONTENEDOR6": TRA_NUM_CONTENEDOR6,
                "TRA_PESO6": TRA_PESO6,
                "TRA_FECHA_SERVICIO6": TRA_FECHA_SERVICIO6,
                "TRA_TIPO_BULTO6": TRA_TIPO_BULTO6,
                "TRA_NUM_BULTO6": TRA_NUM_BULTO6,

                "TRA_NUM_GR_REMITENTE7": TRA_NUM_GR_REMITENTE7,
                "TRA_NUM_GR_TRANSPORTE7": TRA_NUM_GR_TRANSPORTE7,
                "TRA_PLACA7": TRA_PLACA7,
                "TRA_BREVETE7": TRA_BREVETE7,
                "TRA_DIRECCION_INICIO7": TRA_DIRECCION_INICIO7,
                "TRA_DIRECCION_LLEGADA7": TRA_DIRECCION_LLEGADA7,
                "TRA_TIPO_CARGA7": TRA_TIPO_CARGA7,
                "TRA_NUM_CONTENEDOR7": TRA_NUM_CONTENEDOR7,
                "TRA_PESO7": TRA_PESO7,
                "TRA_FECHA_SERVICIO7": TRA_FECHA_SERVICIO7,
                "TRA_TIPO_BULTO7": TRA_TIPO_BULTO7,
                "TRA_NUM_BULTO7": TRA_NUM_BULTO7,

                "TRA_NUM_GR_REMITENTE8": TRA_NUM_GR_REMITENTE8,
                "TRA_NUM_GR_TRANSPORTE8": TRA_NUM_GR_TRANSPORTE8,
                "TRA_PLACA8": TRA_PLACA8,
                "TRA_BREVETE8": TRA_BREVETE8,
                "TRA_DIRECCION_INICIO8": TRA_DIRECCION_INICIO8,
                "TRA_DIRECCION_LLEGADA8": TRA_DIRECCION_LLEGADA8,
                "TRA_TIPO_CARGA8": TRA_TIPO_CARGA8,
                "TRA_NUM_CONTENEDOR8": TRA_NUM_CONTENEDOR8,
                "TRA_PESO8": TRA_PESO8,
                "TRA_FECHA_SERVICIO8": TRA_FECHA_SERVICIO8,
                "TRA_TIPO_BULTO8": TRA_TIPO_BULTO8,
                "TRA_NUM_BULTO8": TRA_NUM_BULTO8,

                "TRA_NUM_GR_REMITENTE9": TRA_NUM_GR_REMITENTE9,
                "TRA_NUM_GR_TRANSPORTE9": TRA_NUM_GR_TRANSPORTE9,
                "TRA_PLACA9": TRA_PLACA9,
                "TRA_BREVETE9": TRA_BREVETE9,
                "TRA_DIRECCION_INICIO9": TRA_DIRECCION_INICIO9,
                "TRA_DIRECCION_LLEGADA9": TRA_DIRECCION_LLEGADA9,
                "TRA_TIPO_CARGA9": TRA_TIPO_CARGA9,
                "TRA_NUM_CONTENEDOR9": TRA_NUM_CONTENEDOR9,
                "TRA_PESO9": TRA_PESO9,
                "TRA_FECHA_SERVICIO9": TRA_FECHA_SERVICIO9,
                "TRA_TIPO_BULTO9": TRA_TIPO_BULTO9,
                "TRA_NUM_BULTO9": TRA_NUM_BULTO9
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

    function limpiar() {
        $("#txtcodigo").val('');
        $("#txt_id_cliente").val('');
        $("#ddltipo_documento_buscar_cliente").val('B');
        $("#txtnrodoc_buscar_cliente").val('');
        $("#txtrazon_social_buscar_cliente").val('');
        $("#flag_transporte").val('');
        $("#flag_cuadrilla").val('');
        $("#flag_resguardo").val('');
        $("#flag_aduana").val('');
        $("#flag_carga").val('');
        $("#flag_otros").val('');
        $("#txtnro_grr_transporte").val('');
        $("#txtnro_grt_transporte").val('');
        $("#txt_placa_transporte").val('');
        $("#txt_brevete_transporte").val('');
        $("#txt_direccion_inicio_transporte").val('');
        $("#txt_direccion_llegada_transporte").val('');
        $("#ddl_tipo_carga_transporte").val('0');
        $("#txt_nro_contenedor_transporte").val('');
        $("#txt_nro_peso_transporte").val('');
        $("#txt_fecha_servicio_transporte").val('');
        $("#ddl_tipo_bulto_transporte").val('0');
        $("#txt_nro_bulto_transporte").val('');
        $("#ddlservicio_cuadrilla").val('0');
        $("#txt_Detalle_cuadrilla").val('');
        $("#txt_lugar_Servicio_cuadrilla").val('');
        $("#txt_nro_personas_cuadrilla").val('');
        $("#txt_proveedor_resguardo").val('');
        $("#txt_ruta_resguardo").val('');
        $("#txt_aduana_aduana").val('');
        $("#txt_manifiesto_aduana").val('');
        $("#txt_regimen_aduana").val('');
        $("#txt_dam_aduana").val('');
        $("#txt_canal_aduana").val('');
        $("#txt_empresa_aduana").val('');
        $("#txt_fecha_arribo_aduana").val('');
        $("#txt_fecha_retiro_aduana").val('');
        $("#txt_almacen_aduana").val('');
        $("#txt_fob_aduana").val('');
        $("#txt_cif_aduana").val('');
        $("#txt_aduana_carga").val('');
        $("#txt_manifiesto_carga").val('');
        $("#txt_puerto_origen_carga").val('');
        $("#txt_pais_carga").val('');
        $("#txt_empresa_transporte_carga").val('');
        $("#txt_empresa_carga").val('');
        $("#txt_fecha_Arribo_carga").val('');
        $("#txt_fecha_retiro_carga").val('');
        $("#txt_peso_Carga").val('');
        $("#txt_volumen_carga").val('');
        $("#txt_nro_bultos_Carga").val('');
        $("#txt_almacen_carga").val('');
        $("#txt_detalle_otros").val('');
        $("#txtobservacion_otros").val('');
        $("#ddlestado").val('A');
    }

    $(document).on('click', '.ver', function (e) {
       
      
        var ajax_data = {
            "ID": $(this).parents("tr").find("td").eq(0).html(),
        };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Obtener_Archivos',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (respuesta) {
                var datos = (typeof respuesta.d) == 'string' ?
                    eval('(' + respuesta.d + ')') :
                    respuesta.d;

                for (var i = 0; i < datos.length; i++) {
                  
                    $("#txtid").val(datos[i].ID);

                  
                    //ARCHIVO 1
                    $("#nombre_foto_original_imagen_logo").val(datos[i].ARCHIVO1_NOMBRE_ORIGINAL);
                    $("#nombre_generado_foto_imagen_logo").val(datos[i].ARCHIVO1_NOMBRE_GENERADO);
                    $("#ruta_foto_imagen_logo").val(datos[i].ARCHIVO1_RUTA);

                    


                    $('#file-logo').fileinput('destroy');
                    if (datos[i].ARCHIVO1_RUTA.trim().length < 1) {
                        var tipos = ['jpeg', 'jpg', 'png','pdf'];
                        $('#file-logo').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Logo',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos
                        });
                    }
                    else {
                        $('#file-logo').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Logo',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos,
                            initialPreview: [datos[i].ARCHIVO1_RUTA],
                            initialPreviewAsData: true,
                          
                            validateInitialCount: true,
                            initialPreviewConfig: [
                                { type: "pdf", caption: datos[i].ARCHIVO1_NOMBRE_ORIGINAL, downloadUrl: datos[i].ARCHIVO1_RUTA, size: 130321, url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Eliminar_Imagen_Logo', width: "120px", key: 1 }
                            ],
                            overwriteInitial: false,


                        });

                    }
                    $('#file-logo').on('filepredelete', function (event, key, jqXHR, data) {
                        $('#nombre_foto_original_imagen_logo').val('');
                        $('#nombre_generado_foto_imagen_logo').val('');
                        $('#ruta_foto_imagen_logo').val('');
                        $('#file-logo').val('');
                    });
                    $('#file-logo').on('filebatchuploadsuccess', function (event, data, previewId, index) {
                        var respuesta = data.response;

                        $('#nombre_foto_original_imagen_logo').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_logo').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_logo').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-logo').on('fileuploaded', function (event, data, previewId, index) {

                        var respuesta = data.response;
                        $('#nombre_foto_original_imagen_logo').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_logo').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_logo').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-logo').on('filecleared', function (event) {
                        $('#nombre_foto_original_imagen_logo').val('');
                        $('#nombre_generado_foto_imagen_logo').val('');
                        $('#ruta_foto_imagen_logo').val('');
                    });
                    $('#file-logo').on('filesuccessremove', function (event, id) {
                        $('#nombre_foto_original_imagen_logo').val('');
                        $('#nombre_generado_foto_imagen_logo').val('');
                        $('#ruta_foto_imagen_logo').val('');
                    });
                    $('#file-logo').on('filezoomshow', function (event, params) {
                        $('#modal_nuevo').css('overflow-y', 'scroll');
                    });


                    /* ARCHIVO 2 */
                    $("#nombre_foto_original_imagen_fondo").val(datos[i].ARCHIVO2_NOMBRE_ORIGINAL);
                    $("#nombre_generado_foto_imagen_fondo").val(datos[i].ARCHIVO2_NOMBRE_GENERADO);
                    $("#ruta_foto_imagen_fondo").val(datos[i].ARCHIVO2_RUTA);

                    $('#file-fondo').fileinput('destroy');
                    if (datos[i].ARCHIVO2_RUTA.trim().length < 1) {
                        var tipos = ['jpeg', 'jpg', 'png', 'pdf'];
                        $('#file-fondo').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Fondo',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos
                        });
                    }
                    else {
                        $('#file-fondo').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Fondo',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos,
                            initialPreview: [datos[i].ARCHIVO2_RUTA],
                            initialPreviewAsData: true,

                            validateInitialCount: true,
                            initialPreviewConfig: [
                                { type: "pdf",caption: datos[i].ARCHIVO2_NOMBRE_ORIGINAL, downloadUrl: datos[i].ARCHIVO2_RUTA, size: 130321, url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Eliminar_Imagen_Fondo', width: "120px", key: 1 }
                            ],
                            overwriteInitial: false,


                        });

                    }
                    $('#file-fondo').on('filepredelete', function (event, key, jqXHR, data) {
                        $('#nombre_foto_original_imagen_fondo').val('');
                        $('#nombre_generado_foto_imagen_fondo').val('');
                        $('#ruta_foto_imagen_fondo').val('');
                        $('#file-fondo').val('');
                    });
                    $('#file-fondo').on('filebatchuploadsuccess', function (event, data, previewId, index) {
                        var respuesta = data.response;

                        $('#nombre_foto_original_imagen_fondo').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo').on('fileuploaded', function (event, data, previewId, index) {

                        var respuesta = data.response;
                        $('#nombre_foto_original_imagen_fondo').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo').on('filecleared', function (event) {
                        $('#nombre_foto_original_imagen_fondo').val('');
                        $('#nombre_generado_foto_imagen_fondo').val('');
                        $('#ruta_foto_imagen_fondo').val('');
                    });
                    $('#file-fondo').on('filesuccessremove', function (event, id) {
                        $('#nombre_foto_original_imagen_fondo').val('');
                        $('#nombre_generado_foto_imagen_fondo').val('');
                        $('#ruta_foto_imagen_fondo').val('');
                    });
                    $('#file-fondo').on('filezoomshow', function (event, params) {
                        $('#modal_nuevo').css('overflow-y', 'scroll');
                    });

                    /* ARCHIVO 3 */
                    $("#nombre_foto_original_imagen_fondo3").val(datos[i].ARCHIVO3_NOMBRE_ORIGINAL);
                    $("#nombre_generado_foto_imagen_fondo3").val(datos[i].ARCHIVO3_NOMBRE_GENERADO);
                    $("#ruta_foto_imagen_fondo3").val(datos[i].ARCHIVO3_RUTA);

                    $('#file-fondo3').fileinput('destroy');
                    if (datos[i].ARCHIVO3_RUTA.trim().length < 1) {
                        var tipos = ['jpeg', 'jpg', 'png', 'pdf'];
                        $('#file-fondo3').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo3',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos
                        });
                    }
                    else {
                        $('#file-fondo3').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo3',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos,
                            initialPreview: [datos[i].ARCHIVO3_RUTA],
                            initialPreviewAsData: true,

                            validateInitialCount: true,
                            initialPreviewConfig: [
                                { type: "pdf", caption: datos[i].ARCHIVO3_NOMBRE_ORIGINAL, downloadUrl: datos[i].ARCHIVO3_RUTA, size: 130321, url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Eliminar_Imagen_Archivo3', width: "120px", key: 1 }
                            ],
                            overwriteInitial: false,


                        });

                    }
                    $('#file-fondo3').on('filepredelete', function (event, key, jqXHR, data) {
                        $('#nombre_foto_original_imagen_fondo3').val('');
                        $('#nombre_generado_foto_imagen_fondo3').val('');
                        $('#ruta_foto_imagen_fondo3').val('');
                        $('#file-fondo3').val('');
                    });
                    $('#file-fondo3').on('filebatchuploadsuccess', function (event, data, previewId, index) {
                        var respuesta = data.response;

                        $('#nombre_foto_original_imagen_fondo3').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo3').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo3').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo3').on('fileuploaded', function (event, data, previewId, index) {

                        var respuesta = data.response;
                        $('#nombre_foto_original_imagen_fondo3').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo3').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo3').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo3').on('filecleared', function (event) {
                        $('#nombre_foto_original_imagen_fondo3').val('');
                        $('#nombre_generado_foto_imagen_fondo3').val('');
                        $('#ruta_foto_imagen_fondo3').val('');
                    });
                    $('#file-fondo3').on('filesuccessremove', function (event, id) {
                        $('#nombre_foto_original_imagen_fondo3').val('');
                        $('#nombre_generado_foto_imagen_fondo3').val('');
                        $('#ruta_foto_imagen_fondo3').val('');
                    });
                    $('#file-fondo3').on('filezoomshow', function (event, params) {
                        $('#modal_nuevo').css('overflow-y', 'scroll');
                    });

                    /* ARCHIVO 4 */
                    $("#nombre_foto_original_imagen_fondo4").val(datos[i].ARCHIVO4_NOMBRE_ORIGINAL);
                    $("#nombre_generado_foto_imagen_fondo4").val(datos[i].ARCHIVO4_NOMBRE_GENERADO);
                    $("#ruta_foto_imagen_fondo4").val(datos[i].ARCHIVO4_RUTA);

                    $('#file-fondo4').fileinput('destroy');
                    if (datos[i].ARCHIVO4_RUTA.trim().length < 1) {
                        var tipos = ['jpeg', 'jpg', 'png', 'pdf'];
                        $('#file-fondo4').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo4',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos
                        });
                    }
                    else {
                        $('#file-fondo4').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo4',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos,
                            initialPreview: [datos[i].ARCHIVO4_RUTA],
                            initialPreviewAsData: true,

                            validateInitialCount: true,
                            initialPreviewConfig: [
                                { type: "pdf", caption: datos[i].ARCHIVO4_NOMBRE_ORIGINAL, downloadUrl: datos[i].ARCHIVO4_RUTA, size: 140421, url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Eliminar_Imagen_Archivo4', width: "120px", key: 1 }
                            ],
                            overwriteInitial: false,


                        });

                    }
                    $('#file-fondo4').on('filepredelete', function (event, key, jqXHR, data) {
                        $('#nombre_foto_original_imagen_fondo4').val('');
                        $('#nombre_generado_foto_imagen_fondo4').val('');
                        $('#ruta_foto_imagen_fondo4').val('');
                        $('#file-fondo4').val('');
                    });
                    $('#file-fondo4').on('filebatchuploadsuccess', function (event, data, previewId, index) {
                        var respuesta = data.response;

                        $('#nombre_foto_original_imagen_fondo4').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo4').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo4').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo4').on('fileuploaded', function (event, data, previewId, index) {

                        var respuesta = data.response;
                        $('#nombre_foto_original_imagen_fondo4').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo4').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo4').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo4').on('filecleared', function (event) {
                        $('#nombre_foto_original_imagen_fondo4').val('');
                        $('#nombre_generado_foto_imagen_fondo4').val('');
                        $('#ruta_foto_imagen_fondo4').val('');
                    });
                    $('#file-fondo4').on('filesuccessremove', function (event, id) {
                        $('#nombre_foto_original_imagen_fondo4').val('');
                        $('#nombre_generado_foto_imagen_fondo4').val('');
                        $('#ruta_foto_imagen_fondo4').val('');
                    });
                    $('#file-fondo4').on('filezoomshow', function (event, params) {
                        $('#modal_nuevo').css('overflow-y', 'scroll');
                    });

                    /* ARCHIVO 5 */
                    $("#nombre_foto_original_imagen_fondo5").val(datos[i].ARCHIVO5_NOMBRE_ORIGINAL);
                    $("#nombre_generado_foto_imagen_fondo5").val(datos[i].ARCHIVO5_NOMBRE_GENERADO);
                    $("#ruta_foto_imagen_fondo5").val(datos[i].ARCHIVO5_RUTA);

                    $('#file-fondo5').fileinput('destroy');
                    if (datos[i].ARCHIVO5_RUTA.trim().length < 1) {
                        var tipos = ['jpeg', 'jpg', 'png', 'pdf'];
                        $('#file-fondo5').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo5',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos
                        });
                    }
                    else {
                        $('#file-fondo5').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo5',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos,
                            initialPreview: [datos[i].ARCHIVO5_RUTA],
                            initialPreviewAsData: true,

                            validateInitialCount: true,
                            initialPreviewConfig: [
                                { type: "pdf", caption: datos[i].ARCHIVO5_NOMBRE_ORIGINAL, downloadUrl: datos[i].ARCHIVO5_RUTA, size: 150521, url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Eliminar_Imagen_Archivo5', width: "120px", key: 1 }
                            ],
                            overwriteInitial: false,


                        });

                    }
                    $('#file-fondo5').on('filepredelete', function (event, key, jqXHR, data) {
                        $('#nombre_foto_original_imagen_fondo5').val('');
                        $('#nombre_generado_foto_imagen_fondo5').val('');
                        $('#ruta_foto_imagen_fondo5').val('');
                        $('#file-fondo5').val('');
                    });
                    $('#file-fondo5').on('filebatchuploadsuccess', function (event, data, previewId, index) {
                        var respuesta = data.response;

                        $('#nombre_foto_original_imagen_fondo5').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo5').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo5').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo5').on('fileuploaded', function (event, data, previewId, index) {

                        var respuesta = data.response;
                        $('#nombre_foto_original_imagen_fondo5').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo5').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo5').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo5').on('filecleared', function (event) {
                        $('#nombre_foto_original_imagen_fondo5').val('');
                        $('#nombre_generado_foto_imagen_fondo5').val('');
                        $('#ruta_foto_imagen_fondo5').val('');
                    });
                    $('#file-fondo5').on('filesuccessremove', function (event, id) {
                        $('#nombre_foto_original_imagen_fondo5').val('');
                        $('#nombre_generado_foto_imagen_fondo5').val('');
                        $('#ruta_foto_imagen_fondo5').val('');
                    });
                    $('#file-fondo5').on('filezoomshow', function (event, params) {
                        $('#modal_nuevo').css('overflow-y', 'scroll');
                    });


                    /* ARCHIVO 6 */
                    $("#nombre_foto_original_imagen_fondo6").val(datos[i].ARCHIVO6_NOMBRE_ORIGINAL);
                    $("#nombre_generado_foto_imagen_fondo6").val(datos[i].ARCHIVO6_NOMBRE_GENERADO);
                    $("#ruta_foto_imagen_fondo6").val(datos[i].ARCHIVO6_RUTA);

                    $('#file-fondo6').fileinput('destroy');
                    if (datos[i].ARCHIVO6_RUTA.trim().length < 1) {
                        var tipos = ['jpeg', 'jpg', 'png', 'pdf'];
                        $('#file-fondo6').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo6',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos
                        });
                    }
                    else {
                        $('#file-fondo6').fileinput({
                            language: 'es',
                            uploadUrl: '../ServiciosWeb/SW_Orden_Servicio.asmx/Subir_Imagen_Archivo6',
                            uploadAsync: false,
                            maxFileCount: 1,
                            removeFromPreviewOnError: true,
                            allowedFileExtensions: tipos,
                            initialPreview: [datos[i].ARCHIVO6_RUTA],
                            initialPreviewAsData: true,

                            validateInitialCount: true,
                            initialPreviewConfig: [
                                { type: "pdf", caption: datos[i].ARCHIVO6_NOMBRE_ORIGINAL, downloadUrl: datos[i].ARCHIVO6_RUTA, size: 160621, url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Eliminar_Imagen_Archivo6', width: "120px", key: 1 }
                            ],
                            overwriteInitial: false,


                        });

                    }
                    $('#file-fondo6').on('filepredelete', function (event, key, jqXHR, data) {
                        $('#nombre_foto_original_imagen_fondo6').val('');
                        $('#nombre_generado_foto_imagen_fondo6').val('');
                        $('#ruta_foto_imagen_fondo6').val('');
                        $('#file-fondo6').val('');
                    });
                    $('#file-fondo6').on('filebatchuploadsuccess', function (event, data, previewId, index) {
                        var respuesta = data.response;

                        $('#nombre_foto_original_imagen_fondo6').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo6').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo6').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo6').on('fileuploaded', function (event, data, previewId, index) {

                        var respuesta = data.response;
                        $('#nombre_foto_original_imagen_fondo6').val(respuesta.nombre_imagen_original);
                        $('#nombre_generado_foto_imagen_fondo6').val(respuesta.nombre_imagen_generado);
                        $('#ruta_foto_imagen_fondo6').val(respuesta.ruta_imagen);
                        Swal.fire('Excelente!', 'La Imagen se Grabo Satisfactoriamente.!', 'success')
                    });
                    $('#file-fondo6').on('filecleared', function (event) {
                        $('#nombre_foto_original_imagen_fondo6').val('');
                        $('#nombre_generado_foto_imagen_fondo6').val('');
                        $('#ruta_foto_imagen_fondo6').val('');
                    });
                    $('#file-fondo6').on('filesuccessremove', function (event, id) {
                        $('#nombre_foto_original_imagen_fondo6').val('');
                        $('#nombre_generado_foto_imagen_fondo6').val('');
                        $('#ruta_foto_imagen_fondo6').val('');
                    });
                    $('#file-fondo6').on('filezoomshow', function (event, params) {
                        $('#modal_nuevo').css('overflow-y', 'scroll');
                    });


                }
               
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });






      













        $('#modal_archivos').modal();
        /*

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
        */


    });
    $("#btnGuardar_Archivo").click(function (e) {

        var ID=$("#txtid").val();
        var ARCHIVO1_NOMBRE_ORIGINAL = $("#nombre_foto_original_imagen_logo").val();
        var ARCHIVO1_NOMBRE_GENERADO = $("#nombre_generado_foto_imagen_logo").val();
        var ARCHIVO1_RUTA = $("#ruta_foto_imagen_logo").val();

        var ARCHIVO2_NOMBRE_ORIGINAL = $("#nombre_foto_original_imagen_fondo").val();
        var ARCHIVO2_NOMBRE_GENERADO = $("#nombre_generado_foto_imagen_fondo").val();
        var ARCHIVO2_RUTA = $("#ruta_foto_imagen_fondo").val();

        var ARCHIVO3_NOMBRE_ORIGINAL = $("#nombre_foto_original_imagen_fondo3").val();
        var ARCHIVO3_NOMBRE_GENERADO = $("#nombre_generado_foto_imagen_fondo3").val();
        var ARCHIVO3_RUTA = $("#ruta_foto_imagen_fondo3").val();

        var ARCHIVO4_NOMBRE_ORIGINAL = $("#nombre_foto_original_imagen_fondo4").val();
        var ARCHIVO4_NOMBRE_GENERADO = $("#nombre_generado_foto_imagen_fondo4").val();
        var ARCHIVO4_RUTA = $("#ruta_foto_imagen_fondo4").val();

        var ARCHIVO5_NOMBRE_ORIGINAL = $("#nombre_foto_original_imagen_fondo5").val();
        var ARCHIVO5_NOMBRE_GENERADO = $("#nombre_generado_foto_imagen_fondo5").val();
        var ARCHIVO5_RUTA = $("#ruta_foto_imagen_fondo5").val();

        var ARCHIVO6_NOMBRE_ORIGINAL = $("#nombre_foto_original_imagen_fondo6").val();
        var ARCHIVO6_NOMBRE_GENERADO = $("#nombre_generado_foto_imagen_fondo6").val();
        var ARCHIVO6_RUTA = $("#ruta_foto_imagen_fondo6").val();

        var ajax_data = {
            "ID": ID,
            "ARCHIVO1_NOMBRE_ORIGINAL": ARCHIVO1_NOMBRE_ORIGINAL,
            "ARCHIVO1_NOMBRE_GENERADO": ARCHIVO1_NOMBRE_GENERADO,
            "ARCHIVO1_RUTA": ARCHIVO1_RUTA,

            "ARCHIVO2_NOMBRE_ORIGINAL": ARCHIVO2_NOMBRE_ORIGINAL,
            "ARCHIVO2_NOMBRE_GENERADO": ARCHIVO2_NOMBRE_GENERADO,
            "ARCHIVO2_RUTA": ARCHIVO2_RUTA,

            "ARCHIVO3_NOMBRE_ORIGINAL": ARCHIVO3_NOMBRE_ORIGINAL,
            "ARCHIVO3_NOMBRE_GENERADO": ARCHIVO3_NOMBRE_GENERADO,
            "ARCHIVO3_RUTA": ARCHIVO3_RUTA,

            "ARCHIVO4_NOMBRE_ORIGINAL": ARCHIVO4_NOMBRE_ORIGINAL,
            "ARCHIVO4_NOMBRE_GENERADO": ARCHIVO4_NOMBRE_GENERADO,
            "ARCHIVO4_RUTA": ARCHIVO4_RUTA,

            "ARCHIVO5_NOMBRE_ORIGINAL": ARCHIVO5_NOMBRE_ORIGINAL,
            "ARCHIVO5_NOMBRE_GENERADO": ARCHIVO5_NOMBRE_GENERADO,
            "ARCHIVO5_RUTA": ARCHIVO5_RUTA,

            "ARCHIVO6_NOMBRE_ORIGINAL": ARCHIVO6_NOMBRE_ORIGINAL,
            "ARCHIVO6_NOMBRE_GENERADO": ARCHIVO6_NOMBRE_GENERADO,
            "ARCHIVO6_RUTA": ARCHIVO6_RUTA

            
        }

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Grabar_Archivos',
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
                    $('#modal_archivos').modal('hide');
                    Swal.fire('Excelente!', 'El registro se Grabo Satisfactoriamente.!', 'success');

                }

                else {
                    Swal.fire('Error!', 'El registro no Grabo.!', 'error');
                    $('#modal_archivos').modal('hide');
                }
                $('body').removeClass('loading'); //Removemos la clase loading
                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });

    });
});