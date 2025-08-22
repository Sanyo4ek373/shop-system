using System.IO;
using UnityEngine;

namespace ShopSystem
{
    public class SaveManager
    {
        private readonly string SaveDirectory = Application.persistentDataPath + "/saves/";

        public void Save<T>(string fileName, T saveData)
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            string jsonData = JsonUtility.ToJson(saveData, true);
            string filePath = SaveDirectory + fileName + ".json";

            File.WriteAllText(filePath, jsonData);
        }

        public T Load<T>(string fileName) where T : new()
        {
            string filePath = SaveDirectory + fileName + ".json";

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonUtility.FromJson<T>(jsonData);
            }
            else
            {
                return new T();
            }
        }

        public void DeleteSave(string fileName)
        {
            string filePath = SaveDirectory + fileName + ".json";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public bool SaveExists(string fileName)
        {
            string filePath = SaveDirectory + fileName + ".json";
            return File.Exists(filePath);
        }
    }
}