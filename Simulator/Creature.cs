using System.Runtime.CompilerServices;
using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature : IMappable
    {
        private int level = 1;
        public Map? Map { get; private set; }
        public Point Position { get; private set; }
        public void InitMapAndPosition(Map map, Point position) 
        {
            Map = map;
            Position = position;
        }
        private string name = "Unknown";
        
        public string Name
        {   
            get => name;
            init
            {
                name = Validator.Shortener(value, 3, 25, '#');
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            }
        }

        public int Level
        {
            get => level;
            init => level = Validator.Limiter(value, 1, 10);
        }
        public abstract int Power { get; }
        public Creature() { }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level >= 1 ? level : 1;
        }

        public string Greeting() => $"Hi, I'm {Name}, my level is {Level}.";
        public void Upgrade()
        {
            if (level < 10)
            {
                level++;
            }

        }

        public void Go(Direction direction)
        {
            if (Map == null)
            {
                Console.WriteLine("Creature's map is not set. Cannot move.");
                return;
            } 
            Point nextPosition = Map.Next(Position, direction);
            if (!Map.Exist(nextPosition))
            {
                Console.WriteLine($"Invalid move. {this.Info} tried to move out of bounds.");
                return;
            }
            try
            {
                Map.Move((IMappable)this, Position, nextPosition);
                Position = nextPosition;           
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to move {this.Info}: {ex.Message}");
            }
        }
        public abstract string Info { get; }
        public abstract char Symbol { get; }
        
        public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    }
}



