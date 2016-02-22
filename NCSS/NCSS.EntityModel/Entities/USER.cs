//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCSS.EntityModel.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        public USER()
        {
            this.ARTICLEs = new HashSet<ARTICLE>();
            this.EVENTs = new HashSet<EVENT>();
            this.LEAVEBALANCEs = new HashSet<LEAVEBALANCE>();
            this.LEAVEMODIFies = new HashSet<LEAVEMODIFY>();
            this.NEWS = new HashSet<NEWS>();
            this.PAYSLIPs = new HashSet<PAYSLIP>();
        }
    
        public int UserId { get; set; }
        public int RoleID { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string PersonalTaxCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual ICollection<ARTICLE> ARTICLEs { get; set; }
        public virtual ICollection<EVENT> EVENTs { get; set; }
        public virtual ICollection<LEAVEBALANCE> LEAVEBALANCEs { get; set; }
        public virtual ICollection<LEAVEMODIFY> LEAVEMODIFies { get; set; }
        public virtual ICollection<NEWS> NEWS { get; set; }
        public virtual ICollection<PAYSLIP> PAYSLIPs { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}