var LeaveAppicationList = function () {
  
    function ListAppView(id,submitby, leavetype, datefrom, dateto, daysoff, status, reason) {
        var self = this;
        self.Id = ko.observable(id);
        self.Submitby = ko.observable(submitby);
        self.Leavetype = ko.observable(leavetype),
        self.Datefrom = ko.observable(datefrom),
        self.Dateto = ko.observable(dateto),
        self.Daysoff = ko.observable(daysoff),
        self.Status = ko.observable(status),
        self.Reason = ko.observable(reason)
    }
    function LeaveType(leavetype, id)
    {
        var self = this;
        self.Leavetype = ko.observable(leavetype);
        self.Id = ko.observable(id);
    }
    function LeaveStatus(statusname, id)
    {
        var self = this;
        self.Statusname = ko.observable(statusname);
        self.Id = ko.observable(id);
    }
    function SearchOption(name, status, leavetype) {
        var self = this;
        self.Name = ko.observable(name);
        self.Status = ko.observable(status);
        self.Leavetype = ko.observableArray(leavetype);
    }
    var self = this;
    self.ACB = "z1";


    self.availableSearchStatus = ko.observableArray([]);
    self.availableSearchStatus.push(new LeaveStatus("All", "-1"));
    self.availableSearchType = ko.observableArray([]);
    self.availableSearchType.push(new LeaveType("All", "-1"));
    self.Options = new SearchOption("", "", "");
    self.LeaveList = ko.observableArray();
    self.currentPage = ko.observable(1);
    self.pageCount = ko.observable(1);
    self.pageSize = ko.observable(10);
    self.totalCount = ko.observable(1);
    self.isSearching = ko.observable(false);
    self.initialize = function () {
        var page = location.hash;
        page = page.split("page=")[1];
        self.getLeaveListByPage("1", self.pageSize, false, self.Options);
    };
    self.GetStatus = function () {
        $.getJSON('/Leave/GetLeaveStatus', function (data) {
            $.each(data, function (key, value) {
                self.availableSearchStatus.push(new LeaveStatus(value.StatusName, value.Id));
            });
        });
    };
    self.GetType = function () {
        $.getJSON('/Leave/GetLeaveType', function (data) {
            $.each(data, function (key, value) {
                self.availableSearchType.push(new LeaveType(value.LeaveType, value.Id));
            });
        });
    };
    self.StartSearching = function () {
        self.isSearching = ko.observable(true);
        self.getLeaveListByPage(1, self.pageSize(), self.isSearching(), self.Options);
    }
    self.getLeaveListByPage = function (pageNo, pageSize, isSearching, Options) {
        var searchOptions = { Name: Options.Name(), Status: Options.Status(), Leavetype: Options.Leavetype() };
        $.ajax({
                url: '../Leave/GetLeaveList',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                data: JSON.stringify({
                    pageNo: pageNo,
                    pageSize: pageSize,
                    isSearching: isSearching,
                    Options: searchOptions
                }),
                success: function(data) {
                    self.LeaveList.removeAll();
                    self.currentPage(data.CurrentPage);
                    self.pageCount(data.PageCount);
                    self.pageSize(data.PageSize);
                    self.totalCount(data.TotalCount);
                    $.each(data.LeaveList, function (key, value) {
                        self.LeaveList.push(new ListAppView(value.Id,value.SubmitBy, value.LeaveType, value.DateFrom, value.DateTo, value.DaysOff,value.Status,value.Reason));
                    });
                    self.createPagination();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Status: " + textStatus); alert("Error: " + errorThrown);
                }
            });
      };

        self.loadPage = function(pageNo, event) {
            console.log(pageNo);
            self.getLeaveListByPage(pageNo, self.pageSize(), self.isSearching(), self.Options);
        };
       
        self.createPagination = function () {
            $("#paginationHolder").pagination({
                pages: self.pageCount(),
                itemsOnPage: self.pageSize(),
                currentPage: self.currentPage(),
                cssStyle: 'light-theme',
                hrefTextPrefix: '#page=',
                prevText: 'Previous Page',
                nextText: 'Next Page',
                onPageClick: self.loadPage // fires when a page is clicked :))
            });

        };
        self.GetStatus();
        self.GetType();
        self.initialize();

}
$(document).ready(function () {
    ko.applyBindings(new LeaveAppicationList());
});
