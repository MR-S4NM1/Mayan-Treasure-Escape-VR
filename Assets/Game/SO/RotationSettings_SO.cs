using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Mr_Sanmi.PuzzleVRGame
{
    #region Enums

    #endregion

    #region Structs

    [System.Serializable] //Convertion to bytes which can be saved in the HDD.
    public struct RotationSettings
    {
        [SerializeField] public bool _continousTurnBool;
        [SerializeField] public bool _snapTurnBool;
    }

    #endregion

    [CreateAssetMenu(fileName = "VR_Settings_SO", menuName = "Scriptable Objects/VR_Settings_SO")] 
    public class RotationSettings_SO : ScriptableObject
    {
        [SerializeField] public RotationSettings rotationSettings;
    }
}