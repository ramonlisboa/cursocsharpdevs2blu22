/*
 * Functions de Apoio
*/

const fillDestaques = (data) => {
    
    data.results.forEach((p,i) => {
        if(i > 3)
            return;
        let item = `<div class="col-3"> 
            <div class="card">
            <div class="card-header bg-danger">
                <h3 class="text-white" >${p.name}</h3>
            </div>
            <div class="card-body">${p.url}</div>
        </div></div>`;
        $('#destaque').append(item);
    });
}

const getView = (viewName, target) => {
    let ajaxConfig = {
        url: `_views/${viewName}.html`,
        dataType: 'html',
        success: (response) => {
            $(target).html(response);
        }
    };

    $.ajax(ajaxConfig);
}