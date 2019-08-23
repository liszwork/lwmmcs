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
        /// 保存
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
            XElement map = new XElement("map");
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

        // 保存先ファイルパスの取得
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
