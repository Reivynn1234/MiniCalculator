using Xunit;
using Either = Redington.Server.Models.Either;
namespace Redington.Server.Tests
{
    public class EitherTests
    {
        Either Data = new Either();
        [Fact]
        public void ValidCalculation()
        {
            Data.A = 0.5;
            Data.B = 0.5;

            Assert.Equal(0.75, Data.Calculation(),2);
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
