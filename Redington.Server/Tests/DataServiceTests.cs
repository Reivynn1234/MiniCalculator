using Xunit;
using DataService = Redington.Server.Models.DataService;
using Data = Redington.Server.Models.Data;
namespace Redington.Server.Tests
{
    public class DataServiceTests
    {
        DataService _service = new DataService();
        Data data = new Data();

        [Fact]
        public void ValidCombinedWith()
        {
            data.A = 0.8;
            data.B = 0.2;

            Assert.Equal(0.16, _service.CombinedWith(data),2);
        }


        [Fact]
        public void ValidEither()
        {
            data.A = 0.5;
            data.B = 0.5;

            Assert.Equal(0.75, _service.Either(data), 2);
        }


        [Fact]
        public void MissingData()
        {
            Assert.False(_service.IsValid(data));
        }

        [Fact]
        public void InBounds()
        {
            data.A = 0.5;
            data.B = 0.5;

            Assert.True(_service.IsValid(data));
        }

        [Fact]
        public void OutBounds()
        {
            data.A = -1;
            data.B = 1.2;

            Assert.False(_service.IsValid(data));
        }
    }
}
