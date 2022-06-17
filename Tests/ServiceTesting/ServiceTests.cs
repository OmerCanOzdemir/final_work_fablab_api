using business_logic.services;
using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ServiceTesting
{
    [TestClass]
    public class ServiceTests
    {
        private IUserService _userServices;
        private readonly Mock<IUserRepository> _userServicesMock = new Mock<IUserRepository>();

        private IProjectService _projectServices;
        private readonly Mock<IProjectRepository> _projectServicesMock = new Mock<IProjectRepository>();

        private IEducationService _educationServices;
        private readonly Mock<IEducationRepository> _educationServicesMock = new Mock<IEducationRepository>();

        private ICategoryService _categoryServices;
        private readonly Mock<ICategoryRepository> _categoryServicesMock = new Mock<ICategoryRepository>();

        [TestInitialize]
        public void Setup()
        {
            _userServices = new UserService(_userServicesMock.Object);
            _projectServices = new ProjectService(_projectServicesMock.Object);
            _educationServices = new EducationService(_educationServicesMock.Object);
            _categoryServices = new CategoryService(_categoryServicesMock.Object);

        }


        [TestMethod]
        public void Test_Should_Pass_When_Getting_User_By_Id()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            var user = new User { Id = id, Firstname = "Omer" };
            var userViewModel = new UserViewModel { User = user };
            _userServicesMock.Setup(u => u.GetUserById(id)).Returns(Task.FromResult(userViewModel));
            //Act
            var userdb = _userServices.GetUserById(id);
            //Assert
            Assert.IsNotNull(userViewModel.User);
        }

        [TestMethod]
        public void Test_Should_Pass_When_Creating_User()
        {
            //Arrange
            _userServicesMock.Setup(u => u.Create(It.IsAny<User>())).Returns((User user) => Task.FromResult(new UserViewModel { User = user }));
            //Act
            var createdUser = _userServices.Create(new User { Id = Guid.NewGuid().ToString(), Firstname = "omer"});

            //Assert
            Assert.IsNotNull(createdUser.User);
            Assert.AreEqual("omer", createdUser.User.Firstname);
        }

        [TestMethod]
        public void Test_Should_Pass_When_Updating_User()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            var user = new User { Id = id, Firstname = "Omer" };
            var userViewModel = new UserViewModel { User = user };
            _userServicesMock.Setup(u => u.GetUserById(id)).Returns(Task.FromResult(userViewModel));
            _userServicesMock.Setup(u => u.Update(It.IsAny<User>())).Returns((User user) => Task.FromResult(new UserViewModel { User = user }));
            //act   
            var updatedUser = _userServices.Update(new User {Firstname = "omer" },id);
            //assert

            Assert.IsNotNull(updatedUser.User);
        }

        [TestMethod]
        public void Test_Should_Pass_When_Creating_Project()
        {
            //Arrange
            _projectServicesMock.Setup(p => p.Create(It.IsAny<Project>())).Returns((Project project) => Task.FromResult(new ProjectViewModel {  Project = project }));
            //Act
            var createdProject = _projectServices.Create(new Project { Id = Guid.NewGuid(), Title = "awesome project" });

            //Assert
            Assert.IsNotNull(createdProject.Project);
            Assert.AreEqual("awesome project", createdProject.Project.Title);
        }

        [TestMethod]
        public void Test_Should_Pass_When_Updating_Project()
        {
            //arrange
            var id = Guid.NewGuid();
            var project = new Project { Id = id, Title = "awesome project" };
            var projectViewModel = new ProjectViewModel { Project = project };
            _projectServicesMock.Setup(u => u.GetProjectById(id)).Returns(Task.FromResult(projectViewModel));
            _projectServicesMock.Setup(u => u.Update(It.IsAny<Project>())).Returns((Project project) => Task.FromResult(new ProjectViewModel { Project = project }));
            //act   
            var updatedProject = _projectServices.Update(new Project { Title = "awesome" }, id);
            //assert

            Assert.IsNotNull(updatedProject.Project);
        }

    }
}
