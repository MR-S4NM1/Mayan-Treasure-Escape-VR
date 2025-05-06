using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    public static ArrowPool instance;

    [SerializeField] protected List<GameObject> _arrowsPool;

    [SerializeField] protected GameObject _arrowPrefab;

    [SerializeField] protected int _numberOfArrows;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        PreparePool();
    }

    protected void PreparePool()
    {
        for (int i = 0; i < _numberOfArrows; ++i)
        {
            GameObject arrow = Instantiate(_arrowPrefab);
            arrow.SetActive(false);
            _arrowsPool.Add(arrow);
        }
    }

    public GameObject GetPooledArrow()
    {
        for (int i = 0; i < _arrowsPool.Count; i++)
        {
            if (!_arrowsPool[i].gameObject.activeInHierarchy)
            {
                return _arrowsPool[i].gameObject;
            }
        }

        return null;
    }

}
