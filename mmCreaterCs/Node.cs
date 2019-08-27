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
        public static readonly string keyMap = "map";
        public static readonly string keyNode = "node";
        public static readonly string attrKeyCreated = "CREATED";
        public static readonly string attrKeyId = "ID";
        public static readonly string attrKeymodified = "MODIFIED";
        public static readonly string attrKeyPosition = "POSITION";
        public static readonly string attrKeyText = "TEXT";

        // Nodeの情報
        private string name = "";
        private string created = "";
        private string id = "";
        // TODO: 内容変更タイミングでその時の日時で更新
        private string modified = "";

        // Nodeのオブジェクト
        private XElement element = null;
        /// <summary>親要素</summary>
        private Node parent = null;
        /// <summary>子要素</summary>
        private List<Node> child = new List<Node>();

        // ロガー
        private Logger logger = new Logger();

        public string Name { get => this.name; set => this.name = value; }
        internal List<Node> Childs { get => this.child; set => this.child = value; }
        public Node Parent { get => this.parent; set => this.parent = value; }
        public XElement Element { get => this.element; }
        public string Id { get => this.id; }

        //public string AttrKeyCreated => this.attrKeyCreated;
        //public string AttrKeyId => this.attrKeyId;
        //public string AttrKeymodified => this.attrKeymodified;
        //public string AttrKeyPosition => this.attrKeyPosition;
        //public string AttrKeyText => this.attrKeyText;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="text">Nodeのテキスト</param>
        /// <param name="position">"right"/"left"</param>
        public Node(string text, string position = "", Node parent = null)
        {
            this.parent = parent;
            this.element = this.CreateNode(text, position);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="text">Nodeのテキスト</param>
        /// <param name="position">"right"/"left"</param>
        public Node(string text, string created, string id, string modified, string position = "", Node parent = null)
        {
            this.parent = parent;
            this.element = this.CreateNode(text, created, id, modified, position);
        }
        
        /// <summary>
        /// 属性値の生成
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetAttrs()
        {
            DateTime dt = DateTime.Now;
            string created = String.Format("{0:yyMMddHHmmssf}", dt);
            string id = String.Format("ID_{0:yyMMddHHmmssf}", dt); ;
            Dictionary<string, string> ids = new Dictionary<string, string>()
            {
                { attrKeyCreated,  created },
                { attrKeyId, id },
                { attrKeymodified, created }
            };
            return ids;
        }

        /// <summary>
        /// POSITION属性を追加するか？
        /// </summary>
        /// <param name="position">設定するPOSITIONの値</param>
        /// <returns>追加するか否か(true=追加する)</returns>
        private bool IsAddPosition(string position)
        {
            if ( position == "" )
            {
                return false;
            }
            // このNodeはroot
            if ( this.parent == null )
            {
                return true;
            }
            // このNodeはbranch-root
            if ( this.parent.parent == null )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Nodeの生成
        /// </summary>
        /// <param name="name">Nodeのテキスト</param>
        /// <param name="position">"right"/"left"</param>
        /// <returns>Nodeエレメント</returns>
        public XElement CreateNode(string name, string created = "", string id = "", string modified = "", string position = "")
        {
            this.name = name;

            // 日時から情報を生成
            Dictionary<string, string> ids = GetAttrs();
            this.created = (created != "") ? created : ids[attrKeyCreated];
            this.id = (id != "") ? id : ids[attrKeyId];
            this.modified = (modified != "") ? modified : ids[attrKeymodified];

            XElement elm = new XElement("node");
            // 必須属性の追加
            Dictionary<string, string> attr = new Dictionary<string, string>()
            {
                { attrKeyCreated, this.created },
                { attrKeyId, this.id },
                { attrKeymodified, this.modified },
                { attrKeyText, this.name }
            };
            // 位置の追加: branch-rootかつPOSITIONあり
            if ( this.IsAddPosition(position) )
            {
                attr.Add(attrKeyPosition, position);
            }
            // XElementに属性を付与
            this.AddAttr(attr, elm);

            return elm;
        }

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
        /// 子要素の削除
        /// </summary>
        /// <param name="id">削除対象のID</param>
        /// <returns>結果</returns>
        public bool DeleteChild(string id)
        {
            this.logger.Log("--DeleteChild--\r\n");
            Node findNode = null;
            foreach ( Node child in this.Childs )
            {
                if ( child.id == id )
                {
                    findNode = child;
                    break;
                }
            }
            if ( findNode == null )
            {
                this.logger.Log("Delete target ID NOT FOUND(" + id + ")\r\n");
                return false;
            }
            
            findNode.ShowMe();
            this.child.Remove(findNode);
            return true;
        }

        public void ShowMe()
        {
            StringBuilder sb = new StringBuilder(this.element.ToString());
            sb.AppendFormat("Text={0}, ID={1} \r\n", this.name, this.id);
            this.logger.Log(sb.ToString());
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
