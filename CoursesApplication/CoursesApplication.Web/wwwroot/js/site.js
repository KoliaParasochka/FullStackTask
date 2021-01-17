// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let modal = document.querySelector('.modal');
let modalBtn = document.querySelector('.btn');
let modalBg = document.querySelector('.modal_bg');

modalBtn.addEventListener('click', function () {
    modal.classList.add('show');
    modalBg.classList.add('show');
});

document.addEventListener('click', function (e) {
    let click = e.target.classList.value;
    if (click === 'modal_bg show') {
        debugger;
        modal.classList.remove('show');
        modalBg.classList.remove('show');
    }
})