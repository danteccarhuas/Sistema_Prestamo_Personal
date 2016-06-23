$(document).ready(function (e) {

    /* Valida las etiquedas del formulario */
    /*$("#frmSeguridad").bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            "txtuser_name": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Usuario por favor.'
                    }
                }
            },
            "txt_password": {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Password por favor.'
                    }
                }
            }
        }
    });*/

    /*$('#frmSeguridad').on('success.form.bv', function (e) {
        e.preventDefault();
       // IniciarSession();
    });*/

    $('#btn_ingresar').click(function (e) {
        //$('#frmSeguridad').attr('action', '/Seguridad/MenuPrincipal');
        //$('#frmSeguridad').attr('action', '/Seguridad/Intranet');
        IniciarSession();
        return false;
    });

    /* function IniciarSession() {
 
     }*/
});

function IniciarSession() {
    var login = $('#txtuser_name').val();
    var password = $('#txt_password').val();
    $.ajax({
        type: "post",
        url: $('#frmSeguridad').attr('action'),
        data: { 'bean.login': login, 'bean.password': password },
        dataType: 'json',
        success: function (result) {
            var resultado = result.resultado;
            if (resultado == 1) {
                location.href = "/Seguridad/MenuPrincipal";
            }
        },
        error: function (xrh, ajaxOptions, thrownError) {
            alert("Error status code: " + xrh.status);
            alert("Error details: " + thrownError);
        }
    });
}