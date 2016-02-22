using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCSS.Model
{
    public class ManageLeaveModel
    {
        public string FullName { get; set; }
        public string ManagerName { get; set; }
        public string AnnualLeave { get; set; }
        public string MedicalLeave { get; set; }
        public string HospitalLeave { get; set; }
        public string NoPayLeave { get; set; }
    }
}
