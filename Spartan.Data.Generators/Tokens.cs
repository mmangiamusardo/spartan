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
        public static IQueryable<Token> FakeTokens()
        {
            var tokens = Builder<Token>.CreateListOfSize(100)
                .All()
                    .With(g => g.UserId = Faker.RandomNumber.Next())
                    .With(g => g.AuthToken = Guid.NewGuid().ToString())
                    .With(g => g.ExpiresOn = DateTime.Now.AddHours(2))
                    .With(g => g.IssuedOn = DateTime.Now)
                    .Build();

            return tokens.AsQueryable<Token>();
        }

    }
}