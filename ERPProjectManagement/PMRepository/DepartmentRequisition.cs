using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public class DepartmentRepository : Repository<Department>
    {
        public dynamic GetDepartments()
        {
            List<Department> list = Entity<Department>().OrderByDescending(x => x.Id).ToList();
            var result = list.Select(x => new { Id = x.Id, Name = x.Name, CStatus = x.CStatus, });
            return result;
        }

        public dynamic PopulateDepartment()
        {
            var query = Entities.Where(x => x.CStatus == true).Select(x => new { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();
            return query;
        }
        public Department GetDepartment(int? Id)
        {
            Department obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public Department GetDepartmentByName(string name)
        {
            Department Department = Entity<Department>().FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return Department;
        }
        //public bool IsDuplicate(string Name)
        //{
        //    bool isExists = Entities.Where(x => (x.Name.ToLower() == Name.ToLower())).Any();
        //    return isExists;
        //}

        public dynamic GetDepartmentById(int? id)
        {
            var department = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                CStatus = x.CStatus
            }).FirstOrDefault();

            return department;
        }
        
    }
}
