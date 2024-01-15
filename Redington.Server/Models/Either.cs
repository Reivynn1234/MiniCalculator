namespace Redington.Server.Models
{
    public class Either: CombinedWith 
    {
        public override double Calculation() => ((A + B) ?? throw new Exception("Missing Data")) -  base.Calculation();
    }
}
