// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.querySelector(".btn-browse").addEventListener("click", function (event) {
    event.preventDefault(); // Prevent default jump

    // Scroll smoothly to the book list section
    document.querySelector("#book-list").scrollIntoView({
        behavior: "smooth"
    });
});
