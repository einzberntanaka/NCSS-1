using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCSS.Model;
using NCSS.BusinessComponents.Components;
using NCSS.Model.FormInit;
using NCSS.Model.Views;

namespace NCSS.Controllers
{
    public class LeaveController : Controller
    {
        //
        // GET: /Leave/
        LeaveManage leaveManagement = new LeaveManage();
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "Users");
            else
            {
                ManageLeaveModel leaveModel = new ManageLeaveModel();
                try
                { 
                    string id = Session["id"].ToString();
                    leaveModel = leaveManagement.GetLeaveBalance(id);
                }
                catch
                {
                }
                return View(leaveModel);
            }
          
        }
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult SubmitLeave()
        {
            try
            {
                string userid = Session["id"].ToString();
                int remainingDays = leaveManagement.GetRemainingDaysOff("1", userid);
                List<Model.LeaveTypeItem> list = leaveManagement.GetLeaveTypeList();
                List<SelectListItem> dropLeaveList = new List<SelectListItem>();
                list.ForEach(p => {
                    dropLeaveList.Add(
                        new SelectListItem { Text = p.LeaveType, Value = p.LeaveId }
                    );
                });
                ViewBag.leaveType = new SelectList(dropLeaveList, "Value", "Text", list.FirstOrDefault().LeaveId);
                SubmitLeaveModel submitLeaveModel = new SubmitLeaveModel();
                submitLeaveModel.DateFrom = DateTime.Now.ToString("MM/dd/yyyy");
                submitLeaveModel.DateTo = DateTime.Now.ToString("MM/dd/yyyy");
                submitLeaveModel.RemainingDays = remainingDays;
                return View(submitLeaveModel);
            }
            catch
            {
                return RedirectToAction("Index", "Users");
            }
            
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult SubmitLeave(SubmitLeaveModel model)
        {
            string userid = Session["id"].ToString();
            if (ModelState.IsValid)
            {

                bool Success = leaveManagement.AddNewLeave(model, userid);
                if(Success)
                    return PartialView("SubmitSuccessful", model);
                else
                    return PartialView("SubmitFailed", model);

            }
            else
            {
                int remainingDays = leaveManagement.GetRemainingDaysOff("1", userid);
                List<Model.LeaveTypeItem> list = leaveManagement.GetLeaveTypeList();
                List<SelectListItem> dropLeaveList = new List<SelectListItem>();
                list.ForEach(p => {
                    dropLeaveList.Add(
                        new SelectListItem { Text = p.LeaveType, Value = p.LeaveId }
                    );
                });
                model.RemainingDays = remainingDays;
                ViewBag.leaveType = new SelectList(dropLeaveList, "Value", "Text", list.FirstOrDefault().LeaveId);
                return PartialView("SubmitForm", model);
            }
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public JsonResult GetRemainingDays(string LeaveId)
        {
            try
            {
                string userid = Session["id"].ToString();
                string remainingDays = leaveManagement.GetRemainingDaysOff(LeaveId, userid).ToString();
                return Json(remainingDays, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(null);
            }
        }
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult LeaveAppList()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public JsonResult GetLeaveList(int? pageNo, int? pageSize, string isSearching, LeaveSearchOptions Options)
        {
            bool IsSearching = Convert.ToBoolean(isSearching);
            LeaveListPageModal pagedList = leaveManagement.GetLeavePageList(pageNo, pageSize, IsSearching, Options);
            return Json(pagedList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public JsonResult GetLeaveStatus()
        {
            List<LeaveStatus> listStatus = leaveManagement.getListLeaveStatus();
            return Json(listStatus, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public JsonResult GetLeaveType()
        {
            List<LeaveTypeItems> listType = leaveManagement.GetLeaveTypes();
            return Json(listType,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult Detail(string Id)
        {
            LeaveView model = leaveManagement.GetLeaveById(Id);
            return View(model);
        }
    }
}
