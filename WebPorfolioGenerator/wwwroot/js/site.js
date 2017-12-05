// Write your JavaScript code.
$("#login-button").click(function (event) {
    event.preventDefault();

    $('form').fadeOut(500);
    $('.wrapper').addClass('form-success');
});

$("#newItemMenu").click(function (event) {
    $('#menuElement').clone().prependTo('#menuElement');
});


function checkPasswords() {

}