function checkDigitAtPosition(value, digit, position) {
    var numberLength = value.toString().length;
    var newPos = numberLength - position;
    var delimiter = Math.pow(10, newPos);
    value = parseInt(value / delimiter);
    return value % 10 == digit;

}

function checkDigiAtPos(value, digit, position) {
    var numberAsString = value.toString();
    return numberAsString[position - 1] == digit;
}

var value = 1234567890;
console.log(checkDigiAtPos(value, 1, 1));
console.log(checkDigitAtPosition(value, 5, 5));