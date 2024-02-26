using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class MinigameParent : MonoBehaviour
{
    public bool IsDeveloping;

    public Action OnGameStartEvent;

    [Header("Minigame Scriptable Object")]
    [SerializeField] protected MinigamesScriptableObjectScript MinigameData;
    [SerializeField] private Animator _uiAnimator;

    [Header("StartGameMinigame")]
    [SerializeField] private bool isCountdown;
    [SerializeField] private TMP_Text _TextCanvas;
    private Coroutine _Coroutine;

    [HideInInspector] public int Score;
    public UnityEvent<int> OnScoreUpdate;
    private bool anyKeyIsPressed = false;

    [HideInInspector] public bool gameIsActive = false;

    private void Awake()
    {
        _TextCanvas.gameObject.transform.parent.gameObject.SetActive(false);
        if (!IsDeveloping)
        {
            MySceneManager.Instance.OnLoadFinish += StartCountdown;
        }

        personalAwake();
    }

    private void Start()
    {
        // El timer debe llamarlo la pantalla de carga
        GameManager.Instance.isPlaying = true;

        personalStart();

        // Quitar ANTES DEL BUILD
        UpdateScore();
        if (IsDeveloping)
        {
            StartCountdown();
        }
    }

    private void OnDestroy()
    {
        if (IsDeveloping) return;
        if (MySceneManager.Instance.OnLoadFinish != null && !gameIsActive)
            MySceneManager.Instance.OnLoadFinish -= StartCountdown;
    }

    private void StartCountdown()
    {
        if (isCountdown)
        {
            Timer(3);
        }
        else
        {
            Timer(0);
        }

        if (IsDeveloping) return;

        if (MySceneManager.Instance.OnLoadFinish != null)
            MySceneManager.Instance.OnLoadFinish -= StartCountdown;
    }

    private void Timer(int value)
    {
        _TextCanvas.gameObject.transform.parent.gameObject.SetActive(true);
        if (_Coroutine != null)
        {
            StopCoroutine(_Coroutine);
        }
        StartCoroutine(TimerCorutine(value));
    }
    private IEnumerator TimerCorutine(int value)
    {
        _TextCanvas.gameObject.transform.parent.gameObject.SetActive(true);
        if (value != 0)
        {
            string text = "Time trial!";
            _TextCanvas.text = text;


            yield return new WaitForSeconds(1);
            while (true)
            {
                if (value == 0)
                {
                    text = "Go!";
                }
                else
                {
                    text = value.ToString();
                }

                _TextCanvas.text = text;
                // Hacer animacion

                yield return new WaitForSeconds(1);

                value--;
                if (value == -1)
                    break;
            }
        }
        else
        {
            string text = "Go!";
            _TextCanvas.text = text;


            yield return new WaitForSeconds(1);
        }
        _TextCanvas.gameObject.transform.parent.gameObject.SetActive(false);
        gameIsActive = true;
        OnGameStart();

        if (OnGameStartEvent != null)
            OnGameStartEvent();
    }

    protected virtual void personalAwake()
    {

    }

    protected virtual void personalStart()
    {

    }

    protected virtual void OnGameStart()
    {

    }

    public virtual void OnGameFinish()
    {
        gameIsActive = false;
        Debug.Log("Finished");
        try
        {
            MinigameData.FinishCheckScore(Score);
        }
        catch (Exception e)
        {
            Debug.LogWarning("No se ha podido guardar, probablemente te falta el SaveManager");
        }
        _Coroutine = StartCoroutine(CoroutineOnGameFinish());
    }

    IEnumerator CoroutineOnGameFinish()
    {
        _TextCanvas.text = "Times Over";
        _TextCanvas.gameObject.transform.parent.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        InputManager.Instance.anyKeyEvent.AddListener(SetPressedButton);

        _TextCanvas.text = "Press A to continue";
        while (true)
        {
            if (anyKeyIsPressed)
                break;

            yield return null;
        }
        InputManager.Instance.anyKeyEvent.RemoveListener(SetPressedButton);
        anyKeyIsPressed = false;

        MySceneManager.Instance.NextScene(2, 1, 1, 0);
        // SceneManager hara cosas
    }

    public void SetPressedButton()
    {
        anyKeyIsPressed = true;
    }

    #region Score

    public void AddScore(int value)
    {
        Score = Score + value;
        UpdateScore();
    }

    public void RemoveScore(int value)
    {
        Score = Score - value;
        Score = Mathf.Clamp(Score, 0, 999999);
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (OnScoreUpdate != null)
            OnScoreUpdate.Invoke(Score);
    }

    #endregion
}
