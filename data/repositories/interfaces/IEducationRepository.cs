using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories.interfaces
{
    public interface IEducationRepository
    {
        Task<EducationViewModel> GetEducationById(Guid id);

        Task<EducationViewModel> GetAllEducations();

        Task<EducationViewModel> GetEducationByName(string name);

        Task<EducationViewModel> Create(Education education);

        Task<EducationViewModel> Update(Education education);

    }
}
