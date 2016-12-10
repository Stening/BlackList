$(function () {
    var FriendList = [];

    var FriendsConnection = $.connection.friendsHub;

    $.connection.hub.start().done(function () {




        FriendsConnection.server.connectToFriends();





    });

    FriendsConnection.client.renderFriends = function (friends) {
        FriendList = friends;
        $("#Friends").empty();
        for (var i = 0; i < friends.length; i++) {
            $("#InviteFriends").append("<div>" + friends[i].UserName + "<button class='AddFriendToList'>Add to list</button>" + "</div>");
            var toAppend = "<div class='col-md-8'>" + friends[i].UserName;


            if (friends[i].Online == true) {

                toAppend += " <span class='glyphicon glyphicon-ok'>";
            }
            else {
                toAppend += " <span class='glyphicon glyphicon-remove'>";
            }
            toAppend += "</div>";
            $("#Friends").append(toAppend)
        }




    }







    $('body').on('click', '.AddFriendToList', function () {
        console.log("Here We will invite the friend to the list, however first we need tha ability to add multiple lists to be able to invite to that specific list");
        //console.log($(this).parent());
    });






    FriendsConnection.client.updateFriends = function () {

        FriendsConnection.server.updateConnectedFriends();

    }


})