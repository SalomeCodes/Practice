using Newtonsoft.Json;
using Practice.LINQ.Models;
using Practice.LINQ.Tests.TestResources;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Practice.LINQ.Tests
{
    public class ResourcesTest
    {
        [Fact]
        public void CanReadAllMechanicsFromTestResource()
        {
            //Arrange
            var json = MechanicTestResource.TESTMECHANICS;
            var mechanicsMock = Encoding.UTF8.GetString(json);

            //Act
            List<Mechanic> mechanics = JsonConvert.DeserializeObject<List<Mechanic>>(mechanicsMock);

            //Assert
            Assert.Equal(10, mechanics.Count);
        }

        [Fact]
        public void CanReadAllMechanicsFromTestResource_ShouldntHaveAnotherAmount()
        {
            //Arrange
            var json = MechanicTestResource.TESTMECHANICS;
            var mechanicsMock = Encoding.UTF8.GetString(json);

            //Act
            List<Mechanic> mechanics = JsonConvert.DeserializeObject<List<Mechanic>>(mechanicsMock);

            //Assert
            Assert.NotEqual(11, mechanics.Count);
        }

        [Fact]
        public void CanReadFirstMechanicFromTestResource_ShouldHaveCorrectValues()
        {
            //Arrange
            var json = MechanicTestResource.TESTMECHANICS;
            var mechanicsMock = Encoding.UTF8.GetString(json);

            //Act
            List<Mechanic> mechanics = JsonConvert.DeserializeObject<List<Mechanic>>(mechanicsMock);

            //Assert
            Assert.Equal(1, mechanics[0].Id);
            Assert.Equal("Leonardo", mechanics[0].Name);
            Assert.Equal(39, mechanics[0].Age);
            Assert.Equal("lalder0@cisco.com", mechanics[0].Email);
            Assert.Equal(3277, mechanics[0].Salary);
            Assert.Equal(24, mechanics[0].Hours);
            Assert.Equal(2, mechanics[0].MakesAbleToRepair.Count);
            Assert.Equal("Mazda", mechanics[0].MakesAbleToRepair[0].Make);
            Assert.Equal("Plymouth", mechanics[0].MakesAbleToRepair[1].Make);
        }

        [Fact]
        public void CanReadFirstMechanicFromTestResource_ShouldNotHaveOtherValues()
        {
            //Arrange
            var json = MechanicTestResource.TESTMECHANICS;
            var mechanicsMock = Encoding.UTF8.GetString(json);

            //Act
            List<Mechanic> mechanics = JsonConvert.DeserializeObject<List<Mechanic>>(mechanicsMock);

            //Assert
            Assert.NotEqual(2, mechanics[0].Id);
            Assert.NotEqual("Bob", mechanics[0].Name);
            Assert.NotEqual(63, mechanics[0].Age);
            Assert.NotEqual("b.smith@gmail.com", mechanics[0].Email);
            Assert.NotEqual(2222, mechanics[0].Salary);
            Assert.NotEqual(48, mechanics[0].Hours);
            Assert.NotEqual(3, mechanics[0].MakesAbleToRepair.Count);
            Assert.NotEqual("Mercedes", mechanics[0].MakesAbleToRepair[0].Make);
            Assert.NotEqual("Chevrolet", mechanics[0].MakesAbleToRepair[1].Make);
        }
    }
}
