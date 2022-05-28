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
    public class ProjectService : IProjectService
    {

        private readonly IProjectRepository _projectRepository;


        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ProjectViewModel Create(Project project)
        {
            throw new NotImplementedException();
        }

        public ProjectViewModel Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ProjectViewModel GetProjectById(string id)
        {
            throw new NotImplementedException();
        }

        public ProjectViewModel GetProjects()
        {
            throw new NotImplementedException();
        }

        public ProjectViewModel Update(Project project, string id)
        {
            throw new NotImplementedException();
        }
    }
}
