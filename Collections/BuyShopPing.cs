using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Collections
{
    public class BuyShopPing
    {
        public BuyShopPing()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public string ProductID = HttpContext.Current.Request["ProductID"];
        public string ProductNum = HttpContext.Current.Request["Num"];
        public string WebsitePrice = "0";

        /// <summary>
        /// 创建购物车
        /// </summary>
        public void CreateCartTable()//
        {

            DataSet ds = new DataSet();//数据集
            DataTable newDT = new DataTable("CartTable");//数据表
            ds.Tables.Add(newDT);
            DataColumn newDC;//列

            newDC = new DataColumn("ProductNewID", System.Type.GetType("System.Int32"));
            newDC.DefaultValue = 1;
            ds.Tables["CartTable"].Columns.Add(newDC);//商品数量

            newDC = new DataColumn("ProductID", System.Type.GetType("System.Int32"));
            ds.Tables["CartTable"].Columns.Add(newDC);//商品ID

            newDC = new DataColumn("ProductNum", System.Type.GetType("System.Int32"));
            newDC.DefaultValue = 1;
            ds.Tables["CartTable"].Columns.Add(newDC);//商品数量

            newDC = new DataColumn("ProductName", System.Type.GetType("System.String"));
            ds.Tables["CartTable"].Columns.Add(newDC);//商品名称

            newDC = new DataColumn("ProductNo", System.Type.GetType("System.String"));
            ds.Tables["CartTable"].Columns.Add(newDC);//商品货号

            newDC = new DataColumn("ProductPic", System.Type.GetType("System.String"));
            ds.Tables["CartTable"].Columns.Add(newDC);  //商品图片

            newDC = new DataColumn("MarketPrice", System.Type.GetType("System.Double"));
            ds.Tables["CartTable"].Columns.Add(newDC);//商品市场价格

            newDC = new DataColumn("WebsitePrice", System.Type.GetType("System.Double"));
            ds.Tables["CartTable"].Columns.Add(newDC);//商品站内价格

            newDC = new DataColumn("Spec", System.Type.GetType("System.String"));
            ds.Tables["CartTable"].Columns.Add(newDC);//商品规格       

            newDC = new DataColumn("ProductTotal", System.Type.GetType("System.Double"));
            ds.Tables["CartTable"].Columns.Add(newDC);//商品总价小计       

            newDC = new DataColumn("IsDeleted", System.Type.GetType("System.Int32"));
            newDC.DefaultValue = 0;
            ds.Tables["CartTable"].Columns.Add(newDC);//商品是否要被移除购物车   

            HttpContext.Current.Session["myCartTable"] = newDT;//将购物和信息存储到session中去
        }

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <returns></returns>
        public DataTable UpdateShoppingCart(SqlModel.Product model)
        {
            if (HttpContext.Current.Session["myCartTable"] == null)
            {
                CreateCartTable();  //调用函数CreateCartTable()新建一个DataTable
                WriteShoppingCart(model);
            }
            else
            {   //如果购物蓝中已有商品，则需要对购物信息表DataTable进行更新，并将其绑定到ShoppingCartDlt
                WriteShoppingCart(model);
            }
            return (DataTable)HttpContext.Current.Session["myCartTable"];
        }
        /// <summary>
        /// 输出购物车
        /// </summary>
        /// <param name="model"></param>
        public void WriteShoppingCart(SqlModel.Product model)
        {
            if (HttpContext.Current.Request.Params["mode"] != "view") //检查是不是在请求查看购物车
            {
              

                DataTable nowTable = (DataTable)HttpContext.Current.Session["myCartTable"];//如果现在已经有购物信息了，即购物车中已经有了商品
                int pn = nowTable.Rows.Count; //已经购买的不同名的商品个数统计
                int i = 0;
                bool hasone = false; //has-one
                int nowProdID;
                while (i < pn && !hasone)//如果购物车中存在该商品，则hasone为true
                {
                    nowProdID = Int32.Parse(nowTable.Rows[i]["ProductID"].ToString());

                    if (nowProdID == Int32.Parse(ProductID)) //判断购物信息表中，是否存有当前放入商品
                    {
                        hasone = true;
                    }
                    else
                    {
                        i++;
                    }
                }


                #region  如果已有该商品，则 hasone=true，更改该数据行
                if (hasone)
                {
                    DataRow oldDR;
                    oldDR = nowTable.Rows[i];

                    oldDR["ProductNum"] = Int32.Parse(oldDR["ProductNum"].ToString()) + Convert.ToInt32(ProductNum);

                    oldDR["ProductTotal"] = Int32.Parse(oldDR["ProductNum"].ToString()) * Double.Parse(oldDR["WebsitePrice"].ToString());

                    nowTable.Rows[i]["ProductNum"] = oldDR["ProductNum"];
                    nowTable.Rows[i]["ProductTotal"] = oldDR["ProductTotal"];
                }
                #endregion


                #region 如果购物车中没有该商品，在表中新加入一行
                else
                {
                    DataRow newDR;

                    if (model != null)
                    {
                        newDR = nowTable.NewRow();

                        newDR["ProductNewID"] = nowTable.Rows.Count + 1;
                        newDR["ProductID"] = model.ID;
                        newDR["ProductNum"] = ProductNum;
                        newDR["ProductName"] = model.ProductName;   //产品名称 
                        newDR["ProductNo"] = model.ProductNo;
                        newDR["ProductPic"] = model.ProductPic;
                        newDR["MarketPrice"] = model.MarketPrice.ToString();      //市场价
                        newDR["WebsitePrice"] = model.WebsitePrice.ToString();    //本网站价                                                                                //商城价
                        newDR["Spec"] = model.Spec;
                        newDR["ProductTotal"] = Convert.ToInt32(ProductNum) * Convert.ToDouble(model.WebsitePrice);

                        nowTable.Rows.Add(newDR);

                    }
                #endregion
                    HttpContext.Current.Session["myCartTable"] = nowTable;
                }
            }

        }


        /// <summary>
        /// 获取购物车中的商品总价格
        /// </summary>
        /// <returns></returns>
        public double GetCaculatorSum()
        {
            Double TotalPri = 0;
            if (HttpContext.Current.Session["myCartTable"] != null) //如果购物车不为空
            {
                int h;
                DataTable nowTable3 = new DataTable("nowCartTable3");
                nowTable3 = (DataTable)HttpContext.Current.Session["myCartTable"];
                if (nowTable3.Rows.Count > 0) //返回购物车中是否有货物
                {
                    for (h = 0; h <= nowTable3.Rows.Count - 1; h++)//一定要是h=0,h<=,而不能是h=1,h<=
                    {
                        TotalPri = TotalPri + Convert.ToDouble(nowTable3.Rows[h]["ProductTotal"]);
                    }
                }
            }
            return TotalPri;
        }

    }


}
