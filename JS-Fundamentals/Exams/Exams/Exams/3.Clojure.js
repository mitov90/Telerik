function Solve(params) {
    var functions = {
        '+': function(operands) {
            var sum = 0;
            var size = operands.length;
            for (var j = 0; j < size; j++) {
                sum += operands[j];
            }
            return sum;
        },
        '-': function(operands) {
            var curRes = operands[0];
            var size = operands.length;
            for (var j = 1; j < size; j++) {
                curRes -= operands[j];
            }
            return curRes;
        },
        '*': function(operands) {
            var curRes = 1;
            var size = operands.length;
            for (var j = 0; j < size; j++) {
                curRes *= operands[j];
            }
            return curRes;
        },
        '/': function(operands) {
            var curRes = operands[0];
            var size = operands.length;
            for (var j = 1; j < size; j++) {
                curRes = parseInt(curRes / operands[j]);
            }
            return curRes;
        },
        'def': function(operands) {
            funcResult[operands[0]] = operands[1];
            return 0;
        }
    };

    function parseLine(curLine) {
        return curLine.split('(').join(' ( ').split(')').join(' ) ').split(',').join(' ').split(' ').filter(function(p) { return p.length > 0; });
    };

    function getNumbers(operands) {
        var size = operands.length;
        var numbers = [];
        for (var j = 1; j < size; j++) {

            if (isFinite(operands[j])) {
                numbers.push(parseInt(operands[j]));
            } else {
                if (funcResult[operands[j]] != undefined) {
                    numbers.push(funcResult[operands[j]]);
                } else {
                    numbers.push(operands[j]);

                }
            }
        }
        return numbers;
    }

    function clojure(tokens) {
        var indexOpening = -1,
            indexClosing = -1,
            curRes = 0,
            numbers = [];

        while (indexOpening !== 0) {
            indexOpening = tokens.lastIndexOf('(');
            indexClosing = tokens.indexOf(')');

            var curEquation = tokens.slice(indexOpening + 1, indexClosing);
            numbers = getNumbers(curEquation);
            curRes = functions[curEquation[0]](numbers);

            if (!isFinite(curRes))
                return curRes;
            if (curRes != undefined)
                tokens.splice(indexOpening, indexClosing - indexOpening, curRes);
            else
                tokens.splice(indexOpening, indexClosing - indexOpening + 1);
        }
        return curRes;
    };

    var result = 0;
    var funcResult = {};
    var paramSize = params.length;
    for (var i = 0; i < paramSize; i++) {
        var line = parseLine(params[i]);
        result = clojure(line);

        if (!isFinite(result))
            return "Division by zero! At Line:" + (i + 1);
    }
    return result;
}

var test = [
    '(def func 10)',
    '(def newFunc (+  func 2))',
    '(def sumFunc (+ func func newFunc 0 0 0))',
    '(* sumFunc 2)'
];

var test1 = [
    '(def func (+ 5 2))             ',
    '(def func2 (/  func 5 2 1 0))  ',
    '(def func3 (/ func 2))         ',
    '(+ func3 func)                 '
];

var test2 = [
    '(def tryFunc 500)                ',
    '(def tryFunc2 (+ 500 tryFunc )   ',
    '(def tryFunc1 (+ 500 tryFunc2 )  ',
    '(/ newFunc  )                    '
];
console.log(Solve(test));