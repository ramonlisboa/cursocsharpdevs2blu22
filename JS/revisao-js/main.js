const usuario = {
    nome:'',
    login: '',
    senha: ''
}

const LOGADO = 'userLogado';

$(document).ready(()=>{
    console.log('JQuery loaded.');

    verificaLogin();
});



// Functions

const realizaLogin = (user) => {

}

const realizaLogoff = (user) => {

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
