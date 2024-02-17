using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    public UnityEvent startEvent;
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
                startEvent.Invoke();
                break;
            case GameStates.GamePause:
                break;
            case GameStates.GameEnd:
                break;
        }
    }
}
