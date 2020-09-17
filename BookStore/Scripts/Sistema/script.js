$(document).ready(() => {
    var _StatusForm = -1;

    // seta foco no primeiro elemento input que não esteja disabled, hidden ou readonly
    $("input:not(:disabled):not(input[type='hidden']):not([readonly])").first().focus();

    $(".padrao").css('height', '' + ($("footer").offset().top - 105) + 'px');
});

function setStatusForm(statusForm) {
    let h3StatusForm = $("*").find('h3[value=' + statusForm + ']')
    let divStatusForm = h3StatusForm.parent()

    switch (statusForm) {
        case 1:
            divStatusForm.addClass('statusForm-novo')
            break;
        case 2:
            divStatusForm.addClass('statusForm-alterar')
            break;
        default:
    }
}