
    $(document).ready(function () {
        var entrypush;

  
        entrypush = $.connection.showAllUsers;
        

        entrypush.client.updateUserList = function(list){
    

                
                
             
                
            for (var i = 0; i <= list.length; i++) {

                
                console.log("före utskirft");
                
                
                
                
                $('#UserListz').append("<div><p class='col-md-6';>" + list[i] + "</p><button class='col-md-6';>Lägg Till Vän</button></div>");


                console.log("i loopen");
            }
        }
        //connect to hub
        $.connection.hub.start().done(function () {
            entrypush.server.send();
                
            });
        });


    