namespace TuneShop.Core.Parts
{
    public abstract class Part
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required double Weight { get; set; }

        public abstract string Describe();
        public abstract int CalculateScore();
    }
}