

$(document).ready(function () {

    $('#createList').click(function () {
        
        //Skapar listan
        createList();

        //Ändrar layout på list elementen vid click
        $(".click-sList").click(function () {
            $(this).toggleClass('toggleClass-li-clicked');
            $(this).find('.bock-class').toggleClass('bock-visible');
        });

        //Tar bort li elementet associerat med trash button
        $('li').on('click', 'button', function () {
            $(this).closest('li').remove();
        });

        //Knapp för att ta bort hela listan
        $('#remove-list').click(function () {
            $('.ul-ShoppingList').remove();
        })

        
    });

    $(".click-sList").click(function () 
    {
        $(this).toggleClass('toggleClass-li-clicked');
        $(this).find('.bock-class').toggleClass('bock-visible');
    });

    function createList() {

        var listWords = ['Mendokse', 'Dajubu', 'Onegai'];
        var ids = ['id1', 'id2', 'id3'];
        var cList = $('<ul/>')
            .addClass('ul-ShoppingList');
        $.each(listWords, function(i) {
            var li = $('<li/>')
                .addClass('li-ShoppingList')
                .addClass('click-sList')
                .prop("id", ids[i])
                .appendTo(cList);
            
                
            var spanInList = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-ok')
                .addClass('bock-class')
                .appendTo(li);
            
            var text = $('<p/>')
                .text(listWords[i])
                .appendTo(li);

            var buttonInList = $('<button />')
                .addClass('remove-button-class')
                .prop('id', ids[i])
               
                .appendTo(li);

            var glyphInbutton = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-trash')
                .appendTo(buttonInList);
                          


        });

        $('.list-div').append(cList);
        
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

