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
        private Logger logger = new Logger();
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
        public XElement CreateNode(string text, string position = "")
        {
            string uniqueNo = GenerateUniqueNo();
            XElement elm = new XElement("node");
            // TODO: ユニーク値を何かしらで管理すべき？
            Dictionary<string, string> attr = new Dictionary<string, string>()
            {
                { "CREATED", string.Format("{0:013d}", int.Parse(uniqueNo)) },
                { "ID", "ID_" + string.Format("{0:09d}", int.Parse(uniqueNo)) },
                { "MODIFIED", string.Format("{0:013d}", int.Parse(uniqueNo)) },
                { "TEXT", text }
            };
            if ( 0 < position.Length )
            {
                attr.Add("POSITION", position);
            }
            AddAttr(attr, elm);

            return null;
        }

#if false
        /// <summary>
        /// 属性の作成
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        //private XAttribute CreateAttr(string key, string val)
        //{
        //    logger.Log("CreateAttr [" + key + "," + val + "]");
        //    XAttribute attr = new XAttribute(key, val);
        //    return attr;
        //}
#endif

        /// <summary>
        /// Nodeに属性を追加する
        /// </summary>
        /// <param name="attrInfo"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private XElement AddAttr(Dictionary<string, string> attrInfo, XElement node)
        {
            XElement editNode = node;
            foreach ( var item in attrInfo )
            {
                //XAttribute attr = CreateAttr(item.Key, item.Value);
                editNode.SetAttributeValue(item.Key, item.Value);
            }
            return editNode;
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
                + datetime;
            logger.Log(msg);
            return datetime;
        }

        /// <summary>
        /// ユニーク番号文字列の生成
        /// </summary>
        /// <returns></returns>
        private string GenerateUniqueNo()
        {
            return "";
        }
    }
}
