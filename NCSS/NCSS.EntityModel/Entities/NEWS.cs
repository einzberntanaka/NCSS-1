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
    
    public partial class NEWS
    {
        public int NewsId { get; set; }
        public Nullable<System.DateTime> NewsDate { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDetail { get; set; }
        public int UserId { get; set; }
    
        public virtual USER USER { get; set; }
    }
}
