$("#login-button").click(function (event) {
    event.preventDefault();

    $('form').fadeOut(500);
    $('.wrapper').addClass('form-success');
});

$("#newItemMenu").click(function (event) {

    //var numero = $("#menuElement").size() + 1;

    //if ($("#menuElement").size() == 1) {
    //    elemento.attr("id", "menuElement_" + numeroMas);  
    //} else {

    //}
    //var elemento = $('#menuElement').clone();
    //var numeroMas = $("#menuElement").size() + 1;

    //$('#menuElement').append(elemento);
});

$("#editUser").submit(function () {
    var result = true;
    if ($("#pswrdOne").val() != $("#pswrdTwo").val()) {
        $("#difPswrd").html("The passwords are different");
        result = false;
    }
    return result;
});
