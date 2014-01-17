using System;

class Circle : Point
{
    public Point center { get; private set; }
    public double radius { get; private set; }
    public Circle(double xCenter, double yCenter, double radius)
        : base(xCenter, yCenter)
    {
        this.radius = radius;
    }
}