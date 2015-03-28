using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DirectoryWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\zCoffee";
            DirectoryInfo startDir = new System.IO.DirectoryInfo(path);

            string fileName = "directory.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("root-dir");
                writer.WriteAttributeString("path", path);

                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", startDir.Name);

                traverse(startDir, writer);

                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }

        public static void traverse(DirectoryInfo folder, XmlWriter writer)
        {
            FileInfo[] fileNames = folder.GetFiles("*.*");

            foreach (FileInfo fi in fileNames)
            {
                //Console.WriteLine("{0}: {1}: {2}", fi.Name, fi.LastAccessTime, fi.Length);
                writer.WriteElementString("file", fi.Name);
            }

            DirectoryInfo[] dirInfos = folder.GetDirectories("*.*");

            foreach (DirectoryInfo d in dirInfos)
            {
                //Console.WriteLine(d.Name);
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", d.Name);
                traverse(d, writer);
                writer.WriteEndElement();
            }
        }
    }
}
