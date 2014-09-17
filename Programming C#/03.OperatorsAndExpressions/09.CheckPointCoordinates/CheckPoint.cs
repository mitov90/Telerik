using System;

class CheckPoint
{
    static void Main()
    {
        double xPoint;
        double yPoint;
        InputPoint(out xPoint, out yPoint);

        Point myPoint = new Point(xPoint, yPoint);
        Circle myCircle = new Circle(1, 1, 3);
        Rectangle myRect = new Rectangle(1, -1, 7, -3);

        bool inCircle = false;
        bool inRect = false;

        if ( myPoint.x * myPoint.x - myCircle.x* myCircle.x +
             myPoint.y * myPoint.y - myCircle.y* myCircle.y <=
             myCircle.radius * myCircle.radius )
            inCircle = true;
        if ( myPoint.x >= myRect.leftX && myPoint.x <= myRect.rightX &&
            myPoint.y >= myRect.bottomY && myPoint.y <= myRect.topY )
            inRect = true;
        Console.WriteLine("Point in circle: {0}\nPoint in rectangle: {1}", inCircle,inRect);
    }

    private static void InputPoint(out double xPoint, out double yPoint)
    {
        do
        {
            Console.WriteLine("Enter x cordinate: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out xPoint) );

        do
        {
            Console.WriteLine("Enter y cordinate: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out yPoint) );
    }
}