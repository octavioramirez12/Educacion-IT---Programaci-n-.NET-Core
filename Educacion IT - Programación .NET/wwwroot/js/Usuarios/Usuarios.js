var tablaUsuarios;
$(document).ready(function () {
    tablaUsuarios = $('#usuarios').DataTable({
        ajax: {
            url: 'https://localhost:7126/api/usuarios/buscarUsuarios',
            dataSrc: ''
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            { data: 'apellido', title: 'Apellido' },
            {
                data: function (row) {
                    return moment(row.fecha_Nacimiento).format("DD/MM/YYYY");
                }, title: 'Fecha de Nacimiento'
            },
            { data: 'clave', title: 'Clave' },
            { data: 'mail', title: 'Mail' },
            { data: 'id_Rol', title: 'Rol' },
            {
                data: function (row) {
                    return row.activo ? "Si" : "No"
                }, title: 'Activo'
            },
            {
                data: function (row) {
                    var botones =
                        `<td><a href='javascript:EditarUsuario(${JSON.stringify(row)})'><i class="fa-solid fa-pen-to-square editarUsuario"></i></a></td>` + 
                        `<td><a href='javascript:EliminarUsuario(${JSON.stringify(row)})'><i class="fa-solid fa-trash eliminarUsuario"></i></a></td>`
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

function GuardarUsuario() {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuariosModal').modal('show');
        }
    })
}

function EditarUsuario(row) {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuariosModal').modal('show');
        }
    })
}

function EliminarUsuario(row) {
    $.ajax({
        type: "POST",
        url: "/Usuarios/EliminarUsuario",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            tablaUsuarios.ajax.reload();
        }
    })
}


//<i class="fa-solid fa-trash"></i>
