using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent startEvent;

    private float timeCheck = 300f;

    public float TimeCheck
    {
        get { return timeCheck; }
        set
        {
            if (value < 0)
                timeCheck = 0f;
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
    }

    public void ChangeGameState(GameStates newGameState)
    {
        state = newGameState;
    }


}