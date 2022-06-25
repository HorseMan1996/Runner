using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }

    private void DestroyObject()
    {
        if (Player.transform.position.x - 10f > this.gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }
        
    }
}
