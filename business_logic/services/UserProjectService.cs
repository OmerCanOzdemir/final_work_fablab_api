using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services
{
    public class UserProjectService : IUserProjectService
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UserProjectService(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }

        public UserProjectViewModel GiveScore(Guid id, int score)
        {
            var userProjectViewModel = _userProjectRepository.GetUserProjectById(id).Result;

            if (userProjectViewModel.ProjectUser == null)
            {
                return userProjectViewModel;
            }
            var userProject = userProjectViewModel.ProjectUser;
            userProject.Score = score;

            return _userProjectRepository.GiveScore(userProject).Result;
        }

        public UserProjectViewModel Participate(string userId, Guid projectId)
        {

            var userProject = new ProjectUser();
            userProject.User_Id = userId;
            userProject.Project_Id = projectId;
            userProject.Rol = "Dev";
            return _userProjectRepository.ParticipateProject(userProject).Result;
        }

        public UserProjectViewModel UnParticipate(Guid id)
        {
            var userProjectViewModel = _userProjectRepository.GetUserProjectById(id).Result;

            if(userProjectViewModel.ProjectUser == null)
            {
                return userProjectViewModel;
            }
            var userProject = userProjectViewModel.ProjectUser;

            return _userProjectRepository.UnParticipate(userProject).Result;
        }
    }
}
