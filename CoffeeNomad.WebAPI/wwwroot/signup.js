document.addEventListener('DOMContentLoaded', function () {
    const signupForm = document.querySelector('.frame-4');
    const loginLink = document.querySelector('.text-wrapper-2');

    // Функция для валидации email
    function isValidEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(email);
    }

    // Функция для валидации пароля (минимум 8 символов)
    function isValidPassword(password) {
        return password.length >= 8;
    }

    // Обработчик отправки формы
    signupForm.addEventListener('submit', async function (e) {
        e.preventDefault();

        // Получаем значения полей
        const name = document.getElementById('name').value.trim();
        const email = document.getElementById('email').value.trim();
        const password = document.getElementById('password').value;

        // Валидация
        /*if (!name) {
            alert('Пожалуйста, введите ваше имя.');
            return;
        }

        if (!isValidEmail(email)) {
            alert('Пожалуйста, введите корректный email.');
            return;
        }

        if (!isValidPassword(password)) {
            alert('Пароль должен содержать минимум 8 символов.');
            return;
        }*/

        // Формируем объект для отправки
        const userData = {
            Name: name,
            Email: email,
            Password: password
        };

        try {
            // Отправляем данные на сервер
            const response = await fetch('/User/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(userData),
            });

            if (!response.ok) {
                throw new Error(`Ошибка: ${response.status}`);
            }

            const result = await response.text();

            if (result === 'Вы уже зарегистрированы под этой почтой') {
                alert(result);
            } else {
                alert('Регистрация прошла успешно!');
                window.location.href = '/User/login'; // Перенаправляем на страницу логина
            }
        }
        catch (error) {
            console.error('Ошибка:', error);
            alert('Произошла ошибка при регистрации. Пожалуйста, попробуйте позже.');
        }
    });

    // Обработка клика по ссылке "Sign In"
    loginLink.addEventListener('click', function (e) {
        e.preventDefault();
        window.location.href = '/User/login';
    });
});
