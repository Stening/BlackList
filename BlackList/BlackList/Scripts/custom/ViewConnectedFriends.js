$(function () {
    var FriendsConnection = $.connection.friendsHub;

    $.connection.hub.start().done(function () {


        

        FriendsConnection.server.connectToFriends();

       



    });

    FriendsConnection.client.renderFriends = function (friends) {

        $("#SomeID").empty();

        $("#SomeID").append("<ul>")
        for (var i = 0; i < friends.length; i++) {

            $("#SomeID").append("<li>" + friends[i].UserName +" "+ friends[i].Online+"</li>");

        }
        $("#SomeID").append("</ul>")




    }

    FriendsConnection.client.updateFriends = function () {

        FriendsConnection.server.updateConnectedFriends();

    }

   
})