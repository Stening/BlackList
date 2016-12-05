$(document).ready(function () {
    var FriendsConnection = $.connection.FriendsHub;

    $.connection.hub.start().done(function () {


        

        FriendsConnection.server.getFriends();





    });

    FriendsConnection.client.renderFriends = function (friends) {

        for (var i = 0; i < friends.length; i++) {
            $("#SomeID").append(friends[i]);
        }

        



    }
})