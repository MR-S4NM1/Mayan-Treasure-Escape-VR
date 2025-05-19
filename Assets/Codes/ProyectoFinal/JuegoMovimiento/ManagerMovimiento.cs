using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMovimiento : MonoBehaviour
{
    [SerializeField] GameObject obstaculos_1, obstaculos_2;
    [SerializeField] Animator moveObstacle1, moveObstacle2;
    int numBola;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bola") && gameObject.name == "triggerEnter")
        {
            numBola++;
            ChangeObstacles();
        }
    }

    private void ChangeObstacles()
    {
        switch (numBola)
        {
            case 1:
                moveObstacle1.SetBool("Move", true); 
                break;

            case 2:
                moveObstacle1.SetBool("Remove", true);
                moveObstacle2.SetBool("Move", true);
                break;

            case 3:
                moveObstacle1.SetBool("Remove", false);
                break;
        }
    }
}
