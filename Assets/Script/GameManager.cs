using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent startEvent;
    public UnityEvent deathEvent;
    public UnityEvent winEvent;

    private float originalTimeCheck = 120f;
    private float timeCheck = 120f;

    public float TimeCheck
    {
        get { return timeCheck; }
        set
        {
            if (value < 0)
                timeCheck = 0f;
            else
                timeCheck = value;
        }
    }
    public enum GameStates
    {
        Menu,
        GameStart,
        GameEnd,
        GameWin
    }

    public GameStates state = GameStates.Menu;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        originalTimeCheck = timeCheck;
    }

    private void Update()
    {
        switch(state)
        {
            case GameStates.Menu:
                TimeCheck = originalTimeCheck;
                break;
            case GameStates.GameStart:
                SubstractTime();
                if (TimeCheck <= 0f)
                    state = GameStates.GameWin;
                break;
            case GameStates.GameEnd:
                deathEvent.Invoke();
                break;
            case GameStates.GameWin:
                winEvent.Invoke();
                break;
        }
    }

    public void SubstractTime()
    {
        TimeCheck -= Time.deltaTime;
    }

    public void ChangeGameState()
    {
        state = GameStates.GameStart;
        startEvent.Invoke();
    }



}
