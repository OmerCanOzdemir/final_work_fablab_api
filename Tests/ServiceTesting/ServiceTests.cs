using business_logic.services;
using business_logic.services.interfaces;
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



    }
}
