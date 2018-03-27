$('.card-front').hide(0);
$('.top-row').each(function (i) {
    $(this).delay(300 * i).fadeIn(300);
});
$('.bottom-row').each(function (i) {
    $(this).delay(300 * i).fadeIn(300);
});