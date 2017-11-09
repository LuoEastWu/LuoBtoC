using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class dal_Advert
    {
        public dal_Advert() { }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<SqlModel.Advert> GetList(int Top, string strWhere, string filedOrder)
        {
            List<SqlModel.Advert> advertList=new List<SqlModel.Advert>();
            Collections.StartSqlSugar.GetInstance((db) => 
            {
                advertList = db.Queryable<SqlModel.Advert>()
                               .Where(strWhere)
                               .OrderBy(filedOrder)
                               .Take(Top)
                               .Select<SqlModel.Advert>(a => new SqlModel.Advert
                               {
                                   ID=a.ID,
                                   AdvertTypeId=a.AdvertTypeId,
                                   AdvertCategory=a.AdvertCategory,
                                   AdvertName=a.AdvertName,
                                   AdvertPic=a.AdvertPic,
                                   AdvertUrl=a.AdvertUrl,
                                   Description=a.Description,
                                   Height=a.Height,
                                   Width=a.Width,
                                   Sort= a.Sort,
                                   CreateDate=a.CreateDate,
                                   IsDelete=a.IsDelete
                               }).ToList();

            });
            return advertList;
        }
    }
}
