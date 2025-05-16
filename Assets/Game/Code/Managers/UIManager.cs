using MayanTreasureEscape.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mr_Sanmi.PuzzleVRGame;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public RotationSettings_SO rotationSettingSO;

    public static UIManager Instance;

    [SerializeField] protected GameObject _generalLobbyPanel;
    [SerializeField] protected GameObject _rotationPanel;

    [SerializeField] protected PlayerCode _playerCode;

    private void Start()
    {
        if (Instance == null) Instance = this;

        _generalLobbyPanel.SetActive(true);
        _rotationPanel.SetActive(false);
    }

    public void ChangeToGameScene()
    {
        SceneChanger.instance.ChangeSceneTo(1);
    }

    public void ActivateRotationPanel()
    {
        Debug.Log("Changing to rotation!");
        _generalLobbyPanel.SetActive(false);
        _rotationPanel.SetActive(true);
    }

    public void ActivateGeneralLobbyPanel()
    {
        _generalLobbyPanel.SetActive(true);
        _rotationPanel.SetActive(false); 
    }

    public void SetContinousRotation()
    {
        rotationSettingSO.rotationSettings._continousTurnBool = true;
        rotationSettingSO.rotationSettings._snapTurnBool = false;

        _playerCode.ReadRotationSettings(rotationSettingSO.rotationSettings._snapTurnBool,
            rotationSettingSO.rotationSettings._continousTurnBool);
    }

    public void SetSnapRotation()
    {
        rotationSettingSO.rotationSettings._continousTurnBool = false;
        rotationSettingSO.rotationSettings._snapTurnBool = true;

        _playerCode.ReadRotationSettings(rotationSettingSO.rotationSettings._snapTurnBool,
            rotationSettingSO.rotationSettings._continousTurnBool); 
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
