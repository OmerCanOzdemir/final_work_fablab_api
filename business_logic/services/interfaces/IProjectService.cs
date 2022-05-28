using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services.interfaces
{
    public interface IProjectService
    {
        ProjectViewModel GetProjects();
        ProjectViewModel GetProjectById(Guid id);
        ProjectViewModel Delete(Guid id);

        ProjectViewModel Create(Project project);

        ProjectViewModel Update(Project project,Guid id);
    }
}
