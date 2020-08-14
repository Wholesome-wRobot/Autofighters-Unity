using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

namespace AutoFighters
{
    public static class SaveSystem
    {
        public static void SaveController(object data, string fileName)
        {
            // Set the controller file location
            string destination = Consts.ApplicationFolder + "/" + fileName + ".dat";
            Debug.Log($"Saving to {destination}");

            // Create/overwrite the file if it already exists
            FileStream file;
            if (File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);

            // Write in the file
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Close();
        }

        public static object LoadController(string controllerName)
        {
            // Set the saved controller location
            string destination = Consts.ApplicationFolder + "/" + controllerName + ".dat";
            Debug.Log($"Loading {destination}");
            FileStream file;

            // Check if file exists
            if (File.Exists(destination))
                file = File.OpenRead(destination);
            else
            {
                Debug.LogError("Save File not found in " + destination);
                return null;
            }

            // Read the file
            BinaryFormatter bf = new BinaryFormatter();
            object data = bf.Deserialize(file);
            file.Close();

            return data;
        }

        public static void SaveCharacters()
        {
            // Define char folder location
            string charFolder = Application.persistentDataPath + Consts.CharacterFolder;
            Directory.CreateDirectory(charFolder);

            // Delete all previous files
            foreach (string charFile in Directory.GetFiles(charFolder))
                File.Delete(charFile);

            // if list characters empty
            if (MainController.Instance.GetListAllCharacters().Count <= 0)
            {
                Debug.LogError("No character to save");
                return;
            }

            // Save all char files
            foreach (CharacterStats characterStats in MainController.Instance.GetListAllCharacters())
            {
                Debug.Log(JsonUtility.ToJson(characterStats));

                // Save their spells
                foreach (Spell spell in characterStats.SpellSlots)
                {
                    //if (spell != null)
                        //spell.SaveItemToFile(Application.persistentDataPath + Consts.SpellsFolder);
                }
            }
        }

        public static List<CharacterStats> LoadCharacters()
        {
            List<CharacterStats> resultList = new List<CharacterStats>();
            string charFolder = Application.persistentDataPath + Consts.CharacterFolder;

            // Clear list of characters in current controller
            MainController.Instance.ClearCharacterList();

            // Load characters
            foreach (string charFile in Directory.GetFiles(charFolder))
            {
                Debug.Log("Loading file : " + charFile.ToString());

                FileStream file;
                file = File.OpenRead(charFile);
                BinaryFormatter bf = new BinaryFormatter();
                CharacterStats characterStats = (CharacterStats)bf.Deserialize(file);

                resultList.Add(characterStats);

                file.Close();
            }

            // Instantiate the spells to equip

            return resultList;
        }
    }
}