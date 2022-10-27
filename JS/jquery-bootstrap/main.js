$(document).ready(()=>{
    console.log('JQuery is loaded.');

    $('#btn-login').click((e)=>{
        $('#modalLogin').modal('toggle');
    })
});