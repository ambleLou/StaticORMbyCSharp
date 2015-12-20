using System;

using System.Xml;
using System.IO;
using tempLog;

namespace xmlReader
{
    public class XMLReader
    {
        //read the xml for usual check
        public XmlDocument OpenXMlFile(string path) {
            XmlDocument document = new XmlDocument();
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                ErrLog.ErrLogToFile("xml path is empty or not exit!");
                Environment.Exit(0);
            }
            try
            {
                document.Load(path);
            }
            catch
            {
                ErrLog.ErrLogToFile(string.Format("can't open xml! Document path:{0}", path));
                Environment.Exit(0);
            }
            return document;
        }
    }
}
