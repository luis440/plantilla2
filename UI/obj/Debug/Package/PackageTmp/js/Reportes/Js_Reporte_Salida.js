$(document).ready(function () {
    /*OBTENER_NIVEL();
    
$("#btnbuscar").click(function (e) {

    BUSCAR_REPORTE_SALIDA();    
});

    function BUSCAR_REPORTE_SALIDA() {

    var FECHA_INICIO = $('#txtfecha_inicio_buscar').val();
    var FECHA_FIN = $('#txtfecha_fin_buscar').val();
    var NRO_DOC = $('#txtnro_documento_buscar').val();
        var NOMBRES = $('#txtnombres_buscar').val();
        var NIVEL = $('#ddlnivel_buscar').val();
        var GRADO = $('#ddlgrado_buscar').val();
        var SECCION = $('#ddlseccion_buscar').val();

        var table = $('#Tabla_Reporte').DataTable();
        table.clear().draw();

        var ajax_data = { "FECHA_INICIO": FECHA_INICIO, "FECHA_FIN": FECHA_FIN, "NRO_DOC": NRO_DOC, "NOMBRES": NOMBRES, "NIVEL": NIVEL, "GRADO": GRADO, "SECCION": SECCION };
    $.ajax({
        type: "POST",
        url: '../ServiciosWeb/SW_Reportes.asmx/Reporte_Salida',
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


                $('#Tabla_Reporte').dataTable({
                    
                    columnDefs: [
                        {
                            className: 'text-center',
                            targets: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
                            type: "html"
                        }

                    ],
                    destroy: true,
                   
                    responsive: true,
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
                    dom: '<"html5buttons"B>lTfgitp',
                    buttons: [
                        { extend: 'copy' },
                        { extend: 'csv' },
                        {extend: 'excel', title: 'Reporte de Salida'},
                        { extend: 'pdf', title: 'Reporte de Salida' },

                        {
                            extend: 'print',
                            customize: function (win) {
                                $(win.document.body).addClass('white-bg');
                                $(win.document.body).css('font-size', '10px');

                                $(win.document.body).find('table')
                                    .addClass('compact')
                                    .css('font-size', 'inherit');
                            }
                        }
                    ]

                }).fnAddData([

                    datos[i].CODIGO,
                    datos[i].NOMBRES,
                    datos[i].SEXO,
                    datos[i].TIPO_DOCUMENTO,
                    datos[i].NRO_DOCUMENTO,
                    datos[i].NIVEL,
                    datos[i].GRADO,
                    datos[i].SECCION,
                    datos[i].HORA,
                    datos[i].FECHA
                  
                ]);

            }
            $('body').removeClass('loading'); //Removemos la clase loading
            $("#Tabla_Reporte").show();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            // alert(error.Message);
            swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
        }
    });


    }
    */
    var NOMBRES = ($.session.get('SESSION_NOMBRES'));

    if (typeof NOMBRES === "undefined") {
        location.href = '../Login.aspx';

    }
    $('#data_1 .input-group.date').datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true,
        format: "dd/mm/yyyy"
    }).datepicker();

    $('#data_2 .input-group.date').datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true,
        format: "dd/mm/yyyy",
   
    }).datepicker();
    /*
    function OBTENER_NIVEL() {

        $('#ddlnivel_buscar').empty().append('<option value=B> << Seleccionar >> </option>');
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

                    $('#ddlnivel_buscar').append('<option value="' + datos[i].CODIGO_NIVEL + '">' + datos[i].DESCRIPCION_NIVEL + '</option>');

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

    $('#ddlnivel_buscar').change(function () {

        $('#ddlgrado_buscar').empty().append('<option value=B> << Seleccionar >> </option>');
        $('#ddlseccion_buscar').empty().append('<option value=B> << Seleccionar >> </option>');
        var NIVEL = $('#ddlnivel_buscar').val();

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

                    $('#ddlgrado_buscar').append('<option value="' + data[i].CODIGO_GRADO + '">' + data[i].DESCRIPCION_GRADO + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });

    $('#ddlgrado_buscar').change(function () {

        $('#ddlseccion_buscar').empty().append('<option value=B> << Seleccionar >> </option>');


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

                    $('#ddlseccion_buscar').append('<option value="' + data[i].CODIGO_SECCION + '">' + data[i].DESCRIPCION_SECCION + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });
    */
});
