$(document).ready(function () {
    var entrypush;

    entrypush = $.connection.showAllUsers;

    entrypush.client.updateUserList = function (list) {
        
        


            for (var i = 0; i <= list.length; i++) {

               

                $('#UserListz').append("<div style='text-align:center;'><p class='col-md-6';>" + list[i] + "</p><button class='col-md-6';>Lägg Till Vän</button></div>");
                

            }

        
            alert(list);

    }

    //connect to hub
    $.connection.hub.start().done(function () {
        entrypush.server.send();

    });
});

