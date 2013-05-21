using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace PluraLeecher.Helpers
{
    public class SerializerHelper
    {
        private string _rootPath;
        private string RootPath
        {
            get
            {
                if (string.IsNullOrEmpty(_rootPath))
                {
                    _rootPath = ConfigurationManager.AppSettings.Get(Strings.AppConfig.Path);
                }
                return _rootPath;
            }
        }


        public void SerializeToFile(object value)
        {
            FileStream fileStream;
            string fileName = string.Format(@"{0}\{1}", RootPath, "videos.dat");
            using (fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, value);
            }

        }
        public TSerializeItemType DeserializeFromFile<TSerializeItemType>() where TSerializeItemType : class
        {
            string fileName = string.Format(@"{0}\{1}", RootPath, "videos.dat");
            if (!File.Exists(fileName))
            {
                return null;
            }
            TSerializeItemType o;
            FileStream fileStream;
            using (fileStream = new FileStream(fileName, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                o = (TSerializeItemType)binaryFormatter.Deserialize(fileStream);
            }
            return o;
        }
    }
}
