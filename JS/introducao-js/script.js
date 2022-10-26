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
