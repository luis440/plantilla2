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

        var MONEDA = $('#ddlmoneda_buscar').val();
        var FECHA = $('#txtfecha_buscar').val();

        var table = $('#Tabla_TipoCambio').DataTable();
        table.clear().draw();

        var ajax_data = { "MONEDA": MONEDA, "FECHA": FECHA };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Tipo_Cambio.asmx/Buscar',
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


                    $('#Tabla_TipoCambio').dataTable({
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].MONEDA,
                        datos[i].FECHA,
                        datos[i].COMPRA,
                        datos[i].VENTA,
                        "<img src='../img/editar_2.png' class='editar' style='width:20px;height:20px' />"

                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#Tabla_TipoCambio").show();
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
        if (TIPO_SERVICIO == 'TRANSPORTE') {
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
        $("#Titulo_Panel").text('Nuevo Factura');

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
            url: '../ServiciosWeb/SW_Tipo_Cambio.asmx/Obtener',
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
                    $("#ddlmoneda").val(datos[i].MONEDA);
                    $("#txtfecha_tipo_cambio").val(datos[i].FECHA);
                    $("#txtcompra").val(datos[i].COMPRA);
                    $("#txtventa").val(datos[i].VENTA);




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



        var MONEDA = $("#ddlmoneda").val();
        var FECHA = $("#txtfecha_tipo_cambio").val();
        var COMPRA = $("#txtcompra").val();
        var VENTA = $("#txtventa").val();
        var USUARIO_CREACION = USUARIO;



        var ajax_data = {

            "MONEDA": MONEDA,
            "FECHA": FECHA,
            "COMPRA": COMPRA,
            "VENTA": VENTA,
            "USUARIO_CREACION": USUARIO_CREACION

        };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Tipo_Cambio.asmx/Grabar',
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
            var MONEDA = $("#ddlmoneda").val();
            var FECHA = $("#txtfecha_tipo_cambio").val();
            var COMPRA = $("#txtcompra").val();
            var VENTA = $("#txtventa").val();
            var USUARIO_MODIFICACION = USUARIO;

            var ajax_data = {
                "ID": ID,
                "MONEDA": MONEDA,
                "FECHA": FECHA,
                "COMPRA": COMPRA,
                "VENTA": VENTA,
                "USUARIO_MODIFICACION": USUARIO_MODIFICACION

            };

            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Tipo_Cambio.asmx/Actualizar',
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


});