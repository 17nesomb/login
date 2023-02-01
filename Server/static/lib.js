const eHints = document.getElementById("hints");

function reset() {
    
}

function create() {

}

function login() {
    let username = document.getElementById("username").value
    let password = document.getElementById("password").value

    try {
        presenceCheck(username, "Enter something (your username) fool");
        presenceCheck(password, "PASSWORD FOOL");
        lengthCheck(password, 5, 15, "please enter a password between 5 and 15 characters");
        eHints.innerText = "";
    } catch (e) {
        eHints.innerText = e;
    }

}

function lengthCheck(input, minLength, maxLength, message) {
    if (input.length > maxLength || input.length < minLength) {
        throw message;
    }
}

function presenceCheck(input, message) {

    if (input == "") {
        throw message;
    }
}