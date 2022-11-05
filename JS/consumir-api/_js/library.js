/* # Confs */
var scripts = $('#scripts').clone();


/* # Functions*/
const getPagina = (url, target) => {
    $.ajax({
        url: `_views/${url}`,
        dataType: 'html',
        success: (pagina) => {
            $(target).html(pagina);
            // $("#scripts").html(scripts);
        }
    });
}


/*
- Function
function myFunc() {

}

- Arrrow Function
const myFunc = () => {}

- Anon Function
setTimeout(()=>{}, 500)
setTimeout(function()=>{}, 500)

*/