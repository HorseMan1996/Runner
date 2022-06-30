using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        CreatePlatform.RunDummy();
        startPosition = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentPlatform = collision.gameObject;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && CreatePlatform.lastPlatform.tag != "Tplatform")
        {
            CreatePlatform.RunDummy();
        }

        if (other is SphereCollider)
        {
            canTurn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
        {
            canTurn = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            CreatePlatform.dummyTraveller.transform.forward = -this.transform.forward;
            CreatePlatform.RunDummy();

            if(CreatePlatform.lastPlatform.tag != "Tplatform")
            {
                CreatePlatform.RunDummy();
            }

            this.transform.position = new Vector3(startPosition.x,
                                                    this.transform.position.y,
                                                    startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            CreatePlatform.dummyTraveller.transform.forward = -this.transform.forward;
            CreatePlatform.RunDummy();

            if (CreatePlatform.lastPlatform.tag != "Tplatform")
            {
                CreatePlatform.RunDummy();
            }

            this.transform.position = new Vector3(startPosition.x,
                                        this.transform.position.y,
                                        startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f,0,0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
    }
}
