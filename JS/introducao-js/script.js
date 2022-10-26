// Variáveis
const URL_VIACEP = 'https://viacep.com.br/ws/@CEP/json/';

// Carregar a página
addEventListener('load', (e) => {
    console.log('Sistema carregado...');
    $('#bloco').style.display = 'none';

    // Registra evento CEP
    $('#cep').addEventListener('blur',(e) => {
        var valorCampo = e.target.value;
        console.log(`O valor digitado foi '${valorCampo}'`)
        if(valorCampo.length >= 8){
            $('#endereco').style.display = 'block';
            var urlCep = URL_VIACEP.replace('@CEP', valorCampo);
            getJson(urlCep)
            .then((resp) =>{
                
            });
        }

    });
});

function getJson(url) {
    return fetch(url)
           .then((resposta) => resposta.json());
}

function $(querySelector) {
    return document.querySelector(querySelector);
}

/*
//--- Introdução
console.log('Script loaded.');
var nome, idade;

// nome = prompt("Informe seu nome");
// console.log(`Nome: ${nome}`);

// idade = prompt('Informe sua idade')
// console.log(`Idade: ${idade}`);
// alert('Olá Mundo');

var bloco = document.getElementById('bloco');

bloco.addEventListener('mouseover',function(e){
    bloco.style.marginLeft = '5em';
    bloco.style.backgroundColor = 'red';
});

bloco.addEventListener('mouseout',function(e){
    bloco.style.marginLeft = '0';
    bloco.style.backgroundColor = 'blueviolet';
});

var textoBloco = document.querySelector('#bloco span');

textoBloco.style.color = '#fff';
*/