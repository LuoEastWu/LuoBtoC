using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class dal_Review
    {
        public List<SqlModel.Review> getPage(string strWhere,string StrOrderBy) 
        {
            List<SqlModel.Review> rev = new List<SqlModel.Review>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                rev = db.Queryable<SqlModel.Review>()
                     .Where(strWhere)
                     .OrderBy(StrOrderBy)
                     .ToList();
            });
            return rev;
        }

       
    }
}
