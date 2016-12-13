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
            
    //   };


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


    var CrudConnection = $.connection.cRUDHub;

    CrudConnection.client.foo = function () { };

    console.log("1");
    CrudConnection.client.renderMyLists = function (myLists) {
        $("#ListMenuItem").empty();
        console.log("renderMyListstesting");
        var html = "<ul>";

        for (var i = 0; i < myLists.length; i++) {
            html += "<li id='" + myLists[i].ListID + "' class='li-in-list'><p>" + myLists[i].Title + "</p></li>";
        }
        html += "</ul>";
        $("#ListMenuItem").append(html);

        console.log(myLists);
        console.log("renderMyListstesting2");
        console.log("5");
    }
    console.log("2");
    CrudConnection.client.renderMyListItems = function (myListItems) {
        $("#MyLists").empty();
        var html = "<ul>";
        console.log(myListItems);
        if (myListItems.length == 0) {
            $("#MyLists").append("Inga saker i listan");
        }
        else {

        
        for (var i = 0; i < myListItems.length; i++) {
            html += "<li id='" + myListItems[i].ListItemID + "'><p>" + myListItems[i].ItemName + "</p></li>";
        }
        html += "</ul>";
        $("#MyLists").append(html);
        }
    }




    function readListFromMenu(myLists) {

    $.connection.hub.start().done(function () {
        console.log("3");

        CrudConnection.server.getMyLists();
        console.log("4");
    }).fail(function (reason) {
        console.log("error")
        console.log(reason);
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

    })
    $("#ListMenuItem a").click(function(){

        console.log("menuclick registered!");
        CrudConnection.server.getMyLists();

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

        });
    }

  
})

