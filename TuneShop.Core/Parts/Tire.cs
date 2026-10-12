using TuneShop.Core.Enums;

namespace TuneShop.Core.Parts
{
    public class Tire : Part
    {
        public required int Width { get; set; }
        public required int AspectRatio { get; set; }
        public required int Diameter { get; set; }
        public required TireType TireType { get; set; }

        public override string Describe()
        {
            return $"Tire: {Name}, {Width}/{AspectRatio}R{Diameter}, {TireType}, grip , {Price:C}, {Weight} kg";
           
        }
        public override int CalculateScore()
        {
            int typeBase = TireType switch
            {
                TireType.Street => 40,
                TireType.Sport => 60,
                TireType.Race => 80,
                _ => 0
            };
            int profileBonus = Math.Clamp((60 - AspectRatio) / 3, 0, 10);
            int widthBonus = Math.Clamp((Width - 185) / 5, 0, 20);
            return Math.Clamp(typeBase + widthBonus + profileBonus, 0, 100);
        }
    }
}