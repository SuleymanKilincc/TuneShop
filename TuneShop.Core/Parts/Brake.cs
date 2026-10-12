using TuneShop.Core.Enums;

namespace TuneShop.Core.Parts

{
    public class Brake : Part
    {
        public required int Diameter { get; set; }
        public required int PadThickness { get; set; }
        public required int RotorThickness { get; set; }
        public required BrakeType BrakeType { get; set; }

    
        public override string Describe()
        {
            return $"Brake: {Name}, {Diameter} mm, pad thickness {PadThickness} mm, rotor thickness {RotorThickness} mm, {BrakeType}, {Price:C}, {Weight} kg";
        }

        
        public override int CalculateScore()
        {
            int typeBase = BrakeType switch
            {
                BrakeType.Street => 40,
                BrakeType.Sport => 60,
                BrakeType.Race => 80,
                _ => 0
            };
            int diameterBonus = Math.Clamp((Diameter - 280) / 6, 0, 20);
            int rotorBonus = Math.Clamp((RotorThickness - 20) / 2, 0, 10);
            return Math.Clamp(typeBase + diameterBonus + rotorBonus, 0, 100);
        }
    }
}
