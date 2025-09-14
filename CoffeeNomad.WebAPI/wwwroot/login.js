document.addEventListener('DOMContentLoaded', function() {
    const loginForm = document.querySelector('.frame-4');
    const emailInput = document.getElementById('email');
    const passwordInput = document.getElementById('password');
    const rememberMeCheckbox = document.getElementById('remember-me');
    const forgotPasswordLink = document.querySelector('a[href="#forgot-password"]');
    const signUpLink = document.querySelector('a[href="#sign-up"]');

    // Функция для отображения ошибок
    function showError(input, message) {
        // Удаляем предыдущие ошибки
        const existingError = input.parentElement.parentElement.querySelector('.error-message');
        if (existingError) {
            existingError.remove();
        }

        // Создаем элемент для ошибки
        const errorElement = document.createElement('div');
        errorElement.className = 'error-message';
        errorElement.textContent = message;
        errorElement.style.color = 'red';
        errorElement.style.fontSize = '12px';
        errorElement.style.marginTop = '5px';

        // Добавляем ошибку после контейнера поля ввода
        input.parentElement.parentElement.appendChild(errorElement);
        
        // Добавляем стиль для поля с ошибкой
        input.style.borderColor = 'red';
    }

    // Функция для очистки ошибок
    function clearError(input) {
        const errorElement = input.parentElement.parentElement.querySelector('.error-message');
        if (errorElement) {
            errorElement.remove();
        }
        input.style.borderColor = '';
    }

    // Валидация email
    //function isValidEmail(email) {
    //    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    //    return emailRegex.test(email);
    //}

    // Валидация формы
    //function validateForm() {
    //    let isValid = true;

    //    // Валидация email
    //    if (emailInput.value.trim() === '') {
    //        showError(emailInput, 'Пожалуйста, введите email');
    //        isValid = false;
    //    } else if (!isValidEmail(emailInput.value)) {
    //        showError(emailInput, 'Пожалуйста, введите корректный email');
    //        isValid = false;
    //    } else {
    //        clearError(emailInput);
    //    }

    //    // Валидация пароля
    //    if (passwordInput.value === '') {
    //        showError(passwordInput, 'Пожалуйста, введите пароль');
    //        isValid = false;
    //    } else {
    //        clearError(passwordInput);
    //    }

    //    return isValid;
    //}

    // Проверяем, есть ли сохраненные данные для автозаполнения
    function checkRememberMe() {
        const savedEmail = localStorage.getItem('rememberedEmail');
        const savedRememberMe = localStorage.getItem('rememberMe') === 'true';
        
        if (savedEmail && savedRememberMe) {
            emailInput.value = savedEmail;
            rememberMeCheckbox.checked = true;
        }
    }

    // Сохраняем данные для запоминания
    function saveRememberMe() {
        if (rememberMeCheckbox.checked) {
            localStorage.setItem('rememberedEmail', emailInput.value.trim());
            localStorage.setItem('rememberMe', 'true');
        } else {
            localStorage.removeItem('rememberedEmail');
            localStorage.removeItem('rememberMe');
        }
    }

    // Обработка отправки формы
    loginForm.addEventListener('submit', async function(e) {
        e.preventDefault(); // Предотвращаем стандартную отправку формы

        //if (!validateForm()) {
        //    return;
        //}

        // Показываем индикатор загрузки
        const submitButton = loginForm.querySelector('.button');
        const originalText = submitButton.querySelector('.button-2').textContent;
        submitButton.querySelector('.button-2').textContent = 'Вход...';
        submitButton.disabled = true;

        // Сохраняем данные для запоминания
        saveRememberMe();

        // Создаем объект с данными для входа
        const loginData = {
            Email: emailInput.value.trim(),
            Password: passwordInput.value
        };

        try {
            // Отправляем запрос на сервер
            const response = await fetch('/User/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
                body: JSON.stringify(loginData)
            });

            if (response.ok) {
                const result = await response.json();
                
                // Успешный вход
                if (result.result) {
                    // Перенаправляем на главную страницу или другую защищенную страницу
                    window.location.href = '/home/index';
                } else {
                    alert('Неверный пароль или вы не зарегистрированы');
                }
            } else {
                // Обработка ошибок от сервера
                const result = await response.text();
                alert(result || 'Произошла ошибка при входе');
            }
        } catch (error) {
            console.error('Ошибка:', error);
            alert('Произошла ошибка при отправке данных');
        } finally {
            // Восстанавливаем кнопку
            submitButton.querySelector('.button-2').textContent = originalText;
            submitButton.disabled = false;
        }
    });

    // Обработка клика по ссылке "Forgot Password?"
    forgotPasswordLink.addEventListener('click', function(e) {
        e.preventDefault();
        const email = emailInput.value.trim();
        
        if (email) //&& isValidEmail(email)
        {
            // Заполняем email в форме восстановления пароля
            window.location.href = `/User/forgot-password?email=${encodeURIComponent(email)}`;
        } else {
            window.location.href = '/User/forgot-password';
        }
    });

    // Обработка клика по ссылке "Sign Up"
    signUpLink.addEventListener('click', function(e) {
        e.preventDefault();
        window.location.href = '/User/signup';
    });

    // Очистка ошибок при вводе
    emailInput.addEventListener('input', () => clearError(emailInput));
    passwordInput.addEventListener('input', () => clearError(passwordInput));

    // Проверяем запомненные данные при загрузке страницы
    checkRememberMe();
});