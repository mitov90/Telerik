using System;

class IsPointInCircle
{  
    static void Main()
    {
        double xPoint;
        double yPoint;
        do{
            Console.WriteLine("Enter x cordinate: ");
        }while(!double.TryParse(Console.ReadLine(), out xPoint));
        do
        {
            Console.WriteLine("Enter x cordinate: ");
        } while ( !double.TryParse(Console.ReadLine(), out yPoint) );

        Point myPoint = new Point(xPoint, yPoint);
        Circle myCircle = new Circle(0, 0, 5);

        if (myPoint.x*myPoint.x + myPoint.y*myPoint.y > myCircle.radius*myCircle.radius)
        {
            Console.WriteLine("The point is outside!");
        }
        else
        {
            if (myPoint.x*myPoint.x + myPoint.y*myPoint.y == myCircle.radius*myCircle.radius)
                Console.WriteLine("The point is on circle edge!");
            else
                Console.WriteLine("The point is inside!");
        }
    }
}

