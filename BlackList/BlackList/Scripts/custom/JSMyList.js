﻿

$(document).ready(function () {
    var CL = $.connection.cRUDHub;

    $.connection.hub.start().done(function () {
        $('#createList').click(function () {
            CL.server.createListCode($('#listName').val());
            $('#listName').toggleClass('toggleClass-hide-create');
            $('#createList').toggleClass('toggleClass-hide-create');
            $('#addToListID').toggleClass('toggleClass-div-show');
        });

    });

    
    function toggleListWords() {
        $(this).toggleClass('toggleClass-li-clicked');
        $(this).find('.bock-class').toggleClass('bock-visible');
    }


    //Tar bort li elemnt från listan efter att detta görs i databasen
    CL.client.deleteWordfromList = function (deleteWordID) {
        $('#'+deleteWordID).remove();
        

    }

    //Add word to list
    
        $('#add-to-list-button').click(function () {
            CL.server.addToListCode($('#textbox-list').val(), $('.headingForListName').prop('id'));

           
            //Knapp för att ta bort hela listan
            $('#remove-list').click(function () {
                $('.ul-ShoppingList').remove();
            });

        });
    


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

        function sendNewWord() {            
            var valueOftextbox = $(this).parent().children('input').val()
            $(this).parents('li').children().children('p').text(valueOftextbox);
            $(this).parents('li').children('div:nth-child(2)').toggleClass('toggleClass-div-show');
            //$(this).parents('li').children('div:nth-child(2)').addClass('toggleClass-div-hide');
            $(this).parents('li').children('div:nth-child(1)').toggleClass('toggleClass-div-hide');
            CL.server.editWordListCode(id, valueOftextbox, $('.headingForListName').prop('id'));
            
        }

        function editWord() {            
            $(this).parent('div').toggleClass('toggleClass-div-hide');
            $(this).parents('li').children('div:nth-child(2)').toggleClass('toggleClass-div-show');
           // $('.update-word-div').toggleClass('toggleClass-div-show');
               
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
                .addClass('col-lg-1')
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
            //.addClass('toggleClass-div-hide')
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

            //$(".click-sList").click(function () {
                
            //    $(this).toggleClass('toggleClass-li-clicked');
            //    $(this).find('.bock-class').toggleClass('bock-visible');
            //});
        
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

