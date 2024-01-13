namespace Redington.Server.Models
{
    public class Either: CombinedWith 
    {
        public override double Calculation() => A + B -  base.Calculation();
    }
}
