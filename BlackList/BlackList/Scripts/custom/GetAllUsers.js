$(document).ready(function () {
    var entrypush;

    entrypush = $.connection.showAllUsers;

    entrypush.client.updateUserList = function (list) {

        var count = 0;


        for (var i = 0; i <= list.length; i++) {


            //$('#UserListz').append("<div style='text-align:center;'><a class='col';>" + list[i] + "</a></div>");

            //   $('#UserListz').append("<div class='col-md-12';><p class='col-md-8'; style='margin: 0 0 0px; overflow-wrap: break-word;'>" + list[i].UserName + "</p><button class='col-md-4' value=" + list[i].Id + ">Lägg Till Vän</button></div>");



            $('#UserListz').append("<select id='cList'></select>");
            for (i = 0; i < list.length; i++) {
                $("#cList").append("<option class='clr'>" +
                list[i] + "</option>");
            }


        };


        var propvalue;
        for (var key in list) {
            propvalue = list[key];
            console.log(key, propvalue);
        }


    };

    //connect to hub
    $.connection.hub.start().done(function () {
        entrypush.server.send();

    });
});