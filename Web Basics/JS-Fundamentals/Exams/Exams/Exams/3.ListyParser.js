function Solve(param) {
    var functions =
    {
        "avg": function(params) {
            //TODO: CHECK lenght -1 
            var num = params.length;
            var sum = this.sum(params);

            return parseInt(sum / num);
        },
        "sum": function(params) {
            var sum = 0;
            var num = params.length;
            for (var j = 0; j < num; j++) {
                sum += parseInt(params[j]);
            }
            return sum;
        },
        "min": function(params) {
            var num = params.length;
            var min = params[0];
            for (var j = 1; j < num; j++) {
                var temp = parseInt(params[j]);
                if (temp < min) {
                    min = temp;
                }
            }
            return min;
        },
        "max": function(params) {
            var num = params.length;
            var max = params[0];
            for (var j = 1; j < num; j++) {
                var temp = parseInt(params[j]);
                if (temp > max) {
                    max = temp;
                }
            }
            return max;
        }
    };

    function parseLine(curLine) { return curLine.split("]").join(" ] ").split("[").join(" [ ").split(',').join(' ').split('def').join("").split(" ").filter(function(p) { return p.length > 0; }); };

    function getNumbers(sliced) {
        var numbers = [];
        var numIndex = 0;
        for (var j = 0; j < sliced.length; j++) {
            if (funcResult[sliced[j]] != undefined) {
                for (var k = 0; k < funcResult[sliced[j]].length; k++) {
                    numbers[numIndex++] = funcResult[sliced[j]][k];
                }
            } else {
                numbers[numIndex++] = parseInt(sliced[j]);
            }
        }
        return numbers;
    }

    function evaluateCommand(tokens) {
        var oper = tokens[0];
        var numbers = getNumbers(tokens.slice(2, tokens.length - 1));
        var result = functions[oper](numbers);
        console.log(result);
        return result;
    }

    function evaluate(tokens) {
        var oper = tokens[0];
        if (functions[oper] != undefined) {
            return evaluateCommand(tokens);
        } else {
            if (functions[tokens[1]] != undefined) {
                funcResult[oper] = [];
                funcResult[oper][0] = evaluateCommand(tokens.slice(1, tokens.length));
            } else {
                if (funcResult[tokens[1]] != undefined) {
                    return funcResult[tokens[1]][0];
                }
                funcResult[oper] = getNumbers(tokens.slice(2, tokens.length - 1));
            }
        }
    };


    //Start Solve()
    var funcResult = {};
    var size = param.length;
    var result;
    for (var i = 0; i < size; i++) {
        var line = parseLine(param[i]);
        result = evaluate(line);
    }
    return result;

}

var test1 = [
    'def func sum[5, 3, -7, 2, 6, 3]      ',
    'def func2 [5, 3, 7, 2, 6, 3]        ', //problem!
    'def func3 min[func2]                ',
    'def func4 max[5, 3, 7, 2, 6, 3]     ',
    'def func5 avg[5, 3, 7, 2, 6, 3]     ',
    'def func6 sum[func2, func3, func4 ] ',
    'sum[func6, func4]                   '
];
var test2 = [
    'def func sum[1, 2, 3, -6]           ',
    'def newList [func, 10, 1]           ',
    'def newFunc sum[func, 100, newList] ',
    '[newFunc]                           '
];

var test3 = [
    'def maxy max[100]                  ',
    'def summary [0]                    ',
    'combo [maxy, maxy,maxy,maxy, 5,6]  ',
    'summary sum[combo, maxy, -18000]   ',
    'def pe6o avg[summary,maxy]         ',
    'sum[7, pe6o]'
];
console.log(Solve(test3));