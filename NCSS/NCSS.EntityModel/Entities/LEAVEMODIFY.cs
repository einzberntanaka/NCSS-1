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
    
    public partial class LEAVEMODIFY
    {
        public int UserId { get; set; }
        public int LeaveId { get; set; }
        public string Action { get; set; }
    
        public virtual LEAVE LEAVE { get; set; }
        public virtual USER USER { get; set; }
    }
}
