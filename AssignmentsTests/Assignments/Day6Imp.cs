using System;
using System.Drawing;
using System.Linq;

namespace AssignmentsTests.Assignments
{

    public class Grid
    {
        private readonly bool[,] _grid;

        public Grid()
            : this(new bool[1000, 1000])
        {
        }

        public Grid(bool[,] grid)
        {
            _grid = grid;
        }

        internal bool GetLightStatus(bool previousStatus, Switch switchAction)
        {
            return switchAction == Switch.Toggle
                ? !previousStatus
                : switchAction == Switch.On;
        }

        public void Execute(LightInstruction instruction)
        {
            var start = instruction.Start;
            var end = instruction.End;

            for (var y = Math.Min(start.Y, end.Y); y <= Math.Max(start.Y, end.Y); y++)
            {
                for (var x = Math.Min(start.X, end.X); x <= Math.Max(start.X, end.X); x++)
                {
                    var previousStatus = _grid[y, x];
                    _grid[y, x] = GetLightStatus(previousStatus, instruction.Switch);
                }
            }
        }

        public int GetTurnedOnLights()
        {
            int nrOfTurnedOnLights = 0;


            for (var y = 0; y < _grid.GetLength(0); y++)
            {
                for (var x = 0; x < _grid.GetLength(1); x++)
                {
                    if (_grid[y, x])
                    {
                        nrOfTurnedOnLights++;
                    }
                }
            }

            return nrOfTurnedOnLights;
        }
    }

    public class LightInstruction
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public Switch Switch { get; set; }

        #region Equality Members

        protected bool Equals(LightInstruction other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End) && Switch == other.Switch;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LightInstruction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Start.GetHashCode();
                hashCode = (hashCode * 397) ^ End.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Switch;
                return hashCode;
            }
        }

        #endregion

        public static LightInstruction Create(string instruction)
        {
            int dummy;
            var numberParts = instruction.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => int.TryParse(x, out dummy))
                .Select(int.Parse).ToList();

            return new LightInstruction
            {
                Start = new Point(numberParts[0], numberParts[1]),
                End = new Point(numberParts[2], numberParts[3]),

                Switch = Enum.GetValues(typeof(Switch)).OfType<Switch>()
                             .First(x => instruction.IndexOf(x.ToString(), StringComparison.InvariantCultureIgnoreCase) != -1)
            };
        }
    }

    public enum Switch
    {
        Off,
        On,
        Toggle
    }
}