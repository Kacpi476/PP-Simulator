using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Point p = new(3, 10);
        Console.WriteLine(p.Next(Direction.Right));
        Console.WriteLine(p.NextDiagonal(Direction.Right));  
        Lab5a();
        Lab5b();
    }
    public static void Lab5a()
    {
        try
        {
            var rect1 = new Rectangle(2, 2, 5, 7);
            Console.WriteLine($"{rect1}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message}");
        }
        try
        {
            var rect2 = new Rectangle(5, 7, 2, 2);
            Console.WriteLine($"{rect2}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message}");
        }
        try
        {
            var rect3 = new Rectangle(1, 1, 1, 5);
            Console.WriteLine($"{rect3}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message}");
        }
        try
        {
            var p1 = new Point(3, 3);
            var p2 = new Point(7, 8);
            var rect4 = new Rectangle(p1, p2);
            Console.WriteLine($"{rect4}");
            var testPoint = new Point(5, 5);
            Console.WriteLine($"{testPoint} {rect4.Contains(testPoint)}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    static void Lab5b()
    {
        SmallSquareMap map = new SmallSquareMap(15);
        Console.WriteLine($"Rozmiar mapy: {map.Size}");
        Point startPoint = new Point(0, 0);
        Point outsidePoint = new Point(-1, -1);
        Console.WriteLine($"Czy {startPoint} należy do mapy: {map.Exist(startPoint)}"); 
        Console.WriteLine($"Czy {outsidePoint} należy do mapy: {map.Exist(outsidePoint)}");
        Point nextRight = map.Next(startPoint, Direction.Right);
        Point nextUp = map.Next(startPoint, Direction.Up);
        Console.WriteLine($"Na prawo od {startPoint} znajduje się: {nextRight}"); 
        Console.WriteLine($"W górę od {startPoint} znajduje się: {nextUp}");
        Point edgePoint = new Point(map.Size - 1, map.Size - 1);
        Point outOfBounds = map.Next(edgePoint, Direction.Right);
        Console.WriteLine($"{edgePoint}: {outOfBounds} <- Kraniec mapy");
        Point diagonal = map.NextDiagonal(startPoint, Direction.Up);
        Console.WriteLine($"Na skos od {startPoint} znajduje się: {diagonal}");
    }
}