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
            "url": "/Admin/Order/getAll"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "date", "width": "30%" },
            { "data": "clientName", "width": "40%" },
            { "data": "paymentType", "width": "40%" },
            { "data": "adress", "width": "40%" },
            { "data": "phoneNumber", "width": "40%" },
            { "data": "amount", "width": "40%" }




        ]



    });
}
