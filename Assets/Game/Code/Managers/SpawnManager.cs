using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    protected Transform spawnTransform;

    [SerializeField]
    protected Transform puzzle;
    // Start is called before the first frame update
    void Start()
    {
        //puzzle.position = spawnTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
