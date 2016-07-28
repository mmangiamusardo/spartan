using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;

using Spartan.Data;
using Spartan.Data.Infrastructure;
using Spartan.Data.Repositories;
using Spartan.Domain;
using Spartan.Service;
using Spartan.Data.Generators;

namespace Spartan.Tests
{
    [TestFixture]
    public class TestService
    {
        #region Variables

            IUnitOfWork _unitOfWork;
            IGymRepository _gymRepo;
            IQueryable<Gym> _rndGyms;

        #endregion

        #region Setup

            [SetUp]
            public void Setup()
            {
                _rndGyms = Generate.FakeGyms();
                _gymRepo = SetupGymRepo();

                _unitOfWork = new Mock<IUnitOfWork>().Object;
            }

            private IGymRepository SetupGymRepo()
            {
                var repo = new Mock<IGymRepository>();

                repo.Setup(r => r.GetAll())
                    .Returns(_rndGyms);

                return repo.Object;
            }

        #endregion

        #region Tests
        [Test]
        public void Service_Should_Return_All_Gyms()
        {
            // Arrange
            var gymSrv = new GymService(_gymRepo, _unitOfWork);

            // Act
            var result = gymSrv.GetAllGyms();

            // Assert
            for (int i = 0; i < _rndGyms.ToList().Count; i++)
            {
                Assert.AreEqual(result.ToList()[i].Id, _rndGyms.ToList()[i].Id);
            }
        }

        #endregion
    }
}
