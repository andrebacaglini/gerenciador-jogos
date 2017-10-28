$(function () {
    documentacao.acoes.click();
});

var documentacao = {
    acoes: {
        click: function () {
            this.detalharListaJogosAmigo();            
        },
        detalharListaJogosAmigo: function () {
            var parametro = { id: window.modelAmigo.AmigoId };
            var urlComParametro = window.urlHelper.adicionarParametrosNaUrl(app.Urls.urlListarJogosAmigo, parametro);

            $("#listarJogosEmprestados").on("click", function () {               
                $.ajax({
                    url: urlComParametro,
                    type: "GET",
                    dataType: "html",
                    success: function (data) {
                        $("#containerModal").html(data);
                        $("#modalListaJogosAmigo").modal("show");
                    }
                });
            });
        }        
    }
};