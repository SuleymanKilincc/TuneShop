using TuneShop.Core.Enums;

namespace TuneShop.Core.Parts
{
    public class Engine : Part
    {
        public required int Cylinders { get; set; }
        public required int DisplacementCc { get; set; }
        public required int Horsepower { get; set; }
        public required int Torque { get; set; }
        public required int MaxRpm { get; set; }
        public required FuelType FuelType { get; set; }

        public override string Describe()
        {
            return $"Engine: {Name}, {Horsepower} hp, {Torque} Nm, {Cylinders} cyl, {DisplacementCc} cc, {FuelType}, {Price:C}, {Weight} kg";
        }

        public override int CalculateScore()
        {
            double power = Math.Min(Horsepower / 6.0, 100);
            double torque = Math.Min(Torque / 8.0, 100);
            double efficiency = Weight > 0 ? Math.Min(Horsepower / Weight * 20, 100) : 0;
            return (int)Math.Round(power * 0.5 + torque * 0.3 + efficiency * 0.2);
        }
    }
}