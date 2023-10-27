let datatable;
$(document).ready(function () {
    loadDatatable();

});


function loadDatatable() {
    datatable = $('#tblData').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar page _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Admin/User/getAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "roles", "width": "20%" },

        ]

    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de Eliminar la Tarjeta?",
        text: "Este proceso es irreversible!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((erase) => {
        if (erase) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });

}