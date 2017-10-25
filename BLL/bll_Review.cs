using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class bll_Review
    {
        DAL.dal_Review dal = new DAL.dal_Review();
        public List<SqlModel.Review> getPage(string strWher,string strOrderBy) 
        {
          return  dal.getPage(strWher, strOrderBy);
        }


       
    }
}
