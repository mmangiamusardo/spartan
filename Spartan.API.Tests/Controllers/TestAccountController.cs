using NUnit.Framework;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

using Spartan.Data;
using Spartan.Domain;
using Spartan.Service;
using Spartan.Core;
using System.Web.Http.Results;
using System.Net;
using System.Web.Http;

namespace Spartan.Tests
{
    [TestFixture]
    public class TestAccountController
    {
        #region Variables
        private const string _dummyAddress = "http://test.com/";
        #endregion

        #region Onetime Setup

        /// <summary>
        /// Onetime setup for all the tests
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {

        }

        #endregion

        #region Onetime TearDown

        /// <summary>
        /// One Time teardown
        /// </summary>
        [OneTimeTearDown]
        public void DisposeAllObjects()
        {
           
        }

        #endregion

        #region Setup

        /// <summary>
        ///  ReInitializeTest is executed after each test
        /// </summary>
        public void ReInitializeTest()
        {

        }

        #endregion

        #region TearDown
        /// <summary>
        /// DisposeAllObjects is invoked after every test execution is complete
        /// </summary>
        [TearDown]
        public void DisposeTest()
        {
            /*
            _productService = null;
            _unitOfWork = null;
            _productRepository = null;
            if (_dbEntities != null)
                _dbEntities.Dispose();
            */
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// http://chimera.labs.oreilly.com/books/1234000001708/ch17.html#_unit_testing_an_apicontroller
        /// </summary>
        [Test]
        public void Controller_Should_Succeds_Registering_User()
        {
            var args = new object[2];

            // Arrange
            var mockUserStore = new Mock<ApplicationUserStore>(SpartanEntitiesContext.Create());
            args[0] = mockUserStore.Object;
            args[1] = null;

            var mockUserManager = new Mock<ApplicationUserManager>(args);

            var model = new RegisterViewModel
            {
                Email = "test@test.com",
                Password = "test",
                ConfirmPassword = "test"
            };

           
            var pwdHasher = mockUserManager.Object.PasswordHasher;
            var user = new ApplicationUser
            {
                 Email = model.Email,
                 PasswordHash= pwdHasher.HashPassword(model.Password)
            };

            // succeded creating a new User
            mockUserManager
                .Setup(um => um.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var controller = new AccountController(mockUserManager.Object);
            controller.ConfigureForTesting(HttpMethod.Post, "http://test.com");

            // Act
            IHttpActionResult result = controller.Register(model).Result;

            //Assert
            mockUserManager
                .Verify(man => man.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),Times.Once);

            Assert.AreEqual(((ResponseMessageResult)result).Response.StatusCode, HttpStatusCode.Created);
            //response.Headers.Location.AbsoluteUri.ShouldEqual("http://test.com/issues/1")
        }
        [Test]
        public void ForgotPassword()
        {
           
        }





        #endregion

        #region Integration Tests




        #endregion


        
    }
}
