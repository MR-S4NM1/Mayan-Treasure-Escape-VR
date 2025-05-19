using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ManagerPuente : MonoBehaviour
{
    [SerializeField] protected XRLever _palanca;
    [SerializeField] protected XRKnob _wheelX;
    [SerializeField] protected XRKnob _wheelY;
    [SerializeField] protected GameObject[] _puentes;
    [SerializeField] protected Transform[] _referencias;
    
    private bool _leverActivation;
    protected float _wheelPosX, _lastWheelPosX1, _lastWheelPosX2;
    protected float _wheelPosY, _lastWheelPosY1, _lastWheelPosY2;
    void Start()
    {
        _leverActivation = true;
    }
    private void OnEnable()
    {
        _palanca.onLeverActivate.AddListener(ActiveLever);
        _palanca.onLeverDeactivate.AddListener(DeactivationLever);
        _wheelX.onValueChange.AddListener(ValueWheelX);
        _wheelY.onValueChange.AddListener(ValueWheelY);
    }

    private void OnDisable()
    {
        _palanca.onLeverActivate.RemoveListener(ActiveLever);
        _palanca.onLeverDeactivate.RemoveListener(DeactivationLever);
        _wheelX.onValueChange.RemoveListener(ValueWheelX);
        _wheelY.onValueChange.RemoveListener(ValueWheelY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_leverActivation)
        {

            _puentes[0].transform.position = new Vector3(_referencias[0].position.x + _wheelPosX,
                _referencias[0].position.y + _wheelPosY, _referencias[0].position.z );
        }
        else
        {
            _puentes[1].transform.position = new Vector3(_referencias[1].position.x + _wheelPosX,
                _referencias[1].position.y + _wheelPosY, _referencias[1].position.z );
        }
    }

    void ActiveLever()
    {
        _leverActivation = true;
        saveLastPos2();
        LastPos1();
    }

    void DeactivationLever()
    {
        _leverActivation = false;
        saveLastPos1();
        LastPos2();
    }

    void ValueWheelX(float value)
    {
        if (value < 2 && value > -2)
        {
            _wheelPosX = value;
        }

    }

    void ValueWheelY(float value)
    {
        if (value < 2 && value > -2)
        {
            _wheelPosY = value;
        }


    }

    void saveLastPos1()
    {
        _lastWheelPosX1 = _wheelPosX;
        _lastWheelPosY1 = _wheelPosY;
    }

    void LastPos1()
    {
        _wheelX.value = (float)_lastWheelPosX1;
        _wheelY.value = (float)_lastWheelPosY1;
    }

    void saveLastPos2()
    {
        _lastWheelPosX2 = _wheelPosX;
        _lastWheelPosY2 = _wheelPosY;
    }

    void LastPos2()
    {
        _wheelX.value = (float)_lastWheelPosX2;
        _wheelY.value = (float)_lastWheelPosY2;
    }

    
}
