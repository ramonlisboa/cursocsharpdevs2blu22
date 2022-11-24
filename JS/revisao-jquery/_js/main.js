

$(document).ready(()=>{
    console.log('JQuery is loaded.');

    //Inicializa parametros do sistema
    init();
});

const init = () => {
    // Carregar Views
    getView('home', '#root');

    // Carregar Servicos
    initializeServices();

    // Carregar Eventos
    initializeEvents();
}

const initializeServices = () => {
    // Carregar/Armazenar Pokemons da API
    atualizarListaPKMNStorage();

    // * Destaques
    fillDestaques();
    

}

const initializeEvents = () => {

    // # Meus Pokemons
    $('#pag-meus-pokemons').click(()=>getView('meus-pokemons','#root'));

    // Botao Pesquisar
    $('#btn-pesquisa').click((e)=>{
        e.preventDefault();
        let valorPesquisa = $('#input-pesquisa').val();
        //realizar pesquisa
    });

}