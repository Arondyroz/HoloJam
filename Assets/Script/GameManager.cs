using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent startEvent;

    private float timeCheck = 300f;

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
        GamePause,
        GameEnd
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

    private void Update()
    {
        switch(state)
        {
            case GameStates.Menu:
                break;
            case GameStates.GameStart:
                SubstractTime();
                startEvent.Invoke();
                break;
            case GameStates.GamePause:
                break;
            case GameStates.GameEnd:
                break;
        }
    }

    public void SubstractTime()
    {
        TimeCheck -= Time.deltaTime;
        if (TimeCheck <= 280)
            Debug.Log("I am here");

        if (timeCheck <= 200)
            Debug.Log("200s");

        if (timeCheck <= 150)
            Debug.Log("150");

        if (timeCheck <= 50)
            Debug.Log("50");

        if (timeCheck <= 0)
            Debug.Log("0");
    }

    public void ChangeGameState()
    {
        state = GameStates.GameStart;
    }


}
