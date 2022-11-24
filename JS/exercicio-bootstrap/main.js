$(document).ready(()=>{
    $('#link-interna').click((e)=>{
        $('#destaque').hide();

        $.ajax({
            url: 'interna.html',
            dataType: 'html',
            success: (data) =>{
                $('main').html(data);
            }
        });
    });
});