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
    
    public partial class LEAVETYPE
    {
        public LEAVETYPE()
        {
            this.LEAVEs = new HashSet<LEAVE>();
            this.LEAVEBALANCEs = new HashSet<LEAVEBALANCE>();
        }
    
        public int LeaveTypeId { get; set; }
        public string LeaveName { get; set; }
    
        public virtual ICollection<LEAVE> LEAVEs { get; set; }
        public virtual ICollection<LEAVEBALANCE> LEAVEBALANCEs { get; set; }
    }
}
