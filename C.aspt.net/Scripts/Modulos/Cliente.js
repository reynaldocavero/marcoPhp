"use strict";
var EMD = EMD || {};
EMD.BusquedaClientes = (function () {

    var init = function () {
        $.ajax({
            type: "POST",
            url: "/Cliente/buscaCliente",
            /*data: JSON.stringify({ xml: ruc }),*/
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {



                $.each(data, function (key, val) {
                    var tr = $('<tr>');
                    tr.html('<td>' + val.id + '</td>' +
                        '<td>' + val.cliente + '</td>' +
                        '<td>' + val.numero + '</td>' +
                        '<td>' + val.activo + '</td>');
                    $('#lista').append(tr);
                });
            },
            error: function (result) {
                alert('ERROR: ' + result.status + ' ' + result.statusText);
            }
        });



    };

    var insPoducto = function (xml) {
        $.ajax({
            type: "POST",
            url: "/Cliente/insCliente",
            data: JSON.stringify({ xml: xml }),

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                init();
            },
            error: function (result) {
                alert('ERROR: ' + result.status + ' ' + result.statusText);
            }
        });
    };

    return {
        init: init,
        insPoducto: insPoducto
    };
})();