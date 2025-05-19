using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BolaMovimento : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("PosBola"))
        {
            //transform.position = other.transform.position;
            gameObject.transform.SetParent(other.transform.parent, false);
            transform.position = other.transform.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
        }
    }
}
