// Function that will run when the html document has fully loaded.
$(document).ready(function () {
    // Declare a connection to the Hub and save the connection in a variable.
    var chat = $.connection.blackListHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (email, name, message, date, listID) {
        console.log(listID);
        $(".listheading-read").prop("id");
        if ($(".listheading-read").prop("id") == listID) {


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
            $("#discussion").prepend('<li><p id="ChatText"><img src="' + result + '" width="15px" height="15px"/><strong>' + encodedName + '</strong>(' + encodedDate + '): ' + encodedMsg + '<p/></li>');
        }
    };
    

    chat.client.renderMessages = function(messages, listID){
        $("#discussion").empty();

        for (var i = 0; i < messages.length; i++) {
            chat.client.broadcastMessage(messages[i].Sender.Email, messages[i].Sender.Name, messages[i].ChatMessage, messages[i].TimeStamp, listID);
        }
    }

    // Start the connection.
    $.connection.hub.start().done(function () {
        // Console.log() when connection is done.
        console.log("done");
        // Function will run if user clicks on element with #sendmessage.
        $('#sendmessage').click(function () {

            var listID = $('.listheading-read').prop("id");
            console.log(listID);

            // Call the Send method on the hub.
            chat.server.send($('#message').val(), listID);
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });



        $("body").on("click", ".li-in-list", function () {

            $("#discussion").empty();
            console.log($(this).prop("id"))
            chat.server.getMessages($(this).prop("id"));
        })



    });
});