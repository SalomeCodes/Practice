using Newtonsoft.Json;
using Practice.LINQ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LINQ.Data
{
    public class MechanicService
    {
        public List<Mechanic> Mechanics { get; }

        public MechanicService(byte[] mechanics)
        {
            Mechanics = JsonConvert.DeserializeObject<List<Mechanic>>(Encoding.UTF8.GetString(mechanics));
        }

        public List<Mechanic> GetMechanics()
        {
            return Mechanics;
        }
    }
}
