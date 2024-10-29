namespace Simulator;
public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        var direction = new List<Direction>();
        foreach (var ch in input.ToUpper())
        {
            switch (ch)
            {
            case 'U':
                direction.Add(Direction.Up);
                break;
            case 'R':
                direction.Add(Direction.Right);
                break;
            case 'D':
                direction.Add(Direction.Down);
                break;
            case 'L':
                direction.Add(Direction.Left);
                break;
            }
        }
        return direction.ToArray();
    }
}