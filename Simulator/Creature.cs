using System.Runtime.CompilerServices;

namespace Simulator
{
    public abstract class Creature
    {
        private int level = 1;
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
        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
        public List<string> Go(List<Direction> directions)
        {
            List<string> results = new List<string>(directions.Count);
            for (int i = 0; i < directions.Count; i++)
            {
            results[i] = Go(directions[i]);
            }
            return results;
        }
        public List<string> Go(string directionsString)
        {
            List<Direction> directions = DirectionParser.Parse(directionsString);
            return Go(directions);
        }
        public abstract string Info { get; }
        
        public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    }
}



