using Mr_Sanmi.PuzzleVRGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCode : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public RotationSettings_SO rotationSettingSO; 

    [SerializeField] protected ActionBasedContinuousTurnProvider _continousTurnProvider;
    [SerializeField] protected ActionBasedSnapTurnProvider _snapTurnProvider;

    [SerializeField] protected InputActionProperty actionPropertyRight;
    [SerializeField] protected InputActionProperty actionPropertyLeft;

    [SerializeField] protected GameObject rightRay;
    [SerializeField] protected GameObject leftRay;

    [SerializeField] protected GameObject _XROrigin;

    protected Transform CheckPointPosition;

    #region UnityMethods

    private void OnDrawGizmos()
    {
        if (_continousTurnProvider == null)
        {
            _continousTurnProvider = GetComponent<ActionBasedContinuousTurnProvider>();
        }

        if (_snapTurnProvider == null)
        {
            _snapTurnProvider = GetComponent<ActionBasedSnapTurnProvider>();
        }
    }

    private void OnEnable()
    {
        _continousTurnProvider.enabled = rotationSettingSO.rotationSettings._continousTurnBool;
        _snapTurnProvider.enabled = rotationSettingSO.rotationSettings._snapTurnBool; 
    }

    private void Update()
    {
        rightRay.SetActive(actionPropertyRight.action.ReadValue<float>() > 0.1f);
        leftRay.SetActive(actionPropertyLeft.action.ReadValue<float>() > 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reset"))
        {
            Debug.Log($"Reset! You hit: {other.gameObject.name}");
            GameManager.instance.ResetLevel();
            
        }

        
    }

    #endregion

    #region PublicMethods

    public void ReadRotationSettings(bool p_snap, bool p_continous)
    {
        _continousTurnProvider.enabled = p_continous; 
        _snapTurnProvider.enabled = p_snap;
    }

    #endregion
}
