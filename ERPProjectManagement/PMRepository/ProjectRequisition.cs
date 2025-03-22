using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public class ProjectRepository : Repository<Project>
    {
        public dynamic GetProjects()
        {
            List<Project> list = Entity<Project>().OrderByDescending(x => x.Id).ToList();
            var result = list.Select(x => new { Id = x.Id, Name = x.Name, Remarks = x.Remarks, CStatus = x.CStatus, });
            return result;
        }

        public dynamic PopulateProject()
        {
            var query = Entities.Where(x => x.CStatus == true).Select(x => new { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();
            return query;
        }

        public Project GetProject(int? Id)
        {
            Project obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public Project GetProjectByName(string name)
        {
            Project Project = Entity<Project>().FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return Project;
        }

        public bool IsDuplicate(string Name)
        {
            bool isExists = Entities.Where(x => (x.Name.ToLower() == Name.ToLower())).Any();
            return isExists;
        }

        public dynamic GetProjectById(int? id)
        {
            var Project = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Remarks = x.Remarks,
                CStatus = x.CStatus
            }).FirstOrDefault();

            return Project;
        }
    }
}
