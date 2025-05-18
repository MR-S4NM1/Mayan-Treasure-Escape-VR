using System;
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

    [Header("Timer")]
    [SerializeField] protected float _timer;
    protected Coroutine _timerCoroutine;

    [Header("BowAndArrowPuzzle")]
    [SerializeField] protected HashSet<GameObject> _totemsDestroyed;
    [SerializeField] protected GameObject _brigde;

    [Header("Doors")]
    [SerializeField] protected GameObject[] _doors;
    [SerializeField] protected GameObject _gate;

    #region UnityMethods
    private void Awake()
    {
        if (instance == null) instance = this;
        _timer = 950.0f;
        _timerCoroutine = StartCoroutine(GameTimer());
        _totemsDestroyed = new HashSet<GameObject>();
        _brigde.SetActive(true);
        _brigde.GetComponent<Rigidbody>().useGravity = false;
    }

    private void Start()
    {

    }

    #endregion

    #region PublicMethods
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

    public void DeleteTotems(GameObject p_totemGO)
    {
        if (!_totemsDestroyed.Contains(p_totemGO))
        {
            _totemsDestroyed.Add(p_totemGO);
            p_totemGO.SetActive(false);
        }

        if (_totemsDestroyed.Count >= 2)
        {
            _brigde.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void OpenDoor(int p_index)
    {
        StartCoroutine(OpenDoorCorroutine(p_index));
    }

    #endregion

    #region LocalMethods

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

    #endregion

    #region Coroutines
    protected IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(5.0f);

        while (_timer > 0.0f)
        {
            //UIManager.instance.UpdateTimer(_timer.ToString());
            yield return new WaitForSeconds(1.0f);
            _timer--;
        }
    }

    #region Coroutines

    protected IEnumerator OpenDoorCorroutine(int p_index)
    {
        Debug.Log($"Index: {p_index}");

        if(p_index == 1)
        {
            _gate.gameObject.SetActive(false);
        }

        _doors[p_index].gameObject.GetComponent<Animator>()?.Play("OpenDoor");

        yield return new WaitForSeconds(2.0f);

        if (_doors[p_index].gameObject.GetComponent<Animator>() != null)
        {
            _doors[p_index].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    #endregion

    #endregion
}
