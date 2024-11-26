namespace Simulator.Maps;

    public class SmallTorusMap : SmallMap
    {

        private readonly int sizeX;
        private readonly int sizeY;


        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return d switch
        {
            Direction.Up => Exist(nextPoint) ? nextPoint : new Point(p.X, (p.Y + 1) % sizeY),
            Direction.Right => Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % sizeX, p.Y),
            Direction.Down => Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % sizeX, p.Y),
            Direction.Left => Exist(nextPoint) ? nextPoint : new Point((p.X - 1 + sizeX) % sizeX, p.Y),
            _ => default,
        };
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return d switch
        {
            Direction.Up => Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % sizeX, (p.Y + 1) % sizeY),
            Direction.Right => Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % sizeX, (p.Y - 1 + sizeY) % sizeY),
            Direction.Down => Exist(nextPoint) ? nextPoint : new Point((p.X - 1 + sizeX) % sizeX, (p.Y - 1 + sizeY) % sizeY),
            Direction.Left => Exist(nextPoint) ? nextPoint : new Point((p.X - 1 + sizeX) % sizeX, (p.Y + 1) % sizeY),
            _ => default,
        };
    }
}