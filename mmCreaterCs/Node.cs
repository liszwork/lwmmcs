/**
 * refs.
 * XML:
 * https://webbibouroku.com/Blog/Article/linq-to-xml
 * http://blog.hiros-dot.net/?p=5159
 * StringBuilder:
 * https://www.sejuku.net/blog/43625#StringBuilder
 */

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
        private string name = "";
        private XElement element = null;
        /// <summary>親要素</summary>
        private XElement parent = null;
        /// <summary>子要素</summary>
        private List<Node> child = new List<Node>();

        public string Name { get => this.name; set => this.name = value; }
        internal List<Node> Childs { get => this.child; set => this.child = value; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Node(string text, string position = "")
        {
            element = CreateNode(text, position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public XElement CreateNode(string text, string position = "")
        {
            name = text;
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
            if ( position == "" )
            {
                attr.Add("POSITION", position);
            }
            AddAttr(attr, elm);

            return elm;
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
            return "1";
        }

        public bool AddChild(Node node)
        {
            Childs.Add(node);
            return true;
        }

        public bool DeleteChild()
        {
            return true;
        }

        public void ShowChild()
        {
            StringBuilder sb = new StringBuilder(element.ToString());
            foreach ( Node node in Childs )
            {
                sb.AppendFormat("\r\n  {0}", node.element.ToString());
            }
            logger.Log(sb.ToString());
        }
    }
}
