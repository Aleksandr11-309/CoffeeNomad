document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('.frame-3').addEventListener('submit', function (e) {
        e.preventDefault();
    });

    document.querySelector('#backInLogin').addEventListener('click', () => {
        window.history.back();
    });
});