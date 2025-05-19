using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRueda : MonoBehaviour
{
    [SerializeField] protected GameObject _ruedaFaltante;
    void Start()
    {
        _ruedaFaltante.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rueda"))
        {
            other.gameObject.SetActive(false);
            _ruedaFaltante.SetActive(true);
        }
    }
}
