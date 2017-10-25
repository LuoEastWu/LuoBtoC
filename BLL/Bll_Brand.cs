using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   
    public class Bll_Brand
    {
        DAL.dal_Brand dal = new DAL.dal_Brand();

        public SqlModel.Brand GetModel(long p)
        {
            return dal.GetModel(p);
        }
    }
}
