/******/({

/***/ "./resources/metronic/js/pages/crud/ktdatatable/base/data-ajax.js":
/*!************************************************************************!*\
  !*** ./resources/metronic/js/pages/crud/ktdatatable/base/data-ajax.js ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {
            "use strict";
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
                                    url: 'Panel/Team/GetAll',
                                }
                            },
                        },
                        layout: {
                            scroll: false
                        },
                        sortable: true,
                        pagination: true,
                        search: {
                            input: $('#kt_datatable_search_query'),
                            key: 'generalSearch'
                        },
                        columns: [{
                            field: 'Id',
                            title: 'ID'
                        }, {
                            field: 'Name',
                            title: 'Team Member',
                            width: 250,
                            template: function template(data) {
                                var user_img = data.staticImage;
                                var output = '';
                                if (user_img != null) {
                                    output = '<div class=\"d-flex align-items-center\">\\\r\n\t\t\t\t\t\t\t\t<div class=\"symbol symbol-40 symbol-sm flex-shrink-0\">\\\r\n\t\t\t\t\t\t\t\t\t<img class=\"\" src=\"Images/' + user_img + '\" alt=\"photo\">\\\r\n\t\t\t\t\t\t\t\t</div>\\\r\n\t\t\t\t\t\t\t\t<div class=\"ml-4\">\\\r\n\t\t\t\t\t\t\t\t\t<div class=\"text-dark-75 font-weight-bolder font-size-lg mb-0\">' + data.Name + '</div>\\\r\n\t\t\t\t\t\t\t</div>';
                                } else {
                                    var stateNo = KTUtil.getRandomInt(0, 7);
                                    var states = ['success', 'primary', 'danger', 'success', 'warning', 'dark', 'primary', 'info'];
                                    var state = states[stateNo];
                                    output = '<div class=\"d-flex align-items-center\">\\\r\n\t\t\t\t\t\t\t\t<div class=\"symbol symbol-40 symbol-light-' + state + ' flex-shrink-0\">\\\r\n\t\t\t\t\t\t\t\t\t<span class=\"symbol-label font-size-h4 font-weight-bold\">' + data.Name.substring(0, 1) + '</span>\\\r\n\t\t\t\t\t\t\t\t</div>\\\r\n\t\t\t\t\t\t\t\t<div class=\"ml-4\">\\\r\n\t\t\t\t\t\t\t\t\t<div class=\"text-dark-75 font-weight-bolder font-size-lg mb-0\">' + data.Name + '</div>\\\r\n\t\t\t\t\t\t\t\t</div>\\\r\n\t\t\t\t\t\t\t</div>';
                                }
                                return output;
                            }
                        }, {
                            field: 'Specialization',
                            title: 'Specialization',
                            width: 'auto'
                        }]
                    });

                    $('#kt_datatable_search_status').on('change', function () {
                        datatable.search($(this).val().toLowerCase(), 'Status');
                    });
                    $('#kt_datatable_search_type').on('change', function () {
                        datatable.search($(this).val().toLowerCase(), 'Type');
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
            /***/
        }),

/***/ 88:
/*!******************************************************************************!*\
  !*** multi ./resources/metronic/js/pages/crud/ktdatatable/base/data-ajax.js ***!
  \******************************************************************************/
/*! no static exports found */
/***/ (function (module, exports, __webpack_require__) {

            module.exports = __webpack_require__(/*! C:\laragon\www\unit\resources\metronic\js\pages\crud\ktdatatable\base\data-ajax.js */"./resources/metronic/js/pages/crud/ktdatatable/base/data-ajax.js");


            /***/
        })

    /******/
});