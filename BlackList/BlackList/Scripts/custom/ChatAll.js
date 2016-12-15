// Function that will run when the html document has fully loaded.
$(document).ready(function () {
    // Declare a connection to the Hub and save the connection in a variable.
    var chat = $.connection.cRUDHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (email, name, message, date) {
        // Console.log() when then function begins to run.
        console.log("broadcast");
        // Create a string that will have the link to a user's profile picture.
        // https://www.gravatar.com/avatar/ decoded email(hash value).
        var result = 'https://www.gravatar.com/avatar/' + md5(email);
        // Html encode profile picture, name and message.
        var encodedEmail = $('<div />').text(email).html();
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
            var encodedDate = $('<div />').text(date).html();
        // Add the message to the page by creating a list item and elements needed.
        $("#discussion").append('<li><p id="ChatText"><img src="' + result + '" width="15px" height="15px"/><strong>' + encodedName + '</strong>(' + encodedDate + '): ' + encodedMsg + '<p/></li>');
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        // Console.log() when connection is done.
        console.log("done");

        
        
        

        // Function will run if user clicks on element with #sendmessage.
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.sendMessage($('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});