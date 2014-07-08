function IsNumberDividedBy5And7(value) {
    return (value % 5 == 0) && (value % 7 == 0);
}

function PrintNumberDivision(value) {
    return IsNumberDividedBy5And7(value) ? String(value + " is divide without remainder") : String(value + " is NOT divide without remainder");
}

console.log(PrintNumberDivision("35"));
console.log(PrintNumberDivision(72));
