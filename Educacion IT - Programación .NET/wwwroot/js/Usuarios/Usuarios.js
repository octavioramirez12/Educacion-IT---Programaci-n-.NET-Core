$(document).ready(function () {
    $('#usuarios').DataTable({
        ajax: {
            url: 'https://localhost:7126/api/usuarios/buscarUsuarios'
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            { data: 'apellido', title: 'Apellido' },
            { data: 'fecha_Nacimiento', title: 'Fecha de Nacimiento' },
            { data: 'mail', title: 'Mail' },
            { data: 'id_Rol', title: 'Rol' },
            { data: 'active', title: 'Activo' },
            { data: 'codigo', title: 'Código' },
        ],
        language:
        {
            url: 'https://cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json'
        }
    });
});

