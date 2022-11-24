$(document).ready((e)=>{
    console.log('#  JQuery loaded.')
    $('#nome').val('Ramon Lisboa');

    $('#btnSalvar').click((e)=>{
        e.preventDefault();
        var nome = $('#nome');
        var email = $('#email');
        // console.log(`Nome: ${$('#nome').val()}`);

        console.log(nome.val());
        console.log(email);
        if(nome.val() === "" ||
           email.val() === ""){
            $('#form').css('border', '2px solid red');
        } else {
            $('#form').css('border', '2px solid green');
            $('#nome-quadro').html(nome.val());
            $('#email-quadro').html(email.val());
            $('#quadro').show();
        }
    });

    $('#email').on('change', (e)=>{
        // e.target == $(this)
        // console.log($(this).val());
        var email = e.target.value;
        console.log(email);
        var valid = String(email)
            .toLowerCase()
            .match(
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            );

            if(valid){
                console.log('Email válido');
                $('#email').css({
                    'background-color':'#ccc'
                });    
                $('#nome').css({
                    'background-color':'#ccc'
                });    
            } else {
                console.log('Email inválido');
                e.target.focus();   
                $('#email').css('outline','1px solid red');      
            }
    });

    $('#quadro').on('mouseenter', (e)=>{
        $('#quadro').addClass('animacao-quadro')
    });
    $('#quadro').on('mouseleave', (e)=>{
        $('#quadro').removeClass('animacao-quadro')
    });
});