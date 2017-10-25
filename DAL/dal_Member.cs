using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class dal_Member
    {

        public dal_Member() { }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SqlModel.Member> GetList(string strWhere)
        {
            List<SqlModel.Member> memberList = new List<SqlModel.Member>();
            SqlSugar.StartSqlSugar.GetInstance((db) =>
            {
                memberList = db.Queryable<SqlModel.Member>()
                               .Where(strWhere)
                               .Select(a => new SqlModel.Member()
                               {
                                   ID=a.ID,
                                   MemberRankId=a.MemberRankId,
                                   MemberName=a.MemberName,
                                   Password=a.Password,
                                   Email=a.Email,
                                   Phone=a.Phone,
                                   QQ=a.QQ,
                                   Address=a.Address,
                                   Remark=a.Remark,
                                   CreateDate=a.CreateDate,
                                   IsDelete=a.IsDelete
                               }).ToList();
            });
            return memberList;
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SqlModel.MemberModel.Member GetModel(long id)
        {

            SqlModel.MemberModel.Member model = new SqlModel.MemberModel.Member();
        
            SqlSugar.StartSqlSugar.GetInstance((db) => 
            {
                var dt = db.Ado.UseStoredProcedure().GetDataTable("Member_GetModel", new { ID = id });
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                    }
                    if (dt.Rows[0]["MemberRankId"] != null && dt.Rows[0]["MemberRankId"].ToString() != "")
                    {
                        model.MemberRankId = int.Parse(dt.Rows[0]["MemberRankId"].ToString());
                    }
                    if (dt.Rows[0]["MemberName"] != null && dt.Rows[0]["MemberName"].ToString() != "")
                    {
                        model.MemberName = dt.Rows[0]["MemberName"].ToString();
                    }
                    if (dt.Rows[0]["Password"] != null && dt.Rows[0]["Password"].ToString() != "")
                    {
                        model.Password = dt.Rows[0]["Password"].ToString();
                    }
                    if (dt.Rows[0]["Email"] != null && dt.Rows[0]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[0]["Email"].ToString();
                    }
                    if (dt.Rows[0]["Phone"] != null && dt.Rows[0]["Phone"].ToString() != "")
                    {
                        model.Phone = dt.Rows[0]["Phone"].ToString();
                    }
                    if (dt.Rows[0]["QQ"] != null && dt.Rows[0]["QQ"].ToString() != "")
                    {
                        model.QQ = dt.Rows[0]["QQ"].ToString();
                    }
                    if (dt.Rows[0]["Address"] != null && dt.Rows[0]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[0]["Address"].ToString();
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
                }
               
                  
            });

            return model;
        
            
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public long Add(SqlModel.MemberModel.Member model)
        {
            long outPutValue=0;
            SqlSugar.StartSqlSugar.GetInstance((db) => 
            {
               
                var outputResult = db.Ado.UseStoredProcedure<dynamic>(() =>
                {
                   
                    var p1 = new SqlSugar.SugarParameter("@ID", null,true);
                    var dbResult = db.Ado.SqlQueryDynamic("Member_ADD", new SqlSugar.SugarParameter[]
                    {
                        p1,
                        new SqlSugar.SugarParameter("@MemberRankId",model.MemberRankId),
                        new SqlSugar.SugarParameter("@MemberName", model.MemberName),
                        new SqlSugar.SugarParameter("@Password", model.Password),
                        new SqlSugar.SugarParameter("@Email", model.Email),
                        new SqlSugar.SugarParameter("@Phone", model.Phone),
                        new SqlSugar.SugarParameter("@QQ", model.QQ),
                        new SqlSugar.SugarParameter("@Address", model.Address),
                        new SqlSugar.SugarParameter("@Remark", model.Remark),
                        new SqlSugar.SugarParameter("@CreateDate", model.CreateDate),
                        new SqlSugar.SugarParameter("@IsDelete", model.IsDelete)
                    });
                    outPutValue =SqlSugar.SqlFunc.ToInt64(p1.Value);
                    return dbResult;
                });
            });

            return outPutValue;
        }
    }
}
