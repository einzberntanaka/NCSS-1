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
    
    public partial class LEAVESTATU
    {
        public LEAVESTATU()
        {
            this.LEAVEs = new HashSet<LEAVE>();
        }
    
        public int LeaveStatusId { get; set; }
        public string LeaveStatusName { get; set; }
    
        public virtual ICollection<LEAVE> LEAVEs { get; set; }
    }
}
