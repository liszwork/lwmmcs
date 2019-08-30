using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mmCreaterCs
{
    class FileManager
    {
        /*
         * TOOD: ファイル未オープン時はファイル選択ダイアログで選択させる。\nそうでない場合、このファイル名を使用する。
         */
        private static string targetFilePath = "";

        /// <summary>
        /// 【回帰】NodeからXML要素を生成
        /// </summary>
        /// <param name="node">参照するNode</param>
        /// <param name="elm">登録先XML要素(root=null)</param>
        /// <returns>XML化したNode郡</returns>
        private static XElement CollectNode(Node node, XElement elm = null)
        {
            // nodeの情報出力
            XElement e = node.Element;
            // 子要素ループ→子要素を回帰で渡す
            foreach ( Node child in node.Childs )
            {
                CollectNode(child, e);
            }
            
            if ( elm == null )
            {
                elm = e;
            }
            else
            {
                elm.Add(e);
            }

            return elm;
        }

        /// <summary>
        /// ファイル保存
        /// </summary>
        /// <param name="root">Root Node</param>
        /// <param name="overwrite">上書き保存</param>
        /// <returns></returns>
        public static bool Save(Node root, bool overwrite = true)
        {
            if ( !GetOpenFileName(overwrite) )
            {
                return false;   // 選択不正
            }

            // root
            XElement rootElm = CollectNode(root);
            // FreeMind上、1番外枠の要素(map)作成し、root追加
            XElement map = new XElement(Node.keyMap);
            map.SetAttributeValue("version", "1.0.1");
            map.Add(rootElm);
            // XMLに作成したNodeのXML要素を追加
            XDocument xml = new XDocument(map);
            // 保存
            xml.Save(targetFilePath);
            // 先頭行(XMLヘッダ)を削除して保存しなおす
            List<string> lines = System.IO.File.ReadAllLines(targetFilePath).ToList();
            lines.RemoveAt(0);
            System.IO.File.WriteAllLines(targetFilePath, lines);

            return true;
        }

        /// <summary>
        /// XElementから指定の属性値を取得
        /// </summary>
        /// <param name="element">対象XElement</param>
        /// <param name="attrName">取得する属性名</param>
        /// <returns>属性の値(存在しない場合、null)</returns>
        private static string GetAttr(XElement element, string attrName)
        {
            XAttribute attr = element.Attribute(attrName);
            return (attr != null) ? attr.Value : "";
        }

        /// <summary>
        /// 【回帰】ファイルから読み込んだXElement配列からNode階層構造を生成
        /// </summary>
        /// <param name="elements">XElement配列</param>
        /// <param name="parentNode">親要素(root=null)</param>
        /// <returns>親要素(回帰にてroot要素)を返す。\nelementsが空の場合、nullとなる。</returns>
        private static Node CreateNodeTree(IEnumerable<XElement> elements, Node parentNode = null)
        {
            Node parent = parentNode;
            Node node = null;
            foreach ( XElement element in elements )
            {
                // 自身の分を生成
                string name = element.Attribute(Node.attrKeyText).Value;
                // 各Attr設定
                string created = GetAttr(element, Node.attrKeyCreated);
                string id = GetAttr(element, Node.attrKeyId);
                string modified = GetAttr(element, Node.attrKeyModified);
                string position = GetAttr(element, Node.attrKeyPosition);

                node = new Node(name, created, id, modified, position, parent);
                // 子要素に続く
                CreateNodeTree(element.Elements(Node.keyNode), node);
                // 親に登録
                if ( parent != null )
                {
                    parent.AddChild(node);
                }
                else
                {
                    // root時は自分を親に設定
                    parent = node;
                }
            }

            return parent;
        }

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <returns>読込結果から生成したNodeManager</returns>
        public static NodeManager Load()
        {
            string path = SelectOpenFile();

            // ファイル読み込みしてNodeへ反映
            XDocument xml = XDocument.Load(path);
            XElement map = xml.Element(Node.keyMap);
            IEnumerable<XElement> rootElements = map.Elements(Node.keyNode);
            Node root = CreateNodeTree(rootElements);
            NodeManager manager = new NodeManager(root);

            return manager;
        }

        // ファイルパスの取得
        private static string SelectOpenFile()
        {
            // TODO: ファイル選択処理の作成
            return @".\test.mm";
        }

        /// <summary>
        /// ファイル名取得
        /// </summary>
        /// <param name="overwrite">上書き保存</param>
        /// <returns>取得成功？</returns>
        private static bool GetOpenFileName(bool overwrite = true)
        {
            if ( !overwrite )
            {
                targetFilePath = SelectOpenFile();
            }
            if ( targetFilePath == "" )
            {
                targetFilePath = SelectOpenFile();
            }

            return (targetFilePath != "");
        }
    }
}
