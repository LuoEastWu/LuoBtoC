using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlModel;
using System.Data;


namespace DAL
{
    public partial class Dal_ProductType
    {

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<ProductType> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            List<ProductType> proList = new List<ProductType>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {

                proList = db.Queryable<ProductType>()
                            .Where(strWhere)
                            .OrderBy(orderby)
                            .Skip(startIndex).Take(endIndex).ToList();
            });
            return proList;
        }

        public List<SqlModel.ProductType> GetPage(string whereStr,string filedOrder) 
        {
            List<SqlModel.ProductType> mode = new List<ProductType>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                mode = db.Queryable<SqlModel.ProductType>()
                         .Where(whereStr)
                         .OrderBy(filedOrder)
                         .ToList();
            });
            return mode;
        }

        public ProductType GetModel(long ID)
        {

            SqlModel.ProductType model = new SqlModel.ProductType();
            DataTable dt = new DataTable();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                dt = db.Ado.UseStoredProcedure().GetDataTable("ProductType_GetModel", new SqlSugar.SugarParameter[]
                {
                    new SqlSugar.SugarParameter("@ID",ID),
                });
            });

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["TypeName"] != null && dt.Rows[0]["TypeName"].ToString() != "")
                {
                    model.TypeName = dt.Rows[0]["TypeName"].ToString();
                }
                if (dt.Rows[0]["Fid"] != null && dt.Rows[0]["Fid"].ToString() != "")
                {
                    model.Fid = int.Parse(dt.Rows[0]["Fid"].ToString());
                }
                if (dt.Rows[0]["Sort"] != null && dt.Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(dt.Rows[0]["Sort"].ToString());
                }
                if (dt.Rows[0]["Depth"] != null && dt.Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(dt.Rows[0]["Depth"].ToString());
                }
                if (dt.Rows[0]["Remark"] != null && dt.Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = dt.Rows[0]["Remark"].ToString();
                }
                if (dt.Rows[0]["CreateDate"] != null && dt.Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());
                }
                if (dt.Rows[0]["IsDelete"] != null && dt.Rows[0]["IsDelete"].ToString() != "")
                {
                    if ((dt.Rows[0]["IsDelete"].ToString() == "1") || (dt.Rows[0]["IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.IsDelete = true;
                    }
                    else
                    {
                        model.IsDelete = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public List<ProductType> GetList(string strWhere)
        {
            List<SqlModel.ProductType> proList = new List<ProductType>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                proList = db.Queryable<SqlModel.ProductType>()
                           .Where(strWhere)
                           .ToList();

            });
            return proList;
        }
    }
}
