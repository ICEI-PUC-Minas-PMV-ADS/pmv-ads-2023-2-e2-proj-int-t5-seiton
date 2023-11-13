// Adicione JavaScript para exibir/ocultar o menu suspenso quando a imagem � clicada

function joaquim() {
    if (document.querySelector('.dropdown-content').style.display === 'block') {
        document.querySelector('.dropdown-content').style.display = 'none';
        } else {
        document.querySelector('.dropdown-content').style.display = 'block';
        }
};

var openModalBtn = $('#openModalBtn');
var closeModalBtn = $('#closeModalBtn');
var modal = $('#myModalE');
var modalContent = $('#modalContent');

function ModalOpen(id, url) {

    // Carregue os dados da p�gina Secundaria.aspx usando AJAX
    $.ajax({
        url: url + id, // Substitua pela URL correta
        type: 'GET',
        success: function (data) {
            modalContent.html(data);
            modal.show();
        },
        error: function () {
            console.error('Erro ao carregar os dados.');
        }
    });
};

closeModalBtn.on('click', function () {
    modal.hide();
});

// Feche o modal se o usu�rio clicar fora dele
$(window).on('click', function (event) {
    if (event.target === modal[0]) {
        modal.hide();
    }
});
