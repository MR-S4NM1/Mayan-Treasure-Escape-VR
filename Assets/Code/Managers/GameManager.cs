using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GeneralGameStates
{
    NONE,
    GAME,
    PAUSE,
    VICTORY,
    GAME_OVER
}

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Author: Miguel Angel Garcia Elizalde and Oscar Francisco Vazquez Guerra
    /// Date: 05/01/2025
    /// Brief: Game Manager that controls every state that the game will have.
    /// </summary>
    [SerializeField] public static GameManager instance;

    [Header("Finite States Machine")]
    [SerializeField] protected GeneralGameStates _state;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    protected void ChangeState(GeneralGameStates p_state)
    {
        if (_state == p_state) return;

        switch (p_state)
        {
            case GeneralGameStates.NONE:
                break;
            case GeneralGameStates.GAME:
                break;
            case GeneralGameStates.PAUSE:
                break;
            case GeneralGameStates.VICTORY:
                break;
            case GeneralGameStates.GAME_OVER:
                break;
        }
    }

    public void PauseOrResumeGame(bool p_pauseBool)
    {
        if (p_pauseBool)
        {
            _state = GeneralGameStates.PAUSE;
            Time.timeScale = 0.0f;
        }
        else
        {
            _state = GeneralGameStates.GAME;
            Time.timeScale = 1.0f;
        }
    }
}
