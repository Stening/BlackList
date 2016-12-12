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
//    $(function () {
//        var arr = ["101", "102", "103", "104"];

//        $.each(arr, function (i, val) {
//            $("#" + val).text("ID: " + val);
//        });
//        $.each(arr, function (i, val) {
//            $("#" + i).append(document.createTextNode(", " + val));
//        });
//    });
//});