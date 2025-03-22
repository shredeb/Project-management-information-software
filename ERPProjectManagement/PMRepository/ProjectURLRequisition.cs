using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public class ProjectURLRepository : Repository<ProjectURL>
    {
        public dynamic GetProjectURLs()
        {
            List<ProjectURL> list = Entity<ProjectURL>().OrderByDescending(x => x.Id).ToList();
            var result = list.Select(x => new { Id = x.Id, Name = x.Name, CStatus = x.CStatus, });
            return result;
        }
        public dynamic PopulateProjectURL()
        {
            var query = Entities.Where(x => x.CStatus == true).Select(x => new { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();
            return query;
        }

        public ProjectURL GetProjectURL(int? Id)
        {
            ProjectURL obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public ProjectURL GetProjectURLByName(string name)
        {
            ProjectURL ProjectURL = Entity<ProjectURL>().FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return ProjectURL;
        }

        public bool IsDuplicate(string Name)
        {
            bool isExists = Entities.Where(x => (x.Name.ToLower() == Name.ToLower())).Any();
            return isExists;
        }

        public dynamic GetProjectURLById(int? id)
        {
            var Projecturl = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                CStatus = x.CStatus
            }).FirstOrDefault();

            return Projecturl;
        }
    }
}
