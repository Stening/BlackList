
$(function () {
    var arr = ["one", "two", "three", "four"];
    var obj = { one: 1, two: 2, three: 3, four: 4};

    $.each(arr, function (i, val) {
        $("#" + val).attr(id,  val);
    });

    $.each(obj, function (i, val) {
        $("#" + i).append(document.createTextNode(" - " + val));
    });


});