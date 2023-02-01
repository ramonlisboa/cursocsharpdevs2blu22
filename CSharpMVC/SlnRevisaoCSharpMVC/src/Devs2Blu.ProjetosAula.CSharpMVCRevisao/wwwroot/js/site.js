$(document).ready(() => {
    $('#btn-search').click((e) => {
        e.preventDefault();
        let nameInput = $('#input-search').val();
        $.ajax({
            url: `/cards/search/${nameInput}`,
            dataType: 'html',
            success: (htmlPartialView) => {
                $('#content-list').html(htmlPartialView);
            }
        });
    })
});