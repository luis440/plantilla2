$(document).ready(function () {


    var ID = ($.session.get('SESSION_ID'));
    var USUARIO = ($.session.get('SESSION_USUARIO'));
    var NOMBRES = ($.session.get('SESSION_NOMBRES'));
    var PERFIL = ($.session.get('SESSION_PERFIL'));
    var APELLIDOS = ($.session.get('SESSION_APELLIDOS'));
    var CORREO = ($.session.get('SESSION_CORREO'));


    OBTENER_DEPARTAMENTO();


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

    function BUSCAR_CLIENTES() {

        var TIPO_DOC = $('#ddltipo_documento_buscar').val();
        var NRO_DOC = $('#txtnro_documento_buscar').val();
        var RAZON_SOCIAL = $('#txtrazon_social_buscar').val();
        var ESTADO = $('#ddlestado_buscar').val();

        var table = $('#Tabla_Clientes').DataTable();
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


                    $('#Tabla_Clientes').dataTable({
                        columnDefs: [
                            { className: 'text-center', targets: [0, 1, 2, 3, 4, 5, 6] }

                        ],
                        destroy: true

                    }).fnAddData([

                        datos[i].ID,
                        datos[i].TIPO_DOC,
                        datos[i].NUM_DOC,
                        datos[i].RAZON_SOCIAL,  
                        datos[i].ESTADO,
                        "<img src='../img/editar_2.png' class='editar' style='width:20px;height:20px' />",
                        "<img src='../img/ELIMINAR.png' class='eliminar' style='width:20px;height:20px'/>"
                    ]);

                }
                $('body').removeClass('loading'); //Removemos la clase loading
                $("#Tabla_Clientes").show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                // alert(error.Message);
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });


    }

    $("#btnnuevo").click(function (e) {
        $("#Titulo_Panel").text('Nuevo Cliente');
        $("#ddltipo_documento").val('RUC');
        $("#txtnrodoc").val('');
        $("#txtrazon_social").val('');
        $("#txtdomicilio_1").val('');
        $("#txtdomicilio_2").val('');
        $("#txttelefono").val('');
        $("#txtcelular").val('');
        $("#txtcorreo").val('');
        $("#txtobservacion").val('');
        $("#ddlestado").val('A');

        $('#ddldepartamento').val('0');
        $('#ddlprovincia').empty().append('<option value=0> << SELECCIONAR >> </option>');
        $('#ddldistrito').empty().append('<option value=0> << SELECCIONAR >> </option>');


        $("#div_estado_buscar").hide();
        $("#btnGuardar").show();
        $("#btnActualizar").hide();

        $('#modal_nuevo').modal();

        /*Eliminar las clases de error*/
        $("#txtnrodoc").removeClass('error_campo_vacio');
        $("#txtrazon_social").removeClass('error_campo_vacio');
       



    });

    $("#btnbuscar").click(function (e) {

        BUSCAR_CLIENTES();

    });

    $(document).on('click', '.eliminar', function (e) {
        var ID, NOMBRES;
        ID = $(this).parents("tr").find("td").eq(0).html();
        NOMBRES = $(this).parents("tr").find("td").eq(3).html();




        Swal.fire({
            title: 'Eliminar Registro?',
            text: "¿Estás seguro de eliminar el Cliente  :  " + NOMBRES + " ?",
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
                    url: '../ServiciosWeb/SW_Clientes.asmx/Eliminar_Clientes',
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
                        $('#Tabla_Clientes').dataTable().fnClearTable();
                        BUSCAR_CLIENTES();
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

                    


                    $("#txtcodigo").val(datos[i].ID);
                    $("#ddltipo_documento").val(datos[i].TIPO_DOC);
                    $("#txtnrodoc").val(datos[i].NUM_DOC);
                    $("#txtrazon_social").val(datos[i].RAZON_SOCIAL);
                    $("#txtdomicilio_1").val(datos[i].DOMICILIO1);
                    $("#txtdomicilio_2").val(datos[i].DOMICILIO2);
                    $("#txtdomicilio_2").val(datos[i].DOMICILIO2);
                    $("#ddlestado").val(datos[i].ESTADO);
                    $("#txttelefono").val(datos[i].TELEFONO);
                    $("#txtcelular").val(datos[i].CELULAR);
                    $("#txtcorreo").val(datos[i].CORREO);
                    $("#ddldepartamento").val(datos[i].DEPARTAMENTO);                  
                    $("#txtobservacion").val(datos[i].OBSERVACION);
                   
                
                    var  departamento = datos[i].DEPARTAMENTO;
                    var provincia = datos[i].PROVINCIA;
                    var distrito = datos[i].DISTRITO;
                    OBTENER_DEPARTAMENTO_PROVINCIA_DISTRITO(departamento, provincia, distrito);
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

            var TIPO_DOC = $("#ddltipo_documento").val();
            var NUM_DOC = $("#txtnrodoc").val();
            var RAZON_SOCIAL = $("#txtrazon_social").val();
            var DOMICILIO1 = $("#txtdomicilio_1").val();
            var DOMICILIO2 = $("#txtdomicilio_2").val();
            var TELEFONO = $("#txttelefono").val();
            var CELULAR = $("#txtcelular").val();
            var CORREO = $("#txtcorreo").val();
            var DEPARTAMENTO = $("#ddldepartamento").val();
            var PROVINCIA = $("#ddlprovincia").val();
            var DISTRITO = $("#ddldistrito").val();
            var OBSERVACION = $("#txtobservacion").val();
            var USUARIO_CREACION = USUARIO;
          

            //  var EMPRESA = $("#ddlempresa").val();
            // var USUARIO_CREACION = $.session.get('SESSION_USUARIO');

            var ajax_data = {
                "TIPO_DOC": TIPO_DOC,
                "NUM_DOC": NUM_DOC,
                "RAZON_SOCIAL": RAZON_SOCIAL,
                "DOMICILIO1": DOMICILIO1,
                "DOMICILIO2": DOMICILIO2,
                "TELEFONO": TELEFONO,
                "CELULAR": CELULAR,
                "CORREO": CORREO,
                "DEPARTAMENTO": DEPARTAMENTO,
                "PROVINCIA": PROVINCIA,
                "DISTRITO": DISTRITO,
                "OBSERVACION": OBSERVACION,
                "USUARIO_CREACION": USUARIO_CREACION
                
            };
            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Clientes.asmx/Grabar_Clientes',
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
                    BUSCAR_CLIENTES();

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
            var TIPO_DOC = $("#ddltipo_documento").val();
            var NUM_DOC = $("#txtnrodoc").val();
            var RAZON_SOCIAL = $("#txtrazon_social").val();
            var DOMICILIO1 = $("#txtdomicilio_1").val();
            var DOMICILIO2 = $("#txtdomicilio_2").val();
            var TELEFONO = $("#txttelefono").val();
            var CELULAR = $("#txtcelular").val();
            var CORREO = $("#txtcorreo").val();
            var DEPARTAMENTO = $("#ddldepartamento").val();
            var PROVINCIA = $("#ddlprovincia").val();
            var DISTRITO = $("#ddldistrito").val();
            var OBSERVACION = $("#txtobservacion").val();
            var USUARIO_MODIFICACION = USUARIO;
            var ESTADO = $("#ddlestado").val();

            var ajax_data = {
                "ID": ID,
                "TIPO_DOC": TIPO_DOC,
                "NUM_DOC": NUM_DOC,
                "RAZON_SOCIAL": RAZON_SOCIAL,
                "DOMICILIO1": DOMICILIO1,
                "DOMICILIO2": DOMICILIO2,
                "TELEFONO": TELEFONO,
                "CELULAR": CELULAR,
                "CORREO": CORREO,
                "DEPARTAMENTO": DEPARTAMENTO,
                "PROVINCIA": PROVINCIA,
                "DISTRITO": DISTRITO,
                "OBSERVACION": OBSERVACION,
                "USUARIO_MODIFICACION": USUARIO_MODIFICACION,
                "ESTADO": ESTADO
            };

            $.ajax({
                type: "POST",
                url: '../ServiciosWeb/SW_Clientes.asmx/Actualizar_Clientes',
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
                    BUSCAR_CLIENTES();
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





    function OBTENER_DEPARTAMENTO() {

        $('#ddldepartamento').empty().append('<option value=0> << SELECCIONAR >> </option>');
        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Clientes.asmx/Obtener_Departamento',
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

                    $('#ddldepartamento').append('<option value="' + datos[i].DEPARTAMENTO + '">' + datos[i].DESCRIPCION + '</option>');

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

    $('#ddldepartamento').change(function () {

        $('#ddlprovincia').empty().append('<option value=0> << SELECCIONAR >> </option>');
        $('#ddldistrito').empty().append('<option value=0> << SELECCIONAR >> </option>');
        var DEPARTAMENTO = $('#ddldepartamento').val();

        var ajax_data = { "DEPARTAMENTO": DEPARTAMENTO };

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Clientes.asmx/Obtener_Provincia',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlprovincia').append('<option value="' + data[i].PROVINCIA + '">' + data[i].DESCRIPCION + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });

    $('#ddlprovincia').change(function () {

        $('#ddldistrito').empty().append('<option value=0> << SELECCIONAR >> </option>');

        var DEPARTAMENTO = $('#ddldepartamento').val();
        var PROVINCIA = $('#ddlprovincia').val();

        var ajax_data = { "DEPARTAMENTO": DEPARTAMENTO, "PROVINCIA": PROVINCIA };



        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Clientes.asmx/Obtener_Distrito',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddldistrito').append('<option value="' + data[i].DISTRITO + '">' + data[i].DESCRIPCION + '</option>');
                }


                $('body').removeClass('loading');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                swal("Error!", "Por favor, prueba los pasos siguientes: <b></br>1.      Cierre todas sus sesiones y vuelva a ingresar al sistema. </br>2.      Compruebe su conexión a Internet.</br> 3.      Reinicie su equipo.</br> 4.      En caso no resuelva la situación, envíe un correo a atencionalcliente@renzocosta.com <b/> ", "error");
            }
        });







    });

    function OBTENER_DEPARTAMENTO_PROVINCIA_DISTRITO(departamento, provincia, distrito) {

        $('#ddlprovincia').empty().append('<option value=0> << SELECCIONAR >> </option>');
        $('#ddldistrito').empty().append('<option value=0> << SELECCIONAR >> </option>');
        var ajax_data = { "DEPARTAMENTO": departamento };

        $.ajax({
            type: "POST",
            url: '../ServiciosWeb/SW_Clientes.asmx/Obtener_Provincia',
            data: JSON.stringify(ajax_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            beforeSend: function () { $('body').addClass('loading'); },
            success: function (respuesta) {
                var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                for (var i = 0; i < data.length; i++) {

                    $('#ddlprovincia').append('<option value="' + data[i].PROVINCIA + '">' + data[i].DESCRIPCION + '</option>');
                }

                $('#ddlprovincia').val(provincia);
                $('body').removeClass('loading');

                var ajax_data = { "DEPARTAMENTO": departamento, "PROVINCIA": provincia };



                $.ajax({
                    type: "POST",
                    url: '../ServiciosWeb/SW_Clientes.asmx/Obtener_Distrito',
                    data: JSON.stringify(ajax_data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    beforeSend: function () { $('body').addClass('loading'); },
                    success: function (respuesta) {
                        var data = (typeof respuesta.d) === 'string' ? eval('(' + respuesta.d + ')') : respuesta.d;

                        for (var i = 0; i < data.length; i++) {

                            $('#ddldistrito').append('<option value="' + data[i].DISTRITO + '">' + data[i].DESCRIPCION + '</option>');
                        }

                        $('#ddldistrito').val(distrito);
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
