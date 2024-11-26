namespace Simulator;
public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        List<Direction> directions = new List<Direction>();
        foreach (var ch in input.ToUpper())
        {
            switch (ch)
            {
            case 'U':
                directions.Add(Direction.Up);
                break;
            case 'R':
                directions.Add(Direction.Right);
                break;
            case 'D':
                directions.Add(Direction.Down);
                break;
            case 'L':
                directions.Add(Direction.Left);
                break;
            }
        }
        return directions;
    }
}