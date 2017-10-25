using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class dal_Brand
    {
        public SqlModel.Brand GetModel(long p)
        {

            SqlModel.Brand model = new SqlModel.Brand();
            DataTable dt = new DataTable();
            SqlSugar.StartSqlSugar.GetInstance((db) =>
            {
                dt = db.Ado.UseStoredProcedure().GetDataTable("Brand_GetModel", new SqlSugar.SugarParameter[]
                {
                   new SqlSugar.SugarParameter("@ID",p)
                });
            });

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["BrandName"] != null && dt.Rows[0]["BrandName"].ToString() != "")
                {
                    model.BrandName = dt.Rows[0]["BrandName"].ToString();
                }
                if (dt.Rows[0]["LogoPic"] != null && dt.Rows[0]["LogoPic"].ToString() != "")
                {
                    model.LogoPic = dt.Rows[0]["LogoPic"].ToString();
                }
                if (dt.Rows[0]["Description"] != null && dt.Rows[0]["Description"].ToString() != "")
                {
                    model.Description = dt.Rows[0]["Description"].ToString();
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
    }
}
