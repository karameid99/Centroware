var KTDatatableAutoColumnHideDemo = function () {
    var demo = function demo() {
        var datatable = $('#kt_datatable').KTDatatable({
            data: {
                type: 'remote',
                pageSize: 10,
                saveState: false,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true,
                source: {
                    read: {
                        url: 'Panel/Contact/GetAll',
                    }
                },
            },
            layout: {
                scroll: true,
                spinner: {
                    overlayColor: '#ff00ff',
                }

            },
            sortable: true,
            pagination: true,
            search: {
                input: $('#kt_datatable_search_query'),
                key: 'generalSearch'
            },
            columns: [{
                field: 'id',
                title: 'ID'
            }, {
                field: 'firstName',
                title: 'First Name',
                width: 'auto',
                autoHide: false,

            }, {
                field: 'lastName',
                title: 'Last Name',
                width: 'auto',
                autoHide: false,

            }, {
                field: 'mobile',
                title: 'Mobile',
                width: 'auto',
                autoHide: false,

            }, {
                field: 'email',
                title: 'Email',
                width: 'auto',
                autoHide: false,

            }
                , {
                field: 'message',
                title: 'Message',
                width: 'auto',
                autoHide: true,

            }],

        });


        $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();
        console.log(datatable.getDataSourceQuery());
    };
    return {
        init: function init() {
            demo();
        }
    };
}();
jQuery(document).ready(function () {
    KTDatatableAutoColumnHideDemo.init();
});