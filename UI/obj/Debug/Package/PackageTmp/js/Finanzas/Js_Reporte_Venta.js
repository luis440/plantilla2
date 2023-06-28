$(document).ready(function () {


    var ID = ($.session.get('SESSION_ID'));
    var USUARIO = ($.session.get('SESSION_USUARIO'));
    var NOMBRES = ($.session.get('SESSION_NOMBRES'));
    var PERFIL = ($.session.get('SESSION_PERFIL'));
    var APELLIDOS = ($.session.get('SESSION_APELLIDOS'));
    var CORREO = ($.session.get('SESSION_CORREO'));


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


    function BUSCAR() {

        var FEC_INI = $('#fecha_inicio_comprobante_buscar').val();
        var FEC_FIN = $('#fecha_fin_comprobante_buscar').val();
        var RAZON_SOCIAL = $('#txtrazon_social_buscar').val();
        var ESTADO = $('#ddlestado_buscar').val();

        var table = $('#Tabla_Reporte_Ventas').DataTable();
        table.clear().draw();

        var ajax_data = { "FEC_INI": FEC_INI, "FEC_FIN": FEC_FIN, "RAZON_SOCIAL": RAZON_SOCIAL, "ESTADO": ESTADO };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Facturacion.asmx/Reporte_Ventas',
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


                    $('#Tabla_Reporte_Ventas').dataTable({
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6,7] }

                        ],
                        dom: 'Bfrtip',
                        buttons: [
                            'copyHtml5',
                            'excelHtml5',
                            'csvHtml5',
                            'pdfHtml5'
                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].FECHA,
                        datos[i].DESCRIPCION,
                        datos[i].NUMERO,
                        datos[i].TIPO_DOC_CLIENTE,
                        datos[i].NUM_DOC_CLIENTE,
                        datos[i].NOMBRE_CLIENTE,
                        datos[i].TOTAL_IGV,
                        datos[i].TOTAL_GENERAL
                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#Tabla_Reporte_Ventas").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });


    }

    $("#btnbuscar").click(function (e) {

        BUSCAR();

    });




    $("#btncerrar").click(function (e) {

        window.location.href = "Principal.aspx";

    });



});
