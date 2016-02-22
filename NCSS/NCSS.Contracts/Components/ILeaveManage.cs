using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCSS.Model;
using NCSS.Model.FormInit;
using NCSS.Model.Views;

namespace NCSS.Contracts.Components
{
    public interface ILeaveManage
    {
        ManageLeaveModel GetLeaveBalance(string userid);
        List<Model.LeaveTypeItem> GetLeaveTypeList();
        int GetRemainingDaysOff(string LeaveTypeId, string UserId);
        bool AddNewLeave(SubmitLeaveModel leave, string userid);
        LeaveListPageModal GetLeavePageList(int? pageNo, int? pageSize, bool isSearching, LeaveSearchOptions Options);
        List<LeaveStatus> getListLeaveStatus();
        List<LeaveTypeItems> GetLeaveTypes();
        LeaveView GetLeaveById(string id);
    }
}
