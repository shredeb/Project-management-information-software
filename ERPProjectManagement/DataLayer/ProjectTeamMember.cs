//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERPProjectManagement.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectTeamMember
    {
        public int Id { get; set; }
        public Nullable<int> ProjectDetailId { get; set; }
        public Nullable<int> TeamMemberId { get; set; }
        public Nullable<bool> CStatus { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual ProjectDetail ProjectDetail { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
