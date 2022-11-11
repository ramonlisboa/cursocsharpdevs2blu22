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
        html.classList.add('card', 'col-4', 'my-4', 'bg-dark');
        html.addEventListener('click', ()=> mostraDetalhesCharacter(character))

        let htmlBody = `
        <div class="card-header">
            <img class="card-img-top" src="${character.image}" alt="${character.name}">
        </div>
        <div class="card-body bg-white">
            <h1 class="text-primary text-center">${character.name}</h1>
        </div>`;

        html.innerHTML = htmlBody;
        main.appendChild(html);
        listCharacter.push(character);
    });
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