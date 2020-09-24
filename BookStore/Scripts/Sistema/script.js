$(document).ready(() => {

    setarFocoPrimeiroComponente();
    autoAjusteAltura();

    $('.button-left').click(function () {
        $('.sidebar').toggleClass('fliph');
    });

});

function autoAjusteAltura() {
    $(".padrao").css('height', '' + ($("footer").offset().top - 55) + 'px');
    $(".menu-lista").css('height', '' + ($("footer").offset().top - 96) + 'px');
    $("[id$='home']").css('height', '' + ($("footer").offset().top - 55) + 'px');
}

function setarFocoPrimeiroComponente() {
    // seta foco no primeiro elemento input que não esteja disabled, hidden ou readonly
    $("input:not(:disabled):not(input[type='hidden']):not([readonly])").first().focus();
}

function setStatusForm(statusForm) {
    let divStatusForm = $(".container.body-content.padrao").find('div:first')

    switch (statusForm) {
        case 1:
            divStatusForm.addClass('statusForm-novo')
            break;
        case 2:
            divStatusForm.addClass('statusForm-alterar')
            break;
        case 3:
            divStatusForm.addClass('statusForm-excluir')
            break;
        case 4:
            divStatusForm.addClass('statusForm-visualizar')
            break;

        default:
    }

    divStatusForm.attr('value', statusForm)
    desabilitarCampos(statusForm)
}

function desabilitarCampos(statusForm) {
    if (statusForm === 3 || statusForm === 4) {
        let inputs = $("form").find('input, select')

        for (var i = 0; i < inputs.length; i++) {
            $(inputs[i]).attr('readonly', 'readonly')
        }
    }
}