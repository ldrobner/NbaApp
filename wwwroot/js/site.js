// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(() => {
    document.querySelectorAll(".ImageCard").forEach( (ic) => {
        ic.addEventListener("click", (ev) => {
            ev.preventDefault();
            ev.target.parentElement.classList.toggle('flipped');
        });
    });
})();