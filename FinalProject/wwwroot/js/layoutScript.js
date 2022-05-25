$(document).ready(function () {
    $("a").each(function () {
        console.log("good");
        console.log($(this).attr('href'));
        if ((window.location.pathname.indexOf($(this).attr('href'))) > -1) {
            $(this).addClass('activeMenuItem');
        }
    });
});