$(document).ready(function() {

});

$(document).on("click", ".desactivar_Articulo", function (ev) {
    ev.stopPropagation();
    MostrarLoading();
    var url = $("#url_DesactivarArticulo").val();
    var codigo = $(this).data("codigo");
    var activo = $(this).is(":checked");

    $.ajax({
        type: "POST",
        url: url,
        data: { id: codigo, activo: activo },
        dataType: "json",
        success: function (res) {
            CerrarLoading();

            if (res.exitoso) {
                toastr.success(res.mensaje);
            }
            else {
                toastr.error(res.mensaje);
            }
        },
        error: function (err) {
            errorCommonManager(err);
        }
    });
});

$(document).on("click", "#btn-GuardarArticulo", function (ev) {
    ev.preventDefault();

    if ($("#frm-DetalleArticulo").valid())
    {
        if ($('.summernote').summernote('isEmpty'))
        {
            swal({
                title: "Revise los siguientes campos",
                html: "<ul><li>El Contenido del artículo es requerido.</li></ul>",
                confirmButtonText: "OK",
            });
            return;
        }
        MostrarLoading();
    }
    $("#frm-DetalleArticulo").submit();
});

$(document).on("submit", "#form-producto-relacionado", function (ev) {
    ev.preventDefault();
    MostrarLoading();
    var form = $(this);
    var url = $(this).attr("action");

    $.ajax({
        type: "POST",
        url: url,
        data: form.serialize(),
        //contentType:"application/json",
        dataType: "json",
        success: function (res) {
            if (res.exitoso) {
                $("#contenedor_ProductosRelacionados").html(res.html);
                Swal.fire("Éxito", res.mensaje, "success");
                $('#md-producto-relacionado').modal('toggle');
                limpiarCamposModal();
            }
            else
                Swal.fire("Error", res.mensaje, "error");
        },
        error: function (err) {
            errorCommonManager(err);
        }
    });
});

$(document).on("click", ".eliminar_producto_relacionado", function (ev) {
    ev.preventDefault();
    var url = $(this).attr("href");

    Swal.fire({
        //title: "Eliminar Producto Asignado",
        html: "¿Está seguro que desea eliminar el <b>producto asignado al artículo</b>?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: "#1a7bb9",
        confirmButtonText: "Si",
        cancelButtonText: "Cancelar",
        allowOutsideClick: false
    }).then(function (result) {
        if (result.value) {
            MostrarLoading();
            $.ajax({
                type: "POST",
                url: url,
                dataType: "json",
                success: function (res) {
                    if (res.exitoso) {
                        $("#contenedor_ProductosRelacionados").html(res.html);
                        Swal.fire("Éxito", res.mensaje, "success");
                    }
                    else
                        Swal.fire("Error", res.mensaje, "error");
                },
                error: function (err) {
                    errorCommonManager(err);
                }
            });
        }
    });
});


function limpiarCamposModal() {
    $("#txtCodigo_ProductoRelacionado").val("");
    $("#txtOrden_ProductoRelacionado").val("");
    $("#txtCantidad_ProductoRelacionado").val("");
}