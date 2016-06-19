$(document).ready(function (e) {
    $('#datePicker_f_nacimiento').datepicker({
        format: 'yyyy-mm-dd',
        language: "es"
    });


    $('#btn_enviar').click(function (e) {
        $.ajax({
            type: "post",
            url: $('#frm_cliente').attr('action'),
            data: {
                'bean.nombres': $('#txt_nombre_guardar').val(), 'bean.ape_paterno': $('#txt_ape_paterno').val(),
                'bean.ape_materno': $('#txt_ape_materno').val(), 'bean.dni': $('#txt_dni').val(), 'bean.direccion': $('#txt_direccion').val(),
                'bean.correo': $('#txt_email').val(), 'bean.telefono': $('#txt_telefono').val(), 'bean.fecha_nacimiento': $('#txt_fecha_nacimiento').val()
            },
            dataType: 'json',
            success: function (resultado) {
                //console.log(resultado.result);
                //$('#txt_cod_tra_guardar').val(resultado.result);
                //$('#ModalLoading').modal('hide');

                if (resultado.result != "") {
                    $('#tab2primary #frm_cliente #txt_cod_soc_cliente').val(resultado.result);
                    var mensaje = "<div class='alert alert-success'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>"
                    + "Se registraron los datos del Cliente " + resultado.result + "</div>";
                    $('#mensajeAlerta').html(mensaje);
                }
            },
            error: function (xrh, ajaxOptions, thrownError) {
                alert("Error status code: " + xrh.status);
                alert("Error details: " + thrownError);
            }
        });
        return false;
    });


    $(function (e) {

        $.ajax({
            url: '/Cliente/ListarCliente',
            type: 'post',
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (resultado) {
                console.log(resultado.result);

                ListarCliente(resultado.result);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Error status code: " + xhr.status);
                alert("Error details: " + thrownError);
            }

        });
    });



    function ListarCliente(data) {
        $('#rellenar').html('');
        var trHTML = '';
        if (data.length > 0) {
            for (var i = 0; i < data.length; i++) {

                trHTML += '<tr><td>'
                    + data[i]['idCliente']
                    + '</td><td>'
                    + data[i]['nombres']
                    + '</td><td>'
                    + data[i]['dni']
                    + '</td><td>'
                    + data[i]['correo']
                    + '</td><td>'
                    + data[i]['telefono']

                    + '</td><td><a data-id="' + data[i]['idCliente'] + '" class="RecuperarPersonaAsociada btn btn-info"><span class="glyphicon glyphicon-edit"></span> </a></td>'
                    + '</td><td><a  data-id="' + data[i]['idCliente'] + '" class="EliminarPersonaAsociada btn btn-danger"><span class="glyphicon glyphicon-trash" ></span></a></td></tr>';
            }
            $('#rellenar').append(trHTML);
        }
        $('#dataTables_example_length').css('display', 'none');
        $('#dataTables_example_filter').css('display', 'none');
    }



});