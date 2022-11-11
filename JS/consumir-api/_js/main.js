/* # Confs */
const URL_API = 'https://pokeapi.co/api/v2/pokemon/';

$(document).ready(()=>{
    getPagina('home.html', 'main');
})

const getPokemonList = (offset=null,limit=null) => {

}


// URL: https://pokeapi.co/api/v2/pokemon/
const getPokemon = () => {
    getPagina('getPokemon.html','main');
    $.ajax({
        url: `${URL_API}?offset=1&limit=500`,
        dataType: 'json',
        success: (data) => {
            console.log(data);
            let listPkm = document.createElement('div');
            $(listPkm).addClass('row');
            $('#getPokemon').html(listPkm);

            data.results.forEach((p, i) => {
                let li = document.createElement('div');
                let card = document.createElement('div');
                let cardHeader = document.createElement('div');
                let cardBody = document.createElement('div');
                $(li).addClass('col-4');
                
                $(card).addClass('card');
                $(cardHeader).addClass('card-header');
                $(cardBody).addClass('card-body');
                
                $(cardHeader).attr('id', `ch-pkm${i}`);
                
                $(cardBody).html(`<h1>${p.name}</h1>`);
                
                
                $(card).append(cardHeader)
                       .append(cardBody);
                $(li).append(card);                     
                $(listPkm).append(li);
                getIMGPokemon(p.url,`#ch-pkm${i}`);
            });
        }
    });
}

// URL: Object pokemon.url
const getIMGPokemon = (url, target) => {
    return $.ajax({
        url: url,
        dataType: 'json',
        success: (data) => {
            let dataHtml = document.createElement('img');
            $(dataHtml).addClass('card-img-top');
            $(dataHtml).attr('src',data.sprites.front_default);
            $(dataHtml).css({width: '256px'});
            $(target).append(dataHtml);
        }
    });
}
