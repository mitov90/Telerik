function calculateTrapezoidArea(a, b, height) {
    a = parseFloat(a);
    b = parseFloat(b);
    height = parseFloat(height);

    return (a + b) / 2 * height;
}

console.log(calculateTrapezoidArea(3, 5, 10));