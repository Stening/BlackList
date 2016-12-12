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
  
        var arr = ["101", "102", "103", "104"];






    var CrudConnection = $.connection.cRUDHub;
    $.connection.hub.start().done(function () {


        CrudConnection.server.getMyLists();

        
    })

    $('body').on('click', '.li-in-list', function () {

        var id = $(this).attr("id")
        console.log(id)
        CrudConnection.server.getListItems(id);


    })


    CrudConnection.client.renderMyLists = function (myLists) {
        
        var html = "<ul>";

        for (var i = 0; i < myLists.length; i++) {
            html += "<li id='" + myLists[i].ListID + "' class='li-in-list'><p>" + myLists[i].Title + "</p></li>";
        }
        html += "</ul>";
        $("#MyLists").append(html);
        

    }
    CrudConnection.client.renderMyListItems = function (myListItems) {
        var html = "<ul>";
        console.log(myListItems);
        for (var i = 0; i < myListItems.length; i++) {
            html += "<li id='" + myListItems[i].ListItemID + "'><p>" + myListItems[i].ItemName + "</p></li>";
        }
        html += "</ul>";
        $("#MyLists").append(html);

    }
  
})