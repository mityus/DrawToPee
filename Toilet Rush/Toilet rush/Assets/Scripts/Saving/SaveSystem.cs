using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Saving
{
    public static class SaveSystem
    {
        public static void SaveData(LevelManager levelManager)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/data.b";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            Data data = new Data(levelManager);
            
            binaryFormatter.Serialize(stream, data);
            stream.Close();
        }
        
         
        public static Data LoadData(){
            string path = Application.persistentDataPath + "/data.b";

            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                Data data = binaryFormatter.Deserialize(stream) as Data;
                stream.Close();

                return data;
            }
            else
            {
                Debug.Log("Error! File does not exist! File does not found in" + path);
                return null;
            }
        }
    }
}
