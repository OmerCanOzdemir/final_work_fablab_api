using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services.interfaces
{
    public interface IEducationService
    {
        EducationViewModel GetEducationByName(string name);
        EducationViewModel Update(Guid id, Education education);
        EducationViewModel Create(Education education);
        EducationViewModel GetEducationById(Guid id);
        EducationViewModel GetEducations();
    }
}
