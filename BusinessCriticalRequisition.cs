using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
   public class BusinessCriticalRepository : Repository<BusinessCritica>
    {
        public dynamic GetBusinessCriticals()
        {

            List<BusinessCritica> list = Entity<BusinessCritica>().OrderByDescending(x => x.Id).ToList();
            var result = list.Select(x => new { Id = x.Id, Name = x.Name, CStatus = x.CStatus, });
            return result;
        }

        public dynamic PopulateBusinessCritical()
        {
            var query = Entities.Where(x => x.CStatus == true).Select(x => new { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();
            return query;
        }

        public BusinessCritica GetBusinessCritical(int? Id)
        {
            BusinessCritica obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public BusinessCritica GetBusinessCriticalByName(string name)
        {
            BusinessCritica BusinessCritical = Entity<BusinessCritica>().FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return BusinessCritical;
        }

        public bool IsDuplicate(string Name)
        {
            bool isExists = Entities.Where(x => (x.Name.ToLower() == Name.ToLower())).Any();
            return isExists;
        }

        public dynamic GetBusinessCriticalById(int? id)
        {
            var businesscritical = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                CStatus = x.CStatus
            }).FirstOrDefault();

            return businesscritical;
        }
    }
}
