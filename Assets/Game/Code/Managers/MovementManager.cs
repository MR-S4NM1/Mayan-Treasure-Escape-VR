using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    int bolasMetidas;

    public void BolaEnPosicion()
    {
        bolasMetidas++;
        if(bolasMetidas == 3)
        {
            GameManager.instance.OpenDoor(3);
        }
    }
    
}
