/*
 * Functions de Apoio
*/

var listaPokemons = new Array();

const fillDestaques = () => {
    let data = stg.getJson(KEY_LISTA_PKMN);
    //console.log(data);
    
    for(let i in data) {
        if(i > 3)
            break;
        let p = data[i];
        let item = `<div class="col-3"> 
            <div class="card">
            <div class="card-header bg-danger">
                <img class="card-img-top" src="${p.img}">
            </div>
            <div class="card-body">
                <h3>${p.name}</h3>
            </div>
        </div></div>`;
        console.log(p);
        $('#destaque').append(item);
    }
}

const getView = (viewName, target) => {
    let ajaxConfig = {
        url: `_views/${viewName}.html`,
        dataType: 'html',
        success: (response) => {
            $(target).html(response);
        }
    };

    $.ajax(ajaxConfig);
}

const atualizarListaPKMNStorage = (force=false) => {
    // if(VerificarAtualizacaoLista() ||
    //     !force)
    //     return;

    listaPokemons = new Array();
    getAPI(URL_API_PKMN,  (data) => {
        //percorre lista de pokemons na propriedade results
         data.results.forEach( (p) => {
            getInfosAPIPromise(p.url).then((objPokemon) => {
                let pkmn = {
                    id: objPokemon.id,
                    name: objPokemon.name,
                    url: p.url,
                    img: objPokemon.sprites.front_default
                }
                listaPokemons.push(pkmn);
                //atualiza lista no storage
                stg.setJson(KEY_LISTA_PKMN, listaPokemons);
            });
        });

    });
}

const VerificarAtualizacaoLista = () => {
    let listaPkmn = stg.getJson(KEY_LISTA_PKMN);
    if(listaPkmn && listaPkmn.length > 0) 
        return true;
    else 
        return false;
}