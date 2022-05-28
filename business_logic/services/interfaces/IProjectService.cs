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
        ProjectViewModel GetProjectById(string id);
        ProjectViewModel Delete(string id);

        ProjectViewModel Create(Project project);

        ProjectViewModel Update(Project project,string id);
    }
}
