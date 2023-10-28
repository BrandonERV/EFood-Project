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
            { "data": "userName" },
            { "data": "name" },
            { "data": "role" },
            {
                "data": {
                    id: "id", lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    let today = new Date().getTime();
                    let block = new Date(data.lockoutEnd).getTime();
                    if (block > today) {
                        
                        return `    
                        <div class="text-center"> 
                            <a onclick=ActiveInactive('${data.id}') class="btn btn-danger text-white" style="cursor:pointer", width:150px >
                                <i class="bi bi-unlock"></i> Activar
                            </a>
                        </div>
                    `;
                    }
                    else {
                        return `
                        <div class="text-center"> 
                            <a onclick=ActiveInactive('${data.id}') class="btn btn-success text-white" style="cursor:pointer", width:150px >
                                <i class="bi bi-lock"></i> Desactivar
                            </a>
                        </div>
                    `;
                    }

                }
            }
        ]
    });
}



function ActiveInactive(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/ActiveInactive',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                datatable.ajax.reload();
            }
            else {
                toastr.error(data.sessage);
            }
        }
    });
}