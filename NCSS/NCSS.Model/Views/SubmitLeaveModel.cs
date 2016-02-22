using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NCSS.Model
{ 
    public class SubmitLeaveModel
    {
        public int LeaveType { get; set; }
        public int RemainingDays { get; set; }
        [Required(ErrorMessage = "Please enter your start date.")]
        public string DateFrom { get; set; }
        [Required(ErrorMessage = "Please enter your end date.")]
        public string DateTo { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number days.")]
        public int DaysOffNumber { get; set; }
        [Required(ErrorMessage = "Please enter your Reason for leaving.")]
        public string Reason { get; set; }
    }
}
