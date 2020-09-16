$(document).ready(() => {
    // seta foco no primeiro elemento input que não esteja disabled, hidden ou readonly
    $("input:not(:disabled):not(input[type='hidden']):not([readonly])").first().focus();

    $(".padrao").css('height', '' + ($("footer").offset().top - 105) + 'px');
});