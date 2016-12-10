$(function () {
    var FriendList = [];

    var FriendsConnection = $.connection.friendsHub;

    $.connection.hub.start().done(function () {


        

        FriendsConnection.server.connectToFriends();

       



    });

    FriendsConnection.client.renderFriends = function (friends) {
        FriendList = friends;
        $("#Friends").empty();

        $("#Friends").append("<ul>")
        for (var i = 0; i < friends.length; i++) {

            $("#Friends").append("<li>" + friends[i].UserName + " " + friends[i].Online + "</li>");
            $("#InviteFriends").append("<li>" + friends[i].UserName + "<button class='AddFriendToList'>Add to list</button>"+"</li>");

        }
        $("#Friends").append("</ul>")




    }

    $('body').on('click', '.AddFriendToList', function () {
        console.log("Here We will invite the friend to the list, however first we need tha ability to add multiple lists to be able to invite to that specific list");
        //console.log($(this).parent());
    });
    





    FriendsConnection.client.updateFriends = function () {

        FriendsConnection.server.updateConnectedFriends();

    }

   
})