
function Point(x, y) {
    this.x = x;
    this.y = y;

    this.getDistanceTo = function(p) {
        return Math.sqrt((this.x - p.x) * (this.x - p.x) + ((this.y - p.y) * (this.y - p.y)));
    };
}

function Line(p1, p2) {
    this.p1 = p1;
    this.p2 = p2;

    this.getLength = function() {
        return p1.getDistanceTo(p2);
    };
}

function canFormTriangle(ls1, ls2, ls3) {
    var a = ls1.getLength();
    var b = ls2.getLength();
    var c = ls3.getLength();

    return a + b > c && a + c > b && b + c > a;
}

var p1 = new Point(0, 2);
var p2 = new Point(4, 1);
var p3 = new Point(-3, 1);

var a = new Line(p1, p2);
var b = new Line(p1, p3);
var c = new Line(p2, p3);
c = 4;
b = c;
console.log(canFormTriangle(a, b, c));