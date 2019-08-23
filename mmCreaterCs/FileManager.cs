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
        private static string targetFile = "";

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
            if ( elm == null )
            {
                elm = e;
            }
            else
            {
                elm.Add(e);
            }
            // 子要素ループ→子要素を回帰で渡す
            foreach ( Node child in node.Childs )
            {
                CollectNode(child, elm);
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

            //// root

            //// 1番外枠の要素
            XElement map = new XElement("map");
            //map.SetAttributeValue("version", "1.0.1");
            //map.Add(root);

            XDocument xml = new XDocument(map);

            XElement elm = CollectNode(root);

            // TODO: 先頭「map」に保存

            // TODO: 保存

            return true;
        }

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
                targetFile = SelectOpenFile();
            }
            if ( targetFile == "" )
            {
                targetFile = SelectOpenFile();
            }

            return (targetFile != "");
        }
    }
}
