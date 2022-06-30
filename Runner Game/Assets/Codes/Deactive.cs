using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive : MonoBehaviour
{
    bool dScheduled = false;
    private void OnCollisionExit(Collision player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (player.gameObject.tag == "Player" && !dScheduled)
            {
                Invoke("SetInactive", 5.0f);
                dScheduled = true;
            }
        }
    }

    void SetInactive()
    {
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
