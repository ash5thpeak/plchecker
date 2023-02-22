// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#txtDrug").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: 'https://localhost:7045/medicinefilter/pl/' + request.term ,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                type: "GET",
                //data: { "plNumber": request.term },
                dataType: "json",
                position: { my: "left top", at: "left bottom" },
                success: function (data) {
                    console.log(data);
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (xhr, textStatus, error) {
                    alert("error: " + xhr.statusText);
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                }
            });
        },
        select: function (e, i) {
            console.log(i);
            $("#lblDrugName").text(i.item.name);
        },
        minLength: 3
    }).data("ui-autocomplete")._renderItem = function (ul, item) {
        //console.log(item.imageSource);
        return $("<li class='ui-autocomplete-row'></li>")
            .data("item.autocomplete", item)
            .append("<img style='width:25px;height:25px' src='" + item.imageSource + "' /> " + item.name)
            .appendTo(ul);
    };
});
