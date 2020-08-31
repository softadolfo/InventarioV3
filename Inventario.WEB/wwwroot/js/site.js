$(function () {

    $(document).on('click', '.showLoading', function (ev) {
        var customMessage = $(this).data("loading-text");
        MostrarLoading(customMessage);
    });

    /*Inicializa los mensajes de alerta*/
    var error = $("#txtMensajeError").val()
    if (error != "" && error != undefined) {
        Swal.fire({
            type: 'error',
            title: 'Error',
            html: error,
        });
    }
    var mensaje = $("#txtMensajeExito").val();
    if (mensaje != "" && mensaje != undefined) {
        Swal.fire({
            type: 'success',
            title: 'Éxito',
            html: mensaje
        });
    }

    var warning = $("#txtWarningMessage").val();
    if (warning != "" && warning != undefined) {
        Swal.fire({
            type: 'warning',
            html: warning
        });
    }

    InitSummerNote(500);

    $('[data-toggle="tooltip"]').tooltip(); 
});

function InitSummerNote(alto) {
    $('.summernote').summernote({
        height: alto,
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'italic', 'underline', 'clear']],
            //['fontname', ['fontname']],
            ['fontsize', ['fontsize']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            //['misc', ['codeview']]
            ['height', ['height']],
            ['table', ['table']],
            ['insert', ['link']],
            //['insert', ['picture']],
            //[‘Insert’, [‘picture’]],
            //['view', ['fullscreen', 'codeview']]
            ['view', ['codeview']]
            //['help', ['help']]
        ],
        lang: "es-ES"
    });
}

function MostrarLoading(mensaje) {
    if (mensaje === undefined) {
        mensaje = "Cargando...";
    }
    Swal.fire({
        allowOutsideClick: false,
        title: mensaje,
        onBeforeOpen: function () {
            Swal.showLoading();
        }
    });
}

function CerrarLoading(callback) {
    if (callback != null && typeof (callback) == "function") {
        sweetAlert.close(null, function () { callback(); });
    } else {
        sweetAlert.close();
    }
    //$("#ventana_loading").hide().remove();
}


function errorCommonManager(ajaxError) {
    switch (ajaxError.status) {
        case 401:
            Swal.fire({
                type: 'warning',
                html: "Su sesión ha caducado, porfavor recargue la página y vuelva a iniciar sesión."
            });
            break;
        default:
            Swal.fire({
                type: 'error',
                html: "Se ha producido un error durante la operación. Por favor inténtelo más tarde o contacte a su servicio de soporte técnico."
            });
            break;
    }
}