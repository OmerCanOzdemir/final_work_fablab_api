using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services.interfaces
{
    public interface IUserProjectService
    {
        UserProjectViewModel Participate(string userId, Guid projectId);
        UserProjectViewModel UnParticipate(Guid id);
    }
}
