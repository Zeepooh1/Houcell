// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function clicked() {
    console.log("TEST");
    var user = document.getElementById("userName").value;
    var pwd = document.getElementById("password").value; 
    window.location.replace(window.location.href + "/LoginCheck?userName=" + user + "&pass=" + pwd);
}