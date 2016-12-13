

$(document).ready(function () {
    var CL = $.connection.cRUDHub;
    //starts the connection to the hub and calls createmethod in hub and creates list
    $.connection.hub.start().done(function () {
        $('#createList').click(function () {
            CL.server.createListCode($('#listName').val());
            $('#listName').toggleClass('toggleClass-hide-create');
            $('#createList').toggleClass('toggleClass-hide-create');
            $('#addToListID').toggleClass('toggleClass-div-show');
        });

    });

    //Makes the words in the list clickable
    

    //Tar bort li elemnt från listan efter att detta görs i databasen
    CL.client.deleteWordfromList = function (deleteWordID) {
        $('#'+deleteWordID).remove();

    }

    
        //Calls the add method in hub and adds the word to the database
        $('#add-to-list-button').click(function () {
            CL.server.addToListCode($('#textbox-list').val(), $('.headingForListName').prop('id'));

           
            //Knapp för att ta bort hela listan
            $('#remove-list').click(function () {
                $('.ul-ShoppingList').remove();
            });

        });
    

    //Creates the html for the list heading
    CL.client.createList = function (listID) {
        var nameOfList = $('#listName').val();

        var listHeading = $('<h2 />')
            .addClass('headingForListName')
            .prop('id', listID);

        var headingText = $('<p/>')
            .text(nameOfList)
            .appendTo(listHeading);

        $('.create-list-div').append(listHeading)
    }

    // Add Words to list
    CL.client.addToList = function (wordsInList, id ) 
    {
        function deleteWord() {
            CL.server.removeFromListCode(id);              
        }

        //Takes new value and updates database, toggles the divs
        function sendNewWord() {            
            var valueOftextbox = $(this).parent().children('input').val()
            $(this).parents('li').children().children('p').text(valueOftextbox);
            $(this).parents('li').children('div:nth-child(2)').toggleClass('toggleClass-div-show');            
            $(this).parents('li').children('div:nth-child(1)').toggleClass('toggleClass-div-hide');
            CL.server.editWordListCode(id, valueOftextbox, $('.headingForListName').prop('id'));
            
        }

        //Toggles the divs fpr update procedure
        function editWord() {            
            $(this).parent('div').toggleClass('toggleClass-div-hide');
            $(this).parents('li').children('div:nth-child(2)').toggleClass('toggleClass-div-show');
           
               
        };

        //Skapar listan med ord
            //var cList = $('<ul/>')
            //.addClass('ul-ShoppingList');
        //$.each(wordsInListArray, function(i) {

        var li = $('<li/>')
            .addClass('li-ShoppingList')
            .addClass('click-sList')
            .prop("id", id);                

            var defaultDiv = $('<div />')
                .addClass('default-div-word')
                .appendTo(li);
            
            var text = $('<p/>')
                .addClass('word-in-p')
                .addClass('col-lg-5')
                .text(wordsInList)
                .click(toggleListWords)
                .appendTo(defaultDiv);

            var spanInList = $('<span/>')
                    .addClass('glyphicon')
                    .addClass('glyphicon-ok')
                    .addClass('bock-class')
                    .appendTo(text);

            var trashButtonInList = $('<button />')
                .addClass('remove-button-class')
                .click(deleteWord)
                .appendTo(defaultDiv);

            var trashGlyphInButton = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-trash')
                .appendTo(trashButtonInList);

            var editButtonInList = $('<button />')
                .addClass('edit-button-class')                
                .click(editWord)
                .appendTo(defaultDiv);

            var editGlyphInButton = $('<span />')
                .addClass('glyphicon')
                .addClass('glyphicon-pencil')
                .appendTo(editButtonInList);

            var updateDiv = $('<div />')
            .addClass('update-word-div')            
            .appendTo(li);

            var newTextBox = $('<input>', {
                type: 'text',
                val: wordsInList
            }).addClass('textbox-for-update').prop('id', 'editBox' + id).appendTo(updateDiv);

            var editButton = $('<button />')
                .addClass('save-new-word')
                .click(sendNewWord)
                .appendTo(updateDiv);

            var updateGlyphInButton = $('<span />')
                .addClass('glyphicon')
                .addClass('glyphicon-floppy-saved')
                .appendTo(editButton);

        
            $('#theUlList').append(li);

            
    }
    
});



//$(this).closest('li').prop('id');

  

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

