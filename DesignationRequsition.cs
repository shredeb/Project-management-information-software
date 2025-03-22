using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public class DesignationRepository : Repository<Designation>
    {
        public dynamic GetDesignations()
        {
            List<Designation> list = Entity<Designation>().OrderByDescending(x => x.Id).ToList();
            var result = list.Select(x => new { Id = x.Id,  Name = x.Name, CStatus = x.CStatus });

            return result;
        }
        public dynamic PopulateDesignation()
        {
            var query = Entities.Where(x => x.CStatus == true).Select(x => new { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();
            return query;
        }
        public Designation GetDesignation(int? Id)
        {
            Designation obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }
        public Designation GetDesignationByName(string name)
        {
            Designation Department = Entity<Designation>().FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return Department;
        }

        public bool IsDuplicate(string Name)
        {
            bool isExists = Entities.Where(x => (x.Name.ToLower() == Name.ToLower())).Any();
            return isExists;
        }


        public dynamic GetDesignationById(int? id)
        {
            var designation = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                CStatus = x.CStatus
            }).FirstOrDefault();

            return designation;
        }
    }
}
