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

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

using Spartan.Data;
using Spartan.Data.Infrastructure;
using Spartan.Data.Repositories;
using Spartan.Domain;
using Spartan.Service;
using Spartan.Data.Generators;
using System.Security.Claims;

namespace Spartan.Tests
{
    [TestFixture]
    public class TestApplicationService
    {
        #region Variables

        IUnitOfWork _unitOfWork;
        IApplicationUserRepository _appUsrRepo;

        ApplicationUserStore _appUsrStore;
        ApplicationUserManager _appUsrManager;

        IQueryable<ApplicationUser> _rndUsrs;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            _rndUsrs = Generate.FakeUsers();
            _appUsrRepo = SetupApplicationUserRepo();
            _appUsrStore = SetupMockApplicationUserStore();
            _unitOfWork = new Mock<IUnitOfWork>().Object;
        }

        private ApplicationUserManager SetupMockApplicationUserManager(ApplicationUserStore storeMock)
        {
            var managerMock = new Mock<ApplicationUserManager>(storeMock);


            return managerMock.Object;
        }

        private ApplicationUserStore SetupMockApplicationUserStore()
        {
            //var storeMock = new Mock<ApplicationUserStore>(SpartanEntitiesContext.Create());
            var storeMock = new Mock<ApplicationUserStore>(new DbFactory());
            var pwdHsh = new PasswordHasher().HashPassword("test");

            storeMock
                .Setup(s => s.FindByIdAsync(It.IsAny<int>()))
                .Returns(
                    (int _Id) => Task.FromResult(_rndUsrs.Where(x => x.Id == _Id).SingleOrDefault())
                );

            //storeMock.Setup(
            //    s => s.CreateAsync(It.IsAny<ApplicationUser>()))
            //    .Returns(
            //        Task.FromResult(IdentityResult.Success)
            //    );

            storeMock
                .Setup(s => s.GetPasswordHashAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(pwdHsh);

            return storeMock.Object;
        }

        private IApplicationUserRepository SetupApplicationUserRepo()
        {
            var repoMock = new Mock<IApplicationUserRepository>();

            repoMock.Setup(
            // il metodo Add esposto dall'interfaccia accetta come argomento
            u => u.Add(It.IsAny<ApplicationUser>()))
            // implementa il metodo callback da invocare che riceve come argomento quello esposto
            .Callback(new Action<ApplicationUser>(newUsr =>
            {
                dynamic maxUsrId = _rndUsrs.Last().Id;
                newUsr.Id = maxUsrId + 1;
                var list = _rndUsrs.ToList();

                list.Add(newUsr);
                _rndUsrs = list.AsQueryable();
            })
            );

            repoMock.Setup(r => r.GetAll())
                .Returns(_rndUsrs);

            return repoMock.Object;

        }

        public void Can_Create_User()
        {
            //Arrange
            var dummyUser = new ApplicationUser() { UserName = "PinkWarrior", Email = "PinkWarrior@PinkWarrior.com" };
            var mockStore = new Mock<ApplicationUserStore>();

            var userManager = new ApplicationUserManager(mockStore.Object, null);
            mockStore.Setup(x => x.CreateAsync(dummyUser))
                        .Returns(Task.FromResult(IdentityResult.Success));

            mockStore.Setup(x => x.FindByNameAsync(dummyUser.UserName))
                        .Returns(Task.FromResult(dummyUser));


            //Act
            Task<IdentityResult> tt = (Task<IdentityResult>)mockStore.Object.CreateAsync(dummyUser);
            var user = userManager.FindByName("PinkWarrior");

            //Assert
            Assert.AreEqual("PinkWarrior", user.UserName);
        }

        #endregion

        #region Unit Tests

        [Test]
        public void Service_Should_Create_User()
        {
            // Arrange
            var pwd = "testpwd";
            var pwdHsh = new PasswordHasher().HashPassword(pwd);
            var testUsr = new ApplicationUser()
            {
                UserName = "testurs",
                PasswordHash = pwdHsh
            };


            int _maxIDBeforeAdd = _rndUsrs.Max(u => u.Id);
            var _appUsrService = new ApplicationUserService(_appUsrRepo, _unitOfWork, _appUsrStore);

            // Act
            //_appUsrService.CreateUser(testUsr);

            //_appUsrService.appUsrStore.CreateAsync(testUsr);
            

            // Assert
            Assert.That(testUsr, Is.EqualTo(_rndUsrs.Last()));
            Assert.That(_maxIDBeforeAdd + 1, Is.EqualTo(_rndUsrs.Last().Id));


        }

        [Test]
        public void Service_Should_Remove_User()
        {

        }

        [Test]
        public void Service_Should_Change_Email_User()
        {

        }

        [Test]
        public void Service_Should_Reset_User_Password_When_Lost()
        {

        }

        #endregion
    }
}
