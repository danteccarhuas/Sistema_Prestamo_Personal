$(document).ready(function (e) {

    //Activar Panel DatosTrabajador y Desactivar Panel ConsultarTrabajador
    $('#btn_nuevo').on('click', function () {
        $('#tab1').prop("disabled", true).addClass('disabled');
        $('#tab2').prop("disabled", false).removeClass('disabled');
        $('#eventotab2primary').prop("disabled", false).removeClass('disabled');/*Quitamos el disabled del tab eventotab2primary*/
        $('.nav-tabs > .active').prop("disabled", true).addClass('disabled').next('li').find('a').trigger('click');

        /*habilitar button btn_enviar*/
        $("#btn_enviar").prop("disabled", false);
    });

    //Activar Panel ConsultarTrabajador y Desactivar PanelDatosTrajador
    $('#btn_salir').on('click', function () {
        $("#frm_trabajador").data('bootstrapValidator').resetForm(true);/*Limpiamos todos los controles del formulario frm_trabajador */
        $('#tab1').prop("disabled", false).removeClass('disabled');
        $('#tab2').prop("disabled", true).addClass('disabled');
        $('.nav-tabs > .active').prop("disabled", true).addClass('disabled').prev('li').find('a').trigger('click');
        $("#mensajeAlerta").html("");
        $("#paginador").html("");/*Limpiar los numero de paginacion*/

        $("#btn_enviar").prop("disabled", false);

        $('#tab1:checked') ? initGrilla() : false;

        $('#hiddenInsert_UpdateTrabajador').val(0);/*Setear hiddenInsert_UpdateTrabajador a 0 Significar que Registrara Trabajador*/
    });

    $('#datePicker_f_nacimiento').datepicker({
        format: 'yyyy-mm-dd',
        language: "es"
    });

    $('#frm_trabajador').on('success.form.bv', function (e) {
        $('#hiddenInsert_UpdateTrabajador').val() == 0 ? RegistrarTrabajador() : ActualizarTrabajador();
        /*deshabilitar button btn_enviar*/
        $("#btn_enviar").prop("disabled", true);
        e.preventDefault();
    });

    $('#btn_buscar').click(function (e) {
        $("#paginador").html("");/*Limpiar los numero de paginacion*/
        $('#ModalLoading').modal('show');
        initGrilla();
        $('#ModalLoading').modal('hide');
    });

    /*Metodo para DarBaja Trabajador*/
    $(document).on("click", ".DarBajaTrabajador", function (e) {
        //e.preventDefault();
        $('#hiddencodtrabajador').val($(this).data('id'));
        $("#modalRemove").modal({
            keyboard: false
        });
    });

    $(".removeBtn").click(function (e) {
        $("#modalRemove").modal("hide");
        var codtrabajador = $('#hiddencodtrabajador').val();
        $.ajax({
            url: '/Trabajador/DarBajaTrabajador',
            type: 'get',
            data: { 'bean.idTrabajador': codtrabajador },
            dataType: 'json',
            success: function (result) {
                if (result.resultado != -1) {
                    $("#paginador").html("");/*Limpiar los numero de paginacion*/
                    initGrilla();
                }
            }
        });

    });

    $('#datePicker_f_nacimiento').datepicker({
        format: 'yyyy-mm-dd',
        language: "es"
    }).on('changeDate', function (e) {
        $('#frm_trabajador').bootstrapValidator(
            'revalidateField', 'bean.fecha_nacimiento');
    });

    /* Valida las etiquedas del formulario */
    $("#frm_trabajador").bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            "bean.nombres": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Nombre por favor.'
                    },
                    regexp: {
                        regexp: /^([A-Za-zñÑáéíóúüÜÁÉÍÓÚÿ\s]+)$/,
                        message: 'Solo Caracteres alfabético.'
                    }
                }
            },
            "bean.ape_paterno": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Apellido Paterno por favor.'
                    },
                    regexp: {
                        regexp: /^([A-Za-zñÑáéíóúüÜÁÉÍÓÚÿ\s]+)$/,
                        message: 'Solo Caracteres alfabético.'
                    }
                }
            },
            "bean.ape_materno": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Apellido Materno por favor.'
                    },
                    regexp: {
                        regexp: /^([A-Za-zñÑáéíóúüÜÁÉÍÓÚÿ\s]+)$/,
                        message: 'Solo Caracteres alfabético.'
                    }
                }
            },
            "bean.dni": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese DNI por favor.'
                    },
                    stringLength: {
                        min: 8,
                        max: 8,
                        message: 'Teléfono tiene 08 cifras máximo.'
                    },
                    integer: {
                        message: 'Ingrese solo números.'
                    }
                }
            },
            "bean.direccion": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Dirección por favor.'
                    }
                }
            },
            "bean.correo": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Correo Electrónico por favor.'
                    },
                    emailAddress: {
                        message: 'El Correo Electronico ingresado no es válida.'
                    }
                }
            },
            "bean.telefono": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese telefono por favor.'
                    },
                    stringLength: {
                        min: 7,
                        max: 7,
                        message: 'Teléfono tiene 07 cifras máximo.'
                    },
                    integer: {
                        message: 'Ingrese solo números.'
                    }
                }
            },
            "bean.fecha_nacimiento": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Fecha de Nacimiento por favor.'
                    },
                    date: {
                        format: 'YYYY-MM-DD',
                        message: 'La fecha de nacimiento no es valida'
                    }
                }
            },
        }
    });
});


