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
    [SerializeField] private float _tiempoMinimo;

    [Header("Panel Tutorial")]
    [SerializeField] private RectTransform panelReference;
    [SerializeField] private Animator _panelAnimator;

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

    public void NextScene(int Value)
    {
        if (LoadCorutine != null)
        {
            StopCoroutine(LoadCorutine);
            LoadCorutine = null;
        }
        LoadCorutine = StartCoroutine(LoadCorutineFunction(Value));
    }

    IEnumerator LoadCorutineFunction(int Value)
    {
        // Ejecuta la animacion de la transicion
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
            loadLevel = SceneManager.LoadSceneAsync(SceneDictionary[Value]);
        }
        else
            Debug.LogError("La escena no existe en el diccionario.");

        // Comprueba cuando ha acabado de cargar la pantalla (se puede poner mas tiempo si es necesario)
        float time = 0;
        while (true)
        {
            if (loadLevel.isDone && time >= _tiempoMinimo)
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

            yield return new WaitForSeconds(5f);

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
        _myanimator.SetTrigger("NextOut");

        // Comprueba si la transicion se ha acabado
        while (true)
        {
            if (_myanimator.GetCurrentAnimatorStateInfo(0).IsName("0"))
            break;


            yield return null;
        }
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
        SceneDictionary.Add(1, "Setting");

        SceneDictionary.Add(10, "SceneManager1");
        SceneDictionary.Add(20, "SceneManager2");
        SceneDictionary.Add(30, "Minijuego3");
        SceneDictionary.Add(40, "Minijuego4");
        SceneDictionary.Add(50, "Minijuego5");


        //SceneDictionary.Add(20, "LevelSelector");
    }


}
