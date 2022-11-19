const URL_API_PKMN = 'https://pokeapi.co/api/v2/pokemon/';


$(document).ready(()=>{
    console.log('JQuery is loaded.');

    init();
    
       
    
});

const init = () => {
    // Carregar Views
    getView('home', '#root');

    // # Meus Pokemons
    $('#pag-meus-pokemons').click(()=>getView('meus-pokemons','#root'));

    // Botao Pesquisar
    $('#btn-pesquisa').click((e)=>{
        e.preventDefault();
        let valorPesquisa = $('#input-pesquisa').val();
        //realizar pesquisa
    });

    // Carregar Servicos
    // * Destaques
    getAPI(URL_API_PKMN, fillDestaques);
}

const fillDestaques = (data) => {
    
    data.results.forEach((p,i) => {
        if(i > 3)
            return;

        let item = document.createElement('div');
        item.classList.add('col-4');
        $(item).html(`<div class="card">
            <div class="card-header bg-danger"></div>
        </div>`);
        $('#destaque').append(item);
    });
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

const getAPI = (url, fnCallBack) => {
    $.ajax({
        url: url,
        dataType: 'json',
        success: (data) => fnCallBack(data)
    });
}

// const getAPI2 = (url, fnCallBack) => {
//     let ajaxConfig = {};
//     ajaxConfig.url = url;
//     ajaxConfig.dataType = 'json';
//     ajaxConfig.success = (data) => fnCallBack(data);

//     $.ajax(ajaxConfig);
// }