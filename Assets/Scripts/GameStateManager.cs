using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    
    public delegate bool GameStateChangeDelegate(GameState targetState);
    public event GameStateChangeDelegate OnGameStateChanged; 
    
    public enum GameState
    {
        ready   = 0,
        playing = 1,
        win     = 2,
        lose    = 3
    }

    private GameState currentState;

    public GameState GetCurrentState()
    {
        return currentState;
    }

    public void SetCurrentState(GameState targetState)
    {
        currentState = targetState;

        if (OnGameStateChanged != null)
        {
            OnGameStateChanged.Invoke(currentState);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetCurrentState(GameState.ready);
    }
}
