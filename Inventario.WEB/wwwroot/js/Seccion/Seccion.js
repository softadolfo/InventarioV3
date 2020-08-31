$(document).ready(function () {
    //valores derminados para poder hacer la carga y mostrar los modales y la tabla para mostrar los datos actualizados
    var modal = document.getElementById("modal-forms");
    var modalContent = document.getElementById("modal-content");
    var modalTitulo = document.getElementById("modal-title");
    var tableContent = document.getElementById("tableSeccion");
    //metodo para detalle obtener la seccion para guardar o eliminar
    $(document).on("click", ".detalleSeccion", function (event) {
        event.preventDefault();
        Bitworks.Ventanas.mostrarLoading();
        var url = $('#urlDetalleSeccion').val();
        var codigo = $(this).data("codigo");
        codigo = (codigo === undefined || codigo == null) ? 0 : codigo;
        $.ajax({
            url: url,
            type: 'GET',
            data: { codigo: codigo },
            success: function (resp) {
                $(modalTitulo).html(resp.titulo)
                $(modalContent).html(resp.htmlViewParial);
                $(modal).modal({
                    backdrop: true,
                    keyboard: false
                });
                utilidadesBitworks.attachForm("formDetalle");
                inicializarEventFunction();
                Bitworks.Ventanas.ocultarLoading();
            },
            error: function (error) {
                Swal.fire('error', error.statusText, "error");
            }
        });
    });
    //metodo ajax para eliminar la seccion
    $(document).on("click", ".eliminarSeccion", function (e) {
        e.preventDefault();
        var codigo = $(this).data("codigo");
        var url = $('#urlEliminarSeccion').val();

        Swal.fire({
            title: "¿Estas seguro de eliminar el registro?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: '¡Si, Eliminar!',
            cancelButtonText: 'Cancelar',
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    method: "POST",
                    url: url,
                    data: { codigo: codigo },
                    success: function (resp) {
                        if (resp.success == true) {
                            $(tableContent).html(resp.viewParcial);
                            swal("Exito", resp.mensaje, "success");
                        }
                        else {
                            swal("Error", resp.mensaje, "error");
                        }
                    }
                });
            }
        })
    });
    //metodo para desactivar o activar la seccion
    $(document).on("click", ".desactivar_Seccion", function (e) {
        e.preventDefault();
        var codigo = $(this).data("codigo");
        var url = $('#urlDesactivarSeccion').val();
        var activo = $(this).is(':checked');
        var butonConfirm = "Desactivar!";
        if (activo == true) {
            butonConfirm = "Activar!";
        }
        Swal.fire({
            title: "¿Estas seguro de desactivar la seccion?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: '¡Si,' + butonConfirm,
            cancelButtonText: 'Cancelar',
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    method: "POST",
                    url: url,
                    data: { codigo: codigo, activo: activo },
                    success: function (resp) {
                            $(tableContent).html(resp.viewParcial);
                            swal("Exito", resp.mensaje, "success");
                    }
                });
            }
        })
    });
    //metodo para inicializar los metodos que se utilizaran dentro de la modal
    function inicializarEventFunction() {
        $(document).on("submit", "#formDetalle", function (e) {
            e.preventDefault();
            var $this = $(this);
            Bitworks.Ventanas.mostrarLoading();
            var datos = new FormData($("#formDetalle")[0]);
            var url = $('#urlAgregarModificar').val();
            $.ajax({
                method: "POST",
                url: url,
                data: datos,
                contentType: false,
                processData: false,
                success: function (resp) {
                    if (resp.success == true) {
                        swal("Exito", resp.mensaje, "success");
                        $(tableContent).html(resp.viewPartial);
                        $(modalTitulo).html()
                        $(modalContent).html();
                        $(modal).modal("hide");
                    }
                    else {
                        var errors = [];
                        $.each(resp.validationErrors, function (i, error) {
                            errors.push(error);
                        });
                        showErrorListFromArray(errors);
                    }
                }
            })
        });
        function showErrorListFromArray(errors) {

            var errorHtml = "<ul>";
            for (var i = 0, len = errors.length; i < len; i++) {
                var error = "<li>" + errors[i] + "</li>";
                errorHtml = errorHtml + error;
            }
            errorHtml = errorHtml + "</ul>";

            swal({
                title: "<h3>Revise la siguiente información</h3>",
                html: errorHtml
            });
        }
    };
});