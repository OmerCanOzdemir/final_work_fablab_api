using api.Controllers;
using business_logic.services.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ControllerTesting
{
    [TestClass]
    public class ControllerTests
    {

        private ProjectController _projectController;

        private readonly Mock<IProjectService> _projectServiceMock = new Mock<IProjectService>();


        private UserController _userController;
        private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();

        private EducationController _educationController;
        private readonly Mock<IEducationService> _educationServiceMock = new Mock<IEducationService>();

        private CategoryController _categoryController;
        private readonly Mock<ICategoryService> _categoryServiceMock = new Mock<ICategoryService>();


        [TestInitialize]
        public void Setup()
        {
            _projectController = new ProjectController(_projectServiceMock.Object);
            _userController = new UserController(_userServiceMock.Object);
            _educationController = new EducationController(_educationServiceMock.Object);
            _categoryController = new CategoryController(_categoryServiceMock.Object);
        }
    }
}
