

$(document).ready(function () {

    $('#createList').click(function () {
        
        //Skapar listan
        var wordarray = ['Matakue', 'Mendokse'];
        var idarray = ['id1', 'id2'];

        createList(wordarray, idarray);

        $('#listName').toggleClass('toggleClass-hide-create');

        //Ändrar layout på list elementen vid click
        $(".click-sList").click(function () {
            $(this).toggleClass('toggleClass-li-clicked');
            $(this).find('.bock-class').toggleClass('bock-visible');
        });

        //Tar bort li elementet associerat med trash button
        

        function removeWord () {
            alert('Funka!')
            //crudRemove($(this).closest('li').prop('id'));
        };

        //Knapp för att ta bort hela listan
        $('#remove-list').click(function () {
            $('.ul-ShoppingList').remove();
        });

        
    });

    $(".click-sList").click(function () 
    {
        $(this).toggleClass('toggleClass-li-clicked');
        $(this).find('.bock-class').toggleClass('bock-visible');
    });

    
    function createList (wordsInListArray, idArray ) {

        function removeWord() {
            alert('ta bort ord')
            //crudRemove($(this).closest('li').prop('id'));
        };

        function editWord() {
            alert('editera ordet ' + $(this).closest('li').prop('id'))
            //crudRemove($(this).closest('li').prop('id'));
        }


            var cList = $('<ul/>')
            .addClass('ul-ShoppingList');
            $.each(wordsInListArray, function(i) {
            var li = $('<li/>')
                .addClass('li-ShoppingList')
                .addClass('click-sList')
                .prop("id", idArray[i])
                .appendTo(cList);
            
                
            var spanInList = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-ok')
                .addClass('bock-class')
                .appendTo(li);
            
            var text = $('<p/>')
                .text(wordsInListArray[i])
                .appendTo(li);

            var trashButtonInList = $('<button />')
                .addClass('remove-button-class')
                .prop('id', idArray[i])
                .click(removeWord)
                .appendTo(li);

            var trashGlyphInButton = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-trash')
                .appendTo(trashButtonInList);

            var editButtonInList = $('<button />')
                .addClass('edit-button-class')
                .prop('id', idArray[i])
                .click(editWord)
                .appendTo(li);

            var editGlyphInButton = $('<span />')
                .addClass('glyphicon')
                .addClass('glyphicon-pencil')
                .appendTo(editButtonInList);


        });

            $('.list-div').append(cList);

            
        
    }

    $(function () {
        // Reference the auto-generated proxy for the hub.  
        var chat = $.connection.chatHub;
        // Create a function that the hub can call back to display messages.
        chat.client.addNewMessageToPage = function (name, message) {
            // Add the message to the page. 
            $('#discussion').append('<li><strong>' + htmlEncode(name)
                + '</strong>: ' + htmlEncode(message) + '</li>');
        };
        // Get the user name and store it to prepend to messages.
        $('#displayname').val(prompt('Enter your name:', ''));
        // Set initial focus to message input box.  
        $('#message').focus();
        // Start the connection.
        $.connection.hub.start().done(function () {
            $('#sendmessage').click(function () {
                // Call the Send method on the hub. 
                chat.server.send($('#displayname').val(), $('#message').val());
                // Clear text box and reset focus for next comment. 
                $('#message').val('').focus();
            });
        });
    });
    // This optional function html-encodes messages for display in the page.
    function htmlEncode(value) {
        var encodedValue = $('<div />').text(value).html();
        return encodedValue;
    }
    
    


});





  

//$(document).ready(function () {

//    if (hasBeenClicked == true) {
//        $("li").click(function () {
//            $(this).css('color', 'black');
//            hasBeenClicked = false;
//        });
//    }
//});




//hasBeenClicked = true;
//if (hasBeenClicked == true) {
//    $('li').click(function () {
//        $(this).css('color', 'black');
//    });
//}



//$(document).ready(function () {
//    $("div").mouseenter(function () {
//        $("li").css('background-color', 'red');
//    });
//});

