const listaContatos = [];
listaContatos.push({nome:'Ramon', email:'ramonl@email.com'})
listaContatos.push({nome:'Luiz', email:'ramonl@email.com'})
listaContatos.push({nome:'João', email:'ramonl@email.com'})
listaContatos.push({nome:'Carlos', email:'ramonl@email.com'})

const listarContatos = () => {
    var listaHTML = $('#lista-contatos');

    listaContatos.forEach((c) => {
        var linha = document.createElement('tr');
        var colNome = document.createElement('td');
        var colEmail = document.createElement('td');
        console.log(c);
        $(colNome).html(c.nome);
        $(colEmail).html(c.email);
        $(linha).append(colNome).append(colEmail);
        $('#lista-contatos').append(linha);
    });
}

$(document).ready(()=>{
    console.log('Dashboard')
    if(!verificaLogin()) {
        window.location.href = 'index.html';
    }

    listarContatos();
})