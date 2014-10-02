window.onload = function() {
    var canvas = document.getElementById('the-canvas');
    
    canvas.width = 400;
    canvas.height = 233;

    var ctx = canvas.getContext('2d'),
        x = Math.random()* canvas.width,
        y = Math.random() * canvas.height,
        xchange = 1,
        ychange = 1;


    

    var startBtn = document.getElementById('btn-start');
    startBtn.addEventListener('click', toggleAnimation);

    var animationFunc = step;
    requestAnimationFrame(animationFunc);

    function step() {
        ctx.lineTo(x, y);
        ctx.stroke();

        x += xchange;
        y += ychange;

        if (x > canvas.width || x < 0) {
            xchange *= -1;
        }
        if (y > canvas.height || y < 0) {
            ychange *= -1;
        }
        animationFunc = requestAnimationFrame(step);

    }

    function toggleAnimation(ev) {
        if (animationFunc) {
            cancelAnimationFrame(animationFunc);
            animationFunc = undefined;
        } else {
            step();
        }
    }
}