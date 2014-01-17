using System;

class Circle : Point
{
    public Point center { get; private set; }
    public double radius { get; private set; }
    public double Perimeter
    {
        get
        {
            return 2 * Math.PI * radius;
        }
    }
    public double Area
    {
        get
        {
            return Math.PI * radius * radius;
        }
    }
    public Circle(double xCenter, double yCenter, double radius)
        : base(xCenter, yCenter)
    {
        this.radius = radius;
    }
}