using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Task<ProjectViewModel> Create(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectViewModel> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectViewModel> GetProjectById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectViewModel> GetProjects()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectViewModel> Update(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
