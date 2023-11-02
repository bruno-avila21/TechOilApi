// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener('load', () => {

    let $ = (elemento) => document.querySelector(elemento)
    console.log("buscador vinculado");

    document.addEventListener("keyup", e => {
        console.log(e.target.value);
        if (e.target.matches("#inputSearch"))
            document.querySelectorAll(".listado").forEach(usuario => {
                usuario.textContent.toLowerCase().includes(e.target.value) ? usuario.classList.remove('filtro')
                    : usuario.classList.add('filtro')
            })

    })
})


const tabla = document.querySelector("#tabla_Usuario > tbody");

function buscarID() {
    $("#tabla_Usuario > tbody").empty();

    $("#nombre") = "Pedro";

}

function mostrarFormulario() {
    var formulario = document.getElementById("mostrar");
    if (formulario.style.display === "none" || formulario.style.display === "") {
        formulario.style.display = "block";
    }
    else {
        formulario.style.display = "none";
    }
}

//function botonDelete() {
//    $("#destroy")

//}
