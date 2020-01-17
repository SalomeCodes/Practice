using Practice.LINQ.Data;
using Practice.LINQ.Models;
using Practice.LINQ.Practice.TestResources;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Practice.LINQ.Practice
{
    public class ComprehensiveQueries
    {
        private readonly MechanicService _service;
        private ITestOutputHelper _testOutputHelper;

        public ComprehensiveQueries(ITestOutputHelper testOutputHelper)
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
            var comprehensiveSyntaxQuery = from mechanic in mechanics
                                           select mechanic;

            var resultComprehension = comprehensiveSyntaxQuery.ToList().Count();

            //Assert
            Assert.Equal(10, resultComprehension);
        }


        [Fact]
        public void FindAllMechanics_ByNameLeonardo()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var comprehensiveSyntaxQuery = from mechanic in mechanics
                                           select mechanic;

            var resultComprehension = comprehensiveSyntaxQuery.ToList().Count();

            //Assert
            Assert.Equal(10, resultComprehension);
        }
    }
}
