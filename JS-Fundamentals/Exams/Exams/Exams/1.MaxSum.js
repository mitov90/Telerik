function Solve( params ) {
    var n = parseInt( params[0] );
    var toHere = 1;
    var maxSoFar = 1;
     for (var i = 1; i < n; i++) {
        if ( parseInt(params[i]) >= parseInt(params[i - 1])) {
             toHere++;
             if (toHere > maxSoFar) {
                  maxSoFar = toHere;
             }
        } else {
             toHere = 1;
        }
    }
     return maxSoFar;
} 

//Result = 16
var arr1 = [
'9',
'1',
'8',
'8',
'7',
'6',
'5',
'7',
'7',
'6'
];

//Expected result 15
var arr2 = ['6 ', '1  ', '3  ', '-5 ', '8  ', '7  ', '-6 '];

//Expected result -1
var arr3 = [
'7 ',
'1 ',
'2 ',
'-3',
'4 ',
'4 ',
'0 ',
'1 '

];

console.log(Solve(arr1));