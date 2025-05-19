using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPuzzlePiece : MonoBehaviour
{
    [SerializeField] GameObject finalPiece;
    void Start()
    {
        finalPiece.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MissingPiece"))
        {
            GameManager.instance.OpenDoor(1);
            finalPiece.SetActive(true); 
            gameObject.SetActive(false);
        }
    }
}
