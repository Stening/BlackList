/*====================================
            On start
====================================*/
$(document).ready(function () {
    var CL = $.connection.blackListHub;
    //$('#myLists').click(function () 
    //{
    //    alet('hej');
    //    listInmeny(listArray);
    //});

    /*====================================
            Reading of the list
    ====================================*/
    //var listArray = ['Stening', 'Josefine', 'Wigge','Niclas']

    //function listInmeny(listArray) {

    //    $.each(listArray, function (i) {

    //        var ulListInMeny = $('<ul/>')
    //            .addClass('ul-list-meny')

    //        var liInMeny = $('<li />')
    //            .addClass('li-in-meny')
    //            .appendTo(ulListInMeny)

    //        var pInMeny = $('<p />')
    //            .text(listArray[i])
    //            .appendTo(liInMeny)


    //        $('#myLists').append(ulListInMeny); 



    //    });

    //   };


    /*====================================
       Generating list item from idlist
    ====================================*/
    function toggleNav() {
        if ($('#site-wrapper').hasClass('show-nav')) {
            // Do things on Nav Close
            $('#site-wrapper').removeClass('show-nav');
        } else {
            // Do things on Nav Open
            $('#site-wrapper').addClass('show-nav');
        }

        //$('#site-wrapper').toggleClass('show-nav');
    }
    $('body').on('click', '.sidemenu-li', function () {
        toggleNav();
    });

    /* Closing of meny with link click in LI element*/
    $('body').on('click', '.li-in-list', function () {
        CrudConnection.server.getListItems($(this).prop("id"));
        var heading = $(this).children().text();
        var liID = $(this).prop('id');
        $('.listheading-read').empty();
        $('.listheading-read').append(heading);
        $('.listheading-read').prop('id', liID);
        toggleNav();

    });


    var CrudConnection = $.connection.blackListHub;

    CrudConnection.client.dummy = function () { };


    CrudConnection.client.renderMyLists = function (myLists) {
        $("#ListMenuItem").empty();
        console.log("renderMyListstesting");
        var html = "<ul>";

        for (var i = 0; i < myLists.length; i++) {
            html += "<li id='" + myLists[i].ListID + "' class='li-in-list'><a href='#'data-toggle='collapse' data-parent='#accordion' data-target='#collapseFive' class='a-in-li' aria-expanded='false' aria-controls='collapseFive'><p>" + myLists[i].Title + "</p></a></li>";

        }
        html += "</ul>";
        $("#ListMenuItem").append(html);

        console.log(myLists);
        console.log("renderMyListstesting2");
        console.log("5");
    };




    CrudConnection.client.renderMyListItems = function (myListItems) {
        $("#secondUl").empty();
        //var html = "<ul>";
        //console.log(myListItems);
        if (myListItems.length == 0) {
            $("#secondUl").append("Inga saker i listan");
        }
        else {


            for (var i = 0; i < myListItems.length; i++) {
                renderListItem(myListItems[i].ItemName, myListItems[i].ListItemID, myListItems[i].IsChecked);


                //html += "<li id='" + myListItems[i].ListItemID + "'><p>" + myListItems[i].ItemName + "</p></li>";
            }
            //    html += "</ul>";
            //    $("#MyLists").append(html);
        }
    };

    var CrudConnection = $.connection.blackListHub;
    $.connection.hub.start().done(function () {
        CrudConnection.server.getMyLists();

    });
    $('body').on('click', '#remove-listItem', function () {
        var listID = $(this).parent().parent().children("h2").prop("id");
        CrudConnection.server.removeListWithItems(listID).done(function () {
            CrudConnection.server.getMyLists();
            $('#collapseFive').toggleClass('collapse');
            $('#collapseFive').toggleClass('in');
            //$('.listheading-read').toggleClass('toggleClass-div-hide');
            //$('#secondUl').toggleClass('toggleClass-div-hide');


        });
        console.log("test" + listID);
    });

    $("#ListMenuItem a").click(function () {

        console.log("menuclick registered!");
        CrudConnection.server.getMyLists();
    });


    CL.client.renderListItem = function (wordsInList, id, bool) {

        renderListItem(wordsInList, id, bool);
        console.log(bool +"var är boolen");
    };



    $('#add-to-listButton').click(function () {
        CL.server.addToListInReadMode($('#textbox-list-readMode').val(), $('.listheading-read').prop('id'));
        $('#textbox-list-readMode').val('');


        //Knapp för att ta bort hela listan
        $('#remove-list').click(function () {
            $('.ul-ShoppingList').remove();
        });

    });

    var renderListItem = function (wordsInList, id, bool) {
        function deleteWord() {

            CL.server.removeFromListCode(id);
        }

        //Takes new value and updates database, toggles the divs
        function sendNewWord() {
            var valueOftextbox = $(this).parent().children('input').val();
            $(this).parents('li').children().children('p').text(valueOftextbox);
            $(this).parents('li').children('div:nth-child(2)').toggleClass('toggleClass-div-show');
            $(this).parents('li').children('div:nth-child(1)').toggleClass('toggleClass-div-hide');
            CL.server.editWordListCode(id, valueOftextbox, $('.headingForListName').prop('id'));

        }

        //Toggles the divs fpr update procedure
        function editWord() {
            $(this).parent('div').toggleClass('toggleClass-div-hide');
            $(this).parents('li').children('div:nth-child(2)').toggleClass('toggleClass-div-show');


        }

        //Skapar listan med ord
        //var cList = $('<ul/>')
        //.addClass('ul-ShoppingList');
        //$.each(wordsInListArray, function(i) {
        //var nameOfList = $('#listName').val();

        //var listHeading = $('<h2 />')
        //    .addClass('headingForListName')
        //    .prop('id', listID);

        //var headingText = $('<p/>')
        //    .text(nameOfList)
        //    .appendTo(listHeading);

        var li = $('<li/>')
            .addClass('li-ShoppingList')
            .addClass('click-sList')
            .prop("id", id);

        var defaultDiv = $('<div />')
            .addClass('default-div-word')
            .appendTo(li);

        var spanInList = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-ok')
                .addClass('bock-class-read')
                .appendTo(defaultDiv);

        var text = $('<p/>')
            .addClass('word-in-p')
            .addClass('col-lg-5')
            .text(wordsInList)
            .click(toggleListWordsHubCall)
            //.click(toggleListWords)
            .appendTo(defaultDiv);
            //.addClass(wordsInList.IsChecked)

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


        $('#secondUl').append(li);
        $('#textbox-list-readMode').val('');


        if (bool == true) {
            text.addClass('toggleClass-li-clicked');
        }
    };

    function toggleListWordsHubCall() {
        var liId = $(this).parents('li').prop('id');
        var listId = $('.listheading-read').prop('id');
        var listName = $(this).text();
        

        
        CL.server.toggleListWordInHub(liId, listId, listName);
    }

    CL.client.toggleListWordsTrue = function (id) {

        $('li#' + id).find('p').addClass('toggleClass-li-clicked');
        //$('#' + id).children('div:nth-child(1)').children('word-in-p').css('color', 'red');//toggleClass('toggleClass-li-clicked');
        //$('#' + id).addClass('bock-visible');
    };

    CL.client.toggleListWordsFalse = function (id) {
        $('li#' + id).find('p').removeClass('toggleClass-li-clicked');
        console.log($('li#' + id).find('p'));
    }

    function toggleListWords() {
        $(this).toggleClass('toggleClass-li-clicked');
        $(this).parent().children('span').toggleClass('bock-read-visible');
    }
    function deleteWord() {
        CL.server.removeFromListCode(id);
    }


});

  
            

