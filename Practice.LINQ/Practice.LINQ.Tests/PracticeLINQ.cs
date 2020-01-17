using Practice.LINQ.Data;
using Practice.LINQ.Models;
using Practice.LINQ.Tests.TestResources;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Practice.LINQ.Tests
{
    public class PracticeLINQ
    {
        private readonly MechanicService _service;

        private ITestOutputHelper _testOutputHelper;

        public PracticeLINQ(ITestOutputHelper testOutputHelper) {
            _testOutputHelper = testOutputHelper;
            _service = new MechanicService(MechanicTestResource.TESTMECHANICS);
        }

        [Fact]
        public void Ext_GetMechanics_ThatCanMakeFords_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var target = mechanics
                .Where(m => m.MakesAbleToRepair.Contains(new Car() { Make = "Ford" })).Select(m => m.Name).ToList();

            //Assert
            Assert.Equal(3, target.Count());
        }
        [Fact]
        public void Com_GetMechanics_ThatCanMakeFords_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        from cars in mechanic.MakesAbleToRepair
                        where cars.Make == "Ford"
                        select mechanic;

            //Assert
            Assert.Equal(3, query.Count());
        }

        [Fact]
        public void Com_GetMechanics_WithNameLeonardo_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        where mechanic.Name == "Leonardo"
                        select mechanic;

            var result = query.ToList().Count();

            //Assert
            Assert.Equal(1, result);
        }
        [Fact]
        public void Ext_GetMechanics_WithNameLeonardo_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.Where(m => m.Name == "Leonardo").ToList().Count();

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Com_GetMechanics_WhoCanRepairANissan_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        from cars in mechanic.MakesAbleToRepair
                        where cars.Make == "Nissan"
                        select mechanic;

            var result = query.FirstOrDefault();

            //Assert
            Assert.Equal("Lisabeth", result.Name);
        }
        [Fact]
        public void Ext_GetMechanics_WhoCanRepairANissan_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.Where(mechanic => mechanic.MakesAbleToRepair.Any(x => x.Make.Contains("Nissan"))).FirstOrDefault();

            //Assert
            Assert.Equal("Lisabeth", result.Name);
            Assert.NotEqual("Durand", result.Name);
        }

        [Fact]
        public void Com_CalculateSalaryPerHourAverage_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        select mechanic;

            var totalHours = query.Sum(m => m.Hours);
            var totalSalary = query.Sum(m => m.Salary);

            var salaryPerHour = Math.Round(totalSalary / totalHours, 2);

            //Assert
            Assert.Equal(64.59m, salaryPerHour);
        }
        [Fact]
        public void Ext_CalculateSalaryPerHourAverage_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.Select(m => m);

            var totalHours = result.Sum(m => m.Hours);
            var totalSalary = result.Sum(m => m.Salary);

            var salaryPerHour = Math.Round(totalSalary / totalHours, 2);

            //Assert
            Assert.Equal(64.59m, salaryPerHour);
        }

        [Fact]
        public void Com_OrderMechanicsByName_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        orderby mechanic.Name
                        select mechanic;

            var result = query.ToList();

            //Assert
            Assert.Equal("Alexis", result[0].Name);
            Assert.Equal("Becka", result[1].Name);
            Assert.Equal("Corby", result[2].Name);
            Assert.Equal("Durand", result[3].Name);
            Assert.Equal("Gerald", result[4].Name);
            Assert.Equal("Ivan", result[5].Name);
            Assert.Equal("Leonardo", result[6].Name);
            Assert.Equal("Lisabeth", result[7].Name);
            Assert.Equal("Lisabeth", result[8].Name);
            Assert.Equal("Vitoria", result[9].Name);
        }
        [Fact]
        public void Ext_OrderMechanicsByName_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.Select(m => m).OrderBy(m => m.Name).ToList();

            //Assert
            Assert.Equal("Alexis", result[0].Name);
            Assert.Equal("Becka", result[1].Name);
            Assert.Equal("Corby", result[2].Name);
            Assert.Equal("Durand", result[3].Name);
            Assert.Equal("Gerald", result[4].Name);
            Assert.Equal("Ivan", result[5].Name);
            Assert.Equal("Leonardo", result[6].Name);
            Assert.Equal("Lisabeth", result[7].Name);
            Assert.Equal("Lisabeth", result[8].Name);
            Assert.Equal("Vitoria", result[9].Name);
        }

        [Fact]
        public void Com_OrderMechanicsByNameAscendingThenBySalaryAscending_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        orderby mechanic.Name, mechanic.Salary
                        select mechanic;

            var result = query.ToList();

            //Assert
            Assert.Equal(2, result[0].Id);
            Assert.Equal(8, result[1].Id);
            Assert.Equal(4, result[2].Id);
            Assert.Equal(5, result[3].Id);
            Assert.Equal(9, result[4].Id);
            Assert.Equal(10, result[5].Id);
            Assert.Equal(1, result[6].Id);
            Assert.Equal(7, result[7].Id);
            Assert.Equal(6, result[8].Id);
            Assert.Equal(3, result[9].Id);
        }
        [Fact]
        public void Ext_OrderMechanicsByNameAscendingThenBySalaryAscending_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.OrderBy(mechanic => mechanic.Name).ThenBy(m => m.Salary).ToList();

            //Assert
            Assert.Equal(2, result[0].Id);
            Assert.Equal(8, result[1].Id);
            Assert.Equal(4, result[2].Id);
            Assert.Equal(5, result[3].Id);
            Assert.Equal(9, result[4].Id);
            Assert.Equal(10, result[5].Id);
            Assert.Equal(1, result[6].Id);
            Assert.Equal(7, result[7].Id);
            Assert.Equal(6, result[8].Id);
            Assert.Equal(3, result[9].Id);
        }

        [Fact]
        public void Com_OrderMechanicsByNameAscendingThenBySalaryDescending_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        orderby mechanic.Name, mechanic.Salary descending
                        select mechanic;

            var result = query.ToList();

            //Assert
            Assert.Equal(2, result[0].Id);
            Assert.Equal(8, result[1].Id);
            Assert.Equal(4, result[2].Id);
            Assert.Equal(5, result[3].Id);
            Assert.Equal(9, result[4].Id);
            Assert.Equal(10, result[5].Id);
            Assert.Equal(1, result[6].Id);
            Assert.Equal(7, result[8].Id);
            Assert.Equal(6, result[7].Id);
            Assert.Equal(3, result[9].Id);
        }
        [Fact]
        public void Ext_OrderMechanicsByNameAscendingThenBySalaryDescending_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.OrderBy(mechanic => mechanic.Name).ThenByDescending(m => m.Salary).ToList();

            //Assert
            Assert.Equal(2, result[0].Id);
            Assert.Equal(8, result[1].Id);
            Assert.Equal(4, result[2].Id);
            Assert.Equal(5, result[3].Id);
            Assert.Equal(9, result[4].Id);
            Assert.Equal(10, result[5].Id);
            Assert.Equal(1, result[6].Id);
            Assert.Equal(7, result[8].Id);
            Assert.Equal(6, result[7].Id);
            Assert.Equal(3, result[9].Id);
        }

        [Fact]
        public void Com_CheckForMechanics_AmountLessThan31WorkHours_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        where mechanic.Hours < 30
                        select mechanic;

            var result = query.ToList();

            //Assert
            Assert.Equal(3, result.Count);
        }
        [Fact]
        public void Ext_CheckForMechanics_AmountLessThan31WorkHours_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.Where(mechanic => mechanic.Hours < 31).ToList();

            //Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Com_CheckForMechanics_WithNameShorterThan6LettersAscending_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        where mechanic.Name.Length < 6
                        orderby mechanic.Name
                        select mechanic;

            var result = query.ToList();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(8, result[0].Id);
            Assert.Equal("Becka", result[0].Name);
            Assert.Equal(4, result[1].Id);
            Assert.Equal("Corby", result[1].Name);
            Assert.Equal(10, result[2].Id);
            Assert.Equal("Ivan", result[2].Name);
        }
        [Fact]
        public void Ext_CheckForMechanics_WithNameShorterThan6LettersAscending_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.Where(mechanic => mechanic.Name.Length < 6).OrderBy(m => m.Name).ToList();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(3, result.Count);
            Assert.Equal(8, result[0].Id);
            Assert.Equal("Becka", result[0].Name);
            Assert.Equal(4, result[1].Id);
            Assert.Equal("Corby", result[1].Name);
            Assert.Equal(10, result[2].Id);
            Assert.Equal("Ivan", result[2].Name);
        }

        [Fact]
        public void Com_CheckForMechanics_WithNameThatContainsLetterEOnSecondPlace_ComprehensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var query = from mechanic in mechanics
                        where mechanic.Name.ElementAt(1) == 'e' 
                        orderby mechanic.Name ascending
                        select mechanic;

            var result = query.ToList();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(8, result[0].Id);
            Assert.Equal("Becka", result[0].Name);
            Assert.Equal(9, result[1].Id);
            Assert.Equal("Gerald", result[1].Name);
            Assert.Equal(1, result[2].Id);
            Assert.Equal("Leonardo", result[2].Name);
        }
        [Fact]
        public void Ext_CheckForMechanics_WithNameThatContainsLetterEOnSecondPlace_ExtensionMethod()
        {
            //Arrange
            List<Mechanic> mechanics = _service.GetMechanics();

            //Act
            var result = mechanics.Where(mechanic => mechanic.Name.ElementAt(1) == 'e').OrderBy(mechanic => mechanic.Name).ToList();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(3, result.Count);
            Assert.Equal(8, result[0].Id);
            Assert.Equal("Becka", result[0].Name);
            Assert.Equal(9, result[1].Id);
            Assert.Equal("Gerald", result[1].Name);
            Assert.Equal(1, result[2].Id);
            Assert.Equal("Leonardo", result[2].Name);
        }
    }
}
