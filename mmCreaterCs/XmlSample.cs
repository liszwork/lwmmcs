using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mmCreaterCs
{
    class XmlSample
    {
        public XmlSample()
        {
            XDocument xml = XDocument.Load(@"C:\tmp\test.xml"); // fopen/close不要
            XElement table = xml.Element("価格表");
            var rows = table.Elements("データ");
            foreach ( XElement row in rows )
            {
                string jp = "";
                string en = "";

                // 商品名
                foreach ( var item in row.Elements("商品") )
                {
                    // 属性ごとに名称をセット
                    XAttribute attr = item.Attribute("言語");
                    switch ( attr.Value )
                    {
                    case "日本語":
                        jp = item.Value;
                        break;
                    case "英語":
                        en = item.Value;
                        break;
                    default:
                        break;
                    }
                }
                // 単価
                XElement rate = row.Element("単価");
                string price = rate.Value;

                // 出力
                Console.WriteLine("[jp/en]" + jp + "/" + en + ", rate: " + price);
            }
        }

        public load()
        {

        }
    }
}
