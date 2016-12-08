

$(document).ready(function () {
    var CL = $.connection.cRUDHub;

    $.connection.hub.start().done(function () {
        $('#createList').click(function () {    
            CL.server.createListCode($('#listName').val());
            $('#listName').toggleClass('toggleClass-hide-create');
            $('#createList').toggleClass('toggleClass-hide-create');
        });
    });

    $(".click-sList").click(function () 
    {
        $(this).toggleClass('toggleClass-li-clicked');
        $(this).find('.bock-class').toggleClass('bock-visible');
    });

    $.connection.hub.start().done(function () {
        $('#add-to-list-button').click(function () {
            CL.server.addToListCode($('#textbox-list').val());

            
            //Ändrar layout på list elementen vid click
            

            //function removeWord() {
            //    alert('Funka!')
            //    //crudRemove($(this).closest('li').prop('id'));
            //};

            //Knapp för att ta bort hela listan
            $('#remove-list').click(function () {
                $('.ul-ShoppingList').remove();
            });


        });
    });


    CL.client.createList = function () {
        var nameOfList = $('#listName').val();
        var listHeading = $('<h2 />')
            .addClass('headingForListName');

        var headingText = $('<p/>')
            .text(nameOfList)
            .appendTo(listHeading);

        $('.create-list-div').append(listHeading)
    }

    
    CL.client.addToList = function (wordsInList, id ) 
    {

        function removeWord() {
            alert('ta bort ord')
            //crudRemove($(this).closest('li').prop('id'));
        };

        function editWord() {
            alert('editera ordet ' + $(this).closest('li').prop('id'))
            //crudRemove($(this).closest('li').prop('id'));
        };

        //Skapar listan med ord
            var cList = $('<ul/>')
            .addClass('ul-ShoppingList');
            //$.each(wordsInListArray, function(i) {
            var li = $('<li/>')
                .addClass('li-ShoppingList')
                .addClass('click-sList')
                .prop("id", id)
                .appendTo(cList);
            
                
            var spanInList = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-ok')
                .addClass('bock-class')
                .appendTo(li);
            
            var text = $('<p/>')
                .text(wordsInList)
                .appendTo(li);

            var trashButtonInList = $('<button />')
                .addClass('remove-button-class')
                .prop('id', id)
                .click(removeWord)
                .appendTo(li);

            var trashGlyphInButton = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-trash')
                .appendTo(trashButtonInList);

            var editButtonInList = $('<button />')
                .addClass('edit-button-class')
                .prop('id', id)
                .click(editWord)
                .appendTo(li);

            var editGlyphInButton = $('<span />')
                .addClass('glyphicon')
                .addClass('glyphicon-pencil')
                .appendTo(editButtonInList);


        
            $('.list-div').append(cList);

            $(".click-sList").click(function () {
                
                $(this).toggleClass('toggleClass-li-clicked');
                $(this).find('.bock-class').toggleClass('bock-visible');
            });
        
    }

    //$(function () {
    //    // Reference the auto-generated proxy for the hub.  
    //    var chat = $.connection.chatHub;
    //    // Create a function that the hub can call back to display messages.
    //    chat.client.addNewMessageToPage = function (name, message) {
    //        // Add the message to the page. 
    //        $('#discussion').append('<li><strong>' + htmlEncode(name)
    //            + '</strong>: ' + htmlEncode(message) + '</li>');
    //    };
    //    // Get the user name and store it to prepend to messages.
    //    $('#displayname').val(prompt('Enter your name:', ''));
    //    // Set initial focus to message input box.  
    //    $('#message').focus();
    //    // Start the connection.
    //    $.connection.hub.start().done(function () {
    //        $('#sendmessage').click(function () {
    //            // Call the Send method on the hub. 
    //            chat.server.send($('#displayname').val(), $('#message').val());
    //            // Clear text box and reset focus for next comment. 
    //            $('#message').val('').focus();
    //        });
    //    });
    //});
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

