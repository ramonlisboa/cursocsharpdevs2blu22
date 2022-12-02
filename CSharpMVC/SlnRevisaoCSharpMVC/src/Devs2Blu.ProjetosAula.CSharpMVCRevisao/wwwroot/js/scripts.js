const getView = (controller, viewName, target, params=null) => {
    let url = `/${controller}/${viewName}`;
    url += (params) ? `${params}` : '';
    let ajaxConfig = {
        url: url,
        dataType: 'html',
        success: (response) => {
            $(target).html(response);
        }
    };

    $.ajax(ajaxConfig);
}