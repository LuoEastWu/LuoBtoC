using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlModel
{
    /// <summary>
    /// 菜单名称
    /// </summary>
    public partial class MenuInfo
    {
        public MenuInfo()
        {

        }
        /// <summary>
        /// 序号
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName { get; set; }
        /// <summary>
        /// 父类型
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 深度
        /// </summary>
        public int Depth { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean IsDelete { get; set; }
    }
}
