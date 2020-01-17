using Practice.LINQ.Data;
using Practice.LINQ.Models;
using Practice.LINQ.Practice.TestResources;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Practice.LINQ.Practice
{
    public class ExtensionQueries
    {
        private readonly MechanicService _service;
        private ITestOutputHelper _testOutputHelper;

        public ExtensionQueries(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _service = new MechanicService(MechanicTestResource.TESTMECHANICS);
        }

        [Fact]
        public void Example_FindAllMechanics()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var extensionSyntaxQuery = mechanics.Select(mechanic => mechanic);

            var resultExtension = extensionSyntaxQuery.ToList().Count();

            //Assert
            Assert.Equal(10, resultExtension);
        }


        [Fact]
        public void FindAllMechanics_ByNameLeonardo()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var extensionSyntaxQuery = mechanics.Select(mechanic => mechanic);

            var resultExtension = extensionSyntaxQuery.ToList().Count();

            //Assert
            Assert.Equal(10, resultExtension);
        }
    }
}
