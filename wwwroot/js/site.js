// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function confirmacion_contraseña() {
  var password = document.getElementById("contraseña").value;
  var confirm = document.getElementById("confirmar_contraseña").value;

  if (confirm !== password) {
    var field = document.getElementById("checkconfirm");
    field.innerHTML = "No son iguales";
    field.style.color = 'white';
  }
}
