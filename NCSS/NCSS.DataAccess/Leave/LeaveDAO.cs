using NCSS.EntityModel.Entities;
using NCSS.Model;
using System.Linq;
using NCSS.Contracts.DataAcess;
using NCSS.EntityModel;
using System.Collections.Generic;
using NCSS.Model.FormInit;
using System;

namespace NCSS.DataAccess.Leave
{
    public class LeaveDAO : ILeaveDAO
    {
        NCSSEntities NCSSEntities = new NCSSEntities();
        public ManageLeaveModel GetLeaveBalance (int userid)
        {
            
            USER user = NCSSEntities.USERs.Where(p => p.UserId == userid).FirstOrDefault();
            List<LEAVEBALANCE> leaveBalance = NCSSEntities.LEAVEBALANCEs.Where(p => p.UserId == userid).ToList();
            ManageLeaveModel manageleave = new ManageLeaveModel
            {
                AnnualLeave = leaveBalance.Where( p => p.LeaveTypeId == 1).FirstOrDefault().RemainingDays.ToString(),
                FullName = user.FullName,
                HospitalLeave = leaveBalance.Where(p => p.LeaveTypeId == 4).FirstOrDefault().RemainingDays.ToString(),
                ManagerName = NCSSEntities.USERs.Where(p => p.UserId == user.ManagerId).FirstOrDefault().FullName,
                MedicalLeave = leaveBalance.Where(p => p.LeaveTypeId == 2).FirstOrDefault().RemainingDays.ToString(),
                NoPayLeave = leaveBalance.Where(p => p.LeaveTypeId == 3).FirstOrDefault().RemainingDays.ToString()
            };
            return manageleave;
        }
        public List<Model.LeaveTypeItem> GetLeaveTypeList ()
        {
            List<Model.LeaveTypeItem> listType = new List<Model.LeaveTypeItem>();
            NCSSEntities.LEAVETYPEs.ToList().ForEach(p =>
            {
                listType.Add(new Model.LeaveTypeItem
                {
                    LeaveId = p.LeaveTypeId.ToString(),
                    LeaveType = p.LeaveName
                });
            });
            return listType;
        }
        public int GetRemainingDays(int LeaveTypeId, int UserId)
        {
            int remainingDays = NCSSEntities.LEAVEBALANCEs.Where(p => p.LeaveTypeId == LeaveTypeId).FirstOrDefault().RemainingDays ?? 0;
            return remainingDays;
            
        }
        public bool AddNewLeave(LEAVE leave, int userid)
        {
            try
            { 
                NCSSEntities.LEAVEs.Add(leave);
                NCSSEntities.SaveChanges();
                LeaveModifyChange(ACTION_TYPE.Submit, leave.LeaveId, userid);
                return true;
            }
            catch
            { return false; }
        }
        public void LeaveModifyChange(string status, int leaveId, int userid)
        {
            if(status == ACTION_TYPE.Submit)
            {
                LEAVEMODIFY leaveAction = new LEAVEMODIFY
                {
                    Action = ACTION_TYPE.Submit,
                    LeaveId = leaveId,
                    UserId = userid
                };
                NCSSEntities.LEAVEMODIFies.Add(leaveAction);
            }
            else
            {
                LEAVEMODIFY leaveAction = NCSSEntities.LEAVEMODIFies.Where(p => p.LeaveId == leaveId & p.UserId == userid).FirstOrDefault();
                if (status == ACTION_TYPE.Approved)
                    leaveAction.Action = ACTION_TYPE.Approved;
                else
                    leaveAction.Action = ACTION_TYPE.Rejected;
            }
            NCSSEntities.SaveChanges();
    
        }
        public LeaveListPageModal GetLeavePageList(int? pageNo, int? pageSize, bool isSearching, LeaveSearchOptions Options)
        {
            LeaveListPageModal Page = new LeaveListPageModal();
            var LeaveRepository = NCSSEntities.LEAVEs.ToList();
            if (isSearching == true)
                LeaveRepository = ApplySearchOption(LeaveRepository, Options);

            List<LeaveListItem> listLeave = new List<LeaveListItem>();
            LeaveRepository.ForEach(p => listLeave.Add(
                new LeaveListItem
                {
                    Id = p.LeaveId.ToString(),
                    DateFrom = p.DateFrom.ToString(),
                    DateTo = p.DateTo.ToString(),
                    DaysOff = p.DaysOff ?? 0,
                    Reason = p.Reason,
                    LeaveType = p.LEAVETYPE.LeaveName,
                    Status = p.LEAVESTATU.LeaveStatusName,
                    SubmitBy = p.LEAVEMODIFies.Where(u => u.Action == ACTION_TYPE.Submit).FirstOrDefault().USER.FullName
                }
                ));

            int pageTakeSize = pageSize ?? 10;
            int pageCount = (LeaveRepository.Count() % pageTakeSize == 0) ? LeaveRepository.Count() / pageTakeSize : (LeaveRepository.Count() / pageTakeSize + 1);
            int pageNumber = pageNo ?? 1;
            pageNumber = pageNumber <= pageCount ? pageNumber : pageCount;
            pageNumber = pageNo <= 0 ? 1 : pageNumber;

            int skipItem = (pageNumber - 1) * pageTakeSize;
            Page.LeaveList = listLeave.OrderBy(p => p.Id).Skip(skipItem).Take(pageTakeSize).ToList();

            Page.CurrentPage = pageNumber;
            Page.PageCount = pageCount;
            Page.PageSize = pageTakeSize;
            Page.TotalCount = LeaveRepository.Count();

            return Page;

        }

        public List<LEAVE> ApplySearchOption(List<LEAVE> listLeave, LeaveSearchOptions Options)
        {
            int LeaveTypeId = Convert.ToInt32(Options.Leavetype);
            int StatusId = Convert.ToInt32(Options.Status);
            if (Options.Name != null && Options.Name != String.Empty)
            {
                var leavesAction = NCSSEntities.LEAVEMODIFies.Where(p => p.Action == ACTION_TYPE.Submit && p.USER.FullName.Contains(Options.Name)).Select(u => u.LeaveId).ToList();
                listLeave = listLeave.Where(p => leavesAction.Contains(p.LeaveId)).ToList();
            }
            if (Options.Leavetype != null && Options.Leavetype != String.Empty && Options.Leavetype != "-1")
                listLeave = listLeave.Where(p => p.LeaveTypeId == LeaveTypeId).ToList();
            if (Options.Status != null && Options.Status != String.Empty && Options.Status != "-1")
                listLeave = listLeave.Where(p => p.LeaveStatusId == StatusId).ToList();
            return listLeave;
        }
        public List<LeaveStatus> GetLeaveStatus()
        {
            List<LeaveStatus> list = new List<LeaveStatus>();
            NCSSEntities.LEAVESTATUS.ToList().ForEach(p =>
            {
                list.Add(
                    new LeaveStatus
                    {
                        Id = p.LeaveStatusId.ToString(),
                        StatusName = p.LeaveStatusName
                    });
            });
            return list;
        } 
        public List<LeaveTypeItems> GetLeaveType()
        {
            List<LeaveTypeItems> list = new List<LeaveTypeItems>();
            NCSSEntities.LEAVETYPEs.ToList().ForEach(p =>
            {
                list.Add(
                    new LeaveTypeItems
                    {
                        Id = p.LeaveTypeId.ToString(),
                        LeaveType = p.LeaveName
                    });

            });
            return list;
        }
        public LEAVE GetLeaveById(int id)
        {
            return NCSSEntities.LEAVEs.Where(p => p.LeaveId == id).FirstOrDefault();
        }
 
    }
}
