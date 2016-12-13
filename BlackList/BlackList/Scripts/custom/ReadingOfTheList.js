/*====================================
            On start
====================================*/
$(document).ready(function () {
    var CL = $.connection.cRUDHub;
    $('#myLists').click(function () 
    {
        alet('hej');
        listInmeny(listArray);
    });

    /*====================================
            Reading of the list
    ====================================*/
    var listArray = ['Stening', 'Josefine', 'Wigge','Niclas']

    function listInmeny(listArray) {

        $.each(listArray, function (i) {

            var ulListInMeny = $('<ul/>')
                .addClass('ul-list-meny')

            var liInMeny = $('<li />')
                .addClass('li-in-meny')
                .appendTo(ulListInMeny)

            var pInMeny = $('<p />')
                .text(listArray[i])
                .appendTo(liInMeny)

           
            $('#myLists').append(ulListInMeny); 

        

        });
            
       };


    /*====================================
       Generating list item from idlist
    ====================================*/

    var CrudConnection = $.connection.cRUDHub;
    $.connection.hub.start().done(function () {
        CrudConnection.server.getMyLists();
        
    })


    $('body').on('click', '#MyLists', function () {
        CrudConnection.server.getListItems();
    })

    CrudConnection.client.renderMyLists = function (myLists) {
        var html = "<ul>";

        for (var i = 0; i < myLists.length; i++) {
            html += "<li class='li-in-list'><p>" + myLists[i].Title + "</p></li>";
        }
        html += "</ul>";
        $("#MyLists").append(html);
        console.log(myLists);
        readListFromMenu(myLists);
        
    }

    $('body').on('click', '.li-in-list', function () {
        readListFromMenu(myLists);
    })

    function readListFromMenu(myLists) {

        //Skapar listan med ord
        //var cList = $('<ul/>')
        //.addClass('ul-ShoppingList');
        
        $.each(myLists[i], function (i) {

            var li = $('<li/>')
                .addClass('li-ShoppingList')
                .addClass('click-sList')
                .prop("id", myList[i].ListItemID);

            var defaultDiv = $('<div />')
                .addClass('default-div-word')
                .appendTo(li);

            var text = $('<p/>')
                .addClass('word-in-p')
                .addClass('col-lg-5')
                .text(myLists[i].ItemName)
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


            $('#collapseFive').append(li);

        });
    }

  
})