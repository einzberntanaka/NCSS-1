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
    
    public partial class PAYSLIP
    {
        public int PayslipId { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> PayslipTime { get; set; }
        public Nullable<double> ContractSalary { get; set; }
        public Nullable<double> TechIncentive { get; set; }
        public Nullable<double> ClientBonus { get; set; }
        public Nullable<double> CompanyBonus { get; set; }
        public Nullable<double> OvertimePayment { get; set; }
        public Nullable<double> SalaryDeduction { get; set; }
        public Nullable<double> HealthInsurance { get; set; }
        public Nullable<double> SocialInsuance { get; set; }
        public Nullable<double> TaxPayable { get; set; }
        public Nullable<double> TakeHomeIncome { get; set; }
    
        public virtual USER USER { get; set; }
    }
}
