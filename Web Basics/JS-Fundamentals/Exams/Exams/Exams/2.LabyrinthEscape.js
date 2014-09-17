function Solve( params ) {
    var rowsCols = parseLine( params[0] );
    var rows = parseInt( rowsCols[0] );
    var cols = parseInt( rowsCols[1] );
    var field = [];

    var startPos = parseLine( params[1] );
    var curRow = parseInt( startPos[0] );
    var curCol = parseInt( startPos[1] );

    for ( var row = 0; row < rows; row++ ) {
        var line = params[row + 2];
        field[row] = [];
        for ( var col = 0; col < cols; col++ ) {
            field[row][col] = line[col];
        }
    }
    var score = 0;
    var jumps = 0;

    while ( true ) {
        var isOut = ( curRow >= rows || curRow < 0 || curCol >= cols || curCol < 0 );
        if ( isOut ) {
            return "out " + score;
        }
        if ( field[curRow][curCol] == 'x' ) {
            return "lost " + jumps;
        }
        score += getScoreOfCell( curRow, curCol, cols );
        jumps++;

        var dir = field[curRow][curCol];
        field[curRow][curCol] = 'x';

        switch ( dir ) {
            case 'l':
                curCol--;
                break;
            case 'r':
                curCol++;
                break;
            case 'd':
                curRow++;
                break;
            case 'u':
                curRow--;
                break;
        }
    }
    function parseLine( line ) {
        return line.split( " " );
    }

    function getScoreOfCell( curRow, curCol, allCols ) {
        return curRow * allCols + curCol + 1;
    }

}


//out 45
var args1 = [
    "3 4",
    "1 3",
    "lrrd",
    "dlll",
    "rddd"
];

//lost 21
var args2 = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"
];

//out 442
var args3 = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "lurlddud",
    "urrrldud",
    "ulllllll"
];

console.log( Solve( args2 ) );
