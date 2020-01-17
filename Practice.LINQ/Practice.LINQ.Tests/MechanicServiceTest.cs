using Practice.LINQ.Data;
using Practice.LINQ.Tests.TestResources;
using System.Linq;
using Xunit;

namespace Practice.LINQ.Tests
{
    public class MechanicServiceTest
    {
        [Fact]
        public void CanGetAllMechanics()
        {
            //Arrange
            MechanicService mechanicService = new MechanicService(MechanicTestResource.TESTMECHANICS);

            //Act
            var result = mechanicService.GetMechanics();

            //Assert
            Assert.Equal(10, result.ToList().Count);
            Assert.Equal(10, mechanicService.Mechanics.ToList().Count);
        } 
    }
}
