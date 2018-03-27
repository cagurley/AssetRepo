$('.card-front').hide(0);
$('.top-row').each(function (i) {
    $(this).delay(400 * i).fadeIn(400);
});
$('.bottom-row').each(function (i) {
    $(this).delay(400 * i).fadeIn(400);
});