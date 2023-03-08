using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Levels;

namespace Saving
{
    public static class SaveSystem
    {
        public static void CreateDataFile(LoadManager loadManager)
        {
            string path = Application.persistentDataPath + "/data.b";

            if (!File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                path = Application.persistentDataPath + "/data.b";
                FileStream stream = new FileStream(path, FileMode.Create);
                
                Data data = new Data(loadManager);
                
                data.isFirstStart = true;
            
                binaryFormatter.Serialize(stream, data);
                
                Debug.Log("Saved path: " + path);
                Debug.Log("Create DataFile!");
                
                Debug.Log("isFirstStart: " + data.isFirstStart);
                
                stream.Close();
            }
            else
            {
                Debug.Log("DataFile has already create!");
                LoadData();
            }
        }
        
        public static void SaveData(LevelManager levelManager)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/data.b";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            Data data = new Data(levelManager);
            
            binaryFormatter.Serialize(stream, data);
            Debug.Log("Saved path: " + path);
            stream.Close();
        }
        
        public static Data LoadData()
        {
            string path = Application.persistentDataPath + "/data.b";

            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                Data data = binaryFormatter.Deserialize(stream) as Data;
                
                Debug.Log("Load path: " + path);
                Debug.Log(data.numberSaveLevel);
                
                stream.Close();

                return data;
            }
            
            throw new Exception("Error! File does not exist! File does not found in" + path);
        }
    }
}
