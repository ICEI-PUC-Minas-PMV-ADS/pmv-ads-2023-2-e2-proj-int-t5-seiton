// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    // Lidar com o clique no botão "Criar Coluna"
    $(".project-name").click(function () {
        // Recupere o projetoId do elemento selecionado, você pode usá-lo para associar a nova coluna ao projeto
        var projetoId = // Recupere o projetoId de alguma forma, talvez de um atributo de dados no HTML

            // Envie uma solicitação AJAX para o servidor para criar a coluna
            $.ajax({
                type: "POST",
                url: "/LogadosController/CriarColuna", // Ação que irá criar a coluna
                data: { projetoId: projetoId }, // Dados que você deseja enviar ao servidor
                success: function (data) {
                    // Lida com a resposta do servidor, se necessário
                    console.log(data);

                    // Recarregue ou atualize a lista de colunas na interface do usuário
                    // Isso pode envolver outra chamada AJAX ou manipulação do DOM para exibir a nova coluna
                },
                error: function (error) {
                    console.error("Erro na solicitação AJAX: " + error);
                }
            });
    });
});