using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCSS.Model.Views
{
    public class LeaveView
    {
        public string Id { get; set; }
        public string SubmitBy { get; set; }
        public string LeaveType { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int DaysOff { get; set; }
        public string Reason { get; set; }
    }
}
