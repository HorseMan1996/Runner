﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    static public GameObject dummyTraveller;
    static public GameObject lastPlatform;

    // Start is called before the first frame update
    void Awake()
    {
        dummyTraveller = new GameObject("dummy");
    }

    public static void RunDummy()
    {
        GameObject p = Pool.singleton.GetRandom();
        if (p == null) 
        {
            return;
        }

        if (lastPlatform != null)
        {

            if (lastPlatform.tag == "")
            {
                dummyTraveller.transform.position = lastPlatform.transform.position +
    PlayerController.player.transform.forward * 20;
            }
            else
            {
                dummyTraveller.transform.position = lastPlatform.transform.position +
                    PlayerController.player.transform.forward * 10;
            }


            if (lastPlatform.tag == "StairUp")
            {
                dummyTraveller.transform.Translate(0, 6.9f, 0);

            }
            else if (lastPlatform.tag == "StairDown")
            {
                dummyTraveller.transform.Translate(0, -6.9f, 0);

            }

        }

        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;

        if (p.tag == "StairDown")
        {
            Debug.Log("AŞAĞI");
           // dummyTraveller.transform.Translate(0, -13.8f, 0);
            // p.transform.Rotate
            p.transform.position = dummyTraveller.transform.position;
        }
    }
    
}
