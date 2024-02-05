using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    public void SaveData()
    {
        SaveItemsEquiped saveItemsEquiped = new SaveItemsEquiped();
        SavePlayerData savePlayerData = new SavePlayerData();
        string Json = JsonUtility.ToJson(savePlayerData);
    }

    #region TextManager

    public static void SaveSaveString(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + "save.txt", saveString);
    }

    public static string LoadSaveString()
    {
        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save.txt");
            return saveString;
        }
        else
        {
            Debug.LogWarning("No save");
            return null;
        }    
    }

    public static void CreateDirectory()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    #endregion
}

#region Class

public class SavePlayerData {
    public string name = "Fred";
    public int coins = 0;
    public SaveItemsEquiped PlayerItems = null;
}

public class SaveItemsEquiped
{
    public int Item1;
    public int Item2;
    public int Item3;
}


public class SaveUnlockable { 
    public int ID;
}

public class SaveMinigame
{
    public int ID;
    public bool isDone;
    public int MaxPoints;
}

public class SaveData
{
    public SavePlayerData SavePlayerData = new SavePlayerData();
    public SaveMinigame[] SaveMinigame = new SaveMinigame[8];
    public SaveUnlockable[] SaveUnlockable;
}

#endregion
