using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCode : MonoBehaviour
{
    [SerializeField] protected float _cooldown;
    [SerializeField] protected float _firePower;
    [SerializeField] protected Transform _spawnPoint;

    protected GameObject _currentArrow;
    protected bool _isReloading;
    protected Vector3 _force;

    protected Coroutine _coroutine;

    private void Start()
    {
        Reload();
    }

    protected void Reload()
    {
        StartCoroutine(ReloadingTimer());
    }

    protected IEnumerator ReloadingTimer()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_cooldown);
        _currentArrow = ArrowPool.instance.GetPooledArrow();
        _currentArrow.gameObject.transform.position = _spawnPoint.position;
        _currentArrow.gameObject.transform.rotation = _spawnPoint.rotation;
        _currentArrow.gameObject.transform.SetParent(this.gameObject.transform);
        _isReloading = false;   
    }

    protected void ShootArrow()
    {
        _currentArrow.gameObject.SetActive(true);
        _currentArrow.GetComponent<ArrowCode>().Fly();
        _currentArrow.gameObject.transform.SetParent(null);
        _currentArrow = null;
        StartCoroutine(ReloadingTimer());

    }

    protected bool TheBowIsReady()
    {
        return (!_isReloading && (_currentArrow != null));
    }

    public void ShootBow()
    {
        if (!_isReloading)
        {
            ShootArrow();
            print("AHHHHHHHH");
        }
    }
}
