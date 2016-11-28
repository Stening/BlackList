

$(document).ready(function () {

    $('#createList').click(function () {
        
        createList();
        $(".click-sList").click(function () {
            $(this).toggleClass('toggleClass-li-clicked');
            $(this).find('.bock-class').toggleClass('bock-visible');
        });
    });

    $(".click-sList").click(function () 
    {
        $(this).toggleClass('toggleClass-li-clicked');
        $(this).find('.bock-class').toggleClass('bock-visible');
    });

    function createList() {

        var listWords = ['Mendokse','Dajubu','Onegai'];
        var cList = $('<ul/>')
            .addClass('ul-ShoppingList');
        $.each(listWords, function(i) {
            var li = $('<li/>')
                .addClass('li-ShoppingList')
                .addClass('click-sList')
                .appendTo(cList);
                
            var spanInList = $('<span/>')
                .addClass('glyphicon')
                .addClass('glyphicon-ok')
                .addClass('bock-class')
                .appendTo(li);
            
            var text = $('<p/>')
                .text(listWords[i])
                .appendTo(li);
                


        });

        $('.list-div').append(cList);
        //$('.li-ShoppingList').append('hej');
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

