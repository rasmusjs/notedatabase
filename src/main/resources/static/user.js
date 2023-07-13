const baseurl = "/user"


const checkSession = () => {
    return sessionStorage.getItem("user") != null;

}

document.addEventListener('DOMContentLoaded', function() {
   if (checkSession()){
       alert("Logged in as "+ sessionStorage.getItem("user").firstName)
   }
});



const loginForm = document.getElementById('loginForm');

loginForm && loginForm.addEventListener('submit', function (event) {


    if (checkSession()) {
        const errorMessage = `You are logged inn as ${user.firstName}`;
        showError(errorMessage);
        return null;
    }


    event.preventDefault(); // Prevents the form from submitting normally

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    const loginData = {
        email: email, password: password
    };

    fetch(baseurl + "/login", {
        method: 'POST', headers: {
            'Content-Type': 'application/json'
        }, body: JSON.stringify(loginData)
    })
        .then(async response => {
            if (response.ok) {
                // Successful response handling
                console.log('Login successful!');
                const user = JSON.stringify(response.json());
                localStorage.setItem('username', user); //store a key/value
                console.log(user.firstName)
            } else {
                // Error response handling
                response.json().then(data => {
                    const errorMessage = data.message || 'An error occurred during login.';
                    showError(errorMessage);
                });
            }
        })
        .catch(error => {
            // Network or other error handling
            console.log('An error occurred during login:', error);
            showError('An error occurred during login. Please try again later.');
        });
});

const errorContainer = document.getElementById('errorContainer');


function showError(message) {
    errorContainer.textContent = message;
    errorContainer.classList.add('error');
}


const forgotPasswordBtn = document.getElementById('forgotPasswordBtn');

forgotPasswordBtn && forgotPasswordBtn.addEventListener('click', function () {
    const email = document.getElementById('email').value;

    const forgotPasswordData = {
        email: email
    };

    fetch(baseurl + "/forgot", {
        method: 'POST', headers: {
            'Content-Type': 'application/json'
        }, body: JSON.stringify(forgotPasswordData)
    })
        .then(response => {
            if (response.ok) {
                // Successful response handling
                console.log('Forgot password email sent!');
            } else {
                // Error response handling
                console.log('Failed to send forgot password email!');
            }
        })
        .catch(error => {
            // Network or other error handling
            console.log('An error occurred while sending the forgot password email:', error);
        });
});


const registerForm = document.getElementById('registerForm');

registerForm && registerForm.addEventListener('submit', function (event) {
    event.preventDefault(); // Prevents the form from submitting normally

    const firstName = document.getElementById('first_name').value;
    const lastName = document.getElementById('last_name').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirm_password').value;

    // Clear any previous error messages
    clearErrors();

    // Validate first name
    if (firstName.trim() === '') {
        displayError('first_name', 'First name is required.');
        return;
    }

    // Validate last name
    if (lastName.trim() === '') {
        displayError('last_name', 'Last name is required.');
        return;
    }

    // Validate email
    if (email.trim() === '') {
        displayError('email', 'Email is required.');
        return;
    }

    // Email format validation using regular expression
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        displayError('email', 'Invalid email format.');
        return;
    }

    // Validate password
    if (password.trim() === '') {
        displayError('password', 'Password is required.');
        return;
    }

    // Validate confirm password
    if (confirmPassword.trim() === '') {
        displayError('confirm_password', 'Confirm password is required.');
        return;
    }

    if (password !== confirmPassword) {
        displayError('confirm_password', 'Passwords do not match.');
        return;
    }

    // If all validations pass, proceed with form submission
    // Your code to submit the form data or perform further actions

    // Example: Send form data to server
    const formData = {
        firstName: firstName,
        lastName: lastName,
        email: email,
        password: password
    };

    fetch(baseurl + "/create", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
        .then(response => {
            if (response.ok) {
                // Successful response handling
                console.log('Registration successful!');
                history.back()
            } else {
                // Error response handling
                response.json().then(data => {
                    const errorMessage = data.message || 'An error occurred during login.';
                    showError(errorMessage);
                });
            }
        })
        .catch(error => {
            // Network or other error handling
            console.log('An error occurred during registration:', error);
        });
});

function displayError(fieldId, errorMessage) {
    const errorSpan = document.getElementById(`${fieldId}_error`);
    errorSpan.textContent = errorMessage;
}

function clearErrors() {
    const errorElements = document.getElementsByClassName('error');
    for (let i = 0; i < errorElements.length; i++) {
        errorElements[i].textContent = '';
    }
}