//Var para definir la pagination de la grilla desde la BD
var paginador;
var totalPaginas;
var itemsPorPagina = 3;
var numerosPorPagina = 10;

/* Se ejecuta cuando carga por primera vez la pagina */
$(window).load(function () {
    //Verificar si Panel Consultar Trabajador esta Checked
    $('#tab1:checked') ? initGrilla() : false;

    /*Desabilitamos el tab eventotab2primary*/
	$('#eventotab2primary').click(function (event) {
	    if ($(this).hasClass('disabled')) {
	        return false;
	    }
	});

});

//Trae TotalRegistroTrabajadir desde a BD para la paginacion
function initGrilla() {
    var cod = $('#txt_codigo_buscar').val() == "" ? "" : $('#txt_codigo_buscar').val();
    var tra = $('#txt_nombre_apellido_buscar').val() == "" ? "" : $('#txt_nombre_apellido_buscar').val();
    var dni = $('#txt_dni_buscar').val() == "" ? "" : $('#txt_dni_buscar').val();
    $.ajax({
        url: '/Trabajador/TotalRegistrosTrabajador',
        type: 'get',
        data: {'bean.idTrabajador': cod, 'bean.nombres': tra, 'bean.dni': dni},
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (resultado) {
            var TotalRegistro = resultado.resultado;
            creaPaginador(TotalRegistro);
        },
        error: function (xhr, ajaxOptions, thrownError) {

            alert("Error status code: " + xhr.status);
            alert("Error details: " + thrownError);
        }
    });

}

//Crea la Paginacion con el tota de Registros Traidos anteriormente desde a BD
function creaPaginador(totalItems) {
    paginador = $(".pagination");
    totalPaginas = Math.ceil(totalItems / itemsPorPagina);
    $('<li><a href="#" class="first_link"><</a></li>').appendTo(paginador);
    $('<li><a href="#" class="prev_link">«</a></li>').appendTo(paginador);

    var pag = 0;
    while (totalPaginas > pag) {
        $('<li><a href="#" class="page_link">' + (pag + 1) + '</a></li>').appendTo(paginador);
        pag++;
    }
    if (numerosPorPagina > 1) {
        $(".page_link").hide();
        $(".page_link").slice(0, numerosPorPagina).show();
    }
    $('<li><a href="#" class="next_link">»</a></li>').appendTo(paginador);
    $('<li><a href="#" class="last_link">></a></li>').appendTo(paginador);

    paginador.find(".page_link:first").addClass("active");
    paginador.find(".page_link:first").parents("li").addClass("active");

    paginador.find(".prev_link").hide();

    paginador.find("li .page_link").click(function () {
        var irpagina = $(this).html().valueOf() - 1;
        cargaPagina(irpagina);
        return false;
    });

    paginador.find("li .first_link").click(function () {
        var irpagina = 0;
        cargaPagina(irpagina);
        return false;
    });
    paginador.find("li .prev_link").click(function () {
        var irpagina = parseInt(paginador.data("pag")) - 1;
        cargaPagina(irpagina);
        return false;
    });

    paginador.find("li .next_link").click(function () {
        var irpagina = parseInt(paginador.data("pag")) + 1;
        cargaPagina(irpagina);
        return false;
    });

    paginador.find("li .last_link").click(function () {
        var irpagina = totalPaginas - 1;
        cargaPagina(irpagina);
        return false;
    });
    cargaPagina(0);
}

