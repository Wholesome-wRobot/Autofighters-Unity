using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void SaveController(object data, string fileName)
    {
        // Set the controller file location
        string destination = Application.persistentDataPath + "/" + fileName + ".dat";
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
        string destination = Application.persistentDataPath + "/" + controllerName + ".dat";
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
        string charFolder = Application.persistentDataPath + "/char";
        Directory.CreateDirectory(charFolder);

        // Delete all previous files
        foreach (string charFile in Directory.GetFiles(charFolder))
            File.Delete(charFile);

        // if list characters empty
        if (MainController.Instance.GetListAllCharacters().Count <= 0)
        {
            Debug.Log("No character to save");
            return;
        }

        // Save all char files
        foreach (CharacterStats characterStats in MainController.Instance.GetListAllCharacters())
        {
            // Save them into a unique file
            string destination = $"{charFolder}/{characterStats.DisplayName}.dat";
            Debug.Log($"Saving character {characterStats.DisplayName} stats to {destination}");
            FileStream file;

            if (File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);
            
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, characterStats);
            file.Close();
        }
    }

    public static List<CharacterStats> LoadCharacters()
    {
        List<CharacterStats> resultList = new List<CharacterStats>();

        // Clear list of characters in current controller
        MainController.Instance.ClearCharacterList();

        // Loop Load all characters from char files
        foreach (string charFile in Directory.GetFiles(Application.persistentDataPath + "/char"))
        {
            Debug.Log("Loading file : " + charFile.ToString());
            
            FileStream file;
            file = File.OpenRead(charFile);
            BinaryFormatter bf = new BinaryFormatter();
            CharacterStats characterStats = (CharacterStats)bf.Deserialize(file);

            resultList.Add(characterStats);

            file.Close();
        }

        return resultList;
    }

}