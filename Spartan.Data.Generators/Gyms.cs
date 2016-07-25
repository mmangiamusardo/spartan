using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;

using Spartan.Domain;

namespace Spartan.Data.Generators
{
    public partial class Generate
    {
        private static RandomGenerator daysGenerator = new RandomGenerator();

        public static IQueryable<Gym> FakeGyms()
        {
            var gyms = Builder<Gym>.CreateListOfSize(100)
                .All()
                    .With(g => g.Name = Faker.Company.Name())
                    .With(g => g.Address = Faker.Address.StreetAddress())
                    .With(g => g.City = Faker.Address.City())
                    //.With(g => g. = Convert.ToBoolean(Faker.RandomNumber.Next(2)))
                    .Build();

            return gyms.AsQueryable<Gym>();
        }
        
     }
}
