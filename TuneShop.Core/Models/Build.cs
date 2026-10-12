using TuneShop.Core.Parts;

namespace TuneShop.Core.Models
{
    public class Build
    {
        private readonly List<Part> _parts = new List<Part>();

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
    }
}