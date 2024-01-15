namespace Redington.Server.Models
{
    public abstract class Data 
    {
        public double? A { get; set; }

        public double? B { get; set; }

        public abstract double Calculation();

        public bool IsValid() 
        {

            return A >= 0 && A <= 1 && B >=0 && B <= 1; 
        }
    }
}
