using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Variables condicionales
    public bool isDialogueActive {private set; get; }
    [SerializeField] public MinigamesScriptableObjectScript[] MinigameScripts;

    // Variables del jugador
    [HideInInspector] public string playerName = "Fred";
    [HideInInspector] public int playerCoins = 0;

    [HideInInspector] public enum GameState{Aire, Puentes, Reciclaje, Mar, AguaLimpia, GranjaPlantas, GranjaZoo, Pancarta, PostGame}
    [HideInInspector] public GameState state = GameState.Aire;

    // GamesUnlocked
    //public Dictionary<int, Scriptable> minigamesScriptableDictionary; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        FirstTime();
        NextState(8);
    }

    private void Update()
    {
        Debug.Log(state);
    }

    #region CalleableFunctions

    // Intentar no utilizar, por que puede generar muchos conflictos
    public void NextState()
    {
        state++;
        SaveManager.SavePlayerData();
    }

    /* 0 - Aire
     * 1 - Puentes
     * 2 - Reciclajes
     * 3 - Mar
     * 4 - AguaLimpia
     * 5 - GranjaPlantas
     * 6 - GranjaZoo
     * 7 - Pancarta
     * 8 - PostGame
     */
    public void NextState(int value)
    {
        state = (GameState)Mathf.Clamp(value, 0, 8);
        SaveManager.SavePlayerData();
    }

    #endregion

    #region Private Functions

    private void FirstTime()
    {
        if (!SaveManager.IsDirectoryExist())
        {
            SaveManager.ResetGame();
        }
        else
        {
            SaveManager.LoadSaveFileSetUp();
        }
    }

    #endregion

    #region Setting Variables

    public void SetisDialogueActive(bool value)
    {
        isDialogueActive = value;
    }
    #endregion
}
