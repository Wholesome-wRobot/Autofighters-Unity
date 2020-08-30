using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AutoFighters
{
    public static class SaveSystem
    {
        public static void SaveController(object data, string fileName)
        {
            // Set the controller file location
            string destination = Consts.PersistentDataPath + "/" + fileName + ".dat";
            Debug.Log($"Saving to {destination}");

            // Create/overwrite the file if it already exists
            FileStream stream;
            if (File.Exists(destination)) stream = File.OpenWrite(destination);
            else stream = File.Create(destination);

            // Write in the file
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, data);

            File.WriteAllText(Application.persistentDataPath + "/" + fileName + ".txt", JsonUtility.ToJson(data));
            stream.Close();
        }

        public static object GetControllerDataFromFile(string controllerName)
        {
            // Set the saved controller location
            string destination = Consts.PersistentDataPath + "/" + controllerName + ".dat";
            Debug.Log($"Loading {destination}");
            FileStream stream;

            // Check if file exists
            if (File.Exists(destination))
                stream = File.OpenRead(destination);
            else
            {
                Debug.LogError("Save File not found in " + destination);
                return null;
            }

            // Read the file
            BinaryFormatter bf = new BinaryFormatter();
            object data = bf.Deserialize(stream);
            stream.Close();

            return data;
        }
    }
}