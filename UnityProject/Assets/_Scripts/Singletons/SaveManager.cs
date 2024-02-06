using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    public static SaveData saveState = new SaveData();
    public static SavePlayerData savePlayerData = new SavePlayerData();

    #region SaveThings

    public static void SavePlayerData()
    {
        SaveItemsEquiped saveItemsEquiped = new SaveItemsEquiped();

        savePlayerData.name = GameManager.Instance.playerName;
        savePlayerData.coins = GameManager.Instance.playerCoins;
        savePlayerData.PlayerItems = saveItemsEquiped;

        saveState.SavePlayerData = savePlayerData;
        saveState.Work = true;

        string Json = JsonUtility.ToJson(saveState);
        SaveSaveString(Json);
    }

    #endregion

    #region LoadThings

    public static void LoadSaveFile()
    {
        try
        {
            saveState = JsonUtility.FromJson<SaveData>(LoadSaveString());
            if (!saveState.Work)
                Debug.LogWarning("No se cargo los datos");

            savePlayerData = saveState.SavePlayerData;
        }
        catch {
            Debug.LogWarning("No se ha conseguido leer el archivo");
        }
    }

    public static void LoadSaveFileSetUp()
    {
        LoadSaveFile();

        GameManager.Instance.playerName = savePlayerData.name;
        GameManager.Instance.playerCoins = savePlayerData.coins;
        // Cargara items equipados

        // Foreach cargando minijuegos completados

        // Foreach cargando coleccionables desbloqueados
    }

    #endregion

    #region TextManager

    public static void SaveSaveString(string saveString)
    {
        if (Application.isEditor)
            return;

        File.WriteAllText(SAVE_FOLDER + "save.txt", saveString + Environment.NewLine + Environment.NewLine + "// PLZ, DO NOT HACK TEH GAME BY MODIFYIN DIS FILE. FINKZ DAT TEH GAME IZ INTENDD 2 BE DEVELOPR WIF TEH GOAL 2 EDUCATE AN NOT 2 BE CHALLENGE. :C");
    }

    public static string LoadSaveString()
    {
        if (Application.isEditor)
        {
            Debug.LogWarning("Se abrio el juego en editor, el save manager no funcionara.");
            return null;
        }

        if (System.IO.File.Exists(SAVE_FOLDER + "save.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save.txt");
            saveString = saveString.Split(Environment.NewLine)[0];

            Debug.Log(saveString);
            return saveString;
        }
        else
        {
            Debug.LogWarning("No save");
            return null;
        }
    }

    public static bool IsDirectoryExist()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            return false;
        }
        return true;
    }

    public static bool IsSaveFileExist()
    {
        if(!System.IO.File.Exists(SAVE_FOLDER + "save.txt"))
        {
            return false;
        }
        return true;
    }

    public static void CreateDirectory()
    {
        if (Application.isEditor)
            return;

        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    #endregion
}

#region Class

[Serializable]
public class SavePlayerData {
    public string name = "Fred";
    public int coins = 0;
    public SaveItemsEquiped PlayerItems = null;
}

[Serializable]
public class SaveItemsEquiped
{
    public int Item1;
    public int Item2;
    public int Item3;
}

[Serializable]
public class SaveUnlockable { 
    public int ID;
}

[Serializable]
public class SaveMinigame
{
    public int ID;
    public bool isDone;
    public int MaxPoints;
}

[Serializable]
public class SaveData
{
    public bool Work = false;
    public SavePlayerData SavePlayerData = new SavePlayerData();
    public SaveMinigame[] SaveMinigame = new SaveMinigame[8];
    public SaveUnlockable[] SaveUnlockable;
}

#endregion