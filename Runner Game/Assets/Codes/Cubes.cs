using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    [SerializeField] GameObject cubePart;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        CreateCube();
    }

    private void CreateCube()
    {
        for (float i = -0.5f; i < 0.5f; i = i + 0.1f)
        {
            //Instantiate(cubePart,new Vector3())
        }
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
