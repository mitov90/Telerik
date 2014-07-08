function isPointInsideCircle(xCoords, yCoords, circleRadius) {
    xCoords = parseFloat(xCoords);
    yCoords = parseFloat(yCoords);

    if (isNaN(xCoords) || isNaN(yCoords)) {
        throw ("Error! There is some incorrect input value!");
    }

    if (xCoords * xCoords + yCoords * yCoords > circleRadius * circleRadius) {
        console.log("OUTSIDE");
    } else {
        console.log("INSIDE");
    }

}

isPointInsideCircle(10, 0, 10);