using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Variables condicionales
    public bool isDialogueActive {private set; get; }

    // Variables del jugador
    public string playerName = "Fred";
    public int playerCoins = 0;

    // GamesUnlocked
    //public Dictionary<int, Scriptable> minigamesScriptableDictionary; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Debug.Log(playerName);
    }

    #region Setting Variables

    public void SetisDialogueActive(bool value)
    {
        isDialogueActive = value;
    }
    #endregion
}
