using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mmCreaterCs
{
    class Node
    {
        private ulong uniqueNo = 0xFFFFFFFF;
        public Node()
        {
            GetDatetimeText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public XElement CreateNode(string text, string position="")
        {
            return null;
        }

        /// <summary>
        /// 属性の作成
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private XAttribute CreateAttr(string key, string val)
        {
            return null;
        }

        /// <summary>
        /// Nodeに属性を追加する
        /// </summary>
        /// <param name="attrInfo"></param>
        /// <param name="node"></param>
        private void AddAttr(Dictionary<string, string> attrInfo, XElement node)
        {

        }

        /// <summary>
        /// 日時文字列の取得
        /// </summary>
        /// <returns></returns>
        private string GetDatetimeText()
        {
            System.DateTime dt = System.DateTime.Now;
            string datetime = String.Format("{0:yyyyMMddHHmmssfff000", dt);
            string msg = String.Format("{0:yyyy年MM月dd日(ddd) HH時mm分ss秒fff}", dt) + "\r\n"
                + datetime
            Console.WriteLine(msg);
            return datetime;
        }
    }
}
