var urlHelper = {
    adicionarParametrosNaUrl: function (urlBase, parametros) {
        var parametrosFormatados = [];
        if (parametros) {
            for (var parametro in parametros) {
                parametrosFormatados.push(parametro + '=' + encodeURIComponent(parametros[parametro]));
            }
            urlBase += '?' + parametrosFormatados.join('&');
        }
        return urlBase;
    }
}   