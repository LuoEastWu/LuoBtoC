using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LuoBtoC.Areas.Admin.Models
{
    public class LabListVm
    {
        public static int PageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        public IEnumerable<LabTable> LabListTables { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
    }

    public class LabTable
    {
        public int LabTableId { get; set; }

        public string LabId
        { set; get; }


        public string LabName
        { set; get; }


        public string LabAddress
        { set; get; }


        public string LabStatus
        { set; get; }


        public int? LabUseNum
        { set; get; }


        public string LabSynopsis
        { set; get; }

    }
}