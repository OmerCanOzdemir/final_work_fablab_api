using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories.interfaces
{
    public interface IProjectRepository
    {
        Task<ProjectViewModel> GetProjects();
        Task<ProjectViewModel> GetProjectById(string id);
        Task<ProjectViewModel> Delete(string id);

        Task<ProjectViewModel> Create(Project project);

        Task<ProjectViewModel> Update(Project project);
    }
}
