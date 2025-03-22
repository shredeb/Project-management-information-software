using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public class BusinessUnitRepository : Repository<BusinessUnit>
    {
        public dynamic GetBusinessUnits ()
        {
            List<BusinessUnit> list = Entity<BusinessUnit>().OrderByDescending(x => x.Id).ToList();
            var result = list.Select(x => new { Id = x.Id, Name = x.Name, CStatus = x.CStatus, });
            return result;
        }

        public dynamic PopulateBusinessUnit()
        {
            var query = Entities.Where(x => x.CStatus == true).Select(x => new { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();
            return query;
        }

        public BusinessUnit GetBusniessUnit(int? Id)
        {
            BusinessUnit obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }
        public BusinessUnit GetBusniessUnitByName(string name )
        {
            BusinessUnit BusinessUnit = Entity<BusinessUnit>().FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return BusinessUnit;
        }

        public bool IsDuplicate(string Name)
        {
            bool isExists = Entities.Where(x => (x.Name.ToLower() == Name.ToLower())).Any();
            return isExists;
        }



        public dynamic GetBusinessUnitById(int? id)
        {
            var busniessunit = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                CStatus = x.CStatus
            }).FirstOrDefault();

            return busniessunit;
        }
    }
}
