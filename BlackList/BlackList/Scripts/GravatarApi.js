$(document).ready(function () {
    console.log("Ready to find images");
    $('#get_image').click(function () {
        // get the email
        var email = $('#email').val();
        // -- maybe validate the email? 
        console.log(email);
        // create a new image with the src pointing to the user's gravatar
        var gravatar = $('<img>').attr({ src: 'http://www.gravatar.com/avatar/' + sha256(email) });
        // append this new image to some div, or whatever
        $('#my_whatever').append(gravatar);
        console.log(gravatar);
        // OR, simply modify the source of an image already on the page
        $('#image').attr('src', 'http://www.gravatar.com/avatar/' + sha256(email));
    });
});