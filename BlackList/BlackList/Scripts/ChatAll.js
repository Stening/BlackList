﻿// Function that will run when the html document has fully loaded.
$(document).ready(function () {
        // Declare a connection to the Hub and save the connection in a variable.
        var chat = $.connection.chatHub;
        // Create a function that the hub can call to broadcast messages.
        chat.client.broadcastMessage = function (name, message) {
            console.log("broadcast");
            // Html encode display name and message.
            var encodedName = $('<div />').text(name).html();
            var encodedMsg = $('<div />').text(message).html();
            // Add the message to the page.
            $("#discussion").append('<li><strong>' + encodedName + '</strong> : ' + encodedMsg + '</li>');
        };
    // Get the user name and store it to prepend to messages.
        //$("#displayname").val(prompt('Enter your name:', ''));
        // Set initial focus to message input box.
        $("#message").focus();
        // Start the connection.
        $.connection.hub.start().done(function () {
            console.log("done");
            $('#sendmessage').click(function () {
                // Call the Send method on the hub.
                chat.server.send($('#message').val());
                console.log("message");
                // Clear text box and reset focus for next comment.
                $('#message').val('').focus();
            });
        });
});