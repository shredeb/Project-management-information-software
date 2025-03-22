using ERPProjectManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public class UserProfileRepository : Repository<UserProfile>
    {
        
        public dynamic GetUserProfiles()
        {
            //List<UserProfile> list = Entity<UserProfile>().OrderByDescending(x => x.Id).ToList();
            var result = Entity<UserProfile>().Select(x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PFnumber = x.PFnumber,
                ContactNo = x.ContactNo,
                Department = x.Department.Name,
                Designation = x.Designation.Name,
                CStatus = x.CStatus,
                DepartmentId = x.DepartmentId,
                DesignationId = x.DesignationId
            }).ToList();
            return result;
        }
       
        public dynamic PopulateUserProfile()
        {
            var query = Entities.Where(x => x.CStatus == true).Select(x => new { Id = x.Id, FullName = x.FirstName + " " + x.LastName}).OrderBy(x => x.FullName).ToList();
            return query; 
        }

        public UserProfile GetUserProfile(int ? Id)
        {
            UserProfile obj = Entities.FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public UserProfile GetUserProfileByEmail(string Email)
        {
            //UserProfile UserProfile = Entity<UserProfile>().FirstOrDefault(a => a.FirstName + " " + a.LastName.ToLower() == FullName.ToLower());
            UserProfile UserProfile = Entity<UserProfile>().FirstOrDefault(a => a.Email.ToLower() == Email.ToLower());
            return UserProfile;
        }
        public bool IsDuplicate(string Email)
        {
            //bool isExits = Entities.Where(x => (x.FirstName + " " + x.LastName.ToLower() == Name.ToLower())).Any();
            bool isExits = Entities.Where(x => (x.Email.ToLower() == Email.ToLower())).Any();
            return isExits;
        }

        public dynamic GetUserProfileById(int? id)
        {
            var UserProfile = Entities.Where(x => x.Id == id).Select(x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.Name,
                DesignationId = x.DesignationId,
                Designation = x.Designation.Name,
                PFnumber = x.PFnumber,
                ContactNo = x.ContactNo,
                CStatus = x.CStatus


            }).FirstOrDefault();

            return UserProfile;
        }
    }
}
