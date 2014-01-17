using System;

class Rectangle
{
    Point topLeft;
    Point bottomRight;
    public double leftX { get { return topLeft.x; } }
    public double rightX { get { return bottomRight.x; } }
    public double bottomY { get { return bottomRight.y; } }
    public double topY { get { return topLeft.y; } }
    public Rectangle(double topX, double topY, double bottomX, double bottomY)
    {
        this.topLeft = new Point(topX, topY);
        this.bottomRight = new Point(bottomX, bottomY);
    }
}

