window.onload = function() {
    var canvasWidth = 600,
        canvasHeight = 400,
        canvas = document.getElementById('the-canvas'),
        ctx = canvas['getContext']('2d');

    canvas.width = canvasWidth;
    canvas.height = canvasHeight;

    document.getElementById('btn-snowman').addEventListener('click', drawSnowman);
    document.getElementById('btn-bike').addEventListener('click', drawBike);
    document.getElementById('btn-house').addEventListener('click', drawHouse);


    function drawSnowman(event) {
        canvas.width = canvas.width;
        var cx = canvasWidth / 2;
        var cy = canvasHeight / 1.5;

        var circleColors = {
            fill: "#90CAD7",
            stroke: "#327D8F"
        };

        var hatColors = {
            fill: "#396693",
            stroke: "#252422"
        };

        var faceStrokeColor = "#20525D";
        var radius = document.getElementById("input-size").valueAsNumber;

        drawHead();
        drawHat();

        function drawHead() {

            drawEllipse(cx, cy, radius * 1.5, radius);
            applyStyles(circleColors.fill, circleColors.stroke);

            drawFace();

            function drawFace() {
                var offset = radius / 8;
                ctx.strokeStyle = faceStrokeColor;
                ctx.lineWidth = 1.5;
                //right eye
                drawEllipse(cx + radius / 5 - offset, cy - radius / 6, radius / 3.5, offset);
                ctx.stroke();
                //left eye
                drawEllipse(cx - radius / 5 - offset, cy - radius / 6, radius / 3.5, offset);
                ctx.stroke();

                //eyeball right
                ctx.fillStyle = faceStrokeColor;
                drawEllipse(cx + radius / 5 - offset - radius / 20, cy - radius / 6, 10, offset);
                ctx.fill();
                //eyeball left
                drawEllipse(cx - radius / 5 - offset - radius / 20, cy - radius / 6, 10, offset);
                ctx.fill();

                //nose
                ctx.beginPath();
                ctx.moveTo(cx - offset, cy + radius / 7);
                ctx.lineTo(cx - 2 * offset, cy + radius / 7);
                ctx.lineTo(cx - offset, cy - offset);
                ctx.stroke();

                //mouth
                drawEllipse(cx - offset, cy + 2 * offset, radius / 1.8, radius / 7);
                ctx.stroke();
            }
        }

        function drawHat() {
            ctx.lineWidth = 1;
            drawEllipse(cx, cy - radius / 2.5, radius * 1.7, radius * 0.25);
            applyStyles(hatColors.fill, hatColors.stroke);

            drawCylinder(cx - radius / 3, cy - 1.35 * radius, radius / 1.5, radius);
            ctx.fillRect(cx - radius / 3, cy - 1.25 * radius, radius / 1.5, radius - radius / 10);
            applyStyles(hatColors.fill, hatColors.stroke);
        }
    }

    function drawBike(ev) {
        canvas.width = canvas.width;
        var x = canvasWidth / 2,
            y = canvasHeight / 1.5,
            radius = document.getElementById("input-size").valueAsNumber,
            circleColors = {
                fill: "#90CAD7",
                stroke: "#327D8F"
            };

        ctx.fillStyle = circleColors.fill;
        ctx.strokeStyle = circleColors.stroke;

        // Wheels
        drawCircle(x, y, radius, 0, 360);
        applyStyles(circleColors.fill, circleColors.stroke);

        drawCircle(x + 160, y, radius, 0, 360);
        applyStyles(circleColors.fill, circleColors.stroke);

        ctx.lineWidth = 2;

        ctx.moveTo(x, y);
        ctx.lineTo(x + 70, y);

        ctx.moveTo(x, y);
        ctx.lineTo(x + 50, y - 50);
        ctx.lineTo(x + 150, y - 50);
        ctx.lineTo(x + 70, y);
        ctx.lineTo(x + 45, y - 65);

        // Seat
        ctx.moveTo(x + 30, y - 65);
        ctx.lineTo(x + 60, y - 65);

        // Hand drive
        ctx.moveTo(x + 160, y);
        ctx.lineTo(x + 147, y - 80);

        ctx.moveTo(x + 147, y - 80);
        ctx.lineTo(x + 115, y - 70);
        ctx.moveTo(x + 147, y - 80);
        ctx.lineTo(x + 165, y - 105);

        ctx.stroke();

        // Bike pedals
        drawCircle(x + 70, y, 10, 0, 360);
        ctx.moveTo(x + 63, y - 7);
        ctx.lineTo(x + 55, y - 17);
        ctx.moveTo(x + 77, y + 7);
        ctx.lineTo(x + 85, y + 17);

        ctx.stroke();
    }

    function drawHouse(ev) {
        canvas.width = canvas.width;
        var cx = canvasWidth / 6,
            cy = canvasHeight / 2.65,
        windowWidth = 100,
        windowHeight = 70,
        sideWidth = 300,
        sideHeight = 250,
        doorWidth = 100,
        doorHeight = 150,
        houseColors = {
            fill: "975B5B",
            stroke: "000000"
        };
        ctx.fillStyle = "#975B5B";

        drawRoof( cx, cy, sideWidth, sideHeight, houseColors);
        drawBase( cx, cy, sideWidth, sideHeight, houseColors);

        drawWindow( cx + 30, cy + 20, windowWidth, windowHeight, houseColors);
        drawWindow( cx + windowWidth + 70, cy + 20, windowWidth, windowHeight, houseColors);
        drawWindow( cx + windowWidth + 70, cy + windowWidth + 20, windowWidth, windowHeight, houseColors);

        drawDoor(130, 350, doorWidth, doorHeight, houseColors);

        function drawRoof(x, y, colors) {
            ctx.beginPath();
            ctx.moveTo(x, y);
            ctx.lineTo(x + sideWidth / 2, y - sideHeight + 100);
            ctx.lineTo(x + sideWidth, y);
            applyStyles(ctx, colors.fill, colors.stroke);

            ctx.beginPath();
            ctx.fillRect(sideWidth, y - 110, 27, 70);
            applyStyles(ctx, colors.fill);

            ctx.beginPath();
            ctx.moveTo(sideWidth, y - 110);
            ctx.lineTo(sideWidth, y - 30);
            applyStyles(ctx, colors.fill);

            ctx.beginPath();
            ctx.moveTo(sideWidth + 27, y - 110);
            ctx.lineTo(sideWidth + 27, y - 30);
            applyStyles(ctx, colors.fill);

            drawEllipse(ctx, 224, 125, 10, 0, 360, 1.4, 0.5);
            applyStyles(ctx, colors.fill);
        }

        function drawBase(x, y, sideWidth, sideHeight, colors) {
            ctx.beginPath();
            ctx.moveTo(x, y);
            ctx.lineTo(x + sideWidth, y);
            ctx.lineTo(x + sideWidth, y + sideHeight);
            ctx.lineTo(x, y + sideHeight);

            applyStyles(ctx, colors.fill, colors.stroke);
        }

        function drawWindow(x, y, width, height, colors) {
            ctx.fillStyle = colors.stroke;
            ctx.strokeStyle = colors.fill;

            ctx.fillRect(x, y, width, height);

            ctx.beginPath();
            ctx.moveTo(x + width / 2, y);
            ctx.lineTo(x + width / 2, y + height);
            ctx.moveTo(x, y + height / 2);
            ctx.lineTo(x + width, y + height / 2);
            ctx.stroke();
        }

        function drawDoor( x, y, width, height, colors) {
            ctx.strokeStyle = colors.stroke;
            y += height / 2;

            ctx.beginPath();
            ctx.lineWidth = 2;
            ctx.moveTo(x, y);
            ctx.lineTo(x, y - height + 50);

            ctx.moveTo(x + width, y);
            ctx.lineTo(x + width, y - height + 50);
            ctx.moveTo(x, y - height + 50);
            ctx.bezierCurveTo(x, 430 - height, x + width, 430 - height, x + width, y - height + 50);
            ctx.stroke();

            ctx.moveTo(x + width / 2, y - height + 15);
            ctx.lineTo(x + width / 2, y);
            ctx.stroke();

            var radius = 5;
            drawCircle(ctx, x + width / 2 - 10, y - height / 2 + 20, radius, 0, 360);
            ctx.stroke();
            drawCircle(ctx, x + width / 2 + 10, y - height / 2 + 20, radius, 0, 360);
            ctx.stroke();
        }

    }


    function drawCircle(x, y, radius, from, to) {
        ctx.beginPath();
        ctx.arc(x, y, radius, from, to);
    }

    function drawCylinder(x, y, w, h) {
        var i, xPos, yPos, pi = Math.PI, twoPi = 2 * pi;

        ctx.beginPath();

        for (i = 0; i < twoPi; i += 0.001) {
            xPos = (x + w / 2) - (w / 2 * Math.cos(i));
            yPos = (y + h / 8) + (h / 8 * Math.sin(i));

            if (i === 0) {
                ctx.moveTo(xPos, yPos);
            } else {
                ctx.lineTo(xPos, yPos);
            }

        }

        ctx.moveTo(x, y + h / 8);
        ctx.lineTo(x, y + h - h / 8);

        for (i = 0; i < pi; i += 0.001) {
            xPos = (x + w / 2) - (w / 2 * Math.cos(i));
            yPos = (y + h - h / 8) + (h / 8 * Math.sin(i));

            if (i === 0) {
                ctx.moveTo(xPos, yPos);
            } else {
                ctx.lineTo(xPos, yPos);
            }
        }

        ctx.moveTo(x + w, y + h / 8);
        ctx.lineTo(x + w, y + h - h / 8);

    }

    function drawEllipse(centerX, centerY, width, height) {

        ctx.beginPath();

        ctx.moveTo(centerX, centerY - height / 2); // A1

        ctx.bezierCurveTo(
            centerX + width / 2, centerY - height / 2, // C1
            centerX + width / 2, centerY + height / 2, // C2
            centerX, centerY + height / 2); // A2

        ctx.bezierCurveTo(
            centerX - width / 2, centerY + height / 2, // C3
            centerX - width / 2, centerY - height / 2, // C4
            centerX, centerY - height / 2); // A1
    }

    function applyStyles(fillStyle, strokeStyle) {
        ctx.fillStyle = fillStyle;
        ctx.strokeStyle = strokeStyle;
        ctx.fill();
        ctx.stroke();
    }

    function drawBezierCurve(xoff, yoff) {
        ctx.beginPath();
        ctx.moveTo(160 + xoff, 500 + yoff);
        ctx.bezierCurveTo(160 + xoff, 515 + yoff, 157 + xoff, 302 + yoff, 157 + xoff, 270 + yoff);
        ctx.bezierCurveTo(157 + xoff, 179 + yoff, 347 + xoff, 176 + yoff, 350 + xoff, 259 + yoff);
        ctx.stroke();
    }
};

