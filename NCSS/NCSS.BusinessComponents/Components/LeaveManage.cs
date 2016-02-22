using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCSS.Model;
using NCSS.Contracts.DataAcess;
using NCSS.DataAccess.Leave;
using NCSS.Contracts.Components;
using NCSS.EntityModel.Entities;
using NCSS.EntityModel;
using NCSS.Model.FormInit;
using NCSS.Model.Views;

namespace NCSS.BusinessComponents.Components
{
    public class LeaveManage : ILeaveManage
    {
        private readonly ILeaveDAO LeaveAccess;
        public LeaveManage()
            :base()
        {
            this.LeaveAccess = new LeaveDAO();
        }
        public ManageLeaveModel GetLeaveBalance(string userid)
        {
            int id = Convert.ToInt32(userid);
            ManageLeaveModel leaveBalance = new ManageLeaveModel();
            leaveBalance = LeaveAccess.GetLeaveBalance(id);
            return leaveBalance;
        }
        public List<Model.LeaveTypeItem> GetLeaveTypeList()
        {
            return LeaveAccess.GetLeaveTypeList();
        }
        public int GetRemainingDaysOff(string LeaveTypeId, string UserId)
        {
            return LeaveAccess.GetRemainingDays(Convert.ToInt32(LeaveTypeId), Convert.ToInt32(UserId));
        }
        public bool AddNewLeave(SubmitLeaveModel leave, string userid)
        {
            LEAVE newLeave = new LEAVE
            {
                DateFrom = Convert.ToDateTime(leave.DateFrom),
                DateTo = Convert.ToDateTime(leave.DateTo),
                DaysOff = leave.DaysOffNumber,
                LeaveTypeId = Convert.ToInt32(LEAVE_TYPE.AnnualLeave),
                LeaveStatusId = Convert.ToInt32(LEAVE_STATUS.Processing),
                Reason = leave.Reason,
                RejectReason = ""

            };
            return LeaveAccess.AddNewLeave(newLeave, Convert.ToInt32(userid));
        }
        public LeaveListPageModal GetLeavePageList(int? pageNo, int? pageSize, bool isSearching, LeaveSearchOptions Options)
        {
            return LeaveAccess.GetLeavePageList(pageNo, pageSize, isSearching, Options);
        }
        public List<LeaveStatus> getListLeaveStatus()
        {
            return LeaveAccess.GetLeaveStatus();
        }
        public List<LeaveTypeItems> GetLeaveTypes()
        {
            return LeaveAccess.GetLeaveType();
        }
        public LeaveView GetLeaveById(string id)
        {
            LEAVE leave = LeaveAccess.GetLeaveById(Convert.ToInt32(id));
            int ID = Convert.ToInt32(id);
            return new LeaveView
            {
                Id = leave.LeaveId.ToString(),
                DateFrom = leave.DateFrom.ToString(),
                DateTo = leave.DateTo.ToString(),
                DaysOff = leave.DaysOff ?? 0,
                LeaveType = leave.LEAVETYPE.LeaveName,
                Reason = leave.Reason,
                SubmitBy = leave.LEAVEMODIFies.Where(p => p.Action == ACTION_TYPE.Submit).Where(u => u.LeaveId == ID).FirstOrDefault().USER.FullName.ToString()
            };
        }
    }
}
