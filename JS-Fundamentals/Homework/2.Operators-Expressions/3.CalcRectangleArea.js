function calculateRectancleArea(width, height) {
    width = parseFloat(width);
    height = parseFloat(height);

    if (isNaN(width) || isNaN(height)) {
        throw new Error("Error! There is some incorrect input value!");
    }

    return width * height;
}

console.log(calculateRectancleArea(7, 3));
