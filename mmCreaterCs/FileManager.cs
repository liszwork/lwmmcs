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

        private static XElement CollectNode(Node node, XElement elm)
        {
            return elm
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="nodes">Nodeリスト</param>
        /// <param name="overwrite">上書き保存</param>
        /// <returns></returns>
        public static bool Save(List<Node> nodes, bool overwrite = true)
        {
            if ( !GetOpenFileName(overwrite) )
            {
                return false;   // 選択不正
            }

            // root

            // 1番外枠の要素
            XElement map = new XElement("map");
            map.SetAttributeValue("version", "1.0.1");
            map.Add(root);

            XDocument xml = new XDocument(map);

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
