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
                string processedName = value.Trim();

                if (processedName.Length < 3)
                {
                    processedName = processedName.PadRight(3, '#');
                }
                else if (processedName.Length > 25)
                {
                    processedName = processedName.Substring(0, 25).TrimEnd();
                    if (processedName.Length < 3)
                    {
                        processedName = processedName.PadRight(3, '#');
                    }
                }

                name = char.ToUpper(processedName[0]) + processedName.Substring(1);
            }
        }

        public int Level
        {
            get => level;
            init
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > 10)
                {
                    value = 10;
                }
                else
                {
                    level = value;
                }

            }
        }
        public abstract int Power { get; }
        public Creature() { }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level >= 1 ? level : 1;
        }

        public void SayHi()
        {
            Console.WriteLine($"Hi I'm {Name} and my level is {Level}");
        }
        public void Upgrade()
        {
            if (level < 10)
            {
                level++;
            }

        }

        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }

        public void Go(Direction direction)
        {
        switch (direction)
            {
                case Direction.Up:
                    Console.WriteLine($"{Name} goes up");
                    break;
                case Direction.Right:
                    Console.WriteLine($"{Name} goes right");
                    break;
                case Direction.Down:
                    Console.WriteLine($"{Name} goes down");
                    break;
                case Direction.Left:
                    Console.WriteLine($"{Name} goes left");
                    break;
            }
        }  
        public void Go(Direction[] directions)
        {
            foreach (var direction in directions)
            {
                Go(direction);
            }
        }
        public void Go(string directions)
        {
            var parsedDirections = DirectionParser.Parse(directions);
            Go(parsedDirections);
        }
    }
        public class Elf : Creature
        {
            private int agility = 1;
            private int SingCounter = 0;

            public int Agility { get => agility; init => agility = value < 0 ? 0 : value > 10 ? 10 : value; }
            public override int Power => 8 * Level + 2 * Agility;
            public void Sing()
            {
                SingCounter++;
                Console.WriteLine($"{Name} is singing.");
                if (SingCounter % 3 == 0)
                {
                    if (agility < 10)
                    {
                        agility++;
                    }
                }
            }

            public Elf() { }
            public Elf(string name = "Unknown Elf", int level = 1, int agility = 1) : base(name, level)
            {
                Agility = agility;
            }
        }

        public class Orc : Creature
        {
            private int rage = 1;
            private int HuntCounter = 0;

            public int Rage { get => rage; init => rage = value < 0 ? 0 : value > 10 ? 10 : value; }
            public override int Power => 7 * Level + 3 * Rage;
            public void Hunt()
            {
                HuntCounter++;
                Console.WriteLine($"{Name} is hunting.");
                if (HuntCounter % 2 == 0)
                {
                    if (rage < 10)
                    {
                        rage++;
                    }
                }
            }
            public Orc() { }
            public Orc(string name = "Unknown Orc", int level = 1, int rage = 1) : base(name, level)
            {
                Rage = rage;
            }
        }
}




