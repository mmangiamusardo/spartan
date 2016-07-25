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

        public static IQueryable<ApplicationUser> FakeUsers()
        {
            var users = Builder<ApplicationUser>.CreateListOfSize(100)
                .All()
                    .With(u => u.Firstname = Faker.Name.First())
                    .With(u => u.Lastname = Faker.Name.Last())
                    .Build();

            return users.AsQueryable<ApplicationUser>();
        }

        public static ApplicationRole[] FakeRoles()
        {
            var roles = Builder<ApplicationRole>.CreateListOfSize(10)
                .All()
                    .With(r => r.RoleDescription = Faker.Name.First())
                    .Build();

            return roles.ToArray();
        }

     }
}
