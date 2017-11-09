using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlModel;
using System.Data;

namespace DAL
{
    public class Dal_Collection
    {
        public List<SqlModel.Collection> getBasePage(string WhereStr, string filedOrder)
        {
            List<SqlModel.Collection> mode = new List<Collection>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                mode = db.Queryable<SqlModel.Collection>()
                         .Where(WhereStr)
                         .OrderBy(filedOrder)
                         .ToList();
            });
            return mode;
        }

        public SqlModel.Collection GetModel(long ID) 
        {
            DataTable dt = new DataTable();
            SqlModel.Collection model = new Collection();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                dt = db.Ado.UseStoredProcedure().GetDataTable("Collection_GetModel", new SqlSugar.SugarParameter[]{
                new SqlSugar.SugarParameter("@ID",ID)
                });
            });

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["ProductId"] != null && dt.Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(dt.Rows[0]["ProductId"].ToString());
                }
                if (dt.Rows[0]["ProductName"] != null && dt.Rows[0]["ProductName"].ToString() != "")
                {
                    model.ProductName = dt.Rows[0]["ProductName"].ToString();
                }
                if (dt.Rows[0]["MemberId"] != null && dt.Rows[0]["MemberId"].ToString() != "")
                {
                    model.MemberId = int.Parse(dt.Rows[0]["MemberId"].ToString());
                }
                if (dt.Rows[0]["MemberName"] != null && dt.Rows[0]["MemberName"].ToString() != "")
                {
                    model.MemberName = dt.Rows[0]["MemberName"].ToString();
                }
                if (dt.Rows[0]["CollectionDate"] != null && dt.Rows[0]["CollectionDate"].ToString() != "")
                {
                    model.CollectionDate = DateTime.Parse(dt.Rows[0]["CollectionDate"].ToString());
                }
                if (dt.Rows[0]["Sort"] != null && dt.Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(dt.Rows[0]["Sort"].ToString());
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


        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(SqlModel.Collection model)
        {
            bool rowsAffected = false;
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                rowsAffected = db.Ado.UseStoredProcedure<bool>(() =>
                {
                    return db.Ado.GetInt("Collection_Update", new
                    {
                        ID = model.ID,
                        ProductId = model.ProductId,
                        ProductName = model.ProductName,
                        MemberId = model.MemberId,
                        MemberName = model.MemberName,
                        CollectionDate = model.CollectionDate,
                        Sort = model.Sort,
                        IsDelete = model.IsDelete
                    }) > 0;
                });
            });
            return rowsAffected;
        }
    }
}
