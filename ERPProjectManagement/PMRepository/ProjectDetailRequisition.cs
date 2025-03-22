using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public class ProjectDetailRepository : Repository<ProjectDetail>
    {
        public dynamic GetProjectDetails()
        {
            //List<ProjectDetail> list = Entity<ProjectDetail>().OrderByDescending(x => x.Id).ToList();
            var result = Entity<ProjectDetail>().Select(x => new
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                Project = x.Project.Name,
                BusinessUnit = x.BusinessUnit.Name,
                BusinessCritical = x.BusinessCritica.Name,
                ProjectURL = x.ProjectURL.Name,
                TFS = x.TFS,
                Remarks = x.Remarks,
                ProjectManagerId = x.ProjectManagerId,
                ProjectManager = x.UserProfile2.FirstName + " " + x.UserProfile2.LastName,
                TeamLeadId = x.TeamLeadId,
                BusinessUnitId = x.BusinessUnitId,
                BusinessCriticaId = x.BusinessCriticaId,
                ProjectURLId = x.ProjectURLId,
                TeamLead = x.UserProfile.FirstName + " " + x.UserProfile.LastName,
                ProductOwnerId = x.ProductOwnerId,
                ProductOwner = x.UserProfile1.FirstName + " " + x.UserProfile1.LastName,

            }).ToList();
            return result;
        }

        public dynamic PopulateProjectDetail()
        {
            var query = Entities.Select(x => new { Id = x.Id, }).OrderBy(x => x.Id).ToList();
            return query;
        }

        public ProjectDetail GetProjectDetail(int? Id)
        {
            ProjectDetail obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public bool IsDuplicate(int ProjectId)
        {
            bool isExists = Entities.Where(x => (x.ProjectId == ProjectId)).Any();
            return isExists;
        }

        public dynamic GetProjectDetailById(int? id)
        {
            var projectTeamMember = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                BusinessUnitId = x.BusinessUnitId,
                BusinessCriticaId = x.BusinessCriticaId,
                ProjectURLId =x.ProjectURLId,
                ProjectManagerId = x.ProjectManagerId,
                ProjectManager = x.UserProfile2.FirstName + " " + x.UserProfile2.LastName,
                TeamLeadId = x.TeamLeadId,
                TeamLead = x.UserProfile.FirstName + " " + x.UserProfile.LastName,
                ProductOwnerId = x.ProductOwnerId,
                ProductOwner = x.UserProfile1.FirstName + " " + x.UserProfile1.LastName,
            }).FirstOrDefault();

            return projectTeamMember;
        }
    }
    
}
