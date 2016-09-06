$(document).on("ready", function () {
    GetID();
})

function GetID() {
    $('#tblList tbody').html('');
    $.getJSON('http://localhost:8082/Api/Categoria', function (data) {
        $.each(data, function (Key, value) {
            $('#tblList tbody').append("<tr><td>"
                + value.Nombre_Categoria + "</td></tr>")
        });
    });
}