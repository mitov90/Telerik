function GetBitAtPos(number, position) {
    var numberAsBinary = number.toString(2);
    return numberAsBinary[numberAsBinary.length-1-position];
}

function ToBinary(number) {
    return number.toString(2);
}

var number = 8749;
console.log(ToBinary(number));
console.log(GetBitAtPos(number, 3));