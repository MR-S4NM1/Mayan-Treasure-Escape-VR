using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCode : MonoBehaviour
{
    [SerializeField] Vector3 _direction;
    [SerializeField] float _arrowSpeed;
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected bool _hasHit;

    protected Coroutine _coroutine;

    public void Fly() {
        _arrowSpeed = 5.0f;
        _direction = transform.forward;
        _rb.useGravity = true;
        transform.SetParent(null);
    }

    private void OnEnable()
    {
        _hasHit = false;
        _coroutine = StartCoroutine(DeactivateArrow());
    }

    private void FixedUpdate()
    {
        _rb.velocity = _direction * _arrowSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasHit) return;
        
        _hasHit = true;
        print($"Has hit: {_hasHit}");
        _arrowSpeed = 0.0f;
        _direction = Vector3.zero;
        _rb.useGravity = false;
        _rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_hasHit) return;

        _hasHit = true;
        print($"Has hit: {_hasHit}");
        _arrowSpeed = 0.0f;
        _direction = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.useGravity = false;
    }

    protected IEnumerator DeactivateArrow()
    {
        yield return new WaitForSeconds(3.0f);
        this.gameObject.SetActive(false);
    }
}