//Carga a grilla con los datos paginados desde a BD
function cargaPagina(pagina) {
    var desde = pagina * itemsPorPagina;
    var cod = $('#txt_codigo_buscar').val() == "" ? ' ' : $('#txt_codigo_buscar').val();
    var tra = $('#txt_nombre_apellido_buscar').val() == "" ? "" : $('#txt_nombre_apellido_buscar').val();
    var dni = $('#txt_dni_buscar').val() == "" ? ' ' : $('#txt_dni_buscar').val();

    $.ajax({
        url: '/Trabajador/ListaTrabajador',
        type: 'get',
        data: { 'bean.idTrabajador': cod, 'bean.nombres': tra, 'bean.dni': dni, 'bean.paginador.limit': itemsPorPagina, 'bean.paginador.offset': desde },
        dataType: 'json',
        success: function (resultado) {
            var data = resultado.resultado;
            $("#rellenar").html("");
            var trHTML = '';
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    trHTML += '<tr><td>'
                        + data[i]['idTrabajador']
                        + '</td><td>'
                        + data[i]['nombres']
                        + '</td><td>'
                        + data[i]['dni']
                        + '</td><td>'
                        + data[i]['tb_usuario']['login']
                        + '</td><td>'
                        + data[i]['tb_usuario']['password']
                        + '</td><td>'
                        + data[i]['telefono']
                        + '</td><td><a data-id="' + data[i]['idTrabajador'] + '" class="RecuperarTrabajador btn btn-info"><span class="glyphicon glyphicon-edit"></span> </a></td>'
                        + '</td><td><a  data-id="' + data[i]['idTrabajador'] + '" class="DarBajaTrabajador btn btn-danger"><span class="glyphicon glyphicon-trash" ></span></a></td></tr>';
                }
                $('#rellenar').append(trHTML);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

            alert("Error status code: " + xhr.status);
            alert("Error details: " + thrownError);
        }
    });

    if (pagina >= 1) {
        paginador.find(".prev_link").show();
    }
    else {
        paginador.find(".prev_link").hide();
    }
    if (pagina < (totalPaginas - numerosPorPagina)) {
        paginador.find(".next_link").show();
    } else {
        paginador.find(".next_link").hide();
    }

    paginador.data("pag", pagina);

    if (numerosPorPagina > 1) {
        $(".page_link").hide();
        if (pagina < (totalPaginas - numerosPorPagina)) {
            $(".page_link").slice(pagina, numerosPorPagina + pagina).show();
        }
        else {
            if (totalPaginas > numerosPorPagina)
                $(".page_link").slice(totalPaginas - numerosPorPagina).show();
            else
                $(".page_link").slice(0).show();

        }
    }
    paginador.children().removeClass("active");
    paginador.children().eq(pagina + 2).addClass("active");
}

//Obtener Data Trabajador para Modificar

