using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class dal_Product
    {
        public dal_Product() { }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<SqlModel.Product> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            List<SqlModel.Product> productList = new List<SqlModel.Product>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                productList = db.Queryable<SqlModel.Product>()
                              .Where(strWhere)
                              .OrderBy(orderby)
                              .Skip(startIndex).Take(endIndex).ToList();
            });
            return productList;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SqlModel.Product GetModel(long ID)
        {
            SqlModel.Product model = new SqlModel.Product();
            DataTable dt = new DataTable();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                dt = db.Ado.UseStoredProcedure().GetDataTable("Product_GetModel", new SqlSugar.SugarParameter[]
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
                if (dt.Rows[0]["ProductTypeId"] != null && dt.Rows[0]["ProductTypeId"].ToString() != "")
                {
                    model.ProductTypeId = long.Parse(dt.Rows[0]["ProductTypeId"].ToString());
                }
                if (dt.Rows[0]["ProductNo"] != null && dt.Rows[0]["ProductNo"].ToString() != "")
                {
                    model.ProductNo = dt.Rows[0]["ProductNo"].ToString();
                }
                if (dt.Rows[0]["ProductName"] != null && dt.Rows[0]["ProductName"].ToString() != "")
                {
                    model.ProductName = dt.Rows[0]["ProductName"].ToString();
                }
                if (dt.Rows[0]["ProductPic"] != null && dt.Rows[0]["ProductPic"].ToString() != "")
                {
                    model.ProductPic = dt.Rows[0]["ProductPic"].ToString();
                }
                if (dt.Rows[0]["Description"] != null && dt.Rows[0]["Description"].ToString() != "")
                {
                    model.Description = dt.Rows[0]["Description"].ToString();
                }
                if (dt.Rows[0]["Brand"] != null && dt.Rows[0]["Brand"].ToString() != "")
                {
                    model.Brand = int.Parse(dt.Rows[0]["Brand"].ToString());
                }
                if (dt.Rows[0]["Spec"] != null && dt.Rows[0]["Spec"].ToString() != "")
                {
                    model.Spec = dt.Rows[0]["Spec"].ToString();
                }
                if (dt.Rows[0]["MarketPrice"] != null && dt.Rows[0]["MarketPrice"].ToString() != "")
                {
                    model.MarketPrice = decimal.Parse(dt.Rows[0]["MarketPrice"].ToString());
                }
                if (dt.Rows[0]["WebsitePrice"] != null && dt.Rows[0]["WebsitePrice"].ToString() != "")
                {
                    model.WebsitePrice = decimal.Parse(dt.Rows[0]["WebsitePrice"].ToString());
                }
                if (dt.Rows[0]["ProductClick"] != null && dt.Rows[0]["ProductClick"].ToString() != "")
                {
                    model.ProductClick = int.Parse(dt.Rows[0]["ProductClick"].ToString());
                }
                if (dt.Rows[0]["ProductNum"] != null && dt.Rows[0]["ProductNum"].ToString() != "")
                {
                    model.ProductNum = int.Parse(dt.Rows[0]["ProductNum"].ToString());
                }
                if (dt.Rows[0]["ProductTotal"] != null && dt.Rows[0]["ProductTotal"].ToString() != "")
                {
                    model.ProductTotal = decimal.Parse(dt.Rows[0]["ProductTotal"].ToString());
                }
                if (dt.Rows[0]["SalesVolume"] != null && dt.Rows[0]["SalesVolume"].ToString() != "")
                {
                    model.SalesVolume = int.Parse(dt.Rows[0]["SalesVolume"].ToString());
                }
                if (dt.Rows[0]["Sort"] != null && dt.Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(dt.Rows[0]["Sort"].ToString());
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

        public bool Delete(long iD)
        {
            int rowsAffected = 0;


            Collections.StartSqlSugar.GetInstance((db)=> 
            {
                rowsAffected = db.Ado.UseStoredProcedure<int>(() =>
                {
                    return db.Ado.GetInt("Product_Delete", new { ID = iD });
                });
            });
            
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<SqlModel.Product> GetPage(string whereStr, string strOrderBy)
        {
            List<SqlModel.Product> proList = new List<SqlModel.Product>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                proList = db.Queryable<SqlModel.Product>()
                          .Where(whereStr)
                          .OrderBy(strOrderBy)
                          .ToList();
            });
            return proList;
        }

        public List<SqlModel.Product> GetList(int p1, string p2, string p3)
        {
            List<SqlModel.Product> list = new List<SqlModel.Product>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                if (p1 > 0)
                {
                    list = db.Queryable<SqlModel.Product>()
                             .Where(p2)
                             .OrderBy(p3)
                             .Take(p1)
                             .ToList();
                }
                else
                {
                    list = db.Queryable<SqlModel.Product>()
                             .Where(p2)
                             .OrderBy(p3)
                             .ToList();
                }

            });
            return list;


        }
    }
}
