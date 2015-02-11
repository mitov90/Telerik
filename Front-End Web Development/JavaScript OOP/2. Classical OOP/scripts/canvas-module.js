/**
 * Created by admin on 6/30/14.
 */
/*
Create a module for drawing shapes using Canvas. Implement the following shapes:
 Rect, by given position (X, Y) and size (Width, Height)
 Circle, by given center position (X, Y) and radius (R)
 Line, by given from (X1, Y1) and to (X2, Y2) positions
*/
var Drawer = (function() {
    var LayerModule = (function() {
        function Layer(params) {
            var canvas = document.createElement('canvas');
            canvas.setAttribute('width', params.width || 0);
            canvas.setAttribute('height', params.height || 0);

            // Set CSS styles to canvas element
            canvas.style.position = 'absolute';
            canvas.style.top = 0;
            canvas.style.left = 0;
            canvas.style.background = 'transparent';

            var stage = document.getElementById(params.containerId) || document.body;
            stage.appendChild(canvas);

            this._canvas = canvas;
            this._stage = stage;
            return this;
        }

        Layer.prototype.add = function(shape) {
            var canvasCtx = this._canvas.getContext("2d");

            canvasCtx.beginPath();
            if (shape instanceof Rect) {
                canvasCtx.fillRect(shape.x, shape.y, shape.width, shape.height);
            }
            else if (shape instanceof Circle) {
                canvasCtx.arc(shape.x, shape.y, shape.radius, 0, 360);
            }
            else if (shape instanceof Line) {
                canvasCtx.moveTo(shape.x1, shape.y1);
                canvasCtx.lineTo(shape.x2, shape.y2);
            }
            canvasCtx.stroke();
        }

        return Layer;
    })();

    /* Shape contructors */

    function Rect(params) {
        this.x = params.x || 0;
        this.y = params.y || 0;
        this.width = params.width || 0;
        this.height = params.height || 0;
        return this;
    }

    function Circle(params) {
        this.x = params.x || 0;
        this.y = params.y || 0;
        this.radius = params.radius || 0;
        return this;
    }

    function Line(params) {
        this.x1 = params.x1 || 0;
        this.y1 = params.y1 || 0;
        this.x2 = params.x2 || 0;
        this.y2 = params.y2 || 0;
        return this;
    }

    return {
        Layer: LayerModule,
        Rect: Rect,
        Circle: Circle,
        Line: Line
    }
})();