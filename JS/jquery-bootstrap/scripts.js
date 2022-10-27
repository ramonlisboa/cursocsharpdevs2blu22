$(document).ready((e)=>{
    console.log('#  JQuery loaded.')
    $('#nome').val('Ramon Lisboa');

    $('#btnSalvar').click((e)=>{
        e.preventDefault();
        console.log(`Nome: ${$('#nome').val()}`);
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
            } else {
                console.log('Email inválido');
                e.target.focus();           
            }
    });
});