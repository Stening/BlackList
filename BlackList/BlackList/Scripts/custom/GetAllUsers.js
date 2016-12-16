$(document).ready(function () {
    var entrypush;

    entrypush = $.connection.showAllUsers;

    entrypush.client.updateUserList = function (list) {
        
        


            for (var i = 0; i <= list.length; i++) {

               

                $('#UserListz').append("<div class='col-md-12';><p class='col-md-8'; style='margin: 0 0 0px; overflow-wrap: break-word;'>" + list[i].UserName + "</p><button class='col-md-4' value=" + list[i].Id + ">Lägg Till Vän</button></div>");
                

            }
            

    }

    //connect to hub
    $.connection.hub.start().done(function () {
        entrypush.server.send();

    });
});

