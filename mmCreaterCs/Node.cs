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
        // Nodeの情報
        private string name = "";
        private string created = "";
        private string id = "";
        private string modified = "";

        // Nodeのオブジェクト
        private XElement element = null;
        /// <summary>親要素</summary>
        private XElement parent = null;
        /// <summary>子要素</summary>
        private List<Node> child = new List<Node>();

        // ロガー
        private Logger logger = new Logger();

        public string Name { get => this.name; set => this.name = value; }
        internal List<Node> Childs { get => this.child; set => this.child = value; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="text">Nodeのテキスト</param>
        /// <param name="position">"right"/"left"</param>
        public Node(string text, string position = "")
        {
            this.element = this.CreateNode(text, position);
        }

        /// <summary>
        /// Nodeの生成
        /// </summary>
        /// <param name="name">Nodeのテキスト</param>
        /// <param name="position">"right"/"left"</param>
        /// <returns>Nodeエレメント</returns>
        public XElement CreateNode(string name, string position = "")
        {
            this.name = name;

            // 日時から情報を生成
            System.DateTime dt = System.DateTime.Now;
            this.created = String.Format("{0:yyMMddHHmmssf", dt);
            this.id = String.Format("ID_{0:yyMMddHHmmssf", dt);
            this.modified = created;

            XElement elm = new XElement("node");
            // TODO: ユニーク値を何かしらで管理すべき？
            Dictionary<string, string> attr = new Dictionary<string, string>()
            {
                { "CREATED", this.created },
                { "ID", this.id },
                { "MODIFIED", this.modified },
                { "TEXT", this.name }
            };

            if ( position == "" )
            {
                attr.Add("POSITION", position);
            }
            this.AddAttr(attr, elm);

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
        /// 子要素の追加
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool AddChild(Node node)
        {
            this.Childs.Add(node);
            return true;
        }

        /// <summary>
        /// TODO: 子要素の削除
        /// </summary>
        /// <returns></returns>
        public bool DeleteChild()
        {
            return true;
        }

        /// <summary>
        /// 子要素をログに出力
        /// </summary>
        public void ShowChild()
        {
            StringBuilder sb = new StringBuilder(this.element.ToString());
            foreach ( Node node in this.Childs )
            {
                sb.AppendFormat("\r\n  {0}", node.element.ToString());
            }
            this.logger.Log(sb.ToString());
        }
    }
}
