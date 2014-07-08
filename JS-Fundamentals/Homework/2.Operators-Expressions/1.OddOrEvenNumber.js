function IsNumberEven(value) {
    if (value % 2 == 0)
        return true;
    return false;
}

function PrintNumberEven(value) {
    if (IsNumberEven(value)) {
        return String(value + " is even");
    }
    return String(value + " is odd");
}

console.log(PrintNumberEven("20"));
console.log(PrintNumberEven(19));
