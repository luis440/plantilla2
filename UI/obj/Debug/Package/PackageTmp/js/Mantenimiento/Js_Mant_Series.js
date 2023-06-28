$(document).ready(function () {


    var ID = ($.session.get('SESSION_ID'));
    var USUARIO = ($.session.get('SESSION_USUARIO'));
    var NOMBRES = ($.session.get('SESSION_NOMBRES'));
    var PERFIL = ($.session.get('SESSION_PERFIL'));
    var APELLIDOS = ($.session.get('SESSION_APELLIDOS'));
    var CORREO = ($.session.get('SESSION_CORREO'));




    OBTENER_TIPO_COMPROBANTE();
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

    function BUSCAR_SERIES() {

        var TIPO_COMPROBANTE = $('#ddltipo_comprobante_buscar').val();
        var SERIE = $('#txtserie_buscar').val();     
        var ESTADO = $('#ddlestado_buscar').val();

        var table = $('#Tabla_Series').DataTable();
        table.clear().draw();

        var ajax_data = { "TIPO_COMPROBANTE": TIPO_COMPROBANTE, "SERIE": SERIE, "ESTADO": ESTADO };
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Series.asmx/Buscar_Series',
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


                    $('#Tabla_Series').dataTable({
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].TIPO_DOCUMENTO,
                        datos[i].SERIE,
                        datos[i].NUMERO,
                        datos[i].ESTADO,
                        "<img src='../img/editar_2.png' class='editar' style='width:20px;height:20px' />",
                        "<img src='../img/ELIMINAR.png' class='eliminar' style='width:20px;height:20px'/>"
                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#Tabla_Series").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> ", "error");
            }
        });


    }

    $("#btnnuevo").click(function (e) {
        $("#Titulo_Panel").text('Nueva Serie');
        $("#ddltipo_comprobante").val('B');
        $("#txtserie").val('');
        $("#txtnumero").val('');
       
        $("#ddlestado").val('A');

        


        $("#div_estado_buscar").hide();
        $("#btnGuardar").show();
        $("#btnActualizar").hide();

        $('#modal_nuevo').modal();

        /*Eliminar las clases de error*/
        $("#txtnrodoc").removeClass('error_campo_vacio');
        $("#txtrazon_social").removeClass('error_campo_vacio');

        OBTENER_EMPRESA();


    });

    $("#btnbuscar").click(function (e) {

        BUSCAR_SERIES();

    });

    $(document).on('click', '.eliminar', function (e) {
        var ID, NOMBRES;
        ID = $(this).parents("tr").find("td").eq(0).html();
        NOMBRES = $(this).parents("tr").find("td").eq(2).html();




        Swal.fire({
            title: 'Eliminar Registro?',
            text: "¿Estás seguro de eliminar la Serie  :  " + NOMBRES + " ?",
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
                    url: '../ServiciosWeb/SW_Series.asmx/Eliminar_Serie',
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
                        $('#Tabla_Series').dataTable().fnClearTable();
                        BUSCAR_SERIES();
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


        /*Eliminar las clases de error*/
        $("#txtapellidos").removeClass('error_campo_vacio');
        $("#txtnombres").removeClass('error_campo_vacio');
        $("#txt_usuario").removeClass('error_campo_vacio');
        $("#txtclave").removeClass('error_campo_vacio');


        $("#Titulo_Panel").text('Actualizar Usuario');
        $("#div_estado_buscar").show();

        $("#btnGuardar").hide();
        $("#btnActualizar").show();

        var ajax_data = {
            "ID": $(this).parents("tr").find("td").eq(0).html(),
        };


        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Series.asmx/Obtener_Series',
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
                    $("#ddlempresa").val(datos[i].EMPRESA);
                    $("#ddltipo_comprobante").val(datos[i].TIPO_DOCUMENTO);
                    $("#txtserie").val(datos[i].SERIE);
                    $("#txtnumero").val(datos[i].NUMERO);
                    $("#ddlestado").val(datos[i].ESTADO);
                   

               
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




        var resultado_validacion = validar_input_vacios();



        if (resultado_validacion == 0) {

         
            var TIPO_COMPROBANTE = $("#ddltipo_comprobante").val();
            var SERIE = $("#txtserie").val();
            var NUMERO = $("#txtnumero").val();         
            var USUARIO_CREACION = USUARIO;



            var ajax_data = {
               
                "TIPO_COMPROBANTE": TIPO_COMPROBANTE,
                "SERIE": SERIE,
                "NUMERO": NUMERO,                
                "USUARIO_CREACION": USUARIO_CREACION

            };
            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Series.asmx/Grabar_Series',
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
                    BUSCAR_SERIES();

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


        if (resultado_validacion == 0) {

            var ID = $("#txtcodigo").val();
           
            var TIPO_COMPROBANTE = $("#ddltipo_comprobante").val();
            var SERIE = $("#txtserie").val();
            var NUMERO = $("#txtnumero").val();        
            var USUARIO_MODIFICACION = USUARIO;
            var ESTADO = $("#ddlestado").val();

            var ajax_data = {
                "ID": ID,
               
                "TIPO_COMPROBANTE": TIPO_COMPROBANTE,
                "SERIE": SERIE,
                "NUMERO": NUMERO,               
                "USUARIO_MODIFICACION": USUARIO_MODIFICACION,
                "ESTADO": ESTADO
            };

            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Series.asmx/Actualizar_Series',
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
                    BUSCAR_SERIES();
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

        $("#txtnrodoc").removeClass('error_campo_vacio');
        $("#txtrazon_social").removeClass('error_campo_vacio');



        var validar = 0;

        var NRO_DOC = $("#txtnrodoc").val();
        var RAZON_SOCIAL = $("#txtrazon_social").val();







        if (NRO_DOC == '') {
            validar = 1;

            alertify.error('El Campo <b> Nro Doc </b> no debe estar vacio.!');
            $("#txtnrodoc").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtnrodoc").removeClass('error_campo_vacio'); }

        if (RAZON_SOCIAL == '') {
            validar = 1;

            alertify.error('El Campo <b> Razon Social </b> no debe estar vacio.!');
            $("#txtrazon_social").addClass('error_campo_vacio');
            return validar;
        }
        else { $("#txtrazon_social").removeClass('error_campo_vacio'); }




        return validar;
    }






    $("#btncerrar").click(function (e) {

        window.location.href = "Principal.aspx";

    });


    function OBTENER_TIPO_COMPROBANTE() {

        $('#ddltipo_comprobante_buscar').empty().append('<option value=0> << SELECCIONAR >> </option>');
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Series.asmx/Obtener_Tipo_Comprobante',
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

                    $('#ddltipo_comprobante_buscar').append('<option value="' + datos[i].CODIGO_TIPO_COMPROBANTE + '">' + datos[i].DESCRIPCION_TIPO_COMPROBANTE + '</option>');
                    $('#ddltipo_comprobante').append('<option value="' + datos[i].CODIGO_TIPO_COMPROBANTE + '">' + datos[i].DESCRIPCION_TIPO_COMPROBANTE + '</option>');

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
   
    function OBTENER_EMPRESA() {

        $('#ddlempresa').empty().append('<option value=0> << SELECCIONAR >> </option>');
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Series.asmx/Obtener_Empresa',
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

                    $('#ddlempresa').append('<option value="' + datos[i].CODIGO_EMPRESA + '">' + datos[i].DESCRIPCION_EMPRESA + '</option>');

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

});