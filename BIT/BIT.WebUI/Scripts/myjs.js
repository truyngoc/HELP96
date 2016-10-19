$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 116) {
            $('.navbar').css("background-color", "#fff");
            $('.navbar').css("padding", "17px");
            $('.navbar a').css("color", "#888");
        } else {
            $('.navbar').css("background-color", "#E6E7E8");
            $('.navbar').css("padding", "30px");
            $('.navbar a').css("color", "#F6921E");
        }
    });
    $('#toggle-login').click(function () {
        $('#login').toggle();
    });
    $(window).scroll(function () {
        if ($(this).scrollTop() > 116) {
            $('.navbar').css("background-color", "#fff");
            $('.navbar').css("border-bottom", "2px solid #e73437");
            $('.navbar').css("padding", "17px");
            $('.navbar a').css("color", "#e73437");
        } else {
            $('.navbar').css("background-color", "#E6E7E8");
            $('.navbar').css("border-bottom", "20px solid #e73437");
            $('.navbar').css("padding", "30px");
            $('.navbar a').css("color", "#e73437");
        }
    });
});