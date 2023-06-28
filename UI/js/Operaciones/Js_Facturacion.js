$(document).ready(function () {
    //var f = new Date();
    //$("#txtfecha_buscar").val(f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear());
    var fecha = new Date(); //Fecha actual
    var mes = fecha.getMonth() + 1; //obteniendo mes
    var dia = fecha.getDate(); //obteniendo dia
    var ano = fecha.getFullYear(); //obteniendo año
    if (dia < 10)
        dia = '0' + dia; //agrega cero si el menor de 10
    if (mes < 10)
        mes = '0' + mes //agrega cero si el menor de 10
    $("#fecha_inicio_comprobante_buscar").val("01" + "/" + mes + "/" + ano);
    $("#fecha_fin_comprobante_buscar").val(dia + "/" + mes + "/" + ano);
    $("#fecha_inicio_comprobante_buscar2").val("01" + "/" + mes + "/" + ano);
    $("#fecha_fin_comprobante_buscar2").val(dia + "/" + mes + "/" + ano);

    var ID = ($.session.get('SESSION_ID'));
    var USUARIO = ($.session.get('SESSION_USUARIO'));
    var NOMBRES = ($.session.get('SESSION_NOMBRES'));
    var PERFIL = ($.session.get('SESSION_PERFIL'));
    var APELLIDOS = ($.session.get('SESSION_APELLIDOS'));
    var CORREO = ($.session.get('SESSION_CORREO'));

    //if (typeof NOMBRES === "undefined") {
    //    location.href = 'Login.aspx';

    //}

    //if (USUARIO != 'admin') {
    //    location.href = 'Login.aspx';

    //}

     
   

    OBTENER_COMBO_TIPO_DOCUMENTO();
    OBTENER_COMBO_FORMA_PAGO();
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
                        columnDefs: [{ className: 'text-center', targets: [0, 1, 2, 3, 4] }],
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

        var TIPO_COMPROBANTE = $('#ddltipo_comprobante_buscar').val();
        var SERIE = $('#ddlserie_buscar').val();
        var NUMERO = $('#nro_doc_buscar').val();
        var RAZON_SOCIAL = $('#razon_social_buscar').val();
        var FECHA_INI = $('#fecha_inicio_comprobante_buscar').val();
        var FECHA_FIN = $('#fecha_fin_comprobante_buscar').val();
        var ESTADO = $('#ddlestado_buscar').val();
       



        var table = $('#Tabla_Comprobantes').DataTable();
        table.clear().draw();

        var ajax_data = {
            "TIPO_COMPROBANTE": TIPO_COMPROBANTE, "SERIE": SERIE, "NUMERO": NUMERO, "RAZON_SOCIAL": RAZON_SOCIAL,
            "ESTADO": ESTADO, "FECHA_INI": FECHA_INI, "FECHA_FIN": FECHA_FIN
        };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Buscar',
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


                    $('#Tabla_Comprobantes').dataTable({
                        "order": [[0, "desc"]],
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5,6,7,8] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].TIPO_COMPROBANTE,
                        datos[i].SERIE,
                        datos[i].NUMERO,
                        datos[i].CLIENTE,
                        datos[i].TOTAL_GENERAL,
                        datos[i].FECHA,
                        datos[i].ESTADO,                      
                          "<img src='../img/ver_doc.png' class='ver' style='width:20px;height:20px' />",
                        "<img src='../img/ELIMINAR.png' class='eliminar' style='width:20px;height:20px'/>"
                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#Tabla_Comprobantes").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> ", "error");
            }
        });


    }


    $("#btnnuevo").click(function (e) {
        $("#Titulo_Panel").text('Nuevo Comprobante');

        $("#txtfecha_tipo_cambio").val('');
        $("#txtcompra").val('');
        $("#txtventa").val('');

        var fecha = new Date(); //Fecha actual
        var mes = fecha.getMonth() + 1; //obteniendo mes
        var dia = fecha.getDate(); //obteniendo dia
        var ano = fecha.getFullYear(); //obteniendo año
        if (dia < 10)
            dia = '0' + dia; //agrega cero si el menor de 10
        if (mes < 10)
            mes = '0' + mes //agrega cero si el menor de 10
        $("#txtfecha_factura").val(dia + "/" + mes + "/" + ano);

        $('#div_Tabla_Detalle_Factura').hide();
        $('#ddlserie').empty().append('<option value=0 selected> << SELECCIONAR >> </option>');
        $('#div_buscar_orden_Servicio').hide();
        $('#div_buscar_factura').hide();
        $("#div_estado_buscar").hide();
        $("#btnGuardar").show();
        $("#btnActualizar").hide();
        $("#btnImprimir").hide();

        $('#modal_nuevo').modal();

        /*Eliminar las clases de error*/
        $("#txtfecha_tipo_cambio").removeClass('error_campo_vacio');
        $("#txtcompra").removeClass('error_campo_vacio');
        $("#txtventa").removeClass('error_campo_vacio');


        $("#txt_codigo").val('');
        $("#ddltipo_comprobante").val('0');
      //  $('#ddlserie').val('0');
        $("#txtnrodo").val('');
        $("#txtnrofactura").val('');
        $("#txtglosa").val('')
        $("#ddlmoneda").val('PEN');
        $("#ddlforma_pago").val('0');
        $("#ddltipo_documento_buscar_cliente").val('B');
        $("#txtnrodoc_buscar_cliente").val('');
        $("#txtrazon_social_buscar_cliente").val('');
        $("#txtdireccion").val('');
        $('#txttoal_general').html('');
        $('#txtsubtotal_general').html('');
        $('#txtsubtotal_igv').html('');
        var table = $('#Tabla_Detalle_Factura').DataTable();
        table.clear().draw();
       
    });
    $("#btnbuscar").click(function (e) {

        BUSCAR();

    });
    $("#btn_buscar_cliente").click(function (e) {

        BUSCAR_CLIENTE();

    });
    $("#btnGuardar").click(function (e) {
     //  alert( $('#Tabla_Detalle_Factura').html());
        var rows = $("#Tabla_Detalle_Factura").dataTable().fnGetNodes();
        var correlativo,codigo, descripcion, und, cantidad, precio, igv, total, totalgeneral, valores, totaligv = 0, subtotal, detalle = "";
        var resultado_validacion = validar_input_vacios();
        var TIPO_COMPROBANTE_VALIDAR = $("#ddltipo_comprobante").val();
        var TIPO_DOC_CLIENTE_VALIDAR = $("#ddltipo_documento_buscar_cliente").val();

        var validar;

        if (TIPO_COMPROBANTE_VALIDAR == "01" && TIPO_DOC_CLIENTE_VALIDAR=="DNI") // factura  y dni
        {
            validar = 1;
            alertify.error('Las Facturas solo pueden ser emitidas con el  <b> RUC </b>  del Cliente');
            $("#ddltipo_comprobante").addClass('error_campo_vacio');
            $("#ddltipo_documento_buscar_cliente").addClass('error_campo_vacio');
            return validar;
        }
        else {
            $("#ddltipo_comprobante").removeClass('error_campo_vacio');
            $("#ddltipo_documento_buscar_cliente").removeClass('error_campo_vacio');
        }

        if (resultado_validacion == 0) {


            if (TIPO_COMPROBANTE_VALIDAR == '07' || TIPO_COMPROBANTE_VALIDAR == '08')
            {

                for (var i = 0; i < rows.length; i++) {

                    correlativo = $(rows[i]).find("td:eq(0)").html();
                    codigo = $(rows[i]).find("td:eq(1)").html();
                    descripcion = $(rows[i]).find("td:eq(2)").html();
                    und = $(rows[i]).find("td:eq(3)").html();
                    cantidad = $(rows[i]).find("td:eq(4)").html();
                    precio = $(rows[i]).find("td:eq(5)").html();
                    igv = $(rows[i]).find("td:eq(7)").html();
                    total = $(rows[i]).find("td:eq(8)").html();
                    totalgeneral = $('#txttoal_general').html().substring(6, 50);
                    subtotal = $('#txtsubtotal_general').html().trim().substring(10, 50);
                    valores = 'ª' + correlativo + 'º' + codigo + 'º' + descripcion + 'º' + und + 'º' + cantidad + 'º' + precio + 'º' + igv + 'º' + total;
                    totaligv = $('#txtsubtotal_igv').html().substring(4, 50);
                    detalle = detalle + valores;
                }
                var TIPO_COMPROBANTE = $("#ddltipo_comprobante").val();
                var SERIE = $("#ddlserie").val();
                var NRO_ORDEN = $("#txtnrodo").val();
                var FECHA = $("#txtfecha_factura").val();
                var MONEDA = $("#ddlmoneda").val();
                var FORMA_PAGO = $("#ddlforma_pago").val();
                var TIPO_DOC_CLIENTE = $("#ddltipo_documento_buscar_cliente").val();
                var NUM_DOC_CLIENTE = $("#txtnrodoc_buscar_cliente").val();
                var RAZON_SOCIAL = $("#txtrazon_social_buscar_cliente").val();
                var DIRECCION = $("#txtdireccion").val();
                var DETALLE = detalle;
                var USUARIO_CREACION = USUARIO;
                var TOTAL_GENERAL = totalgeneral;
                var TOTAL_IGV = totaligv;
                var SUBTOTAL_GENERAL = subtotal;
                var SERIE_FACURA = $("#serie_factura_relacionada").val();
                var NRO_FACURA = $("#numero_factura_relacionada").val();
                var FECHA_FACURA = $("#fecha_factura_relacionada").val();
                var GLOSA = $("#txtglosa").val();
                var FORMA_PAGO_DESCRIPCION = $("#ddlforma_pago option:selected").html();
              


                var ajax_data = {

                    "TIPO_COMPROBANTE": TIPO_COMPROBANTE,
                    "SERIE": SERIE,
                    "SERIE_FACURA": SERIE_FACURA,
                    "NRO_FACURA": NRO_FACURA,
                    "FECHA_FACURA": FECHA_FACURA,
                    "FECHA": FECHA,
                    "MONEDA": MONEDA,
                    "FORMA_PAGO": FORMA_PAGO,
                    "TIPO_DOC_CLIENTE": TIPO_DOC_CLIENTE,
                    "NUM_DOC_CLIENTE": NUM_DOC_CLIENTE,
                    "RAZON_SOCIAL": RAZON_SOCIAL,
                    "DIRECCION": DIRECCION,
                    "DETALLE": DETALLE,
                    "USUARIO_CREACION": USUARIO_CREACION,
                    "TOTAL_GENERAL": TOTAL_GENERAL,
                    "TOTAL_IGV": TOTAL_IGV,
                    "SUBTOTAL_GENERAL": SUBTOTAL_GENERAL,
                    "GLOSA": GLOSA,
                    "FORMA_PAGO_DESCRIPCION": FORMA_PAGO_DESCRIPCION
                };
                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Facturacion.asmx/Grabar_Nota',
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
                            Swal.fire('Excelente!', 'El registro se Grabo Satisfactoriamente.!', 'success');
                        }

                        else {
                            Swal.fire('Error!', 'El registro no Grabo.!', 'error');
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
            else
            {
                for (var i = 0; i < rows.length; i++) {

                    correlativo = $(rows[i]).find("td:eq(0)").html();
                    codigo = $(rows[i]).find("td:eq(1)").html();
                    descripcion = $(rows[i]).find("td:eq(2)").html();
                    und = $(rows[i]).find("td:eq(3)").html();
                    cantidad = $(rows[i]).find("td:eq(4)").html();
                    precio = $(rows[i]).find("td:eq(5)").find("input").val();
                    igv = $(rows[i]).find("td:eq(7)").html();
                    total = $(rows[i]).find("td:eq(8)").html();
                    totalgeneral = $('#txttoal_general').html().substring(6, 50);
                    subtotal = $('#txtsubtotal_general').html().substring(10, 50);
                    valores = 'ª' + correlativo + 'º' + codigo + 'º' + descripcion + 'º' + und + 'º' + cantidad + 'º' + precio + 'º' + igv + 'º' + total;
                    totaligv = $('#txtsubtotal_igv').html().substring(4, 50);
                    detalle = detalle + valores;
                }
                var TIPO_COMPROBANTE = $("#ddltipo_comprobante").val();
                var SERIE = $("#ddlserie").val();
                var NRO_ORDEN = $("#txtnrodo").val();
                var FECHA = $("#txtfecha_factura").val();
                var MONEDA = $("#ddlmoneda").val();
                var FORMA_PAGO = $("#ddlforma_pago").val();
                var TIPO_DOC_CLIENTE = $("#ddltipo_documento_buscar_cliente").val();
                var NUM_DOC_CLIENTE = $("#txtnrodoc_buscar_cliente").val();
                var RAZON_SOCIAL = $("#txtrazon_social_buscar_cliente").val();
                var DIRECCION = $("#txtdireccion").val();
                var DETALLE = detalle;
                var USUARIO_CREACION = USUARIO;
                var TOTAL_GENERAL = totalgeneral;
                var TOTAL_IGV = totaligv;
                var SUBTOTAL_GENERAL = subtotal;
                var SERIE_FACURA = $("#serie_factura_relacionada").val();
                var NRO_FACURA = $("#numero_factura_relacionada").val();
                var FECHA_FACURA = $("#fecha_factura_relacionada").val();
                var GLOSA = $("#txtglosa").val();
                var FORMA_PAGO_DESCRIPCION = $("#ddlforma_pago option:selected").html();
                var ajax_data = {

                    "TIPO_COMPROBANTE": TIPO_COMPROBANTE,
                    "SERIE": SERIE,
                    "NRO_ORDEN": NRO_ORDEN,
                    "FECHA": FECHA,
                    "MONEDA": MONEDA,
                    "FORMA_PAGO": FORMA_PAGO,
                    "TIPO_DOC_CLIENTE": TIPO_DOC_CLIENTE,
                    "NUM_DOC_CLIENTE": NUM_DOC_CLIENTE,
                    "RAZON_SOCIAL": RAZON_SOCIAL,
                    "DIRECCION": DIRECCION,
                    "DETALLE": DETALLE,
                    "USUARIO_CREACION": USUARIO_CREACION,
                    "TOTAL_GENERAL": TOTAL_GENERAL,
                    "TOTAL_IGV": TOTAL_IGV,
                    "SUBTOTAL_GENERAL": SUBTOTAL_GENERAL,
                    "GLOSA": GLOSA,
                    "FORMA_PAGO_DESCRIPCION": FORMA_PAGO_DESCRIPCION
                };
                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Facturacion.asmx/Grabar',
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
                            Swal.fire('Excelente!', 'El registro se Grabo Satisfactoriamente.!', 'success');
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



          





        }



    });
    $("#btnImprimir").click(function (e) {
        //var ajax_data = {
        //    "ID": $(this).parents("tr").find("td").eq(0).html(),
        //};
           
        var  codigo = $("#txt_codigo").val(); 
        var tipo_comprobante = $("#ddltipo_comprobante").val(); 


        if (tipo_comprobante == '01') {

            window.open("../Vista_Reportes/Mostrar_Fatura.aspx?CODIGO=" + codigo + "", "mywindow", 'width=800,height=860,scrollbars=yes,resizable=yes,location=center,status=no,location=no')

        }
        else if (tipo_comprobante == '03')
        {
            window.open("../Vista_Reportes/Mostrar_Boleta.aspx?CODIGO=" + codigo + "", "mywindow", 'width=800,height=860,scrollbars=yes,resizable=yes,location=center,status=no,location=no')
        }
        else if (tipo_comprobante == '07') {
            window.open("../Vista_Reportes/Mostrar_Nota_Credito.aspx?CODIGO=" + codigo + "", "mywindow", 'width=800,height=860,scrollbars=yes,resizable=yes,location=center,status=no,location=no')
        }
        else if (tipo_comprobante == '08') {
            window.open("../Vista_Reportes/Mostrar_Nota_Debito.aspx?CODIGO=" + codigo + "", "mywindow", 'width=800,height=860,scrollbars=yes,resizable=yes,location=center,status=no,location=no')
        }
        //$.ajax({
        //    type: "POST",
        //    url: '../ServiciosWeb/SW_Facturacion.asmx/Imprimir',
        //    data: JSON.stringify(ajax_data),
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    async: true,
        //    success: function (respuesta) {
        //        var datos = (typeof respuesta.d) == 'string' ?
        //            eval('(' + respuesta.d + ')') :
        //            respuesta.d;

        //        for (var i = 0; i < datos.length; i++) {

        //            $("#txt_id_cliente").val(datos[i].ID);
        //            $("#ddltipo_documento_buscar_cliente").val(datos[i].TIPO_DOC);
        //            $("#txtnrodoc_buscar_cliente").val(datos[i].NUM_DOC);
        //            $("#txtrazon_social_buscar_cliente").val(datos[i].RAZON_SOCIAL);
        //            $("#txtdireccion").val(datos[i].DOMICILIO1);
        //        }
        //        var table = $('#Tabla_Clientes_Buscar').DataTable();
        //        table.clear().draw();
        //        $('#contiene_tabla').hide();

        //    },
        //    error: function (XMLHttpRequest, textStatus, errorThrown) {
        //        var error = eval("(" + XMLHttpRequest.responseText + ")");
        //        alert(error.Message);
        //    }
        //});

    });
    
   
    $("#btncerrar").click(function (e) {

        window.location.href = "Principal.aspx";

    });
    $("#btn_buscar_orden_servicio_principal").click(function (e) {
        var table = $('#Tabla_Orden_Servicio').DataTable();
        table.clear().draw();

        $('#modal_orden').modal();

    });
    $("#btn_buscar_factura_principal").click(function (e) {

        var table = $('#Tabla_Comprobantes').DataTable();
        table.clear().draw();

        $('#modal_comprobantes').modal();

    });
    $("#btnbuscar_orden_servicio").click(function (e) {

        var TIPO_SERVICIO = $('#ddltipo_servicio_buscar').val();
        var NRO_ORDEN_SERVICIO = $('#txt_numero_orden_buscar').val();
        var RAZON_SOCIAL = $('#txt_razon_social_buscar').val();
        var ESTADO = $('#ddlestado_orden_servicio_buscar').val();

        var table = $('#Tabla_Orden_Servicio').DataTable();
        table.clear().draw();

        var ajax_data = { "TIPO_SERVICIO": TIPO_SERVICIO, "NRO_ORDEN_SERVICIO": NRO_ORDEN_SERVICIO, "RAZON_SOCIAL": RAZON_SOCIAL, "ESTADO": ESTADO };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Buscar_Orden_servicio',
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
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].NUM_ORDEN_SERVICIO,
                        datos[i].FECHA_CREACION,
                        datos[i].TIPO_SERVICIO,
                        datos[i].RAZON_SOCIAL,
                        datos[i].ESTADO,
                        "<img src='../img/check1.png' class='seleccionar_orden' style='width:20px;height:20px' />",

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
    });

    $("#btnbuscar_comprobantes").click(function (e) {

        var TIPO_COMPROBANTE = $('#ddltipo_comprobante_buscar').val();
        var SERIE = $('#ddlserie_buscar').val();
        var NUMERO = $('#nro_doc_buscar').val();
        var RAZON_SOCIAL = $('#razon_social_buscar').val();
        var FECHA_INI = $('#fecha_inicio_comprobante_buscar2').val();
        var FECHA_FIN = $('#fecha_fin_comprobante_buscar2').val();
        var ESTADO = $('#ddlestado_buscar').val();




        var table = $('#Tabla_Comprobantes2').DataTable();
        table.clear().draw();

        var ajax_data = {
            "TIPO_COMPROBANTE": TIPO_COMPROBANTE, "SERIE": SERIE, "NUMERO": NUMERO, "RAZON_SOCIAL": RAZON_SOCIAL,
            "ESTADO": ESTADO, "FECHA_INI": FECHA_INI, "FECHA_FIN": FECHA_FIN
        };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Buscar_comprobantes',
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


                    $('#Tabla_Comprobantes2').dataTable({
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6, 7, 8] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].TIPO_COMPROBANTE,
                        datos[i].SERIE,
                        datos[i].NUMERO,
                        datos[i].CLIENTE,
                        datos[i].TOTAL_GENERAL,
                        datos[i].FECHA,
                        datos[i].ESTADO,
                        "<img src='../img/check1.png' class='seleccionar_comprobante' style='width:20px;height:20px' />",
                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#Tabla_Comprobantes2").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> ", "error");
            }
        });

    });


    $(document).on('click', '.ver', function (e) {


        /*Eliminar las clases de error*/
        //$("#txtapellidos").removeClass('error_campo_vacio');
        //$("#txtnombres").removeClass('error_campo_vacio');
        //$("#txt_usuario").removeClass('error_campo_vacio');
        //$("#txtclave").removeClass('error_campo_vacio');
        var table = $('#Tabla_Detalle_Factura').DataTable();
        table.clear().draw();

        $("#Titulo_Panel").text('Ver Comprobante');
        $("#div_estado_buscar").show();
        $('#div_Tabla_Detalle_Factura').show();
        $("#btnGuardar").hide();
        $("#btnImprimir").show();

        var ajax_data = {
            "ID": $(this).parents("tr").find("td").eq(0).html(),
        };


        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (respuesta) {
                var datos = (typeof respuesta.d) == 'string' ?
                    eval('(' + respuesta.d + ')') :
                    respuesta.d;

                for (var i = 0; i < datos.length; i++) {

                    $("#txt_codigo").val(datos[i].ID);
                    $("#ddltipo_comprobante").val(datos[i].TIPO_COMPROBANTE);
                    $('#ddlserie').append('<option  value="' + datos[i].SERIE + '" selected>' + datos[i].SERIE + '</option>');
                    $("#txtnrodo").val(datos[i].NUM_DOC_REL);
                    $("#txtnrofactura").val(datos[i].SERIE_DOC_REL+'-'+datos[i].NUM_DOC_REL);
                    $("#txtfecha_factura").val(datos[i].FECHA);
                    $("#ddlmoneda").val(datos[i].MONEDA);
                    $("#ddlforma_pago").val(datos[i].FORMA_PAGO);
                    $("#ddltipo_documento_buscar_cliente").val(datos[i].TIPO_DOC_CLIENTE);
                    $("#txtnrodoc_buscar_cliente").val(datos[i].NUM_DOC_CLIENTE);
                    $("#txtrazon_social_buscar_cliente").val(datos[i].NOMBRE_CLIENTE);
                    $("#txtdireccion").val(datos[i].DIRECCION_CLIENTE);
                    $('#txttoal_general').html('Total: ' + datos[i].TOTAL_GENERAL);
                    $('#txtsubtotal_general').html('Sub Total: ' + datos[i].SUBTOTAL_GENERAL);
                    $('#txtsubtotal_igv').html('Igv: ' + datos[i].TOTAL_IGV);
                    $("#txtglosa").val(datos[i].GLOSA);

                    if (datos[i].TIPO_COMPROBANTE == '07' || datos[i].TIPO_COMPROBANTE == '08')//nota de credito y debito
                    {
                        $('#div_buscar_orden_Servicio').hide();
                        $('#div_buscar_factura').show();
                    }
                    else {
                        $('#div_buscar_orden_Servicio').show();
                        $('#div_buscar_factura').hide();
                    }
                }
               


                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener_Detalle',
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


                            $('#Tabla_Detalle_Factura').dataTable({

                                destroy: true,
                                "paging": false,
                                "searching": false,
                                "info": false,
                                "autoWidth": false,
                              
                                columnDefs: [
                                    { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6, 7, 8] }

                                ],
                                columnDefs: [{
                                    width: "800px",
                                    targets: 2
                                }, {
                                    width: "80px",
                                    targets: [4, 5, 6]
                                }]

                            }).fnAddData([
                                datos[i].ID,
                                datos[i].CODIGO,
                                datos[i].SERVICIO,
                                datos[i].UNIDAD,
                                datos[i].CANTIDAD,
                                datos[i].PRECIO,
                                datos[i].PRECIO,
                                datos[i].IGV,
                                datos[i].TOTAL

                            ]);

                        }
                        $('body').removeClass('loading'); //Removemos la clase loading
                        $("#Tabla_Detalle_Factura").show();
                        $('#modal_nuevo').modal();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        // alert(error.Message);
                        swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> ", "error");
                    }
                });




            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });



    });
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
                    $("#txtdireccion").val(datos[i].DOMICILIO1);
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
    $(document).on('click', '.seleccionar_orden', function (e) {

        var table = $('#Tabla_Detalle_Factura').DataTable();
        table.clear().draw();
        var table = $('#Tabla_Detalle_Factura').DataTable({
            destroy: true,
            "paging": false,
            "searching": false,
            "info": false,
            "autoWidth": false,
            columnDefs: [
                { className: 'text-center', targets: [0, 1, 3, 4, 5, 6, 7] }
                //    {
                //       className: 'text-left', width: "800px", targets: [2]
                //},
            ],
            columnDefs: [{
                width: "800px",
                targets: 2
            }
            //    {
            //        className: 'text-center',
            //        targets: [ 6]

                //}
            ]




        });
        var ajax_data = {
            "ID": $(this).parents("tr").find("td").eq(0).html()
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

                    $("#txtnrodo").val(datos[i].NUM_ORDEN_SERVICIO);
                    $("#txt_id_cliente").val(datos[i].ID_CLIENTE);
                    $("#ddltipo_documento_buscar_cliente").val(datos[i].TIPO_DOC);
                    $("#txtnrodoc_buscar_cliente").val(datos[i].NUM_DOC);
                    $("#txtrazon_social_buscar_cliente").val(datos[i].RAZON_SOCIAL);
                    $("#txtdireccion").val(datos[i].DIRECCION_CLIENTE);

                }

                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Orden_Servicio.asmx/Obtener_Detalle',
                    data: JSON.stringify(ajax_data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (respuesta) {
                        var datos = (typeof respuesta.d) == 'string' ?
                            eval('(' + respuesta.d + ')') :
                            respuesta.d;

                        for (var i = 0; i < datos.length; i++) {
                            $('#Tabla_Detalle_Factura').dataTable().fnAddData([
                                datos[i].ID,
                                datos[i].CODIGO_SERVICIO,
                                datos[i].DESCRIPCION_SERVICIO,
                                'ZZ',
                                '1',
                                '<input type="text" type="number" step="0.01"  class="form-control precio" onkeyup="funcion(event, this)" onblur="funcion(event, this)"/>',
                                '0',
                                '0',
                                '0'

                            ]);

                        }


                        $('#div_Tabla_Detalle_Factura').show();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        alert(error.Message);
                    }
                });




                //if ($("#flag_transporte").val() == 1) { $("#panel_transporte").show(); } else { $("#panel_transporte").hide(); }
                //if ($("#flag_cuadrilla").val() == 1) { $("#panel_cuadrilla").show(); } else { $("#panel_cuadrilla").hide(); }
                //if ($("#flag_resguardo").val() == 1) { $("#panel_resguardo").show(); } else { $("#panel_resguardo").hide(); }
                //if ($("#flag_aduana").val() == 1) { $("#panel_aduana").show(); } else { $("#panel_aduana").hide(); }
                //if ($("#flag_carga").val() == 1) { $("#panel_carga").show(); } else { $("#panel_carga").hide(); }
                //if ($("#flag_otros").val() == 1) { $("#panel_otros").show(); } else { $("#panel_otros").hide(); }



                //  $('#modal_orden').modal('hide');

                $("#modal_orden").modal('hide');//ocultamos el modal
                $('#modal_orden body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
                $('#modal_orden .modal-backdrop').remove();//eliminamos el backdrop del modal

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });


    });
    $(document).on('click', '.seleccionar_comprobante', function (e) {
        var table = $('#Tabla_Detalle_Factura').DataTable();
        table.clear().draw();

        var ajax_data = {
            "ID": $(this).parents("tr").find("td").eq(0).html(),
        };


        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (respuesta) {
                var datos = (typeof respuesta.d) == 'string' ?
                    eval('(' + respuesta.d + ')') :
                    respuesta.d;

                for (var i = 0; i < datos.length; i++) {

                    $("#txt_codigo").val(datos[i].ID);
                   // $("#ddltipo_comprobante").val(datos[i].TIPO_COMPROBANTE);
                   // $('#ddlserie').append('<option  value="' + datos[i].SERIE + '" selected>' + datos[i].SERIE + '</option>');
                    $('#txtnrofactura').val(datos[i].SERIE + '-' + datos[i].NUMERO);
                    $('#serie_factura_relacionada').val(datos[i].SERIE);
                    $('#numero_factura_relacionada').val(datos[i].NUMERO);
                    
                   // $("#txtnrodo").val(datos[i].NUM_DOC_REL);
                    $("#fecha_factura_relacionada").val(datos[i].FECHA); 
                    $("#ddlmoneda").val(datos[i].MONEDA);
                    $("#ddlforma_pago").val(datos[i].FORMA_PAGO);
                    $("#ddltipo_documento_buscar_cliente").val(datos[i].TIPO_DOC_CLIENTE);
                    $("#txtnrodoc_buscar_cliente").val(datos[i].NUM_DOC_CLIENTE);
                    $("#txtrazon_social_buscar_cliente").val(datos[i].NOMBRE_CLIENTE);
                    $("#txtdireccion").val(datos[i].DIRECCION_CLIENTE);
                    $('#txttoal_general').html('Total:    ' + datos[i].TOTAL_GENERAL);
                    $('#txtsubtotal_general').html('Sub Total:    ' + datos[i].SUBTOTAL_GENERAL);
                    $('#txtsubtotal_igv').html('Igv:    ' + datos[i].TOTAL_IGV);
                }

                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener_Detalle',
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


                            $('#Tabla_Detalle_Factura').dataTable({

                                destroy: true,
                                "paging": false,
                                "searching": false,
                                "info": false,
                                "autoWidth": false,
                                columnDefs: [
                                    { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6, 7, 8] }

                                ],
                                columnDefs: [{
                                    width: "800px",
                                    targets: 2
                                }, {
                                    width: "80px",
                                    targets: [4, 5, 6]
                                }]

                            }).fnAddData([
                                datos[i].ID,
                                datos[i].CODIGO,
                                datos[i].SERVICIO,
                                datos[i].UNIDAD,
                                datos[i].CANTIDAD,
                                datos[i].PRECIO,
                                datos[i].PRECIO,
                                datos[i].IGV,
                                datos[i].TOTAL

                            ]);

                        }
                        $('body').removeClass('loading'); //Removemos la clase loading
                        $("#Tabla_Detalle_Factura").show();

                        $('#div_Tabla_Detalle_Factura').show();
                        $("#modal_comprobantes").modal('hide');//ocultamos el modal
                        $('#modal_comprobantes body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
                        $('#modal_comprobantes .modal-backdrop').remove();//eliminamos el backdrop del modal


                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        // alert(error.Message);
                        swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> ", "error");
                    }
                });




            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });


    });
    
    $(document).on('click', '.eliminar', function (e) {
        var ID, NOMBRES,SERIE,NUMERO,TIPO_COMPROBANTE;
        ID = $(this).parents("tr").find("td").eq(0).html();
        TIPO_COMPROBANTE = $(this).parents("tr").find("td").eq(1).html();
        SERIE = $(this).parents("tr").find("td").eq(2).html();
        NUMERO = $(this).parents("tr").find("td").eq(3).html();
       



        Swal.fire({
            title: 'Anular Comprobante?',
            text: "¿Estás seguro de anular el Comprobante  :  " + SERIE + "-" + NUMERO+ " ?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#1ab394',
            cancelButtonColor: '#6c757d',
            confirmButtonText: 'Si, Anular !'
        }).then((result) => {
            if (result.value) {


                var ajax_data = {
                    "ID": ID,
                    "TIPO_COMPROBANTE": TIPO_COMPROBANTE,
                    "SERIE": SERIE,
                    "NUMERO": NUMERO


                };

                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Facturacion.asmx/Anular_Comprobante',
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

                            Swal.fire('Anulado !', 'El Comprobante ha sido Anulado.', 'success');
                        }
                        else
                        {
                            Swal.fire('Error!', 'El Comprobante no ha sido Anulado..!', 'error')
                        }
                        $('#Tabla_Comprobantes').dataTable().fnClearTable();
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


    $('#ddltipo_comprobante').change(function () {

        $('#ddlserie').empty().append('<option value=0> << SELECCIONAR >> </option>');

        var TIPO_DOCUMENTO = $('#ddltipo_comprobante').val();

        var ajax_data = { "TIPO_DOCUMENTO": TIPO_DOCUMENTO };

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener_Series',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlserie').append('<option value="' + data[i].SERIE + '">' + data[i].SERIE + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });

      
       
        if (TIPO_DOCUMENTO == '07' || TIPO_DOCUMENTO == '08')//nota de credito y debito
        {
            $('#div_buscar_orden_Servicio').hide();
            $('#div_buscar_factura').show();
        }
        else
        {
            $('#div_buscar_orden_Servicio').show();
            $('#div_buscar_factura').hide();
        }

      
        







    });
    $('#ddltipo_comprobante_buscar').change(function () {

        $('#ddlserie_buscar').empty().append('<option value=0> << SELECCIONAR >> </option>');



        var TIPO_DOCUMENTO = $('#ddltipo_comprobante_buscar').val();

        var ajax_data = { "TIPO_DOCUMENTO": TIPO_DOCUMENTO };

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener_Series',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlserie_buscar').append('<option value="' + data[i].SERIE + '">' + data[i].SERIE + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });

    $('#ddltipo_comprobante_buscar2').change(function () {

        $('#ddlserie_buscar2').empty().append('<option value=0> << SELECCIONAR >> </option>');



        var TIPO_DOCUMENTO = $('#ddltipo_comprobante_buscar2').val();

        var ajax_data = { "TIPO_DOCUMENTO": TIPO_DOCUMENTO };

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener_Series',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlserie_buscar2').append('<option value="' + data[i].SERIE + '">' + data[i].SERIE + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });
   


    function OBTENER_COMBO_TIPO_DOCUMENTO() {

        $('#ddltipo_comprobante').empty().append('<option value=0> << SELECCIONAR >> </option>');
        $('#ddltipo_comprobante_buscar').empty().append('<option value=0> << SELECCIONAR >> </option>');
       
        
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener_Tipo_Comprobantes',
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddltipo_comprobante').append('<option value="' + data[i].CODIGO + '">' + data[i].TIPO_COMPROBANTE + '</option>');
                    $('#ddltipo_comprobante_buscar').append('<option value="' + data[i].CODIGO + '">' + data[i].TIPO_COMPROBANTE + '</option>');
                    
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });


    }
    function OBTENER_COMBO_FORMA_PAGO() {

        $('#ddlforma_pago').empty().append('<option value=0> << SELECCIONAR >> </option>');
      

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Obtener_Forma_Pago',
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlforma_pago').append('<option value="' + data[i].ID + '">' + data[i].DESCRIPCION + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });


    }
   
  


    function validar_input_vacios() {
        /*Eliminar las clases de error*/

        $("#ddltipo_comprobante").removeClass('error_campo_vacio');
        $("#ddlserie").removeClass('error_campo_vacio');
        $("#txtnrodo").removeClass('error_campo_vacio');
        $("#ddlforma_pago").removeClass('error_campo_vacio');
        $("#ddltipo_documento_buscar_cliente").removeClass('error_campo_vacio');
        $("#txtnrodoc_buscar_cliente").removeClass('error_campo_vacio');
        $("#txtrazon_social_buscar_cliente").removeClass('error_campo_vacio');
        $("#txtdireccion").removeClass('error_campo_vacio');
        $('#txttoal_general').removeClass('error_campo_vacio');

        var validar = 0;

        var TIPO_COMPROBANTE = $("#ddltipo_comprobante").val();
        var SERIE = $("#ddlserie").val();
        var NRO_ORDEN = $("#txtnrodo").val();
        var FORMA_PAGO = $("#ddlforma_pago").val();
        var TIPO_DOC_CLIENTE = $("#ddltipo_documento_buscar_cliente").val();
        var NRO_DOC_CLIENTE = $("#txtnrodoc_buscar_cliente").val();
        var RAZON_SOCIAL_CLIENTE = $("#txtrazon_social_buscar_cliente").val();
        var DIRECCION = $("#txtdireccion").val();
        var TOTAL_GENEREAL = $(".precio").val();




        if (TIPO_COMPROBANTE == '0') {
            validar = 1;

            alertify.error('Debe seleccionar el campo <b> Tipo Comprobante </b>');
            $("#ddltipo_comprobante").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#ddltipo_comprobante").removeClass('error_campo_vacio'); }

        if (SERIE == 'B') {
            validar = 1;

            alertify.error('Debe seleccionar el campo <b> Serie </b> ');
            $("#ddlserie").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#ddlserie").removeClass('error_campo_vacio'); }

        //if (NRO_ORDEN == '') {
        //    validar = 1;

        //    alertify.error('El Campo <b> Orden de Servicio  </b> no debe estar vacio.!');
        //    $("#txtnrodo").addClass('error_campo_vacio');
        //    return validar;
        //}
        //else { $("#txtnrodo").removeClass('error_campo_vacio'); }

        if (FORMA_PAGO == '0') {
            validar = 1;

            alertify.error('Debe seleccionar el campo <b> Forma de Pago  </b> ');
            $("#ddlforma_pago").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#ddlforma_pago").removeClass('error_campo_vacio'); }

        if (TIPO_DOC_CLIENTE == 'B') {
            validar = 1;

            alertify.error('Debe seleccionar el campo <b> Tipo Doc   </b> ');
            $("#ddltipo_documento_buscar_cliente").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#ddltipo_documento_buscar_cliente").removeClass('error_campo_vacio'); }

        if (NRO_DOC_CLIENTE == '') {
            validar = 1;

            alertify.error('El Campo <b> Nro Doc  </b> no debe estar vacio.!');
            $("#txtnrodoc_buscar_cliente").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtnrodoc_buscar_cliente").removeClass('error_campo_vacio'); }

        if (RAZON_SOCIAL_CLIENTE == '') {
            validar = 1;

            alertify.error('El Campo <b> Razon Social  </b> no debe estar vacio.!');
            $("#txtrazon_social_buscar_cliente").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtrazon_social_buscar_cliente").removeClass('error_campo_vacio'); }

        if (DIRECCION == '') {
            validar = 1;

            alertify.error('El Campo <b> Direccion  </b> no debe estar vacio.!');
            $("#txtdireccion").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtdireccion").removeClass('error_campo_vacio'); }

        if (TOTAL_GENEREAL == '') {
            validar = 1;

            alertify.error('El <b> Precio  </b> no debe estar vacio.!');
            $(".precio").addClass('error_campo_vacio');
            return validar;
        }
        else { $(".precio").removeClass('error_campo_vacio'); }

        

        return validar;
    }
});


function funcion(e, elemento) {
  
   
    var subtotal = elemento.value;
    var igv = (elemento.value * 18) / 100;
    var total = parseFloat(elemento.value) + parseFloat(igv);

    $(elemento).parent().parent().find("td").eq(7).html(igv.toFixed(2));
    $(elemento).parent().parent().find("td").eq(8).html(total.toFixed(2));
    $(elemento).parent().parent().find("td").eq(6).html(subtotal);
    var rows = $("#Tabla_Detalle_Factura").dataTable().fnGetNodes();

    var suma = 0; var suma_subtotal = 0; var suma_igv = 0;
    for (var i = 0; i < rows.length; i++) {
      
     
        suma = suma + parseFloat($(rows[i]).find("td:eq(8)").html());
        suma_subtotal = suma_subtotal + parseFloat($(rows[i]).find("td:eq(6)").html());
        suma_igv = suma_igv + parseFloat($(rows[i]).find("td:eq(7)").html());
    }

    $('#txtsubtotal_general').html('Sub total: ' + suma_subtotal.toFixed(2));
    $('#txtsubtotal_igv').html('Igv: ' + suma_igv.toFixed(2));
    $('#txttoal_general').html('Total: ' + suma.toFixed(2));
}