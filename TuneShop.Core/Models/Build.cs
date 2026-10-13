using TuneShop.Core.Parts;

namespace TuneShop.Core.Models
{
    public class Build
    {
        private readonly List<Part> _parts = new List<Part>();

        public IReadOnlyList<Part> Parts => _parts;

        public Vehicle Vehicle { get; }

        public Build(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public void AddPart(Part part)
        {
            if (_parts.Any(p => p.GetType() == part.GetType()))
                throw new InvalidOperationException($"Build already has a part of type {part.GetType().Name}.");
            _parts.Add(part);
        }

        public double GetTotalWeight()
        {
            double totalWeight = _parts.Sum(p => p.Weight) + Vehicle.Weight;
            return totalWeight;
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = _parts.Sum(p => p.Price);
            return totalPrice;
        }

        public int GetTotalHorsepower()
        {
            Engine? engine = _parts.OfType<Engine>().FirstOrDefault();

            if (engine != null)
                return engine.Horsepower;

            return Vehicle.Horsepower;
        }

        public int GetTotalTorque()
        {
            Engine? engine = _parts.OfType<Engine>().FirstOrDefault();
            if (engine != null)
                return engine.Torque;
            return Vehicle.Torque;
        }

        public int GetAveragePartScore()
        {
            if (_parts.Count == 0)
                return 0;

            return (int)Math.Round(_parts.Average(p => p.CalculateScore()));
        }

        public void RemovePart(Part part)
        {
            if (!_parts.Remove(part))
                throw new InvalidOperationException("Build does not contain the specified part.");
        }

        public void ReplacePart(Part part)
        {
            int removed = _parts.RemoveAll(p => p.GetType() == part.GetType());
            if (removed == 0)
                throw new InvalidOperationException($"Build does not contain a part of type {part.GetType().Name}.");
            _parts.Add(part);
        }
    }
}