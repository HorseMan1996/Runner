using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (!PlayerController.isDead)
        {
            this.transform.position += PlayerController.player.transform.forward * -0.1f;
        } 


        if (PlayerController.currentPlatform == null) return;
    }
}
