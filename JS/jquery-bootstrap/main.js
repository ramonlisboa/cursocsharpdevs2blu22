$(document).ready(()=>{
    console.log('JQuery is loaded.');

    $('#alert').hide();

    $('#btn-login').click((e)=>{
        $('#modalLogin').modal('toggle');
    })

    // Carregar Pagina
    $('#intro-jquery').click((e)=>{
        $.ajax({
            url: "introducao-jquery.html",
            success: (data, textStatus, xhr)=>{
                console.log(data);
                console.log(textStatus);
                console.log(xhr);
                $('#conteudo').html(data);
            }
          });
    });

    $('#btn-salvar-teste').click(()=> {
        let nome = $('#nome').val();
        let idade = $('#idade').val();
        let htmlMsg = `Pessoa ${nome} - Idade ${idade}`;
        showMsgToast(htmlMsg);
        showMsgAlert(htmlMsg);
    });
});


const showMsgToast = (msg) => {
    let elToast = document.getElementById('msgToast');
    $('#msg-body').html(msg);
    const toast = new bootstrap.Toast(elToast)
    toast.show();
}

const showMsgAlert = (msg) => {
    $('#msg-alert').html(msg);
    $('#alert').fadeIn('slow');

    setTimeout(()=>{
        $('#alert').fadeOut('slow');
    },3000);
}