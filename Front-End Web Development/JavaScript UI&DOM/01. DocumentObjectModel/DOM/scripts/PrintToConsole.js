
window.onload = function () {
    var button = document.getElementById("butOk");
    var textField = document.getElementById('inputVal');

    button.addEventListener('click', parseText, false);
    textField.addEventListener('input', changeButton, false);

    function changeButton(event) {
        button.disabled = false;
    }


    function parseText(event) {
        var cnt = document.getElementById('content');
        var newText = document.createElement('p');
        newText.style.display = "inline";
        newText.textContent = textField.value;
        cnt.appendChild(newText);
        textField.value = "";
        button.disabled = true;
    };
}


