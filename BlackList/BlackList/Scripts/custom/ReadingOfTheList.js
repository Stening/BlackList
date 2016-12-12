$(function () {




    var CrudConnection = $.connection.cRUDHub;
    $.connection.hub.start().done(function () {


        CrudConnection.server.getMyLists();

    });


    CrudConnection.client.renderMyLists = function (myLists) {

        var html = "<ul>";

        for (var i = 0; i < myLists.length; i++) {
            html += "<li class='li-in-list'><p>" + myLists[i].Title + "</p></li>";
        }
        var html = "</ul>";
        $("#MyLists").append(html);
        console.log(myLists);

    }

    $('body').on('click', '#MyLists', function () {

        CrudConnection.server.getListItems();


    })
})