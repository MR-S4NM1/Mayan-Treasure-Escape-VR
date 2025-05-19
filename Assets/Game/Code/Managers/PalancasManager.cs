using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PalancasManager : MonoBehaviour
{
    

    [SerializeField] XRJoystick joystick_1;
    [SerializeField] XRJoystick joystick_2;
    [SerializeField] XRJoystick joystick_3;
    [SerializeField] GameObject[] prefabCompletoJoystick_1;
    [SerializeField] GameObject[] prefabCompletoJoystick_2;
    [SerializeField] GameObject[] prefabCompletoJoystick_3;
    Vector2 _posJoystick_1, _posJoystick_2, _posJoystick_3;
    [SerializeField] Vector2 _destinoJoystick_1, _destinoJoystick_2, _destinoJoystick_3;
    [SerializeField] bool Joy1, Joy2, Joy3;

    protected HashSet<XRJoystick> _completejoysticks;

    void Start()
    {
        _completejoysticks = new HashSet<XRJoystick>();

        prefabCompletoJoystick_1[1].SetActive(false);
        prefabCompletoJoystick_2[1].SetActive(false);
        prefabCompletoJoystick_3[1].SetActive(false);
    }
    private void OnEnable()
    {
        joystick_1.onValueChangeX.AddListener(UpdateX_1);
        joystick_1.onValueChangeY.AddListener(UpdateY_1);
        joystick_2.onValueChangeX.AddListener(UpdateX_2);
        joystick_2.onValueChangeY.AddListener(UpdateY_2);
        joystick_3.onValueChangeX.AddListener(UpdateX_3);
        joystick_3.onValueChangeY.AddListener(UpdateY_3);
    }

    private void OnDisable()
    {
        joystick_1.onValueChangeX.RemoveListener(UpdateX_1);
        joystick_1.onValueChangeY.RemoveListener(UpdateY_1);
        joystick_2.onValueChangeX.RemoveListener(UpdateX_2);
        joystick_2.onValueChangeY.RemoveListener(UpdateY_2);
        joystick_3.onValueChangeX.RemoveListener(UpdateX_3);
        joystick_3.onValueChangeY.RemoveListener(UpdateY_3);
    }

    // Update is called once per frame
    void Update()
    {
        CheckJoysticksPositions();
    }

    private void CheckJoysticksPositions()
    {
        if (_posJoystick_1.x < _destinoJoystick_1.x && _posJoystick_1.y > _destinoJoystick_1.y && !Joy1)
        {
            Joy1 = true;
            prefabCompletoJoystick_1[0].SetActive(false);
            prefabCompletoJoystick_1[1].SetActive(true);
            _completejoysticks.Add(joystick_1);
        }

        if (_posJoystick_2.x > _destinoJoystick_2.x && _posJoystick_2.y < _destinoJoystick_2.y && !Joy2)
        {
            Joy2 = true;
            prefabCompletoJoystick_2[0].SetActive(false);
            prefabCompletoJoystick_2[1].SetActive(true);
            _completejoysticks.Add(joystick_2);
        }

        if (_posJoystick_3.x > _destinoJoystick_3.x && _posJoystick_3.y > _destinoJoystick_3.y && !Joy3)
        {
            Joy3 = true;
            prefabCompletoJoystick_3[0].SetActive(false);
            prefabCompletoJoystick_3[1].SetActive(true);
            _completejoysticks.Add(joystick_3);
        }

        if(_completejoysticks.Count >= 3)
        {
            GameManager.instance.OpenDoor(0);
        }
    }


    void UpdateX_1(float value)
    {
        _posJoystick_1.x = value;
    }

    void UpdateY_1(float value)
    {
        _posJoystick_1.y = value;
    }

    void UpdateX_2(float value)
    {
        _posJoystick_2.x = value;
    }

    void UpdateY_2(float value)
    {
        _posJoystick_2.y = value;
    }

    void UpdateX_3(float value)
    {
        _posJoystick_3.x = value;
    }

    void UpdateY_3(float value)
    {
        _posJoystick_3.y = value;
    }
}
