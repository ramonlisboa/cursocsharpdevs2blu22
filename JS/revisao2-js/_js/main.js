var listCharacter = new Array();

addEventListener('load', function(){
    getAPI(URL_API_CHARACTER, criaListaCharacter);
});


const criaListaCharacter = (data) => {
    let main = getElement('main');
    console.log(data);
    listCharacter = new Array();

    data.results.forEach(character => {
        let html = document.createElement('div');
        html.classList.add('card', 'col-2', 'my-4', 'bg-dark', 'ms-1');
        html.addEventListener('click', ()=> mostraDetalhesCharacter(character))

        let htmlBody = `
        <div class="card-header">
            <img class="card-img-top" src="${character.image}" alt="${character.name}">
        </div>
        <div class="card-body bg-white">
            <h2 class="text-primary text-center">${character.name}</h2>
        </div>`;

        html.innerHTML = htmlBody;
        main.appendChild(html);
        listCharacter.push(character);
    });

    gerarPaginacao(data.info);
}

const mostraDetalhesCharacter = (character) => {
    console.log(character);
    let div = document.createElement('div');
    getElement('#modal-body').innerHTML = "";
    div.classList.add('card', 'col-12', 'my-4', 'bg-dark');

    let cardBody = `
            <div class="card-header">
                <img class="card-img-top" src="${character.image}" alt="Rick">
            </div>
            <div class="card-body bg-white">
                <h1 class="text-primary text-center">${character.name}</h1>
                <article>
                    <ul class="list-group">
                        <li class="list-group-item">${character.status}</li>
                        <li class="list-group-item">${character.species}</li>
                        <li class="list-group-item">${character.gender}</li>
                        <li class="list-group-item">${character.origin.name}</li>
                        <li class="list-group-item">${character.location.name}</li>
                        <li class="list-group-item">${character.url}</li>
                        <li class="list-group-item">${character.created}</li>
                    </ul>
                </article>
            </div>
        `;
        div.innerHTML = cardBody;
        getElement('#modal-body').appendChild(div);

        $('#charModal').modal('show');
}

const gerarPaginacao = (info, currentPage=null) => {
    let pag = getElement('#pagination');
    pag.innerHTML = "";
    
    let prevItem = novoItemPagination(info.prev, 'Previous');
    pag.appendChild(prevItem);
    
    let indexPagination = (currentPage && currentPage > 5) ? currentPage - 5 : 0;

    for (let index = indexPagination; index < info.pages; index++) {
        if(currentPage == null &&
             index < 5) {
            let liItemPag = novoItemPagination(`${URL_API_CHARACTER}?page=${index + 1}`, `${index + 1}`);
                pag.appendChild(liItemPag); 
        }
        if(currentPage == null &&
            (index > (info.pages - 5) &&
                index < info.pages)) {
           let liItemPag = novoItemPagination(`${URL_API_CHARACTER}?page=${index + 1}`, `${index + 1}`);
               pag.appendChild(liItemPag); 
       }

        // item clicado
        if(currentPage && !(indexPagination > (currentPage) ||
            indexPagination < (info.pages - 5))) {
                let liItemPag = novoItemPagination(`${URL_API_CHARACTER}?page=${index + 1}`, `${index + 1}`);
                pag.appendChild(liItemPag);                
        }
    }

    let nextItem = novoItemPagination(info.next, 'Next');
    pag.appendChild(nextItem);
}

const novoItemPagination = (url, index) => {
    let liItem = document.createElement('li');
    liItem.classList.add('page-item');    
    liItem.innerHTML = `<a onclick="irItemPaginacao('${url}')" class="page-link" href="#">${index}</a>`;
    return liItem;
}

const irItemPaginacao = (url) => {

}
