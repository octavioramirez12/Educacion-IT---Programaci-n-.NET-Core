var tablaRoles;
$(document).ready(function () {
    tablaRoles = $('#roles').DataTable({
        ajax: {
            url: 'https://localhost:7126/api/roles/buscarRoles',
            dataSrc: ''
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            {
                data: function (row) {
                    return row.activo ? "Si" : "No"
                }, title: 'Activo'
            },
            {
                data: function (row) {
                    var botones =
                        `<td><a href='javascript:EditarRol(${JSON.stringify(row)})'><i class="fa-solid fa-pen-to-square editarRol"></i></a></td>` + 
                        `<td><a href='javascript:EliminarRol(${JSON.stringify(row)})'><i class="fa-solid fa-trash eliminarRol"></i></a></td>`
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

function GuardarRol() {
    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#rolesAddPartial').html(resultado);
            $('#rolesModal').modal('show');
        }
    })
}

function EditarRol(row) {
    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#rolesAddPartial').html(resultado);
            $('#rolesModal').modal('show');
        }
    })
}

function EliminarRol(row) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "Estas seguro?",
        text: "Vas a eliminar al rol!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Si, eliminar!",
        cancelButtonText: "No, cancelar!",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: "/Roles/EliminarRol",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    tablaRoles.ajax.reload();
                    swalWithBootstrapButtons.fire({
                        title: "Eliminado!",
                        text: "El rol ha sido eliminado.",
                        icon: "success"
                    });
                }
            })
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire({
                title: "Cancelado",
                text: "No se ha eliminado ningún rol",
                icon: "error"
            });
        }
    });
    
}


//<i class="fa-solid fa-trash"></i>
