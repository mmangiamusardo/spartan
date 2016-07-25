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

namespace Spartan.Tests
{
    [TestFixture]
    public class TestApplicationService
    {

        #region Variables

            IUnitOfWork _unitOfWork;
            IApplicationUserRepository _appUsrRepo;
            IQueryable<ApplicationUser> _rndUsrs;

            // ApplicationUserManager _mockUserManager;
            // UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> _mockUserStore;

        #endregion

        #region Setup

            [SetUp]
            public void Setup()
            {
                _rndUsrs = Generate.FakeUsers();
                _appUsrRepo = SetupApplicationUserRepo();

                _mockUserStore = ApplicatioUserStore();
            //_mockUserManager = new ApplicationUserManager(_mockUserStore, null);

                _unitOfWork = new Mock<IUnitOfWork>().Object;

            }

            private IApplicationUserRepository SetupApplicationUserRepo()
            {
                var repo = new Mock<IApplicationUserRepository>();

                repo.Setup(r => r.GetAll())
                    .Returns(_rndUsrs);

                return repo.Object;
            }

            //private  Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
            //{
            //    IList<IUserValidator<TUser>> UserValidators = new List<IUserValidator<TUser>>();
            //    IList<IPasswordValidator<TUser>> PasswordValidators = new List<IPasswordValidator<TUser>>();

            //    var store = new Mock<IUserStore<TUser>>();
            //    UserValidators.Add(new UserValidator<TUser>());
            //    PasswordValidators.Add(new PasswordValidator<TUser>());
            //    var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, UserValidators, PasswordValidators, null, null, null, null, null);
            //    return mgr;
            //}

        #endregion

        #region Tests
        [Test]
        public void Service_Should_Create_User()
        {

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
