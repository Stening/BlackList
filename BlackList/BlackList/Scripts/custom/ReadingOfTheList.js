$(function () {

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

    }

  
})