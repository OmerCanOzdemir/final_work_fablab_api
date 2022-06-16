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
              .UseInMemoryDatabase(databaseName: "Transcriptions Test")
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
        public async Task Test()
        {
            Assert.IsTrue(true);

        }
    }
}
