using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void Update()
    {
        Debug.Log(playerName);
    }

    #region FirstTime

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
