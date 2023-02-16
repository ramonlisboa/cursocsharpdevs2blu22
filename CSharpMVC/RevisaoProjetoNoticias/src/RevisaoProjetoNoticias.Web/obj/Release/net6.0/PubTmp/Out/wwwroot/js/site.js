$(document).ready(() => {
    console.log('CMSSite - Script loaded.');

    
});

liveToastMessage = (message, origin) => {
    $('#toast-body').html(message);
    $('#toast-origin').html(origin);
    $('#toast-time').html(new Date().toLocaleTimeString('pt-BR', {hour12: false,
                                                                    hour: "numeric",
                                                                    minute: "numeric"
                                                                }));
    const toastLiveMessages = $('#liveToast');
    const toast = new bootstrap.Toast(toastLiveMessages)

    toast.show()
}

msgModalMessage = (message, callback) => {
    $('#modal-body').html(message);
    $('#btnModalCallback').click(() => callback());

    $('#msgModal').modal('show');
}

closeMsgModalMessage = () => {
    $('#msgModal').modal('hide');
}