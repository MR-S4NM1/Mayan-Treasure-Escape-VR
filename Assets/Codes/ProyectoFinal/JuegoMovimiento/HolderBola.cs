using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderBola : MonoBehaviour
{
    [SerializeField] GameObject bola;
    [SerializeField] GameObject puerta;
    [SerializeField] Animator animator;
    [SerializeField] MovementManager movementManager;
    void Start()
    {
        bola.SetActive(false);
        //puerta.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            other.gameObject.SetActive(false);
            bola.SetActive(true);
            gameObject.SetActive(false);
            puerta.SetActive(true) ;
            animator.SetBool("Move", true);
            movementManager.BolaEnPosicion();
        } 
    }
}
