/*====================================
            On start
====================================*/
$(window).ready(function () {
//$(document).ready(function () {
//$(function () {
    //var CL = $.connection.cRUDHub;
    //$('#myLists').click(function () 
    //{
    //    alet('hej');
    //    listInmeny(listArray);
    //});

    ///*====================================
    //        Reading of the list
    //====================================*/
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


    ///*====================================
    //   Generating list item from idlist
    //====================================*/
  
    //    var arr = ["101", "102", "103", "104"];






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





    $.connection.hub.start().done(function () {
        console.log("3");

        CrudConnection.server.getMyLists();
        console.log("4");
    }).fail(function (reason) {
        console.log("error")
        console.log(reason);
    })

    $('body').on('click', '.li-in-list', function () {

        var id = $(this).attr("id")
        console.log(id)
        CrudConnection.server.getListItems(id);


    })
    $("#ListMenuItem a").click(function(){

        console.log("menuclick registered!");
        CrudConnection.server.getMyLists();

    })


    $('body').on('click', '#ListMenuItem', function () {


       


    })
    
   
  
})

