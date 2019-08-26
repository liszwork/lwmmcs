using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mmCreaterCs
{
    class NodeManager
    {
        private Node root;
        private Node current;

        internal Node Root { get => this.root; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="rootText">ルートのテキスト</param>
        public NodeManager(string rootText)
        {
            root = new Node(rootText);
            current = root;
        }

        /// <summary>
        /// Node構成を作成済みのものを直接セット
        /// </summary>
        /// <param name="node"></param>
        public NodeManager(Node node)
        {
            root = node;
            current = node;
        }

        /// <summary>
        /// Nodeの追加
        /// </summary>
        /// <param name="text">追加するNodeのテキスト</param>
        /// <returns></returns>
        public bool Add(string text)
        {
            if ( text == "" )
            {
                return false;
            }

            string position = "";
            if ( current.Parent == this.root )
            {
                // TODO: 現在位置が右固定
                position = "right";
            }
            Node node = new Node(text, position, current);
            current.AddChild(node);

            Console.WriteLine("==============");
            root.ShowChild();
            Console.WriteLine("----");
            current.ShowChild();

            return true;
        }

        /// <summary>
        /// rootの子要素を取得
        /// </summary>
        /// <returns>子要素の名称リスト</returns>
        public List<string> GetRootChildNames()
        {
            List<string> names = new List<string>();
            foreach ( Node item in root.Childs )
            {
                names.Add(item.Name);
            }
            return names;
        }

        /// <summary>
        /// カレントの子要素を取得
        /// </summary>
        /// <returns>子要素の名称リスト</returns>
        public List<string> GetCurrentChildNames()
        {
            List<string> names = new List<string>();
            foreach ( Node item in current.Childs )
            {
                names.Add(item.Name);
            }
            return names;
        }

        /// <summary>
        /// 対象名称の要素をカレントにセット
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SetCurrentNode4Name(string name)
        {
            if ( name == "" )
            {
                return false;
            }

            foreach ( Node node in current.Childs )
            {
                if ( node.Name == name )
                {
                    current = node;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Node表示情報の取得
        /// </summary>
        /// <param name="indentLevel"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetNodeInfoText(int indentLevel, Node node)
        {
            int level = indentLevel;
            StringBuilder retStringBuilder = new StringBuilder();
            // 自分
            for ( int i = 0; i < level; i++ )
            {
                retStringBuilder.Append("-");
            }
            retStringBuilder.AppendLine(node.Name);
            retStringBuilder.Append("\n");
            level++;
            // 自分の子供
            foreach ( Node childNode in node.Childs )
            {
                retStringBuilder.Append(GetNodeInfoText(level, childNode));
                retStringBuilder.Append("\n");
            }
            return retStringBuilder.ToString();
        }

        /// <summary>
        /// 全Nodeの表示情報を取得
        /// </summary>
        /// <returns></returns>
        public string ShowAll()
        {
            StringBuilder retStringBuilder = new StringBuilder();
            return GetNodeInfoText(0, root);
        }

        /// <summary>
        /// カレントNodeの名称取得
        /// </summary>
        /// <returns></returns>
        public string GetCurrentName()
        {
            return current.Name;
        }

        /// <summary>
        /// カレントの親を選択し、名称を返す。
        /// rootの場合、""を返す。
        /// </summary>
        /// <returns>親Node名</returns>
        public string PrevNode()
        {
            if ( this.current.Parent == null )
            {
                return "";
            }
            this.current = this.current.Parent;
            string name = this.current.Name;
            return (name == null) ? "" : name;
        }
    }
}
