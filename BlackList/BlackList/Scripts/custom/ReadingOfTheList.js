/*====================================
            On start
====================================*/
$(document).ready(function () {
    var CL = $.connection.cRUDHub;

    /*====================================
            Reading of the list
    ====================================*/
    $.connection.hub.start().done(function () {
        $('#read-list-button').click(function () {
            CL.server.readTheListJS($('#textbox-list').val(), $('.headingForListName').prop('id'));



        });
    });

    /*====================================
       Generating list item from idlist
    ====================================*/
    $(function () {
        var arr = ["101", "102", "103", "104"];

        $.each(arr, function (i, val) {
            $("#" + val).text("ID: " + val);
        });
        $.each(arr, function (i, val) {
            $("#" + i).append(document.createTextNode(", " + val));
        });
    });
});