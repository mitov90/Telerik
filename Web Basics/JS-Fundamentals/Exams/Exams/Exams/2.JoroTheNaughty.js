function Solve(params) {
    function getValues(line) {
        return line.split(' ').map(function(v) { return parseInt(v); });
    }

    function getScoreFromCell(curRow, allCols, curCol) {

        return curRow * allCols + curCol+1;
    }

    var firstLine = getValues(params[0]);
    var startPos = getValues(params[1]);
    var curRow = startPos[0],
        curCol = startPos[1],
        rows = firstLine[0],
        cols = firstLine[1],
        score = 0,
        jumpsCount = 0,
        allJumps = firstLine[2],
        jumps = [],
        field = [];
    for (var j = 0; j < rows; j++) {
        field[j] = [];
        for (var k = 0; k < cols; k++) {
            field[j][k] = false;
        }
    }

    for (var i = 0; i < allJumps; i++) {
        //jumps[i][0] -> row
        //jumps[i][1] -> col
        jumps[i] = [];
        jumps[i] = getValues(params[2 + i]);
    }

    while (true) {

        field[curRow][curCol] = true;

        score += getScoreFromCell(curRow, cols, curCol);

        curRow += jumps[jumpsCount % allJumps][0];
        curCol += jumps[jumpsCount % allJumps][1];
        jumpsCount++;

        if (curRow < 0 || curRow >= rows || curCol < 0 || curCol >= cols) {
            return "escaped " + score;
        }

        if (field[curRow][curCol] == true) {
            return "caught " + jumpsCount;
        }
        
    }

}

//escaped 89
var test1 = [
    '6 7 3 ',
    '0 0   ',
    '2 2   ',
    '-2 2  ',
    '3 -1  '
];

console.log(Solve(test1));