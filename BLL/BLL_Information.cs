using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Information
    {
        DAL.dal_Information dal = new DAL.dal_Information();
        public List<SqlModel.Information> GetPage(string whereStr, string p)
        {
           return dal.GetPage(whereStr, p);
        }
    }
}
