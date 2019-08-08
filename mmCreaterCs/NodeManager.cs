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

            Node node = new Node(text);
            current.AddChild(node);

            Console.WriteLine("==============");
            root.ShowChild();
            Console.WriteLine("----");
            current.ShowChild();

            return true;
        }

        public List<string> GetChildNames()
        {
            List<string> names = new List<string>();
            foreach ( Node item in root.Childs )
            {
                names.Add(item.Name);
            }
            return names;
        }

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

        // TODO: 表示文言の作成うまくいってない
        private string ChildText(int indentLevel, Node node)
        {
            int level = indentLevel;
            StringBuilder retStringBuilder = new StringBuilder();
            // 自分
            for ( int i = 0; i < level; i++ )
            {
                retStringBuilder.Append("-");
            }
            retStringBuilder.AppendLine(node.Name);
            level++;
            // 自分の子供
            foreach ( Node childNode in node.Childs )
            {
                retStringBuilder.AppendLine(ChildText(level, childNode));
            }
            return retStringBuilder.ToString();
        }

        public string ShowAll()
        {
            StringBuilder retStringBuilder = new StringBuilder();
            return ChildText(0, root);
        }
    }
}
