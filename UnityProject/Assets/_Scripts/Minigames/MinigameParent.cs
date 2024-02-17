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
    public Action OnGameStartEvent;

    [Header("Minigame Scriptable Object")]
    [SerializeField] protected MinigamesScriptableObjectScript MinigameData;
    [SerializeField] private Animator _uiAnimator;

    [Header("StartGameMinigame")]
    [SerializeField] private bool isCountdown;
    [SerializeField] private GameObject _startTimerCanvas;
    [SerializeField] private TMP_Text _textStartTimer;
    private Coroutine _timerCoroutine;

    [HideInInspector] public int Score;
    public UnityEvent<int> OnScoreUpdate;

    [HideInInspector] public bool gameIsActive = false;

    private void Awake()
    {
        _startTimerCanvas.SetActive(false);
        // MySceneManager.Instance.OnLoadFinish += StartCountdown;
        personalAwake();
    }

    private void Start()
    {
        // El timer debe llamarlo la pantalla de carga

        personalStart();

        // Quitar ANTES DEL BUILD
        UpdateScore();
        StartCountdown();
    }

    private void OnDestroy()
    {
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

        if(MySceneManager.Instance.OnLoadFinish != null)
            MySceneManager.Instance.OnLoadFinish -= StartCountdown;
    }

    private void Timer(int value)
    {
        _startTimerCanvas.SetActive(true);
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }
        StartCoroutine(TimerCorutine(value));
    }
    private IEnumerator TimerCorutine(int value)
    {
        _startTimerCanvas.SetActive(true);
        if (value != 0)
        {
            string text = "Time trial!";
            _textStartTimer.text = text;


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

                _textStartTimer.text = text;
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
            _textStartTimer.text = text;


            yield return new WaitForSeconds(1);
        }
        _startTimerCanvas.SetActive(false);
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

    #region Score

    public void AddScore(int value)
    {
        Score = Score + value;
        UpdateScore();
    }

    public void RemoveScore(int value)
    {
        Score = Score - value;
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (OnScoreUpdate != null)
            OnScoreUpdate.Invoke(Score);
    }

    #endregion
}
