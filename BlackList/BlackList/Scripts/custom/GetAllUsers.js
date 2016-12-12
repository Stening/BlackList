
    $(document).ready(function () {
        var entrypush;
        entrypush = $.connection.showAllUsers;


        entrypush.client.updateUserList = function(list){
            
            

                //$(".UserListz").append(list)
                alert("Innan loop");
            console.log("innan loopen");
            for (var i = 0; i < list.Count; i++) {
                $('#UserListz').append("<li>wigge</li>");
                console.log("i loopen");
            }
                


            
            
            
        }

        //connect to hub
        $.connection.hub.start().done(function () {
            entrypush.server.send();
                
            });
        });


    