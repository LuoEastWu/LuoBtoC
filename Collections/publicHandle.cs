using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Collections
{
    public class publicHandle
    {
        public publicHandle()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region   处理字符串
        /// <summary>
        /// 截取字符传
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="endstr">结尾字符</param>
        /// <returns></returns>
        public static string GetSubstring(string str, int length, string endstr)
        {
            string tStr = "";

            try
            {
                if (length > str.Length)
                {
                    tStr = str;
                }
                else
                {
                    char[] trimChars = { ' ', '<', 'B', 'R', '>' };
                    tStr = str.Trim(trimChars);
                    tStr = str.Substring(0, length) + endstr;
                    //System.Windows.Forms.MessageBox.Show(tStr);
                }
                tStr = Filter(tStr, "nohtml");
            }
            catch
            {
                tStr = str;
            }
            return tStr;
        }


        /// <summary>
        /// 字符过滤
        /// </summary>
        /// <param name="str">传入的字符</param>
        /// <param name="mode">过滤模式</param>
        /// <example>Filter("<b>b</b>>hfghfgh", "HTML")</example>
        /// <returns>过滤后的字符串</returns>
        public static string Filter(string str, string mode)
        {
            mode = mode.ToLower();

            if (str != null)
            {
                if (str.Length > 0)
                {
                    switch (mode)
                    {
                        case "html":
                            //str = str.Replace("\r\n", "\n");
                            //str = str.Replace("'", "&#39;");
                            //str = str.Replace("\"", "&#34;");
                            //str = str.Replace("<", "&#60;");
                            //str = str.Replace(">", "&#62;");
                            //str = str.Replace("\n", "<br />");
                            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                            //str = Regex.Replace(str, @"<a [^>]*?>", "<a href=\"#\">", RegexOptions.IgnoreCase);
                            //str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);
                            //str = str.Replace("<script src=http://7sesex.com/x.js></script>", "").Replace("<script src=http://3b3.org/c.js></script>", "");
                            //str = str.Replace("<script", "");
                            //str = str.Replace("</script>", "");

                            break;
                        case "nohtml":
                            str = Regex.Replace(str, "<[^>]*>", "");
                            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<a [^>]*?>", "<a href=\"#\">", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);
                            if (str.ToLower().IndexOf("<script>") >= 0)
                            {
                                str = str.Replace(Regex.Match(str, @"(?<=<script).+(?=</script>)").Value, "");
                            }
                            str = Regex.Replace(str, "&nbsp;", "");
                            str = Regex.Replace(str, "&ldquo;", "");
                            str = Regex.Replace(str, "&amp;", "");
                            str = Regex.Replace(str, "&rdquo;", "");
                            str = Regex.Replace(str, "&quot;", "");

                            str = HttpContext.Current.Server.HtmlEncode(str);
                            break;
                        case "sql":
                            str = str.Replace("'", " ");
                            str = str.Replace(";", " ");
                            str = str.Replace("1=1", " ");
                            str = str.Replace("|", " ");
                            str = str.Replace("<", " ");
                            str = str.Replace(">", " ");
                            str = str.Replace("--", "");
                            str = str.Replace("|", "");
                            str = str.Replace("(", "");
                            str = str.Replace(")", "");
                            str = str.Replace("{", "");
                            str = str.Replace("}", "");
                            str = str.Replace("[", "");
                            str = str.Replace("]", "");
                            str = str.Replace("@", "");
                            str = str.Replace("#", "");
                            str = str.Replace("%20", "");
                            str = str.Replace("*", "");
                            str = str.Replace("!", "");
                            str = str.Replace("=", "");
                            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<a [^>]*?>", "<a href=\"#\">", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                            break;
                        case "htmltojs":
                            str = str.Replace("\r\n", "\n");
                            str = str.Replace(@"\", @"\\");
                            str = str.Replace("'", "\\\'");
                            str = str.Replace("\"", "\\\"");
                            str = str.Replace("/", "\\/");
                            str = str.Replace("\n", "<br />");
                            str = str.Replace(" ", "&nbsp;");
                            break;
                        default:
                            str = str.Replace("'", "''");
                            str = str.Replace(";", "；");
                            break;
                    }
                }
            }
            return str;
        }
        #endregion

        /// <summary>
        /// 截取数组字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSubStr(string[] str, string s)
        {
            foreach (string substr in str)
            {
                if (s.IndexOf(substr) > -1)
                {
                    s = s.Substring(0, s.IndexOf(substr));
                }
            }
            if (s.LastIndexOf('?') + 1 == s.Length)
            {
                s = s.Replace("?", "");
            }
            if (s.LastIndexOf('&') + 1 == s.Length)
            {
                s = s.Replace("&", "");
            }
            return s;
        }


        /// <summary>
        /// 弹出提示信息
        /// </summary>    
        /// <param name="page">this.Page</param>
        /// <param name="message">提示信息</param>
        /// <param name="url">url</param>
        public static string ShowMessage(string message, string url)
        {
            return "<script language=\"javascript\" >alert('" + message + "');javascript:location='" + url + "';</script>";

        }
        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="page">this.Page</param>
        /// <param name="message">提示信息</param>
        public static string ShowMessage(string message)
        {

            return "<script language=\"javascript\" >alert('" + message + "');</script>";


        }
    }
}
