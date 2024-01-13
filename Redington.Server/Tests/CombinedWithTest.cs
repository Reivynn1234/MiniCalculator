using Xunit;
using CombinedWith = Redington.Server.Models.CombinedWith;
namespace Redington.Server.Tests
{
    public class CombinedWithTests
    {
        CombinedWith Data = new CombinedWith();
        [Fact]
        public void ValidCalculation()
        {
            Data.A = 0.8;
            Data.B = 0.2;

            Assert.Equal(0.16, Data.Calculation(),2);
        }

        [Fact]
        public void InBounds()
        {
            Data.A = 0.5;
            Data.B = 0.5;

            Assert.True(Data.IsValid());
        }

        [Fact]
        public void OutBounds()
        {
            Data.A = -1;
            Data.B = 1.2;

            Assert.False(Data.IsValid());
        }
    }
}
