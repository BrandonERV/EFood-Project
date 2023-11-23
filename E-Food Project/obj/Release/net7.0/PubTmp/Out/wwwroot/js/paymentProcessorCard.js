
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
            "url": "/Admin/PaymentProcessorCard/getAll"
        },

        "columns": [
            { "data": "id" },
            { "data": "paymentProcessor.name"},
            { "data": "card.name" },
            
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a onclick=Delete("/Admin/PaymentProcessorCard/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="bi bi-trash3-fill"></i>
                            </a>
                        </div>
                    `;

                }, "width": "20%"

            }
        ]



    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de Eliminar la tarjeta?",
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