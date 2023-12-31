var tablaProductos;
$(document).ready(function () {
    tablaProductos = $('#productos').DataTable({
        ajax: {
            url: 'https://localhost:7126/api/productos/buscarProductos',
            dataSrc: ''
        },
        columns: [
            { data: 'id', title: 'Id' },
            {
                data: 'imagen', render: function (data) {
                    if (data != "" && data != null) {
                        return `<img src="data:image/jpef;base64,${data}" width="100px" height="100px" style="border-radius:15px"></img>`
                    }
                    else {
                        return `<img src="../images/nofoto.jpg" width="100px" height="100px" style="border-radius:15px"></img>`

                    }
            }, title: 'Imagen' },
            { data: 'descripcion', title: 'Descripción' },
            { data: 'stock', title: 'Stock' },
            { data: 'precio', title: 'Precio' },
            {
                data: function (row) {
                    return row.activo ? "Si" : "No"
                }, title: 'Activo'
            },
            {
                data: function (row) {
                    var botones =
                        `<td><a href='javascript:EditarProducto(${JSON.stringify(row)})'><i class="fa-solid fa-pen-to-square editarProducto"></i></a></td>` + 
                        `<td><a href='javascript:EliminarProducto(${JSON.stringify(row)})'><i class="fa-solid fa-trash eliminarProducto"></i></a></td>`
                    return botones;
                }
            }
        ],
        language:
        {
            url: 'https://cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json'
        }
    });
});

function GuardarProducto() {
    $.ajax({
        type: "POST",
        url: "/Productos/ProductosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#productosAddPartial').html(resultado);
            $('#productosModal').modal('show');
        }
    })
}

function EditarProducto(row) {
    $.ajax({
        type: "POST",
        url: "/Productos/ProductosAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#productosAddPartial').html(resultado);
            $('#productosModal').modal('show');
        }
    })
}

function EliminarProducto(row) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "Estas seguro?",
        text: "Vas a eliminar el producto!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Si, eliminar!",
        cancelButtonText: "No, cancelar!",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: "/Productos/EliminarProducto",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    tablaProductos.ajax.reload();
                    swalWithBootstrapButtons.fire({
                        title: "Eliminado!",
                        text: "El producto ha sido eliminado.",
                        icon: "success"
                    });
                }
            })
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire({
                title: "Cancelado",
                text: "No se ha eliminado ningún producto",
                icon: "error"
            });
        }
    });
    
}


//<i class="fa-solid fa-trash"></i>
