$(function () {
    jogo.acoes.click();
});

var jogo = {
    acoes: {
        click: function () {
            this.detalharAmigoDoJogo();            
        },
        detalharAmigoDoJogo: function () {
            var parametro = { id: window.modelJogo.JogoId };
            var urlComParametro = window.urlHelper.adicionarParametrosNaUrl(app.Urls.urlDetalharAmigoJogo, parametro);

            $("#detalharAmigo").on("click", function () {               
                $.ajax({
                    url: urlComParametro,
                    type: "GET",
                    dataType: "html",
                    success: function (data) {
                        $("#containerModal").html(data);
                        $("#modalDetalheAmigo").modal("show");
                    }
                });
            });
        }        
    }
};