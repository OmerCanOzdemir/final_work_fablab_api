using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            project.Created_Date = DateTime.Now;
            project.IsDeleted = false;
            return _projectRepository.Create(project).Result;
        }

        public CommentViewModel CreateComment(Guid id, Comment comment)
        {
            var projectViewModel = _projectRepository.GetProjectById(id).Result;

            if (projectViewModel.Project == null)
            {
                return new CommentViewModel(null, HttpStatusCode.NotFound,"Project not found");
            }
            comment.ProjectId = id;
            comment.CreatedTime = DateTime.Now;
            return _projectRepository.CreateComment(comment).Result;
        }

        public ProjectViewModel Delete(Guid id)
        {

            var projectViewModel = _projectRepository.GetProjectById(id).Result;

            if (projectViewModel.Project == null)
            {
                return projectViewModel;
            }
            var dbProject = projectViewModel.Project;

            dbProject.IsDeleted = true;
            return _projectRepository.Delete(dbProject).Result;


        }

        public ProjectViewModel GetProjectById(Guid id)
        {
            return _projectRepository.GetProjectById(id).Result;
        }

        public ProjectViewModel GetProjects()
        {
            return _projectRepository.GetProjects().Result;
        }

        public ProjectViewModel Update(Project project, Guid id)
        {
            var projectViewModel = _projectRepository.GetProjectById(id).Result;

            if (projectViewModel.Project == null)
            {
                return projectViewModel;
            }
            var dbProject = projectViewModel.Project;

            dbProject.IsPublic = project.IsPublic;
            dbProject.Description = project.Description;
            dbProject.Title = project.Title;
            dbProject.CoverDescription = project.CoverDescription;
            dbProject.Category_Id = project.Category_Id;

            return _projectRepository.Update(dbProject).Result;
        }
    }
}
