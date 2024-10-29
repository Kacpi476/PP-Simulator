namespace Simulator
{
    internal class Creature
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
    }
}



