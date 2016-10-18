$(document).ready(function () {
    $(".fliphover").hover(function () {
        $(this).addClass('hover');
    }, function () {
        $(this).removeClass('hover');
    });

    $("ul.sidebar-menu li.sub-menu a").hover(function () {
        $(this).addClass('hovered');
    }, function () {
        $(this).removeClass('hovered');
    });
});