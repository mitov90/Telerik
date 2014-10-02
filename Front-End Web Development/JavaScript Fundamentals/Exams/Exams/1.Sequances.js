function Solve( params ) {
    function getNum(value) {
        return parseInt(value);
    }

    var size = parseInt(params[0]);
    var count = 1,
        array = [];


    for (var i = 0; i < size; i++) {

        array[i] = parseInt(params[i + 1]);

        if (i > 0 && array[i] < array[i - 1]) {
            count++;
        }
        
    }
    return count;
}

var test1 = [
'6 ',
'1 ',
'3 ',
'-5',
'8 ',
'7 ',
'-6',

];

console.log(Solve(test1));