$(document).on("click", ".RecuperarTrabajador", function (e) {

    var codigo_trabajador = $(this).data('id');
    $.ajax({
        url: '/Trabajador/RecuperarTrabajador',
        type: 'get',
        data: { idTrabajador: codigo_trabajador },
        dataType: 'json',
        success: function (result) {

            $('#tab1').prop("disabled", true).addClass('disabled');
            $('#tab2').prop("disabled", false).removeClass('disabled');
            $('#eventotab2primary').prop("disabled", false).removeClass('disabled');/*Quitamos el disabled del tab eventotab2primary*/
            $('.nav-tabs > .active').prop("disabled", true).addClass('disabled').next('li').find('a').trigger('click');

            $("#hiddenInsert_UpdateTrabajador").val(1);//Seteamos el flag a 1, significa que se modificara los datos de Trabajador
            var data1 = result.resultado;

            //hidden para recuperar luego para el actualizar PersonaAsociada
            $('#frm_trabajador #txt_cod_tra_guardar').val(data1.idTrabajador);
            $('#frm_trabajador #txt_hiddenidUsuario').val(data1.tb_usuario.idUsuario);
            $("#frm_trabajador #txt_nombre_guardar").val(data1.nombres);
            $("#frm_trabajador #txt_ape_paterno").val(data1.ape_paterno);
            $("#frm_trabajador #txt_ape_materno").val(data1.ape_materno);
            $("#frm_trabajador #txt_dni").val(data1.dni);
            $("#frm_trabajador #txt_direccion").val(data1.direccion);
            $("#frm_trabajador #txt_email").val(data1.correo);
            $("#frm_trabajador #txt_telefono").val(data1.telefono);
            $("#frm_trabajador #txt_fecha_nacimiento").val(data1.fecha_nacimiento);
        }
    });
    e.preventDefault();
    $("#myModal").modal({
        keyboard: false,
        backdrop: 'static'

    });
});

//function RegistrarTrabajador
function RegistrarTrabajador() {
    $.ajax({
        type: "post",
        url: $('#frm_trabajador').attr('action'),
        data: {
            'bean.nombres': $('#txt_nombre_guardar').val(), 'bean.ape_paterno': $('#txt_ape_paterno').val(),
            'bean.ape_materno': $('#txt_ape_materno').val(), 'bean.dni': $('#txt_dni').val(), 'bean.direccion': $('#txt_direccion').val(),
            'bean.correo': $('#txt_email').val(), 'bean.telefono': $('#txt_telefono').val(), 'bean.fecha_nacimiento': $('#txt_fecha_nacimiento').val(),
        },
        dataType: 'json',
        success: function (resultado) {
            //console.log(resultado.result);
            //$('#txt_cod_tra_guardar').val(resultado.result);
            //$('#ModalLoading').modal('hide');

            if (resultado.result != "") {
                $('#tab2primary #frm_trabajador #txt_cod_tra_guardar').val(resultado.result);
                var mensaje = "<div class='alert alert-success'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>"
                + "Se registraron los datos del Trabajador " + resultado.result + "</div>";
                $('#mensajeAlerta').html(mensaje);
            }
        },
        error: function (xrh, ajaxOptions, thrownError) {
            alert("Error status code: " + xrh.status);
            alert("Error details: " + thrownError);
        }
    });
}


/*Actualiza Trabajador*/
function ActualizarTrabajador() {
    $('#hiddenInsert_UpdateTrabajador').val(0);/*Setear hiddenInsert_UpdateTrabajador a 0 Significar que Registrara Trabajador*/
    $('#ModalLoading').modal('show');
    $.ajax({
        type: "get",
        url: '/Trabajador/ModificarTrabajador',
        data: { 'bean.idTrabajador': $('#txt_cod_tra_guardar').val(),
                'bean.tb_usuario.idUsuario': $('#txt_hiddenidUsuario').val(),
                'bean.nombres': $('#txt_nombre_guardar').val(), 'bean.ape_paterno': $('#txt_ape_paterno').val(),
                'bean.ape_materno': $('#txt_ape_materno').val(), 'bean.dni': $('#txt_dni').val(),
                'bean.direccion': $('#txt_direccion').val(),
                'bean.correo': $('#txt_email').val(), 'bean.telefono': $('#txt_telefono').val(),
                'bean.fecha_nacimiento': $('#txt_fecha_nacimiento').val(),
        },
        contentType: false,
        dataType: 'json',
        success: function (result) {
            $('#ModalLoading').modal('hide');

            if (result.resultado != "" && result.resultado != -1) {
                var mensaje = "<div class='alert alert-success'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>"
                + "Se actualizaron los datos del Trabajador</div>";
                $('#mensajeAlerta').html(mensaje);
            }
        },
        error: function (xrh, ajaxOptions, thrownError) {
            alert("Error status code: " + xrh.status);
            alert("Error details: " + thrownError);
        }
    });
}