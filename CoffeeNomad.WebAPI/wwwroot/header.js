document.addEventListener('DOMContentLoaded', function() {
    document.querySelector('#dashboardLink').addEventListener('click', () => {
        window.location.href = '/Dashboard/dashboard';
    });

    document.querySelector('#menuLink').addEventListener('click', () => {
        window.location.href = '/Menu/Index';
    });

    document.querySelector('#ordersLink').addEventListener('click', () => {
        window.location.href = '/Orders/Index';
    });

    document.querySelector('#settingsLink').addEventListener('click', () => {
        window.location.href = '/Settings/Index';
    });
});