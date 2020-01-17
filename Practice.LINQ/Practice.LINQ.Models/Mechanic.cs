using System.Collections.Generic;

namespace Practice.LINQ.Models
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int Hours { get; set; }
        public List<Car> MakesAbleToRepair { get; set; }
    }
}
