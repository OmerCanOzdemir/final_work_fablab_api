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
    public class EducationService : IEducationService
    {

        private readonly IEducationRepository _educationRepository;


        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public EducationViewModel Create(Education education)
        {
            education.Name = education.Name.ToUpper();
            return _educationRepository.Create(education).Result;
        }

        public EducationViewModel GetEducationById(Guid id)
        {
            return _educationRepository.GetEducationById(id).Result;
        }

        public EducationViewModel GetEducationByName(string name)
        {
            name = name.ToUpper();
            return _educationRepository.GetEducationByName(name).Result;
        }

        public EducationViewModel GetEducations()
        {
            return _educationRepository.GetAllEducations().Result;
        }

        public EducationViewModel Update(Guid id, Education education)
        {
            var educationViewModel = _educationRepository.GetEducationById(id).Result;

            if (educationViewModel.Education == null)
            {
                return educationViewModel;
            }
            var dbEducation = educationViewModel.Education;
            dbEducation.Name = education.Name.ToUpper();
            dbEducation.Department_Address = education.Department_Address;

            return _educationRepository.Update(dbEducation).Result;
        }
    }
}
