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
        $('#frmSeguridad').attr('action', '/Seguridad/Intranet');
    });

    /* function IniciarSession() {
 
     }*/
});