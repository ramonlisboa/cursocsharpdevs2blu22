const usuario = {
    nome:'',
    login: '',
    senha: ''
}

const LOGADO = 'userLogado';
const USER = 'user';

$(document).ready(()=>{
    console.log('JQuery loaded.');

    verificaLogin();
});

// Functions

const getPagina = (page, target) => {
    $.ajax({
        url: page,
        dataType: 'html',
        success: (pResponse) => {
            $(target).html(pResponse);
        }
    });
}

const realizaLogin = (user) => {
    localStorage.setItem(LOGADO, 'true');
    localStorage.setItem(USER, JSON.stringify(user));
    window.location.href = 'dashboard.html';
}

const realizaLogoff = () => {
    localStorage.removeItem(LOGADO);
    localStorage.removeItem(USER);
}

const verificaLogin = () => {
    if(localStorage.getItem(LOGADO) == 'true'){
        console.log('Logado');
        return true;
    } else {
        console.log('Deslogado');
        return false;
    }
}

const getRegistroStorage = (key) =>{
    return localStorage.getItem(key);
}

const insertRegistroStorage = (key, value) => {
    if(typeof value == usuario){
        localStorage.setItem(key, JSON.stringify(value));
    }
}
