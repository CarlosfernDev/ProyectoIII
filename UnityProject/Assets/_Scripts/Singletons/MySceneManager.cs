using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;

    private Coroutine LoadCorutine;

    [SerializeField] private Animator _myanimator;
    [SerializeField] private List<AnimatorOverrideController> fadeTransition;
    [SerializeField] private float _tiempoMinimo;

    [Header("Panel Tutorial")]
    [SerializeField] private GameObject ingameCanvas;
    [SerializeField] private RectTransform panelReference;
    [SerializeField] private Animator _panelAnimator;

    private bool anyKeyIsPressed = false;

    public bool isLoading;
    public Action OnLoadFinish;
    private Dictionary<int, string> SceneDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        _panelAnimator.gameObject.SetActive(false);

        LearnDictionary();
    }

    public void NextScene(int Value, int fadein, int fadeout, float MinimalTime)
    {
        if (LoadCorutine != null)
        {
            StopCoroutine(LoadCorutine);
            LoadCorutine = null;
        }
        LoadCorutine = StartCoroutine(LoadCorutineFunction(Value, fadein, fadeout, MinimalTime));
    }

    IEnumerator LoadCorutineFunction(int Value, int fadein, int fadeout, float LoadTime)
    {
        isLoading = true;

        if (Value >= 10 && Value < 100)
        {
            ingameCanvas.SetActive(true);
        }
        else
        {
            ingameCanvas.SetActive(false);
        }

        // Ejecuta la animacion de la transicion
        _myanimator.runtimeAnimatorController = fadeTransition[fadein];
        _myanimator.SetTrigger("NextIn");

        // Comprueba cuando acaba la animacion
        while (true)
        {
            if (_myanimator.GetCurrentAnimatorStateInfo(0).IsName("1"))
            break;

            yield return null;
        }

        AsyncOperation loadLevel = null;

        if (SceneDictionary.ContainsKey(Value))
        {
            if(GameManager.Instance != null)
            {
                if (Value <= 9)
                    GameManager.Instance.programState = GameManager.ProgramState.Menu;
                else if (Value >= 10 && Value <= 79)
                    GameManager.Instance.programState = GameManager.ProgramState.Minigame;
                else if (Value >= 100)
                    GameManager.Instance.programState = GameManager.ProgramState.Hub;
            }
            else
            {
                Debug.LogWarning("No hay GameManager");
            }

            loadLevel = SceneManager.LoadSceneAsync(SceneDictionary[Value]);
        }
        else
            Debug.LogError("La escena no existe en el diccionario.");

        // Comprueba cuando ha acabado de cargar la pantalla (se puede poner mas tiempo si es necesario)
        float time = 0;
        while (true)
        {
            if (loadLevel.isDone && time >= LoadTime + _tiempoMinimo)
                break;

            time += Time.deltaTime;
            yield return null;
        }

        if(Value >= 10 && Value < 100)
        {
            _panelAnimator.gameObject.SetActive(true);

            _panelAnimator.SetTrigger("NextIn");

            while (true)
            {
                if (_panelAnimator.GetCurrentAnimatorStateInfo(0).IsName("1"))
                    break;
                yield return null;
            }

            InputManager.Instance.anyKeyEvent.AddListener(SetPressedButton);

            while (true)
            {
                if (anyKeyIsPressed)
                    break;

                yield return null;
            }

            InputManager.Instance.anyKeyEvent.RemoveListener(SetPressedButton);

            anyKeyIsPressed = false;

            _panelAnimator.SetTrigger("NextOut");
            while (true)
            {
                if (_panelAnimator.GetCurrentAnimatorStateInfo(0).IsName("0"))
                    break;
                yield return null;
            }

            _panelAnimator.gameObject.SetActive(false);
        }


        // Ejecuta la siguiente transicion
        _myanimator.runtimeAnimatorController = fadeTransition[fadeout];
        _myanimator.SetTrigger("NextOut");

        // Comprueba si la transicion se ha acabado
        while (true)
        {
            if (_myanimator.GetCurrentAnimatorStateInfo(0).IsName("0"))
            break;


            yield return null;
        }

        if(OnLoadFinish != null)
        {
            OnLoadFinish();
        }

        isLoading = false;
    }

    public void SetPressedButton()
    {
        anyKeyIsPressed = true;
    }

    private void ChargeScene(int Value)
    {
        if (SceneDictionary.ContainsKey(Value))
            SceneManager.LoadScene(SceneDictionary[Value]);
        else
            Debug.LogError("No existe esta entrada en la escena");
    }

    // Aqui es donde se asigna un numero al nombre de la escena, se debe hacer manualmente.
    // Intentaremos dejar del 1-9 para interfaces del menu.
    // Y del 10 al 80 para cada minijuego, donde 10 sera el primero el 20 el segundo...
    // El selector de niveles seran 100 y se le ira sumando uno por cada escena necesaria.
    private void LearnDictionary()
    {
        SceneDictionary = new Dictionary<int, string>();
        SceneDictionary.Add(1, "MainMenu");
        SceneDictionary.Add(2, "TestMainMenu");

        SceneDictionary.Add(10, "ODS2_Scene");
        SceneDictionary.Add(20, "SceneManager2");
        SceneDictionary.Add(30, "ODS7_FRAN");
        SceneDictionary.Add(40, "InputManagerTest");
        SceneDictionary.Add(50, "Minijuego5");


        //SceneDictionary.Add(20, "LevelSelector");
    }


}
