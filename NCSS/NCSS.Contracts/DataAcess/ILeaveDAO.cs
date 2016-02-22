using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCSS.Model;
using NCSS.EntityModel.Entities;
using NCSS.Model.FormInit;

namespace NCSS.Contracts.DataAcess
{
    public interface ILeaveDAO
    {
        ManageLeaveModel GetLeaveBalance(int userid);
        List<Model.LeaveTypeItem> GetLeaveTypeList();
        int GetRemainingDays(int LeaveTypeId, int UserId);
        bool AddNewLeave(LEAVE leave, int userid);
        LeaveListPageModal GetLeavePageList(int? pageNo, int? pageSize, bool isSearching, LeaveSearchOptions Options);
        List<LeaveStatus> GetLeaveStatus();
        List<LeaveTypeItems> GetLeaveType();
        LEAVE GetLeaveById(int id);
    }
}
