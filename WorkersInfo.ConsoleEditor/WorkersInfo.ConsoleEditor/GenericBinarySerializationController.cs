using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace WorkersInfo.ConsoleEditor
{
    public class GenericBinarySerializationController<T> where T : class
    {

        public T Load(string fileName)
        {
            if (!File.Exists(fileName))
                return null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            using (FileStream fSteam = File.OpenRead(fileName))
            {
                return (T)bFormatter.Deserialize(fSteam);
            }
        }

        public void Save(T data, string fileName)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            using (var fStream = File.OpenWrite(fileName))
            {
                bFormatter.Serialize(fStream, data);
            }
        }
    }
}