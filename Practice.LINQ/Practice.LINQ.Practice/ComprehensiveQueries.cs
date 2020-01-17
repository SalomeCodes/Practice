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
            var result = (from mechanic in mechanics
                                           select mechanic).ToList().Count();

            //Assert
            Assert.Equal(10, result);
        }


        /// <summary>
        /// Find all the mechanics whos name is Leonardo with extension methods.
        /// </summary>
        [Fact]
        public void FindAllMechanics_ByNameLeonardo()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Single(result);
            Assert.Equal("Leonardo", result[0].Name);
        }

        /// <summary>
        /// Find all the mechanics that can repair a ford with extension methods.
        /// </summary>
        [Fact]
        public void FindAllMechanics_ThatCanRepairFords()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Collection(result,
                mechanic =>
                {
                    Assert.Equal(2, mechanic.Id);
                    Assert.Equal("Alexis", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(5, mechanic.Id);
                    Assert.Equal("Durand", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(10, mechanic.Id);
                    Assert.Equal("Ivan", mechanic.Name);
                }
            );
        }

        /// <summary>
        /// Find all the mechanics that can repair fords and order them by age with the oldest mechanic first.
        /// Assuming that the oldest has most experience.
        /// </summary>
        [Fact]
        public void FindAllMechanics_ThatCanRepairFords_SortByAge_OldToYoung()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Collection(result,
                mechanic =>
                {
                    Assert.Equal(5, mechanic.Id);
                    Assert.Equal("Durand", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(2, mechanic.Id);
                    Assert.Equal("Alexis", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(10, mechanic.Id);
                    Assert.Equal("Ivan", mechanic.Name);
                }
            );
        }

        /// <summary>
        /// Find all the mechanics that can repair fords and order them by age with the youngest mechanic first.
        /// Assuming that the youngest is the cheapest.
        /// </summary>
        [Fact]
        public void FindAllMechanics_ThatCanRepairFords_SortByAge_YoungToOld()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Collection(result,
                mechanic =>
                {
                    Assert.Equal(10, mechanic.Id);
                    Assert.Equal("Ivan", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(2, mechanic.Id);
                    Assert.Equal("Alexis", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(5, mechanic.Id);
                    Assert.Equal("Durand", mechanic.Name);
                }
            );
        }

        /// <summary>
        /// Find all the mechanics and sum the working hours.
        /// So we know how much hours of work we have in a week.
        /// </summary>
        [Fact]
        public void FindAllMechanics_SumWorkingHours()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            int result = 0;

            //Assert
            Assert.Equal(353, result);
        }

        /// <summary>
        /// Find all the mechanics and sum the working hours.
        /// So we know what we can plan for the week average per day.
        /// </summary>
        [Fact]
        public void FindAllMechanics_AverageWorkingHours()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            double result = 0;

            //Assert
            Assert.Equal(35.3, result);
        }

        /// <summary>
        /// Find all the mechanics that have less than 31 working hours a week. 
        /// </summary>
        [Fact]
        public void FindAllMechanics_ThatHaveLessThan_31WorkingHours()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Collection(result,
                mechanic =>
                {
                    Assert.Equal(1, mechanic.Id);
                    Assert.Equal("Leonardo", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(8, mechanic.Id);
                    Assert.Equal("Becka", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(10, mechanic.Id);
                    Assert.Equal("Ivan", mechanic.Name);
                }
            );
        }

        /// <summary>
        /// Find all the mechanics that have less than 31 working hours a week, sort by age.
        /// So we can see if it has to do with age.
        /// </summary>
        [Fact]
        public void FindAllMechanics_ThatHaveLessThan_31WorkingHours_SortByAge_OldToYoung()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Collection(result,
                mechanic =>
                {
                    Assert.Equal(8, mechanic.Id);
                    Assert.Equal("Becka", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(10, mechanic.Id);
                    Assert.Equal("Ivan", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(1, mechanic.Id);
                    Assert.Equal("Leonardo", mechanic.Name);
                }
            );
        }

        [Fact]
        public void FindAllMechanics_WithANameShorterThan6Letters()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Collection(result,
                mechanic =>
                {
                    Assert.Equal(4, mechanic.Id);
                    Assert.Equal("Corby", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(8, mechanic.Id);
                    Assert.Equal("Becka", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(10, mechanic.Id);
                    Assert.Equal("Ivan", mechanic.Name);
                }
            );
        }

        /// <summary>
        /// Find all mechanics that have a name with the letter e on the 2 place of the name.
        /// For example:
        /// Kelly -> correct
        /// Henry -> correct
        /// Brett -> incorrect
        /// </summary>
        [Fact]
        public void FindAllMechanics_WithANameThatContainsLetterE_OnSecondIndex()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            List<Mechanic> result = new List<Mechanic>();

            //Assert
            Assert.Collection(result,
                mechanic =>
                {
                    Assert.Equal(1, mechanic.Id);
                    Assert.Equal("Leonardo", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(8, mechanic.Id);
                    Assert.Equal("Becka", mechanic.Name);
                },
                mechanic =>
                {
                    Assert.Equal(9, mechanic.Id);
                    Assert.Equal("Gerald", mechanic.Name);
                }
            );
        }
    }
}
