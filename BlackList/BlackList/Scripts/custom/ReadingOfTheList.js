/*====================================
            On start
====================================*/
$(document).ready(function () {
    var CL = $.connection.cRUDHub;

    /*====================================
            Reading of the list
    ====================================*/
    $.connection.hub.start().done(function () {
        $('#add-to-list-button').click(function () {
            CL.server.addToListCode($('#textbox-list').val(), $('.headingForListName').prop('id'));
            
            //readTheListJS
        });
    });

    CL.client.addToList = function (wordsInList, id) {
        var cList = $('<ul/>')
        .addClass('ul-ShoppingList');

        var li = $('<li/>')
        .addClass('li-ShoppingList')
        .prop("id", id)
        .appendTo(cList);

        var text = $('<p/>')
        .addClass('word-in-p')
        .text(wordsInList)
        .appendTo(li);
    };

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