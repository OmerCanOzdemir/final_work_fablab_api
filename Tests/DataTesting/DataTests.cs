using data.context;
using data.models.entities;
using data.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskModel = data.models.entities.TaskModel;
namespace Tests.DataTesting
{
    [TestClass]
    public class DataTests
    {
        private Context _context;

        private UserRepository userRepository;
        private ProjectRepository projectRepository;
        private EducationRepository educationRepository;
        private CategoryRepository categoryRepository;


        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "finalWorkTest")
              .Options;

            _context = new Context(options);

            userRepository = new UserRepository(_context);
            projectRepository = new ProjectRepository(_context);
            educationRepository = new EducationRepository(_context);
            categoryRepository = new CategoryRepository(_context);

        }


        [TestMethod]
        public async Task Test_Should_Pass_When_Creating_User()
        {
            //Arrange
            var user = new User { Id = Guid.NewGuid().ToString(), Firstname = "Omer Can",Lastname = "Ozdemir" };
            //Act
            var userViewModel = await userRepository.Create(user);  
            //Assert
            Assert.AreEqual(user, userViewModel.User);
          
        }
        [TestMethod]
        public async Task Test_Should_Pass_When_Updating_User()
        {
            //Arrange
            var user = new User { Id = Guid.NewGuid().ToString(), Firstname = "Omer Can", Lastname = "Ozdemir" };
            //Act
            var userViewModel = await userRepository.Create(user);

            var updatedUserViewModel = await userRepository.Update(userViewModel.User);
            //Assert
            Assert.AreEqual(user, updatedUserViewModel.User);

        }

   
        [TestMethod]
        public async Task Test_Should_Pass_When_Getting_User_With_Invalid_Id()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();
            //Act
            var userViewModel = await userRepository.GetUserById(id);
            //Assert
            Assert.IsNull(userViewModel.User);
        }

        [TestMethod]
        public async Task Test_Should_Pass_When_Getting_User_With_Invalid_Email()
        {
            //Arrange
            var email = Guid.NewGuid().ToString();
            //Act
            var userViewModel = await userRepository.GetUserByEmail(email);
            //Assert
            Assert.IsNull(userViewModel.User);
        }
        [TestMethod]
        public async Task Test_Should_Pass_When_Creating_Project()
        {
            //Arrange
            var project = new Project { Id = Guid.NewGuid(), Title = "awesome project" };
            //Act
            var projectViewModel = await projectRepository.Create(project);
            //Assert
            Assert.AreEqual(project, projectViewModel.Project);

        }

        [TestMethod]
        public async Task Test_Should_Pass_When_Updating_Project()
        {
            //Arrange
            var project = new Project { Id = Guid.NewGuid(), Title = "awesome project" };
            //Act
            var projectViewModel = await projectRepository.Create(project);
            var updatedProjectViewModel = await projectRepository.Update(projectViewModel.Project);
            //Assert
            Assert.AreEqual(project, updatedProjectViewModel.Project);

        }


        [TestMethod]
        public async Task Test_Should_Pass_When_Deleting_Project()
        {
            //Arrange
            var project = new Project { Id = Guid.NewGuid(), Title = "awesome project" };
            //Act
            var projectViewModel = await projectRepository.Create(project);
            var deletedProjectViewModel = await projectRepository.Delete(projectViewModel.Project);

            //Assert
            Assert.AreEqual(project, deletedProjectViewModel.Project);

        }

        [TestMethod]
        public async Task Test_Should_Pass_When_Creating_Education()
        {
            //Arrange
            var education = new Education { Id = Guid.NewGuid(), Name = "Toegepaste informatica" };
            //Act
            var educationViewModel = await educationRepository.Create(education);
            //Assert
            Assert.AreEqual(education, educationViewModel.Education);
        }

        [TestMethod]
        public async Task Test_Should_Pass_When_Updating_Education()
        {
            //Arrange
            var education = new Education { Id = Guid.NewGuid(), Name = "Toegepaste informatica" };
            //Act
            var educationViewModel = await educationRepository.Create(education);
            var updatedEducation = await educationRepository.Update(educationViewModel.Education);
            //Assert
            Assert.AreEqual(education, updatedEducation.Education);
        }


        [TestMethod]
        public async Task Test_Should_Pass_When_Creating_Category()
        {
            //Arrange
            var category = new Category { Id = Guid.NewGuid(), Name = "api" };
            //Act
            var categoryViewModel = await categoryRepository.Create(category);
            //Assert
            Assert.AreEqual(category, categoryViewModel.Category);
        }
        [TestMethod]
        public async Task Test_Should_Pass_When_Updating_Category()
        {
            //Arrange
            var category = new Category { Id = Guid.NewGuid(), Name = "api" };
            //Act
            var categoryViewModel = await categoryRepository.Create(category);
            var updatedCategory = await categoryRepository.Update(categoryViewModel.Category);
            //Assert
            Assert.AreEqual(category, updatedCategory.Category);
        }



    }
}
