using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Linq;


namespace mmCreaterCs
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            testNode();



            Application.Run(new Form1());
        }

        static void testNode()
        {
            testCreateXML();
            testCreateXML2();
            testCreateXML3();
        }

        static void testCreateXML()
        {
            /*-----
             <?xml version="1.0" encoding="utf-8"?>
             <Node>
               <Item1 />
               <Item2 />
             </Node>
             -----*/
            XDocument x = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XElement("Root",
                    new XElement("Item1"),
                    new XElement("Item2")
                    )
                );
            x.Save(@".\dat\test.xml");
        }
        static void testCreateXML2()
        {
            string path = @".\dat\test2.xml";

            /*-----
             -----*/
            XElement root = new XElement("Root");
            XElement iA = new XElement("ItemB");
            XElement iB = new XElement("ItemB");

            root.Add(iA, iB);

            XElement map = new XElement("map");
            XAttribute mapAttr = new XAttribute("version", "1.0.1");
            //map.Attribute = mapAttr;
            map.SetAttributeValue("version", "1.0.1");
            map.Add(root);

            XDocument x = new XDocument(map);
            x.Save(path);

            // 先頭行(XMLヘッダ)を削除して保存
            List<string> lines = System.IO.File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            System.IO.File.WriteAllLines(path, lines);
        }
        static void testCreateXML3()
        {
            Node root = new Node("root");
            Node item1 = new Node("item1");
            Node item2 = new Node("item2");
            root.AddChild(item1);
            root.AddChild(item2);

            root.ShowChild();
        }
    }
}
