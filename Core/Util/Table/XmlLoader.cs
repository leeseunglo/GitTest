using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core.Util.Table
{
    public class XmlLoader
    {
        public static void Create<T>(string fileName, T xmlData)
        {
            FileHelper.CreateDirectory(fileName);
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
                File.Delete(fileName);

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                bf.Serialize(fs, xmlData);
                fs.Close();
            }
        }

        public static T Load<T>(string fileName) where T : class
        {
            FileHelper.CreateDirectory(fileName);
            FileInfo info = new FileInfo(fileName);
            if (false == info.Exists)
                return null;

            T data = null;
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                data = (T)bf.Deserialize(fs);
                fs.Close();
            }

            return data;
        }
    }
}
