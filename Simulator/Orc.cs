namespace Simulator;
public class Orc : Creature
        {
            private int rage = 1;
            private int HuntCounter = 0;

            public int Rage { get => rage; init => rage = Validator.Limiter(value, 0, 10); }
            public override int Power => 7 * Level + 3 * Rage;
            public void Hunt()
            {
                HuntCounter++;
                if (++HuntCounter % 2 == 0 && rage < 10)
                {
                    rage++;
                }
            }
            public Orc() { }
            public Orc(string name = "Unknown Orc", int level = 1, int rage = 1) : base(name, level)
            {
                Rage = rage;
            }
            public override string Info => $"{Name} [{Level}][{Rage}]";
            public override char Symbol => 'O';
        }