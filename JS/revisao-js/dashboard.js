const delay = (ms) => new Promise((res) => setTimeout(res, ms));
const LISTA_CONTATOS = "lista_contatos";
var listaContatos = new Array();

$(document).ready(() => {
  console.log("Dashboard");
  limpaCampos();
  $("#msg .alert").hide();

  if (!verificaLogin()) {
    window.location.href = "index.html";
  }

  $("#btn-salvar").click((e) => salvarContato());

  listarContatos();
});

const regEventClickTr = () => {
    $("tr").click((e) => {
        let tr = $(e.target.parentElement);
        let regLinha = tr.find("td");
        let tdId = regLinha[0];
        $("#id").val($(tdId).html());
        $("#nome").val($(regLinha[1]).html());
        $("#email").val($(regLinha[2]).html());
      });
}

const salvarContato = () => {
  let nome = $("#nome");
  let email = $("#email");
  let id = $("#id");
  let tamLista = listaContatos == null ? 0 : listaContatos.length;
  let contato
  let msg = "Por favor, preencher todos os campos...";
  
  if (listaContatos == null) {
      listaContatos = new Array();
    }
    
    if (nome.val() === "" || email.val() === "") {
        $("#msg .alert").html(`<h3>${msg}</h3>`);
        $(".toast-body").html(msg);
        $("#msg .alert").fadeIn("slow", async () => {
            await delay(3000);
            $("#msg .alert").fadeOut("slow");
        });
        const toastLive = document.getElementById("liveToast");
        const toast = new bootstrap.Toast(toastLive);
        toast.show();
        return;
    }

    contato = { id: 0, 
        nome: nome.val(), 
        email: email.val() };

    if (id.val() !== "") {
        var i = listaContatos.findIndex((contato) => contato.id === id.val());
        contato.id = id.val();
        listaContatos.splice(i,1,contato);
    } else {
        let idInsert = tamLista + 1;
        contato.id = idInsert;
        listaContatos.push(contato);
  }

  setJsonItem(LISTA_CONTATOS, listaContatos);
  listarContatos();
  limpaCampos();
};

const listarContatos = () => {
  var listaHTML = $("#lista-contatos");
  listaHTML.html("");
  listaContatos = new Array();
  listaContatos = getJsonItem(LISTA_CONTATOS);

  if (listaContatos == null || listaContatos.length <= 0) return;

  listaContatos.forEach((c) => {
    var linha = document.createElement("tr");
    var colId = document.createElement("td");
    var colNome = document.createElement("td");
    var colEmail = document.createElement("td");
    var colActions = document.createElement("td");
    $(colActions).html(`<div class="d-flex">
        <button onclick="removeItemList(${c.id});" 
        class="btn btn-sm btn-danger">&times;</button>
    </div>`);

    $(colId).html(c.id);
    $(colNome).html(c.nome);
    $(colEmail).html(c.email);
    $(linha).append(colId).append(colNome).append(colEmail).append(colActions);
    listaHTML.append(linha);
  });

  regEventClickTr();
};

const removeItemList = (id) => {
  var i = listaContatos.findIndex((contato) => contato.id === id);
  listaContatos.splice(i, 1);

  setJsonItem(LISTA_CONTATOS, listaContatos);
  listarContatos();
};

const limpaCampos = () =>{
    $("#id").val("");
    $("#nome").val("");
    $("#email").val("");
}