using System;

internal class PriorityQueueDemo
{
    /// <summary>
    ///     Based on the article "Priority Queues with C#" by James McCaffrey:
    ///     http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    /// </summary>
    private static void Main()
    {
        Console.WriteLine("\nBegin Priority Queue demo");

        Console.WriteLine("\nCreating priority queue of Employee items\n");
        var queue = new PriorityQueue<Employee>();

        var e1 = new Employee("Aiden", 1.0);
        var e2 = new Employee("Baker", 2.0);
        var e3 = new Employee("Chung", 3.0);
        var e4 = new Employee("Dunne", 4.0);
        var e5 = new Employee("Eason", 5.0);
        var e6 = new Employee("Flynn", 6.0);

        Console.WriteLine("Adding " + e5 + " to priority queue");
        queue.Enqueue(e5);
        Console.WriteLine("Adding " + e3 + " to priority queue");
        queue.Enqueue(e3);
        Console.WriteLine("Adding " + e6 + " to priority queue");
        queue.Enqueue(e6);
        Console.WriteLine("Adding " + e4 + " to priority queue");
        queue.Enqueue(e4);
        Console.WriteLine("Adding " + e1 + " to priority queue");
        queue.Enqueue(e1);
        Console.WriteLine("Adding " + e2 + " to priority queue");
        queue.Enqueue(e2);

        Console.WriteLine("\nPriory queue is: ");
        Console.WriteLine(queue.ToString());
        Console.WriteLine("\n");

        Console.WriteLine("Removing an employee from priority queue");
        var e = queue.Dequeue();
        Console.WriteLine("Removed employee is " + e);
        Console.WriteLine("\nPriory queue is now: ");
        Console.WriteLine(queue.ToString());
        Console.WriteLine("\n");

        Console.WriteLine("Removing a second employee from queue");
        e = queue.Dequeue();
        Console.WriteLine("\nPriory queue is now: ");
        Console.WriteLine(queue.ToString());
        Console.WriteLine("\n");
    }
}