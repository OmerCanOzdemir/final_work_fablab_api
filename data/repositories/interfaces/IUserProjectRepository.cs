using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.models.entities;
namespace data.repositories.interfaces
{
    public interface IUserProjectRepository
    {
        Task<UserProjectViewModel> ParticipateProject(ProjectUser userProject);

        Task<UserProjectViewModel> UnParticipate(ProjectUser userProject);

        Task<UserProjectViewModel> GetUserProjectById(Guid id);
    }
}
