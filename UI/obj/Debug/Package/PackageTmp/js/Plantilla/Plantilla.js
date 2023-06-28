$(document).ready(function () {

    var Body = $('body');
    Body.addClass('preloader-site');

});

$(window).on("load", function () {





    /* OBTENER PARAMETRO URL */
    function parametroURL(_par) {
        var _p = null;
        if (location.search) location.search.substr(1).split("&").forEach(function (pllv) {
            var s = pllv.split("="), //separamos llave/valor
                ll = s[0],
                v = s[1] && decodeURIComponent(s[1]); //valor hacemos encode para prevenir url encode
            if (ll == _par) { //solo nos interesa si es el nombre del parametro a buscar
                if (_p == null) {
                    _p = v; //si es nula, quiere decir que no tiene valor, solo textual
                } else if (Array.isArray(_p)) {
                    _p.push(v); //si ya es arreglo, agregamos este valor
                } else {
                    _p = [_p, v]; //si no es arreglo, lo convertimos y agregamos este valor
                }
            }
        });
        return _p;
    }

    var Codigo = parametroURL('Codigo');


   

   

  
    var ajax_data = { "CODIGO": Codigo };
    $.ajax({
        type: "POST",
        url: '../ServiciosWeb/SW_Plantilla.asmx/Obtener_Datos_Plantilla',
        data: JSON.stringify(ajax_data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        beforeSend: function () {
            //$('body').addClass('loading2');

        },
        success: function (respuesta) {
            var datos = (typeof respuesta.d) == 'string' ?
                eval('(' + respuesta.d + ')') :
                respuesta.d;

            //if (datos.length == 0) {
            //    window.location.href = "../Error.aspx";
            //}
            //else {
                for (var i = 0; i < datos.length; i++) {

                    $("#codigo_alumno").text(datos[i].CODIGO);
                    $("#nombre_alumno").text(datos[i].NOMBRES);
                    $("#documento_alumno").text(datos[i].NRO_DOCUMENTO);
                    $("#nivel_alumno").text(datos[i].NIVEL);
                    $("#grado_alumno").text(datos[i].GRADO);
                    $("#seccion_alumno").text(datos[i].SECCION);
                    $('#img_alumno').prop("src", datos[i].RUTA_FOTO_ALUMNO);

                  

               // }

                /* $('body').removeClass('loading2');*/ //Removemos la clase loading
                $('.preloader-wrapper').fadeOut();
                $('body').removeClass('preloader-site');
            }





        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });

    // window.location.href = "Tarjeta.aspx";
    /*  }*/

 



});